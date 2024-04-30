import {Toast, ToastContainer} from 'react-bootstrap';
import { observer } from 'mobx-react';
import { toastStore } from '@/stores/ToastStore.ts';
import { CSSTransition } from 'react-transition-group';
import './toast.scss';

export const ToastComponent: React.FC = observer(() => {
    const toastClass = `toast toast--${toastStore.type}`;
    return (
        <ToastContainer>
            <CSSTransition
                in={toastStore.show}
                timeout={300}
                classNames="toast-animation"
                unmountOnExit
            >
                <Toast onClose={toastStore.toggleShow} className={toastClass}>
                    {toastStore.message}
                    <button className="button" onClick={toastStore.toggleShow}>OK</button>
                </Toast>
            </CSSTransition>
        </ToastContainer>
    );
});
