// components/TableBody.tsx
import {observer} from "mobx-react";
import {TableInput} from "@components/Table/TableInput/TableInput";
import {useTableStore} from "@/stores/TableStoreContext.tsx";
import './table-body.scss'
import {TableSelect} from "@components/Table/TableSelect/TableSelect.tsx";

export const TableBody = observer(() => {
    const TableStore = useTableStore();

    return (
        <tbody className="table__body">
        {TableStore.data.map((item, index) => (
            <tr key={index} className={`table__row ${TableStore.selectedRows[index] ? 'table__row--active' : ''}`}>
                <td className="table__item">
                    <input
                        type="checkbox"
                        className="table__checkbox"
                        checked={TableStore.selectedRows[index]}
                        onChange={() => TableStore.toggleRow(index)}
                    />
                </td>
                {Object.keys(item).map(header => (
                    header !== 'id' ? (
                        <td key={`${header}-${index}`} className="table__item">
                            {
                                header.endsWith('FK') ? (
                                    <TableSelect
                                        index={index}
                                        keyField={header}
                                        value={item[header]}
                                        options={TableStore.additionalData[header] || []}
                                        id={item.id}
                                    />
                                ) : header.endsWith('Date') ? (
                                    <TableInput
                                        index={index}
                                        keyField={header}
                                        value={item[header]?.split('T')[0]}
                                        id={item.id}
                                        type="date" // Указываем, что это поле даты
                                    />
                                ) : (
                                    <TableInput
                                        index={index}
                                        keyField={header}
                                        value={item[header]}
                                        id={item.id}
                                    />
                                )
                            }
                        </td>
                    ) : (
                        <td style={{display: "none"}}>{item[header]}</td>
                    )
                ))}
            </tr>
        ))}
        {Array(5 - TableStore.data.length).fill(null).map((_, i) => (
            <tr key={`empty-${i}`} className="table__row table__row--empty"></tr>
        ))}
        </tbody>
    );
});
