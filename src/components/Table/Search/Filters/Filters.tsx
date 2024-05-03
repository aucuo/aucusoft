import {observer} from "mobx-react";
import {Dropdown, Form} from "react-bootstrap";
import {useTableStore} from "@/stores/TableStoreContext.tsx";
import {useState} from "react";

export const Filters = observer(() => {
    const TableStore = useTableStore();

    const [filterField, setFilterField] = useState('');
    const [filterValue, setFilterValue] = useState('');
    const [dateFilterType, setDateFilterType] = useState('on'); // Default is 'on'
    const [sortField, setSortField] = useState('');
    const [sortDirection, setSortDirection] = useState('asc');
    const handleFilterSubmit = (field:string, value:string, dateType:string) => {
        if (field.endsWith('Date')) {
            TableStore.setFilter(field, value, dateType); // Modify setFilter to handle date type
        } else if (field.endsWith('FK')) {
            field = field.replace('FK', 'Id')
            TableStore.setFilter(field, value);
        } else {
            TableStore.setFilter(field, value);
        }
        TableStore.loadData();
    };
    const handleClearFilter = () => {
        setFilterField('');
        setFilterValue('');
        TableStore.clearFilters();
        TableStore.loadData();
    };

    const handleClearSorting = () => {
        setSortField('');
        setSortDirection('asc');
        TableStore.clearSorting();
        TableStore.loadData();
    };
    return (
        <>
            <Dropdown className="filters__button--add">
                <Dropdown.Toggle className="button button--small button--transparent">
                    <svg width="18" height="18">
                        <use href="public/icons/sprites.svg#sort"></use>
                    </svg>
                    Filter{filterField ? `: ${filterField}` : ''}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    <Dropdown.ItemText>Field</Dropdown.ItemText>
                    <Form.Select
                        className="dropdown-item-select"
                        defaultValue=""
                        value={filterField}
                        onChange={(event) => {
                            setFilterField(event.target.value);
                            setDateFilterType('on'); // Reset to default when field changes
                        }}>
                        <option value="" disabled={true}>
                            N/A
                        </option>
                        {TableStore.availableFilters.map(filterKey => (
                            (filterKey != 'id') && (
                                <option value={filterKey} key={filterKey}>
                                    {filterKey}
                                </option>
                            )
                        ))}
                    </Form.Select>
                    {filterField.endsWith('Date') && (
                        <>
                            <Dropdown.ItemText>Date Filter Type</Dropdown.ItemText>
                            <Form.Select
                                className="dropdown-item-select"
                                value={dateFilterType}
                                onChange={(event) => setDateFilterType(event.target.value)}>
                                <option value="on">On</option>
                                <option value="before">Before</option>
                                <option value="after">After</option>
                            </Form.Select>
                        </>
                    )}
                    <Dropdown.ItemText>{filterField.endsWith('Date') ? 'Date' : 'Contains'}</Dropdown.ItemText>
                    <input
                        className="dropdown-item-input"
                        type={filterField.endsWith('Date') ? 'date' : 'text'}
                        placeholder={filterField.endsWith('Date') ? '' : 'contains'}
                        value={filterValue}
                        onChange={(event) => setFilterValue(event.target.value)}
                    />
                    <div className="dropdown__buttons">
                        <button
                            className="button button--small dropdown-item-button"
                            style={{margin: "10px 0 0 0"}}
                            onClick={() => {
                                handleFilterSubmit(filterField, filterValue, dateFilterType); // Pass the dateFilterType to submit function
                            }}>Submit filter
                        </button>
                        <button
                            className="button button--small dropdown-item-button"
                            style={{margin: "10px 0 0 0"}}
                            onClick={handleClearFilter}>
                            Clear
                        </button>
                    </div>
                </Dropdown.Menu>
            </Dropdown>
            <Dropdown className="filters__button--filter">
                <Dropdown.Toggle className="button button--small button--transparent">
                    Sort{sortField ? `: ${sortField}` : ''}
                    <svg width="18" height="18">
                        <use href="public/icons/sprites.svg#arrow"></use>
                    </svg>
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    <Dropdown.ItemText>Field</Dropdown.ItemText>
                    <Form.Select
                        className="dropdown-item-select"
                        defaultValue=""
                        value={sortField}
                        onChange={(event) => setSortField(event.target.value)}>
                        <option value="" disabled={true}>
                            N/A
                        </option>
                        {TableStore.availableFilters.map(filterKey => (
                            (filterKey != 'id' && !filterKey.endsWith('FK')) && (
                                <option value={filterKey} key={filterKey}>
                                    {filterKey}
                                </option>
                            )
                        ))}
                    </Form.Select>

                    <Dropdown.ItemText>Sort</Dropdown.ItemText>
                    <Form.Select
                        className="dropdown-item-select"
                        defaultValue="asc"
                        value={sortDirection}
                        onChange={(event) => setSortDirection(event.target.value)}>
                        <option value="asc">Ascending</option>
                        <option value="desc">Descending</option>
                    </Form.Select>

                    <div className="dropdown__buttons">
                        <button className="button button--small dropdown-item-button"
                                style={{margin: "10px 0 0 0"}}
                                onClick={() => {
                                    TableStore.setSorting(sortField, sortDirection);
                                    TableStore.loadData();
                                }}>Submit sort
                        </button>
                        <button className="button button--small dropdown-item-button"
                                style={{margin: "10px 0 0 0"}}
                                onClick={handleClearSorting}>Clear
                        </button>
                    </div>
                </Dropdown.Menu>
            </Dropdown>
        </>
    );
});
