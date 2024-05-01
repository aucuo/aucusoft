import '@/App.scss'

import {Info} from '@components/Info/Info.tsx'
import {Table} from "@components/Table/Table.tsx";

export function ProjectsContent() {
    return (
        <>
            <Info
                header='Projects'
                text='Stay hungry, stay foolish'/>
            <div className="col-12">
                <Table tableName="Projects"/>
            </div>
            <div className="col-12 col-xxl-4">
                <Table tableName="Tasks"/>
            </div>
            <div className="col-12 col-lg-6 col-xxl-4">
                <Table tableName="ProjectsTechnologies"/>
            </div>
            <div className="col-12 col-lg-6 col-xxl-4">
                <Table tableName="ProjectsDocuments"/>
            </div>
        </>
    );
}