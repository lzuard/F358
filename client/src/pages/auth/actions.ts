import {postAsync} from "../../utils/api/actions.ts";
import type {IProcessResultWithData} from "../../utils/api/types.ts";
import type {IAuthUser} from "./types.ts";


const LOGIN_URL = 'auth/login'



export const loginAsync = async ({login, password}: IAuthUser) =>
  await postAsync<IProcessResultWithData<string>, IAuthUser>(LOGIN_URL, {login, password})