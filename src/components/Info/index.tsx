interface Props {
    header: string;
    text: string;
}

export function Info({ header, text }: Props) {
    return (
        <>
            <div className="info">
                <h2 className="info__header">
                    {header}
                </h2>
                <p className="info__text">
                    {text}
                </p>
            </div>
        </>
    )
}