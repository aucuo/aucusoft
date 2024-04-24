// components/Table.tsx
import {observer} from "mobx-react";
import {Frame} from '@components/Frame';
import {Search} from "@components/Table/Search/Search";
import {Navigation} from "@components/Table/Navigation/Navigation";
import {TableHead} from "@components/Table/TableHead/TableHead";
import {TableBody} from "@components/Table/TableBody/TableBody";
import {TableStoreProvider} from './TableStoreContext.tsx'; // Импорт контекста, если его нет, создайте его
import './table.scss';
import {useEffect, useMemo} from "react";
import {Spinner} from "react-bootstrap";
import TableStore from "@components/Table/TableStore.ts";

export const Table = observer(({tableName, search = true, navigation = true}: {
    tableName: string,
    search?: boolean,
    navigation?: boolean,
}) => {
    const tableStore = useMemo(() => new TableStore(), [tableName]);

    useEffect(() => {
        tableStore.setBaseUrl(tableName);
        tableStore.loadData();
    }, [tableName, tableStore]);

    const refreshData = () => {
        tableStore.loadData(); // Предполагаем, что loadData это метод для обновления данных
    };

    if (tableName === undefined || tableStore.data.length === 0) {
        return (
            <TableStoreProvider tableStore={tableStore}>
                <Frame name={tableName} refreshTable={refreshData}>
                    {search && <Search/>}
                    <div className="frame__empty">
                        <svg width={24} height={24}>
                            <use xlinkHref='public/icons/sprites.svg#sad'></use>
                        </svg>
                        No data available. Try to reload
                        <div className="frame__empty-url">{tableStore.url}</div>
                    </div>
                    {navigation && <Navigation/>}
                </Frame>
            </TableStoreProvider>
        );
    }

    if (tableStore.isLoading) {
        return (
            <TableStoreProvider tableStore={tableStore}>
                <Frame name={tableName} refreshTable={refreshData}>
                    {search && <Search/>}
                    <div className="table table--loading">
                        <Spinner animation="border" role="status"></Spinner>
                    </div>
                    {navigation && <Navigation/>}
                </Frame>
            </TableStoreProvider>
        );
    }

    return (
        <TableStoreProvider tableStore={tableStore}>
            <Frame name={tableName} refreshTable={refreshData}>
                {search && <Search/>}
                <div className="table">
                    <table className="table" cellSpacing={0}>
                        <TableHead/>
                        <TableBody/>
                    </table>
                </div>
                {navigation && <Navigation/>}
            </Frame>
        </TableStoreProvider>
    );
});
