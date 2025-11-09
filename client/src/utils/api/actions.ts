import {apiClient} from './base';
import {toast} from "react-toastify";


export async function postAsync<TResponse, TBody>(
  url: string,
  data: TBody
): Promise<TResponse | null> {
  try{
    return await apiClient.post<TResponse>(url, data).then(res => res.data);
  }
  catch {
    toast.error("Не удалось связаться с сервером, попробуйте позже")
    return null
  }

}
