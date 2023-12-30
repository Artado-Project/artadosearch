import React, { useState } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { ConfigProvider } from 'antd';
import { BrowserRouter as Router } from 'react-router-dom';

const checkTheme = () => {
    const theme = localStorage.getItem('theme');
    return theme === 'dark';
}

const Root = () => {
    const [darkMode, setDarkMode] = useState(checkTheme());

    return (
        <React.StrictMode>
            <ConfigProvider>
                <App />
            </ConfigProvider>
        </React.StrictMode>
    );
};

const root = ReactDOM.createRoot(document.getElementById('root') ?? document.createElement('div'));
root.render(<Root />);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals(console.log);
