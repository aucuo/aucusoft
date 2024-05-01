import './login.scss';
import {Frame} from "@components/Frame/Frame.tsx";
import { useState} from 'react';
import { observer } from 'mobx-react';
import AuthStore from '@/stores/AuthStore';
import authStore from "@/stores/AuthStore";
import {Spinner} from "react-bootstrap";
import {appStore} from "@/stores/AppStore.ts";
import {toastStore} from "@/stores/ToastStore.ts";

export const Login = observer(() => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        try {
            await AuthStore.login(username, password);
        } catch (error) {
            toastStore.setShow(`Login failed: ${error}`, "error");
        }
    }

    return (
        <div className="login">
            <Frame name={'Login'} hasButtons={false}>
                <form className="login__form" onSubmit={e => {
                    e.preventDefault();
                    handleLogin();
                }}>
                    {authStore.isLoading &&
                        <>
                            <div className="login--loading">
                                <Spinner animation="border" role="status"></Spinner>
                            </div>
                        </>
                    }
                    <div className="input login__input">
                        <input type="text" autoComplete="on" placeholder="Username" value={username}
                               onChange={e => setUsername(e.target.value)} required maxLength={20}/>
                    </div>
                    <div className="input login__input">
                        <input type="password" autoComplete="on"  placeholder="Password" value={password}
                               onChange={e => setPassword(e.target.value)} required maxLength={20}/>
                    </div>
                    <button type="submit" className="button login__button">Login</button>
                </form>
                <div className="login__additional">
                    <button className="login__button--additional button" type="button"
                            onClick={() => window.open("https://github.com/aucuo", '_blank')}>
                        <svg width={24} height={24}>
                            <use xlinkHref={`public/icons/sprites.svg#github`}></use>
                        </svg>
                    </button>
                    <button className="login__button--additional button" type="button"
                            onClick={() => window.open("https://www.instagram.com/aucuo/", '_blank')}>
                        <svg width={24} height={24}>
                            <use xlinkHref={`public/icons/sprites.svg#instagram`}></use>
                        </svg>
                    </button>
                    <button className="login__button--additional button" type="button"
                            onClick={() => window.open("https://t.me/aucuo", '_blank')}>
                        <svg width={24} height={24}>
                            <use xlinkHref={`public/icons/sprites.svg#telegram`}></use>
                        </svg>
                    </button>
                    <button className="login__button--additional button" onClick={appStore.toggleTheme}>
                        <svg className="sidebar__icon" width={24} height={24}>
                            <use xlinkHref='public/icons/sprites.svg#mask'></use>
                        </svg>
                    </button>
                </div>
            </Frame>
        </div>
    );
});