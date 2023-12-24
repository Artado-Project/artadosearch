import { useEffect } from 'react';
import { message } from 'antd';

const AlertMessage = (): null => {
    useEffect((): void => {
        const alertParams = new URLSearchParams(window.location.search);
        const alertType: string = alertParams.get('ret_no');

        const showAlert = () => {
            switch (alertType) {
                case 'empty-url':
                    message.warning({
                        content: 'Attention! Input value cannot be empty! (EMPTY-URL)',
                        style: {
                            fontWeight: 'bold',
                            fontSize: '0.8rem',
                            fontFamily: 'assistant',
                        }
                    });
                    break;

                default:
                    break;
            }
        };

        showAlert();
    }, );

    return null;
};

export default AlertMessage;
