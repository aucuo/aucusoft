// TableStoreContext.ts
import React from 'react';
import TableStore from "@/stores/TableStore.ts";

export const TableStoreContext = React.createContext<TableStore | undefined>(undefined);

export const useTableStore = () => {
    const context = React.useContext(TableStoreContext);
    if (context === undefined) {
        throw new Error('useTableStore must be used within a TableStoreProvider');
    }
    return context;
};

export const TableStoreProvider: React.FC<{children: React.ReactNode, tableStore: TableStore}> = ({children, tableStore}) => {
    return <TableStoreContext.Provider value={tableStore}>{children}</TableStoreContext.Provider>;
};
