import { useEffect, useState } from 'react';
import { notification } from 'antd';

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
                            message: 'Warning - Missing Parameter',
                            description: 'Attention, the URL or input value cannot be empty. If you are getting this error, you are probably having a problem with missing parameters. If you are interacting with a web service or API, make sure you provide the correct parameters.',
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
