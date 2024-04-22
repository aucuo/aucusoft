import '@/App.scss'

import {Aside} from '@components/aside'
import {Info} from '@components/info'
import {Note} from '@components/note'
import {Table} from '@components/table'
import {Toast, ToastContainer} from 'react-bootstrap'
import {useState} from "react";

function App() {
    const tableData = [
        {
            projectName: "Project Alpha",
            budget: 121000,
            manager: "Shikovets Egor",
            status: "Active",
        },
        {
            projectName: "Project Beta",
            budget: 121000,
            manager: "Demchishina Anna",
            status: "Pause",
        },
        {
            projectName: "Project Gamma",
            budget: 121000,
            manager: "Shikovets Egor",
            status: "Ended",
        },
        {
            projectName: "Project Alpha",
            budget: 121000,
            manager: "Shikovets Egor",
            status: "Active",
        },
        {
            projectName: "Project Beta",
            budget: 121000,
            manager: "Demchishina Anna",
            status: "Pause",
        },
    ];

    const [show, setShow] = useState(true);
    const toggleShow = () => setShow(!show);

    return (
        <>
            <Aside/>
            <div className="main">
                <Info
                    header='Workflow'
                    text='The main application blocks will be displayed here'/>
                <div className="main__row row">
                    <div className="col-8">
                        <Table data={tableData}/>
                    </div>
                    <div className="col-4">
                        <Note
                            header='Hire a new web designer'
                            text='Lorem Ipsum is simply dummy text of the printing and typesetting industry. It to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting'/>
                    </div>
                </div>

                <ToastContainer>
                    <Toast onClose={toggleShow} show={show} delay={3000} autohide>
                        Text
                        <button className="button"onClick={toggleShow}>OK</button>
                    </Toast>
                </ToastContainer>
            </div>
        </>
    )
}

export default App