import './aside.scss'
import {appStore} from "@/stores/AppStore.ts"
interface AsideProps {
    activePage: string;
    onMenuItemClick(newContent:string): void;
}
export function Aside({activePage, onMenuItemClick} : AsideProps) {
    return (
        <>
            <aside className='sidebar'>
                <div className="sidebar__top">
                    <div className="sidebar__database">
                        <img src="public/database_image.png" alt="Database image"/>
                        <span className="sidebar__database-name">aucusoft</span>
                    </div>
                    <nav>
                        <ul className="sidebar__nav">
                            <li className={`sidebar__link ${(activePage === 'workflow') ? 'sidebar__link--active' : ''}`} onClick={()=>onMenuItemClick('workflow')}>
                                <svg className="sidebar__icon" width={24} height={24}>
                                    <use xlinkHref='public/icons/sprites.svg#magic-star'></use>
                                </svg>
                            </li>
                            <li className={`sidebar__link ${(activePage === 'projects') ? 'sidebar__link--active' : ''}`} onClick={()=>onMenuItemClick('projects')}>
                                <svg className="sidebar__icon" width={24} height={24}>
                                    <use xlinkHref='public/icons/sprites.svg#code'></use>
                                </svg>
                            </li>
                            <li className={`sidebar__link ${(activePage === 'employees') ? 'sidebar__link--active' : ''}`} onClick={()=>onMenuItemClick('employees')}>
                                <svg className="sidebar__icon" width={24} height={24}>
                                    <use xlinkHref='public/icons/sprites.svg#people'></use>
                                </svg>
                            </li>
                            <li className={`sidebar__link ${(activePage === 'clients') ? 'sidebar__link--active' : ''}`} onClick={()=>onMenuItemClick('clients')}>
                                <svg className="sidebar__icon" width={24} height={24}>
                                    <use xlinkHref='public/icons/sprites.svg#happyemoji'></use>
                                </svg>
                            </li>
                            <li className={`sidebar__link ${(activePage === 'company') ? 'sidebar__link--active' : ''}`} onClick={()=>onMenuItemClick('company')}>
                                <svg className="sidebar__icon" width={24} height={24}>
                                    <use xlinkHref='public/icons/sprites.svg#building'></use>
                                </svg>
                            </li>
                        </ul>
                    </nav>
                </div>
                <div className="sidebar__bottom">
                    <ul className="sidebar__nav">
                        <li className="sidebar__link" onClick={appStore.toggleTheme}>
                            <svg className="sidebar__icon" width={24} height={24}>
                                <use xlinkHref='public/icons/sprites.svg#mask'></use>
                            </svg>
                        </li>
                        <li className="sidebar__link">
                            <svg className="sidebar__icon" width={24} height={24}>
                                <use xlinkHref='public/icons/sprites.svg#setting'></use>
                            </svg>
                        </li>
                        <li className="sidebar__link">
                            <svg className="sidebar__icon" width={24} height={24}>
                                <use xlinkHref='public/icons/sprites.svg#logout'></use>
                            </svg>
                        </li>
                    </ul>
                </div>
            </aside>
        </>
    )
}