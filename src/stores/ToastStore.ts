import { makeAutoObservable, runInAction } from 'mobx';

class ToastStore {
    show = false;
    message = '';
    type: 'default' | 'error' | 'warning' = 'default';
    hideTimeout: NodeJS.Timeout | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    setShow(message: string, type: 'default' | 'error' | 'warning' = 'default') {
        if (this.show) {
            runInAction(() => {
                this.show = false; // Set `show` to false inside an action
            });
            if (this.hideTimeout) clearTimeout(this.hideTimeout);
            setTimeout(() => {
                this.setMessageAndShow(message, type);
            }, 50);
        } else {
            this.setMessageAndShow(message, type);
        }
    }

    setMessageAndShow(message: string, type: 'default' | 'error' | 'warning') {
        runInAction(() => {
            this.message = message;
            this.type = type;
            this.show = true;
        });
        this.resetHideTimeout();
    }

    resetHideTimeout() {
        if (this.hideTimeout) clearTimeout(this.hideTimeout);
        const displayDuration = this.type === 'error' ? 10000 : 5000;
        this.hideTimeout = setTimeout(() => {
            runInAction(() => {
                this.show = false; // Set `show` to false inside an action
                this.hideTimeout = null;
            });
        }, displayDuration);
    }

    toggleShow = () => {
        runInAction(() => {
            this.show = !this.show; // Toggle `show` inside an action
        });
    }
}

export const toastStore = new ToastStore();
