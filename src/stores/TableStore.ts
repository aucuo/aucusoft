import { makeAutoObservable, runInAction } from "mobx";
import {toastStore} from "@/stores/ToastStore.ts";

interface DataItem {
    [key: string]: any;
    additional?: {
        [key: string]: Option,
    }
}

interface Option {
    id: number;
    name: string;
}

class TableStore {
    data: DataItem[] = [];
    additionalData: { [key: string]: Option[] } = {};  // Сюда сохраняем данные для select
    selectedRows: boolean[] = [];
    currentPage: number = 1;
    pagesCount: number = 1;
    searchQuery: string = '';
    availableFilters: string[] = [];
    isLoading: boolean = false;
    url?: string = undefined;
    urlParams?: string = '';

    constructor(tableName: string) {
        makeAutoObservable(this);
        this.url = `https://localhost:7030/aucusoft/${tableName}`;
    }

    // URL
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

    // Table search
    async setSearchQuery(query: string) {
        console.log(query)
        this.isLoading = true;
        this.searchQuery = query;
        if (query !== "") this.updateUrlParams("searchQuery", this.searchQuery);
        else this.removeUrlParam("searchQuery")
        await this.loadData()
    }

    // Table pagination
    async setCurrentPage(page: number) {
        this.currentPage = Math.min(Math.max(page, 1), this.pagesCount);
        await this.loadData();
    }
    async nextPage() {
        if (this.currentPage < this.pagesCount) {
            await this.setCurrentPage(this.currentPage + 1);
        }
    }
    async previousPage() {
        if (this.currentPage > 1) {
            await this.setCurrentPage(this.currentPage - 1);
        }
    }

    // Table rows
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

    // API
    async loadData() {
        // Добавление стандартных параметров запроса
        let params = new URLSearchParams(this.urlParams);
        params.set('pageIndex', this.currentPage.toString());
        params.set('pageSize', '5');
        params.set('sortDirection', 'asc');

        const url = `${this.url}?${params.toString()}`;
        this.isLoading = true;
        try {
            const response = await fetch(url);
            const jsonData = await response.json();

            runInAction(() => {
                this.data = jsonData.data.filter((item : DataItem)=> Object.values(item).some(v => v !== null && !(Array.isArray(v) && v.length === 0)));
                this.additionalData = jsonData.additional;
                this.pagesCount = jsonData.totalPages;
                this.selectedRows = new Array(this.data.length).fill(false);
                if (!this.availableFilters.length) {
                    this.availableFilters = Object.keys(this.data[0] || {});
                }
                this.isLoading = false;
            });
        } catch (error) {
            runInAction(() => {
                toastStore.setShow(`Failed to fetch data: ${error}`, "error");
                this.isLoading = false;
            });
        }
    }
    // Update API
    async updateItem(index: number, key: string, value: any, id: number) {
        const item = this.data[index];
        if (item) {
            item[key] = value;
            await this.submitData(id);
        }
    }
    async submitData(id: number) {
        const item = this.data.find(item => item.id === id);
        if (!item) {
            toastStore.setShow("Item with the specified ID not found.", "warning");
            return;
        }

        const baseUrl = this.url || "https://localhost:7030/aucusoft/Projects";
        const params = new URLSearchParams();

        Object.keys(item).forEach(key => {
            if (key.endsWith('FK')) {
                const newKey = key.replace('FK', 'ID');
                params.append(newKey, item[key]);
            } else if (key.endsWith('Date')) {
                params.append(key, item[key]);
            } else {
                params.append(key, item[key]);
            }
        });

        const url = `${baseUrl}/${id}?${params.toString()}`;

        try {
            const response = await fetch(url, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: params
            });
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            toastStore.setShow("Data successfully updated", "default");
            await this.loadData();
        } catch (error) {
            toastStore.setShow(`Failed to submit data: ${error}`, "warning");
            console.error("Failed to submit data:", error);
        }
    }
}

export default TableStore;
