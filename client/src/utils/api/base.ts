import axios, { AxiosError, type AxiosInstance } from 'axios';
import {toast} from "react-toastify";

const apiClient: AxiosInstance = axios.create({
  baseURL: "http://localhost:5550/v1", //TODO: add url
  headers: {
    'Content-Type': 'application/json',
  },
  //withCredentials: true, // если API использует cookie
});

apiClient.interceptors.request.use((config) => {
  const token = localStorage.getItem("token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

apiClient.interceptors.response.use(
  (response) => response,
  async (error: AxiosError) => {
    if (error.response) {
      const status = error.response.status;

      if (status === 401) {
        toast.warning("Сессия устарела. Необходимо заново войти в аккаунт.")
        window.location.href = '/login'; //TODO: use router
      }
      else if (status === 503) {
        toast.error("В настоящий момент сервис недоступен. Попробуйте позже.")
      }
      else if (status >= 500) {
        toast.error("Что-то пошло не так.")
      }
    }

    return Promise.reject(error);
  }
);

export default apiClient;
