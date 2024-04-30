import '@/App.scss'

import {Info} from '@components/Info'
import {Note} from '@components/Note'
import {Table} from "@components/Table";

export function ClientsContent() {
    return (
        <>
            <Info
                header='Clients'
                text='Our happy money givers'/>
            <div className="col-12">
                <Table tableName="Clients"/>
            </div>
            <div className="col-12 col-xl-8">
                <Table tableName="ClientsFeedbacks"/>
            </div>
            <div className="col-12 col-xl-4">
                <Note
                    header='Hire a new web designer'
                    text='Lorem Ipsum is simply dummy text of the printing and typesetting industry. It to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting'/>
            </div>
        </>
    );
}
