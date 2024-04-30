import React from 'react'
import ReactDOM from 'react-dom/client'
import App from '@/App.tsx'
import 'normalize.css'
import './Bootstrap.scss'
import './index.scss'
import './theme.scss'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode >
    <App />
  </React.StrictMode>,
)
