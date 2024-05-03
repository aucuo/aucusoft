import React, {useCallback, useState} from 'react';
import { observer } from "mobx-react";
import {Modal} from "react-bootstrap";
import './search.scss';
import {useTableStore} from "@/stores/TableStoreContext.tsx";
import {debounce} from "lodash";
import {Filters} from "@components/Table/Search/Filters/Filters.tsx";

export const Search = observer(() => {
    const TableStore = useTableStore();
    const [isShown, setIsShown] = useState(false);
    const [inputValue, setInputValue] = useState('');
    const [showModal, setShowModal] = useState(false);
    const toggleFilters = () => {
        setIsShown(!isShown);
    };

    const debouncedSearch = useCallback(debounce((searchValue: string) => {
        TableStore.setSearchQuery(searchValue);
    }, 300), []);

    const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
        debouncedSearch(event.target.value);
    };

    const handleAdd = async () => {
        const newItem = {
            id: Math.random(),
            ...Object.keys(TableStore.data[0] || {}).reduce((acc : any, key) => {
                if (key.endsWith('Date')) {
                    acc[key] = new Date().toISOString().split('T')[0];
                } else if (key.endsWith('FK')) {
                    acc[key] = (TableStore.additionalData[key] && TableStore.additionalData[key][0]?.id) || "N/A";
                } else {
                    acc[key] = "N/A";
                }
                return acc;
            }, {})
        };

        if (TableStore.data.length > 4) TableStore.data.pop();
        TableStore.data.unshift(newItem);
        TableStore.selectedRows.pop();
        TableStore.selectedRows.unshift({ id: newItem.id, selected: false });
        await TableStore.addData(newItem);
    }

    const handleDelete = () => {
        setShowModal(true);
    }

    const confirmDelete = () => {
        const selectedIds = TableStore.selectedRows
            .filter(row => row.selected)
            .map(row => row.id);

        selectedIds.forEach(id => TableStore.deleteData(id))

        setShowModal(false);
    };

    const handleClose = () => setShowModal(false);

    return (
        <div className="search">
            <Modal show={showModal} centered={true} onHide={handleClose}>
                <Modal.Header>
                    <Modal.Title>Confirm Deletion</Modal.Title>
                </Modal.Header>
                <Modal.Body>Are you sure you want to delete the selected items?</Modal.Body>
                <Modal.Footer>
                    <button className="button" onClick={handleClose}>
                        Cancel
                    </button>
                    <button className="button" onClick={confirmDelete}>
                        Delete
                    </button>
                </Modal.Footer>
            </Modal>
            <div className="search__top">
                <div className="input input--search search__input">
                    <input
                        type="text"
                        placeholder="Search"
                        value={inputValue}
                        onInput={handleSearchChange}
                    />
                </div>
                <button className="button search__button--add" type="button" onClick={() => handleAdd()}>
                    <svg width="18" height="18">
                        <use href="public/icons/sprites.svg#add-square"></use>
                    </svg>
                </button>
                <button className="button search__button--delete" type="button" onClick={() => handleDelete()}>
                    <svg width="18" height="18">
                        <use href="public/icons/sprites.svg#trash"></use>
                    </svg>
                </button>
                <button className="button search__button--filter" type="button" onClick={toggleFilters}>
                    <svg width="18" height="18">
                        <use href="public/icons/sprites.svg#sort"></use>
                    </svg>
                    Filters
                </button>
            </div>
            <div className={`search__filters filters ${isShown ? '' : 'hidden'}`}>
                <Filters/>
            </div>
        </div>
    );
});