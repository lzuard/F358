import './style.scss'
import {type InputHTMLAttributes, useState} from "react";

interface IInputProps extends InputHTMLAttributes<HTMLInputElement> {
  id: string
  inputType: string
  setValue?: (value: string) => void
  label?: string | undefined,
  error?: string | undefined,
}


export default function Input({
  id,
  inputType,
  setValue,
  label = undefined,
  error = undefined,
  ...rest
}: IInputProps) {
  const ICON_EYE_OPEN_PATH = "/assets/icon_eye_open.png"
  const ICON_EYE_CLOSE_PATH = "/assets/icon_eye_close.png"

  const [isShowPassword, setIsShowPassword] = useState(false)

  const handleShowPassword = () => setIsShowPassword((prev) => !prev)

  const inputTypeInner = inputType === "password" && isShowPassword ? "text" : inputType
  const iconSource = isShowPassword ? ICON_EYE_CLOSE_PATH : ICON_EYE_OPEN_PATH

  return (
    <div className={`input-container ${error ? "error" : ""}`}>
      <div className="label-container">
        {label && (
          <label htmlFor={id}>{label}</label>
        )}
        {error && (
          <label htmlFor={id}>{error}</label>
        )}
      </div>
      <div className="input-wrapper">
        {setValue
          ? <input
            type={inputTypeInner}
            id={id}
            onChange={(e => setValue(e.target.value))}
            {...rest}
          />
          : <input
            type={inputTypeInner}
            id={id}
            {...rest}
          />
        }
        {inputType === "password" && (
          <button
            type="button"
            className="toggle-password-btn"
            onClick={handleShowPassword}
            tabIndex={-1}>
            <img src={iconSource} alt="Show password button"/>
          </button>
        )}
      </div>
    </div>
  )
}