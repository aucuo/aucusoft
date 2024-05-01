import '@/App.scss'

import {Info} from '@components/Info/Info.tsx'
import {Table} from "@components/Table/Table.tsx";

export function EmployeesContent() {
    return (
        <>
            <Info
                header='Employees'
                text='Tables related to company employee'/>
            <div className="col-12">
                <Table tableName="Employee"/>
            </div>
            <div className="col-12 col-lg-6">
                <Table tableName="Worklogs"/>
            </div>
            <div className="col-12 col-lg-6">
                <Table tableName="Employeetasks"/>
            </div>
        </>
    );
}