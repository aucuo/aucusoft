import React, {useState} from 'react';
import './frame.scss';

interface Props {
    name: string,
    children: React.ReactNode;
}

export function Frame({ name, children }: Props) {
    const [isFull, setIsFull] = useState(false);

    function resizeFrame() {
        setIsFull(!isFull); // Переключаем состояние

        console.log(isFull)
    }

    // Добавляем динамический класс в зависимости от состояния isFull
    const frameClass = `frame ${isFull ? 'frame--full' : ''}`;

    return (
        <div className={frameClass}>
            <div className="frame__top">
                <span className="frame__name">{name}</span>
                <div className="frame__resize" onClick={resizeFrame}>
                    <svg className="frame__icon" width={24} height={24}>
                        <use xlinkHref='public/icons/sprites.svg#maximize-3'></use>
                    </svg>
                </div>
            </div>
            <div className="frame__body">{children}</div>
        </div>
    );
}
