export function Search() {
    return (
        <div className="search">
            <div className="search__top">
                <div className="input input--search search__input">
                    <input type="text" placeholder="Search"/>
                </div>
                <button className="button" type="button">
                    <svg className="note__icon" width="24" height="24">
                        <use href="public/icons/sprites.svg#add-square"></use>
                    </svg>
                </button>
                <button className="button" type="button">
                    <svg className="note__icon" width="24" height="24">
                        <use href="public/icons/sprites.svg#sort"></use>
                    </svg>
                    Filters
                </button>
            </div>
            <div className="search__filters filters">
                <button className="button button--small">
                    Name
                    <svg className="note__icon" width="24" height="24">
                        <use href="public/icons/sprites.svg#arrow"></use>
                    </svg>
                </button>
                <button className="button button--small">
                    Name
                    <svg className="note__icon" width="24" height="24">
                        <use href="public/icons/sprites.svg#arrow"></use>
                    </svg>
                </button>
                <button className="button button--small button--transparent">
                    <svg className="note__icon" width="24" height="24">
                        <use href="public/icons/sprites.svg#add"></use>
                    </svg>
                    Add filter
                </button>
            </div>
        </div>
    );
}