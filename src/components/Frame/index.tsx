import React, {useEffect, useState} from 'react';
import './frame.scss';

interface Props {
    name: string,
    children: React.ReactNode;
    refreshTable?: ()=>void;
}

export function Frame({ name, children, refreshTable }: Props) {
    const [isFull, setIsFull] = useState(false);

    const frameClass = `frame ${isFull ? 'frame--full' : ''}`;
    function resizeFrame() {
        setIsFull(!isFull); // Переключаем состояние
    }
    useEffect(() => {
        document.body.classList.toggle('dark-overlay', isFull);
        document.body.classList.toggle('maximized', isFull);

        // Очистка: удаление стиля затемнения при размонтировании компонента
        return () => {
            document.body.classList.remove('dark-overlay');
        };
    }, [isFull]);

    return (
        <div className={frameClass}>
            <div className="frame__top">
                <span className="frame__name">{name}</span>
                <div className="frame__top-buttons">
                    <button className="frame__resize frame__button button button--transparent button--nopadding" onClick={refreshTable} title={'Refresh Table'}>
                        <svg className="frame__icon" width={24} height={24}>
                            <use xlinkHref='public/icons/sprites.svg#refresh'></use>
                        </svg>
                    </button>
                    <button className="frame__refresh frame__button button button--transparent button--nopadding" onClick={resizeFrame}  title={'Maximize'}>
                        <svg className="frame__icon" width={24} height={24}>
                            <use xlinkHref='public/icons/sprites.svg#maximize-3'></use>
                        </svg>
                    </button>
                </div>
            </div>
            <div className="frame__body">{children}</div>
        </div>
    );
}
