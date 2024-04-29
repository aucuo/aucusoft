import '@/App.scss'

import {Aside} from '@components/Aside'
import {Info} from '@components/Info'
import {Note} from '@components/Note'
import {Toast, ToastContainer} from 'react-bootstrap'
import {Table} from "@components/Table";
import {useState} from "react";

function WorkflowContent() {
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

function ProjectsContent() {
    return (
        <>
            <Info
                header='Projects'
                text='Stay hungry, stay foolish'/>
            <div className="col-12">
                <Table tableName="Projects"/>
            </div>
        </>
    );
}

function EmployeesContent() {
    return (
        <>
            <Info
                header='Employees'
                text='Tables related to company employee'/>
            <div className="col-12">
                <Table tableName="Employee"/>
            </div>
        </>
    );
}

function ClientsContent() {
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

function CompanyContent() {
    return (
        <>
            <Info
                header='Clients'
                text='Our happy money givers'/>
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

function App() {
    const [show, setShow] = useState(true);
    const toggleShow = () => setShow(!show);

    const [content, setContent] = useState('workflow');
    const switchContent = (newContent: string) => {
        setContent(newContent);
    }

    return (
        <>
            <Aside activePage={content} onMenuItemClick={switchContent}/>
            <div className="main">
                <div className="main__row row">
                    {content === 'workflow' && <WorkflowContent/>}
                    {content === 'projects' && <ProjectsContent/>}
                    {content === 'employees' && <EmployeesContent/>}
                    {content === 'clients' && <ClientsContent/>}
                    {content === 'company' && <CompanyContent/>}
                </div>

                <ToastContainer>
                    <Toast onClose={toggleShow} show={show} delay={3000} autohide>
                        Text
                        <button className="button" onClick={toggleShow}>OK</button>
                    </Toast>
                </ToastContainer>
            </div>
        </>
    )
}

export default App