import { makeAutoObservable } from 'mobx';

class AppStore {
    theme: string = localStorage.getItem('theme') || "dark";

    constructor() {
        makeAutoObservable(this);
        localStorage.setItem(('theme'), this.theme);
    }

    toggleTheme = () => {
        this.theme = this.theme === 'dark' ? 'light' : 'dark';
        localStorage.setItem(('theme'), this.theme);
    }
}

export const appStore = new AppStore();
