import React, { useState, useEffect } from 'react';
import './table-input.scss';
import {useTableStore} from "@components/Table/TableStoreContext.tsx";

interface TableInputProps {
    index: number;
    keyField: string;
    value: string;
}

export const TableInput = ({ index, keyField, value }: TableInputProps) => {
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
        setInputValue(value); // Обновляем локальное состояние при изменении внешнего value
    }, [value]);

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
    };

    const handleBlur = () => {
        setIsFocused(false);
        setInputValue(value); // Восстанавливаем исходное значение при потере фокуса
    };

    const handleKeyDown = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            TableStore.updateItem(index, keyField, inputValue);
            TableStore.submitData(); // Вызов функции отправки данных
            (event.target as HTMLInputElement).blur(); // Убираем фокус с input
        }
        if (event.key === 'Escape') {
            (event.target as HTMLInputElement).blur(); // Убираем фокус с input
        }
    };

    return (
        <input
            className="table-input"
            type="text"
            value={inputValue}
            onChange={handleChange}
            onFocus={() => setIsFocused(true)}
            onBlur={handleBlur}
            onKeyDown={handleKeyDown}
        />
    );
};
