import {postAsync} from "../../utils/api/actions.ts";
import type {IProcessResult, IProcessResultWithData} from "../../utils/api/types.ts";
import type {IAuthUser, IRegisterUser} from "./types.ts";


const LOGIN_URL = 'auth/login'
const REGISTER_URL = 'auth/register'



export const loginAsync = async ({login, password}: IAuthUser) =>
  await postAsync<IProcessResultWithData<string>, IAuthUser>(LOGIN_URL, {login, password})

export const registerAsync = async({login, password, firstName, lastName} : IRegisterUser) =>
  await postAsync<IProcessResult, IRegisterUser>(REGISTER_URL, {login, password, firstName, lastName})