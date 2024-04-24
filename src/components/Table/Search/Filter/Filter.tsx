import { observer } from "mobx-react";
import { Dropdown, Form } from "react-bootstrap";
import './search.scss';

interface FilterProps {
    fieldName: string;
    setSort: (field: string, value: string) => void;
    setContains: (field: string, value: string) => void;
    removeFilter: (field: string) => void;
}

export const Filter = observer(({ fieldName, setSort, setContains, removeFilter }: FilterProps) => {
    const handleSortChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        setSort(fieldName, event.target.value);
    };

    const handleContainsChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setContains(fieldName, event.target.value);
    };

    const handleDelete = () => {
        removeFilter(fieldName);
    };

    return (
        <Dropdown className="filters__button--filter">
            <Dropdown.Toggle className="button button--small button--transparent">
                {fieldName}
                <svg width="18" height="18">
                    <use href="public/icons/sprites.svg#arrow"></use>
                </svg>
            </Dropdown.Toggle>

            <Dropdown.Menu>
                <Dropdown.ItemText>Sort</Dropdown.ItemText>
                <Form.Select className="dropdown-item-select" onChange={handleSortChange}>
                    <option value="">None</option>
                    <option value="asc">Ascending</option>
                    <option value="desc">Descending</option>
                </Form.Select>

                <Dropdown.ItemText>Contains</Dropdown.ItemText>
                <input className="dropdown-item-input" type="text" onChange={handleContainsChange}/>
                <button className="dropdown-item-button button button--small ml-a" onClick={handleDelete}>DELETE</button>
            </Dropdown.Menu>
        </Dropdown>
    );
});
