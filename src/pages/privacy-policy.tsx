import React from "react";
import './../assets/Index.css';
import { Button } from "antd";

function PrivacyPolicy() {
    return (
        <>
            <div className={'Artado-container'} id={'artadoManifestContainer'}>
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>Privacy Policy</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                    >
                        Home
                    </Button>
                </div>
            </div>
        </>
    )
}

export default PrivacyPolicy;
