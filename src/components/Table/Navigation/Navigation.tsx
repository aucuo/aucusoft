import { observer } from "mobx-react";
import './navigation.scss';
import {useTableStore} from "@components/Table/TableStoreContext.tsx";

export const Navigation = observer(() => {
    const TableStore = useTableStore();
    const maxDigits = TableStore.pagesCount.toString().length;
    const formattedCurrentPage = TableStore.currentPage.toString().padStart(maxDigits, '0');
    return (
        <div className="navigation">
            <button
                onClick={() => TableStore.previousPage()}
                className="button button--navigation"
                disabled={TableStore.currentPage === 1}>
                <svg className="navigation__arrow navigation__arrow--left" width="18" height="18">
                    <use href="public/icons/sprites.svg#arrow"></use>
                </svg>
            </button>
            <div className="navigation__page">
                {formattedCurrentPage}/{TableStore.pagesCount}
            </div>
            <button
                onClick={() => TableStore.nextPage()}
                className="button button--navigation"
                disabled={TableStore.currentPage === TableStore.pagesCount}>
                <svg className="navigation__arrow navigation__arrow--right" width="18" height="18">
                    <use href="public/icons/sprites.svg#arrow"></use>
                </svg>
            </button>
        </div>
    );
});