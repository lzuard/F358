import './style.scss'

interface IInputProps {
  id: string
  value: string
  inputType: string
  setValue: (value: string) => void
  label?: string | undefined,
  placeholder?: string | undefined,
}


export default function Input({
  id,
  value,
  inputType,
  setValue,
  label = undefined,
  placeholder = undefined,
}: IInputProps) {

  return (
    <div className="input-container">
      {label && (
        <label htmlFor={id}>{label}</label>
      )}
      <input
        value={value}
        onChange={e => setValue(e.target.value)}
        type={inputType}
        id={id}
        placeholder={placeholder}/>
    </div>
  )
}