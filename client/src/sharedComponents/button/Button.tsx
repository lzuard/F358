import './style.scss'

interface ButtonProps {
    text: string;
    onClick: () => void;
    disabled?: boolean
}

export function Button({ text, onClick, disabled = false}: ButtonProps) {
    return(
        <button onClick={onClick} disabled={disabled}>
            {text}
        </button>
    )
}