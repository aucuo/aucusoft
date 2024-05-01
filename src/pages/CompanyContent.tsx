import '@/App.scss'

import {Info} from '@components/Info/Info.tsx'
import {Table} from "@components/Table/Table.tsx";

export function CompanyContent() {
    return (
        <>
            <Info
                header='Company'
                text='Work with all company-related tables'/>
            <div className="col-12 col-xl-6">
                <Table tableName="Meetings"/>
            </div>
            <div className="col-12 col-xl-6">
                <Table tableName="Managers"/>
            </div>
            <div className="col-12 col-xl-4">
                <Table tableName="Positions"/>
            </div>
            <div className="col-12 col-xl-4">
                <Table tableName="Departments"/>
            </div>
            <div className="col-12 col-xl-4">
                <Table tableName="Technologies"/>
            </div>
        </>
    );
}
