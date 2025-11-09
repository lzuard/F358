import axios, { AxiosError, type AxiosInstance } from 'axios';
import {toast} from "react-toastify";
import {type NavigateFunction } from "react-router-dom";

export const apiClient: AxiosInstance = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
  //withCredentials: true, // если API использует cookie
});

export const ConfigureClient = (navigate: NavigateFunction) =>{

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
            localStorage.removeItem("token");
            navigate("/auth");
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
}

