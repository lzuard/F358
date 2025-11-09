
export interface IAuthUser {
  login: string
  password: string
}

export interface IRegisterUser{
  login: string
  password: string
  firstName: string
  lastName: string | undefined
}