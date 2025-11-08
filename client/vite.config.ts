import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  server: {
      port: 8888,
      host: true,
  },
  plugins: [react()],
})
