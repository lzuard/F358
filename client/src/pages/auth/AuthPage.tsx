import './AuthPage.scss'
import Input from "../../sharedComponents/input/Input.tsx";
import {Button} from "../../sharedComponents/button/Button.tsx";
import {useEffect, useState} from "react";

export function AuthPage() {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [isLoginEnabled, setIsLoginEnabled] = useState(false);

  useEffect(() => {
    setIsLoginEnabled(login.length > 0 && password.length > 0);
  }, [login, password]);

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
            setValue={setLogin}
          />
          <Input
            id="password"
            inputType="password"
            label="Пароль"
            placeholder="Введите пароль"
            value={password}
            setValue={setPassword}
          />
          <Button
            text="Войти"
            onClick={() => alert(login + " " + password)}
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
