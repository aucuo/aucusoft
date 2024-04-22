import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'
import {resolve} from 'path'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@': resolve(__dirname, './src'),
      '@components': resolve(__dirname, './src/components'),
      '@public': resolve(__dirname, './public'),
      '@icons': resolve(__dirname, './public/icons'),
      '@assets': resolve(__dirname, './src/assets'),
    }
  }
})
