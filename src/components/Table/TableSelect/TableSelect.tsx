import React, { useState, useEffect } from 'react';
import './table-select.scss';
import {useTableStore} from "@/stores/TableStoreContext.tsx";

interface TableSelectProps {
    index: number;
    keyField: string;
    value: string;
    options: Option[];
    id: number;
}

interface Option {
    id: number;
    name: string;
}

export const TableSelect = ({ index, keyField, value, options, id }: TableSelectProps) => {
    const TableStore = useTableStore();
    const [selectValue, setSelectValue] = useState(value);
    const [isFocused, setIsFocused] = useState(false);

    useEffect(() => {
        if (!document.body.classList.contains('maximized')) {
            document.body.classList.toggle('dark-overlay', isFocused);
            return () => {
                if (!document.body.classList.contains('maximized'))
                    document.body.classList.remove('dark-overlay');
            };
        }
    }, [isFocused]);

    useEffect(() => {
        setSelectValue(value);
    }, [value]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        setIsFocused(false);
        (event.target as HTMLSelectElement).blur();
        const newValue = event.target.value;
        setSelectValue(newValue);
        TableStore.updateItem(index, keyField, newValue, id);
    };

    const handleBlur = () => {
        setIsFocused(false);
        setSelectValue(value);
    };

    const handleKeyDown = (event: React.KeyboardEvent<HTMLSelectElement>) => {
        if (event.key === 'Escape') {
            (event.target as HTMLSelectElement).blur();
        }
    };

    return (
        <select
            className="table-select"
            value={selectValue || ""}
            onChange={handleChange}
            onFocus={() => setIsFocused(true)}
            onBlur={handleBlur}
            onKeyDown={handleKeyDown}
        >
            <option value="" disabled={true}>N/A</option>
            {options.map(option => (
                <option key={option.id} value={option.id}>{option.name}</option>
            ))}
        </select>
    );
};
