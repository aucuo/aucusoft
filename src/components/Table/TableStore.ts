import { makeAutoObservable, runInAction } from "mobx";

interface DataItem {
    [key: string]: any;
}

class TableStore {
    data: DataItem[] = [];
    filteredData: DataItem[] = [];
    selectedRows: boolean[] = [];
    currentPage: number = 1;
    pagesCount: number = 1;
    searchQuery: string = '';
    availableFilters: string[] = [];
    isLoading: boolean = false;
    url?: string = undefined;
    urlParams?: string = '';

    constructor() {
        makeAutoObservable(this);
    }

    setBaseUrl(tableName: string) {
        this.url = `https://localhost:7030/aucusoft/${tableName}`;
    }

    updateUrlParams(key: string, value: string) {
        let params = new URLSearchParams(this.urlParams);
        params.set(key, value);  // Обновляет или добавляет параметр
        this.urlParams = params.toString();
    }

    removeUrlParam(key: string) {
        let params = new URLSearchParams(this.urlParams);
        params.delete(key);  // Удаляет параметр
        this.urlParams = params.toString();
    }

    async loadData() {
        // Добавление стандартных параметров запроса
        let params = new URLSearchParams(this.urlParams);
        params.set('pageIndex', this.currentPage.toString());
        params.set('pageSize', '5');
        params.set('sortDirection', 'asc');

        const url = `${this.url}?${params.toString()}`;

        console.log([url]);  // Для отладки

        this.isLoading = true;
        try {
            const response = await fetch(url);
            const jsonData = await response.json();

            runInAction(() => {
                jsonData.data.map((item : DataItem) => {
                    Object.keys(item).forEach((key) => {
                        if (key === 'id') {
                            delete item[key];
                        }
                    });
                })
                this.data = jsonData.data.filter((item : DataItem)=> Object.values(item).some(v => v !== null && !(Array.isArray(v) && v.length === 0)));
                this.filteredData = this.data;
                this.pagesCount = jsonData.totalPages;
                this.selectedRows = new Array(this.data.length).fill(false);
                if (!this.availableFilters.length) {
                    this.availableFilters = Object.keys(this.data[0] || {});
                }
                this.isLoading = false;
            });
        } catch (error) {
            runInAction(() => {
                //todo сделать показ попапа на ошибки
                console.error("Failed to fetch data:", error);
                this.isLoading = false;
            });
        }
    }

    // todo сделать в бэке возврат значение в items, добавление, удаление, редактирование

    setSearchQuery(query: string) {
        console.log(query)
        this.isLoading = true;
        this.searchQuery = query;
        if (query !== "") this.updateUrlParams("searchQuery", this.searchQuery);
        else this.removeUrlParam("searchQuery")
        this.loadData()
    }

    setCurrentPage(page: number) {
        this.currentPage = Math.min(Math.max(page, 1), this.pagesCount);
        this.loadData();
    }

    nextPage() {
        if (this.currentPage < this.pagesCount) {
            this.setCurrentPage(this.currentPage + 1);
        }
    }

    previousPage() {
        if (this.currentPage > 1) {
            this.setCurrentPage(this.currentPage - 1);
        }
    }

    toggleRow(index: number) {
        this.selectedRows[index] = !this.selectedRows[index];
    }

    toggleAllRows() {
        const allSelected = this.selectedRows.every(Boolean);
        this.selectedRows.fill(!allSelected);
    }

    get allSelected() {
        return this.selectedRows.every(Boolean);
    }

    updateItem(index: number, key: string, value: any) {
        const item = this.filteredData[index];
        if (item) {
            item[key] = value;
        }
    }

    submitData() {

    }
}

export default TableStore;
