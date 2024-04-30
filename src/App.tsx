import '@/App.scss'

import {Aside} from '@components/Aside'
import {useState} from "react";
import {ToastComponent} from "@components/Table/Toast/Toast.tsx";
import {WorkflowContent} from "@/pages/Workflow.tsx";
import {EmployeesContent} from "@/pages/Employees.tsx";
import {CompanyContent} from "@/pages/Company.tsx";
import {ClientsContent} from "@/pages/Clients.tsx";
import {ProjectsContent} from "@/pages/Projects.tsx";

function App() {
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

                <ToastComponent/>
            </div>
        </>
    )
}

export default App