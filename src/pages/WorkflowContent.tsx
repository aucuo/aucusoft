import '@/App.scss'

import {Info} from '@components/Info/Info.tsx'
import {Note} from '@components/Note/Note.tsx'
import {Table} from "@components/Table/Table.tsx";

export function WorkflowContent() {
    return (
        <>
            <Info
                header='Workflow'
                text='The main application blocks will be displayed here'/>
            <div className="col-12 col-xl-8">
                <Table tableName="Projects"/>
            </div>
            <div className="col-12 col-xl-4">
                <Note
                    header='Hire a new web designer'
                    text='Lorem Ipsum is simply dummy text of the printing and typesetting industry. It to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting'/>
            </div>
            <div className="col-12 col-xl-6">
                <Table tableName="Employee"/>
            </div>
            <div className="col-12 col-xl-6">
                <Table tableName="Meetings"/>
            </div>
        </>
    );
}