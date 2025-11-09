import './style.scss'
import {useState} from "react";

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  text: string
  onClick?: () => Promise<void> | void
  loading?: boolean
}

export function Button({
  text,
  onClick,
  type = "button",
  disabled,
  loading = false,
  ...rest
}: ButtonProps) {
  const [isLoading, setIsLoading] = useState(false)

  const handleClick = async () => {
    if (!onClick) return
    try {
      setIsLoading(true)
      await onClick()
    } finally {
      setIsLoading(false)
    }
  }

  const isButtonDisabled = disabled || isLoading || loading

  return (
    <button
      type={type}
      onClick={onClick ? handleClick : undefined}
      disabled={isButtonDisabled}
      {...rest}
    >
      {isLoading || loading ? "Загрузка..." : text}
    </button>
  )
}