import { useEffect, useState } from 'react';
import { notification } from 'antd';

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../../language/${language}/index-page.json`);

const theme = localStorage.getItem('theme') ?? 'light';

const AlertMessage = (): null => {
    const [hasAlertShown, setHasAlertShown] = useState(false);

    useEffect(() => {
        if (!hasAlertShown) {
            const alertParams = new URLSearchParams(window.location.search);
            const alertType: string | null = alertParams.get('ret_no');

            const showAlert = () => {
                switch (alertType) {
                    case 'empty-url':
                        notification.warning({
                            message: (
                                <div style={ theme === 'night' ? { color: '#ffce9c' } : { color: '#3c3c3c' }}>
                                    {languageData.alerts.missing_parameters}
                                </div>
                            ),
                            description: (
                                <div style={theme === 'night' ? {color: '#ffd39c'} : {color: '#c5c5c5'}}>
                                    {languageData.alerts.missing_parameters_desc}
                                </div>
                            ),
                            placement: 'bottomRight',
                            duration: 15,
                            style: theme === 'night' ? { backgroundColor: '#884305', color: '#d0d0d0 !important', borderRadius: 5} : { color: '#3c3c3c' }
                        });
                        break;

                    default:
                        break;
                }
            };

            showAlert();
            setHasAlertShown(true);
        }
    }, [hasAlertShown]);

    return null;
};

export default AlertMessage;
