import './style.scss'
import Input from "../../sharedComponents/input/Input.tsx";
import {Button} from "../../sharedComponents/button/Button.tsx";
import {HintWithLink} from "../../sharedComponents/HintWithLink/HintWithLink.tsx";
import {registerAsync} from "./actions.ts";
import {useForm} from "react-hook-form";
import {useEffect, useState} from "react";
import {ProcessStatus} from "../../utils/api/types.ts";
import {toast} from "react-toastify";
import {useNavigate} from "react-router-dom";


interface RegisterFormData {
  login: string
  password: string
  passwordConfirm: string
  firstName: string
  lastName?: string
}

export function RegisterPage() {
  const [backendErrors, setBackendErrors] = useState<string[]>([]);
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    watch,
    trigger,
    formState: {errors, isValid, isSubmitting}
  } = useForm<RegisterFormData>({
    mode: "onBlur"
  });

  const password = watch("password")
  const passwordConfirm = watch("passwordConfirm")

  useEffect(() => {
    if (password && passwordConfirm) trigger("passwordConfirm");
  }, [password, passwordConfirm, trigger]);

  const onSubmit = async (data: RegisterFormData) => {
    const result = await registerAsync({
      login: data.login,
      password: data.password,
      firstName: data.firstName,
      lastName: data.lastName,
    })

    if(result === null)
      return;

    if(result.status === ProcessStatus.Success) {
      toast.success("Успешная регистрация")
      navigate("/auth")
    }
    else{
      setBackendErrors(result.errors)
    }
  }

  const EMPTY_FIELD_ERROR = "Нельзя оставлять пустым"

  return (
    <div className="auth-container">
      <div className="auth-window">
        <h1>Регистрация</h1>

        <form className="auth-form" onSubmit={handleSubmit(onSubmit)}>
          <Input
            id="login"
            inputType="text"
            label="Логин"
            placeholder="Введите логин"
            error={errors.login?.message}
            {...register("login", {
              required: EMPTY_FIELD_ERROR,
              minLength: {value: 3, message: "Не менее 3 символов"}
            })}
          />
          <Input
            id="password"
            inputType="password"
            label="Пароль"
            placeholder="Введите пароль"
            error={errors.password?.message}
            {...register("password", {
              required: EMPTY_FIELD_ERROR,
              minLength: { value: 6, message: "Не менее 6 символов"}
            })}
          />
          <Input
            id="passwordConfirm"
            inputType="password"
            label="Повторите пароль"
            placeholder="Введите пароль ещё раз"
            error={errors.passwordConfirm?.message}
            {...register("passwordConfirm", {
              required: EMPTY_FIELD_ERROR,
              validate: (value) =>
                value === password || "Пароли не совпадают",
            })}
          />
          <Input
            id="firstName"
            inputType="text"
            label="Имя"
            placeholder="Введите имя"
            error={errors.firstName?.message}
            {...register("firstName", {
              required: "Нельзя оставлять пустым",
            })}
          />
          <Input
            id="secondName"
            inputType="text"
            label="Фамилия"
            placeholder="Введите фамилию (опционально)"
            {...register("lastName")}
          />
          {backendErrors.length > 0 && (
            <div className="error-message">
              {backendErrors.map((val, index) => (<p key={index}>{val}</p>))}
            </div>
          )}
          <Button
            text="Зарегистрироваться"
            type="submit"
            disabled={!isValid || isSubmitting}
            loading={isSubmitting}
          />
        </form>

        <HintWithLink
          linkTo="/auth"
          linkToText="Войти"
          textBeforeLink="Уже есть аккаунт?"
        />
      </div>
    </div>
  )
}