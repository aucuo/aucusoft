import { makeAutoObservable } from 'mobx';

class AppStore {
    isDark: boolean = true;

    constructor() {
        makeAutoObservable(this);
    }

    toggleTheme = () => {
        this.isDark = !this.isDark;
        console.log(this.isDark)
    }
}

export const appStore = new AppStore();
