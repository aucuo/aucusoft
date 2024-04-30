import '@/App.scss'

import {Aside} from '@components/Aside'
import {useState} from "react";
import {ToastComponent} from "@components/Toast/Toast.tsx";
import {WorkflowContent} from "@/pages/WorkflowContent.tsx";
import {EmployeesContent} from "@/pages/EmployeesContent.tsx";
import {CompanyContent} from "@/pages/CompanyContent.tsx";
import {ClientsContent} from "@/pages/ClientsContent.tsx";
import {ProjectsContent} from "@/pages/ProjectsContent.tsx";
import { observer } from 'mobx-react';
import {appStore} from "@/stores/AppStore.ts"

function App() {
    const [content, setContent] = useState('workflow');
    const switchContent = (newContent: string) => {
        setContent(newContent);
    }

    return (
        <div className="App" data-theme={appStore.isDark ? "dark" : "light"}>
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
        </div>
    )
}

export default observer(App)