import './note.scss';
import { Frame } from '@components/Frame/Frame.tsx';
import {useEffect, useState} from "react";

interface Props {
    menu?: boolean;
}

export function Note({menu = true}: Props) {
    const [header, setHeader] = useState('');
    const [text, setText] = useState('');

    useEffect(() => {
        const storedHeader = localStorage.getItem('nt-hdr');
        const storedText = localStorage.getItem('nt-txt');
        if (storedHeader) setHeader(storedHeader);
        if (storedText) setText(storedText);
    }, []);

    const handleHeaderChange = (newHeader: string) => {
        localStorage.setItem('nt-hdr', newHeader);
        setHeader(newHeader);
    };

    const handleTextChange = (newText: string) => {
        localStorage.setItem('nt-txt', newText);
        setText(newText);
    };

    return (
        <Frame name={'Notes'}>
            {menu && <Menu />}
            <div className="note">
                <div className="note__wrapper">
                    <h2 className="note__header" contentEditable={true}
                        onBlur={e => handleHeaderChange(e.currentTarget.textContent || '')}
                        suppressContentEditableWarning={true}>
                        {header}
                    </h2>
                    <div className="note__text" contentEditable={true}
                         onBlur={e => handleTextChange(e.currentTarget.textContent || '')}
                         suppressContentEditableWarning={true}>
                        {text}
                    </div>
                </div>
            </div>
        </Frame>
    );
}

function Menu() {
    const applyStyle = (style: string) => {
        const textElement = document.querySelector('.note__text');
        const selection = window.getSelection();

        if (selection && textElement != null && selection.rangeCount > 0) {
            const range = selection.getRangeAt(0);
            const selectedNode = range.commonAncestorContainer;

            if (textElement.contains(selectedNode)) {
                document.execCommand(style, false);
            }
        }
    };

    let icons = [
        // { name: "task", action: () => console.log('Task action') },
        // { name: "add-square", action: () => console.log('Add square action') },
        { name: "text-bold", action: () => applyStyle('bold')},
        { name: "text-italic", action: () => applyStyle('italic') },
        // { name: "verify", action: () => console.log('Verify action') },
    ];

    return (
        <div className="note__icons">
            {icons.map(icon => (
                <button className="note__button button" type="button" key={icon.name} onClick={icon.action}>
                    <svg className="note__icon" width={24} height={24}>
                        <use xlinkHref={`public/icons/sprites.svg#${icon.name}`}></use>
                    </svg>
                </button>
            ))}
        </div>
    );
}