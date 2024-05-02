import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { ConfigProvider, theme } from 'antd';

const checkTheme = () => {
    const theme = localStorage.getItem('theme');
    return theme === 'night';
}

const Root = () => {
    const [darkMode, setDarkMode] = useState(checkTheme());
    const { defaultAlgorithm, darkAlgorithm } = theme;

    // setting prefer-scheme to dark
    useEffect(() => {
        if (darkMode) {
            document.documentElement.setAttribute('data-theme', 'dark');
        } else {
            document.documentElement.setAttribute('data-theme', 'light');
        }
    }, [darkMode]);


    return (
        <React.StrictMode>
            <ConfigProvider
                theme={{ algorithm: darkMode ? darkAlgorithm : defaultAlgorithm }}
            >
                <App />
            </ConfigProvider>
        </React.StrictMode>
    );
};

const root = ReactDOM.createRoot(document.getElementById('root') ?? document.createElement('div'));
root.render(<Root />);

reportWebVitals(console.log);
