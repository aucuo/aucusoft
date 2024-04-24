// components/TableBody.tsx
import { observer } from "mobx-react";
import { TableInput } from "@components/Table/TableInput/TableInput";
import './table-body.scss'
import {useTableStore} from "@components/Table/TableStoreContext.tsx";
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
                    <td key={`${header}-${index}`} className="table__item">
                        <TableInput
                            index={index}
                            keyField={header}
                            value={item[header]?.toString() || "N/A"}
                        />
                    </td>
                ))}
            </tr>
        ))}
        {Array(5 - TableStore.data.length).fill(null).map((_, i) => (
            <tr key={`empty-${i}`} className="table__row table__row--empty"></tr>
        ))}
        </tbody>
    );
});
