import './note.scss';
import { Frame } from '@components/frame';

interface Props {
    header: string;
    text: string;
    menu?: boolean;
}

export function Note({ header, text, menu = true }: Props) {

    const handleHeaderChange = () => {
    }

    const handleTextChange = () => {
    }

    return (
        <Frame name={'Notes'}>
            {menu && <Menu />}
            <div className="note">
                <div className="note__wrapper">
                    <h2 className="note__header" contentEditable={true} onBlur={handleHeaderChange}
                        suppressContentEditableWarning={true}>
                        {header}
                    </h2>
                    <div className="note__text" contentEditable={true} onBlur={handleTextChange}
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
        { name: "task", action: () => console.log('Task action') },
        { name: "add-square", action: () => console.log('Add square action') },
        { name: "text-bold", action: () => applyStyle('bold')},
        { name: "text-italic", action: () => applyStyle('italic') },
        { name: "verify", action: () => console.log('Verify action') },
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