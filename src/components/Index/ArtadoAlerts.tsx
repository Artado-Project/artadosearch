import { useEffect, useState } from 'react';
import { notification } from 'antd';

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../../language/${language}/index-page.json`);

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
                            message: languageData.alerts.missing_parameters,
                            description: languageData.alerts.missing_parameters_desc,
                            placement: 'bottomRight',
                            duration: 15
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
