import React, {useState, useEffect} from 'react';
import './table-input.scss';
import {useTableStore} from "@/stores/TableStoreContext.tsx";

interface TableInputProps {
    index: number;
    keyField: string;
    value: string;
    type?: string;
    id: number;
}

export const TableInput = ({ index, keyField, value, type = 'text', id}: TableInputProps) => {
    const TableStore = useTableStore();
    const [inputValue, setInputValue] = useState(value);
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
        setInputValue(value);
    }, [value]);

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
    };

    const handleBlur = async () => {
        setIsFocused(false);
        setInputValue(value);
    };

    const handleKeyDown = async (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            await TableStore.updateItem(index, keyField, inputValue, id);
            (event.target as HTMLInputElement).blur(); // Убираем фокус с input
        }
        if (event.key === 'Escape') {
            (event.target as HTMLInputElement).blur(); // Убираем фокус с input
            setInputValue(value);
        }
    };

    return (
        <input
            className="table-input"
            type={type}
            value={inputValue?.toString() || ""}
            placeholder={"N/A"}
            onChange={handleChange}
            onFocus={() => setIsFocused(true)}
            onBlur={handleBlur}
            onKeyDown={handleKeyDown}
        />
    );
};
