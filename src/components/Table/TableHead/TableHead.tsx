// components/TableHead.tsx
import { observer } from "mobx-react";
import './table-head.scss'
import {useTableStore} from "@components/Table/TableStoreContext.tsx";
export const TableHead = observer(() => {
    const TableStore = useTableStore();
    return (
        <thead className="table__head">
        <tr>
            <th className="table__item">
                <input
                    type="checkbox"
                    className="table__checkbox"
                    checked={TableStore.allSelected}
                    onChange={() => TableStore.toggleAllRows()}
                />
            </th>
            {TableStore.data.length > 0 && Object.keys(TableStore.data[0]).map(header => (
                <th key={header} className="table__item">{header}</th>
            ))}
        </tr>
        </thead>
    );
});
