import './AuthPage.scss'
import Input from "../../sharedComponents/input/Input.tsx";
import {Button} from "../../sharedComponents/button/Button.tsx";
import {useEffect, useState} from "react";
import {loginAsync} from "./actions.ts";
import {ProcessStatus} from "../../utils/api/types.ts";
import {toast} from "react-toastify";

export function AuthPage() {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [isLoginEnabled, setIsLoginEnabled] = useState(false);
  const [isLoginError, setIsLoginError] = useState(false);
  const [errors, setErrors] = useState<string[]>([]);

  useEffect(() => {
    setIsLoginEnabled(login.length > 0 && password.length > 0 && !isLoginError);
  }, [login, password, isLoginError]);

  function handleLoginChange(value: string) {
    setIsLoginError(false)
    setLogin(value)
  }

  function handlePasswordChange(value: string) {
    setIsLoginError(false)
    setPassword(value)
  }

  const handleLogin = async () => {
    localStorage.removeItem("token")
    const result = await loginAsync({login, password})

    if(result.status === ProcessStatus.Success) {
      toast.success("Login successfully.")
      localStorage.setItem("token", result.data[0])
      setIsLoginError(false);
      setErrors([]);
    }
    else{
      setErrors(result.errors)
      setIsLoginError(true)
    }
  }

  return (
    <div className="auth-container">
      <div className="auth-window">
        <h1>Авторизация</h1>

        <div className="auth-form">
          <Input
            id="login"
            inputType="text"
            label="Логин"
            placeholder="Введите ваш логин"
            value={login}
            setValue={handleLoginChange}
          />
          <Input
            id="password"
            inputType="password"
            label="Пароль"
            placeholder="Введите пароль"
            value={password}
            setValue={handlePasswordChange}
          />
          {isLoginError && (
            <div className="error-message">
              {errors.map((val, index) => (<p id={index.toString()}>{val}</p>))}
            </div>
          )}
          <Button
            text="Войти"
            onClick={handleLogin}
            disabled={!isLoginEnabled}
          />
        </div>
        <p className="auth-hint">
          Нет аккаунта? <a href="/register">Зарегистрироваться</a>
        </p>
      </div>
    </div>
  )
}
