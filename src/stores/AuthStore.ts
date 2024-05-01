// src/stores/AuthStore.ts
import {makeAutoObservable, runInAction} from "mobx";
import {toastStore} from "@/stores/ToastStore.ts";

class AuthStore {
    token: string | null = localStorage.getItem('token') || null;
    user?: string | null = null;
    isLoading: boolean = false;

    constructor() {
        makeAutoObservable(this);
    }

    setToken(token: string) {
        this.token = token;
        localStorage.setItem('token', token);
    }

    clearToken() {
        this.token = null;
        localStorage.removeItem('token');
    }

    setUser(user: string | null) {
        this.user = user;
    }

    isAuthenticated() {
        return this.token !== null;
    }

    login = async (username: string, password: string) => {
        this.isLoading = true;
        try {
            const response = await fetch('https://localhost:7030/aucusoft/user/login', {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({username, password})
            });

            if (response.ok) {
                const data = await response.json();
                console.log(data);
                this.setToken(data.token);
                this.setUser(username); // Определяйте, какие данные пользователя вам нужны
                toastStore.setShow(`Successful login`, "default");
            } else {
                toastStore.setShow(`Login failed: wrong credentials`, "warning");
            }
        } catch (error) {
            console.error(error);
            toastStore.setShow(`${error}`, "error");
        } finally {
            runInAction(() => {
                this.isLoading = false;
            });
        }
    }

    logout = () => {
        this.clearToken();
        this.setUser(null);
    }
}

export default new AuthStore();
