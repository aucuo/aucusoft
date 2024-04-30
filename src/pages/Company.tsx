import '@/App.scss'

import {Info} from '@components/Info'
import {Note} from '@components/Note'
import {Table} from "@components/Table";

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
                <Note
                    header='Hire a new web designer'
                    text='Lorem Ipsum is simply dummy text of the printing and typesetting industry. It to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting'/>
            </div>
        </>
    );
}
