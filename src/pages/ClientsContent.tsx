import '@/App.scss'

import {Info} from '@components/Info/Info.tsx'
import {Table} from "@components/Table/Table.tsx";

export function ClientsContent() {
    return (
        <>
            <Info
                header='Clients'
                text='Our happy money givers'/>
            <div className="col-12">
                <Table tableName="Clients"/>
            </div>
            <div className="col-12 col-xl-12">
                <Table tableName="ClientsFeedbacks"/>
            </div>
        </>
    );
}
