import apiClient from './base';


export async function postAsync<TResponse, TBody>(
  url: string,
  data: TBody
): Promise<TResponse> {
  return await apiClient.post<TResponse>(url, data).then(res => res.data);
}
