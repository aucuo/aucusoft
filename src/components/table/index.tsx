import { useState } from 'react';
import { Frame } from '@components/frame';
import { formatValue } from './_helpers.ts';
import './table.scss';
import {Search} from "@components/table/search.tsx";

interface DataItem {
    [key: string]: any;
}

interface TableProps {
    data: DataItem[];
    menu?: boolean;
}

export function Table({ data, menu = true }: TableProps) {
    if (data.length === 0)
        return (
            <Frame name={'Table'}>
                <div className="frame__empty">
                    <svg width={24} height={24}>
                        <use xlinkHref='public/icons/sprites.svg#sad'></use>
                    </svg>
                    No data available.
                </div>
            </Frame>
        );

    const headers = Object.keys(data[0]);
    const [selectedRows, setSelectedRows] = useState(new Array(data.length).fill(false));

    const toggleActiveRow = (index: number) => {
        const newSelectedRows = [...selectedRows];
        newSelectedRows[index] = !newSelectedRows[index];
        setSelectedRows(newSelectedRows);
    }

    const toggleAllRows = () => {
        if (selectedRows.every(Boolean)) {
            setSelectedRows(new Array(data.length).fill(false));
        } else {
            setSelectedRows(new Array(data.length).fill(true));
        }
    }

    return (
        <Frame name={'Table'}>
            {menu && <Search />}
            <div className="table">
                <table cellSpacing={0}>
                    <thead className="table__header">
                    <tr>
                        <th className="table__item">
                            <input
                                type="checkbox"
                                className="table__checkbox"
                                onChange={toggleAllRows}
                                checked={selectedRows.every(Boolean) && selectedRows.length > 0}
                            />
                        </th>
                        {headers.map(header => (
                            <th key={header} className="table__item">{header.replace(/([A-Z])/g, ' $1').trim()}</th>
                        ))}
                    </tr>
                    </thead>
                    <tbody className="table__body">
                    {data.map((item, index) => (
                        <tr key={index} className={`table__row ${selectedRows[index] ? 'table__row--active' : ''}`}>
                            <td className="table__item">
                                <input
                                    type="checkbox"
                                    className="table__checkbox"
                                    onChange={() => toggleActiveRow(index)}
                                    checked={selectedRows[index]}
                                />
                            </td>
                            {headers.map(header => (
                                <td key={`${header}-${index}`} className="table__item">
                                    <input
                                        disabled={true}
                                        className="table__input"
                                        type="text"
                                        value={formatValue(item[header])}
                                    />
                                </td>
                            ))}
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        </Frame>
    );
}
