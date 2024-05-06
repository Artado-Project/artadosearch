import React from "react";
import {Alert, Button} from "antd";
import ArtadoFooter from "../../components/Index/ArtadoFooter";

const Error404: React.FC = () => {
    return (
        <>
            <div className={'Artado-container'}>
                <Alert
                    message={[
                        <>
                            <h1 className={'font__source-code-pro'} style={{fontSize: 24, fontWeight: "bold"}}>
                                HTTP: 404.0 - 404.1
                            </h1>
                            <small className={'font__source-code-pro'}>Not Found - Site Not Found.</small>
                        </>
                    ]}
                    banner
                    showIcon={false}
                    type={'error'}
                    style={{
                        padding: 10,
                        textAlign: 'center',
                        maxWidth: '100%',
                        top: '30%',
                        marginBottom: "20px",
                        borderRadius: '0 0 5px 5px'
                    }}
                />
                <br/><br/><br/><br/><br/>
                <div className={'Artado-row'} style={{textAlign: "center"}}>
                    <div className={'column-xs-12 column-sm-12 column-md-12 column-lg-12 column-xl-12'}>
                        <h3 className={'font__open-sans-bold'}
                            style={{fontSize: 18, fontWeight: "bold", color: '#888'}}>
                            Opps... Before Artadosaurus could discover the page you were looking for, a meteorite
                            fell on his head.
                        </h3>
                        <small style={{fontSize: 12, fontWeight: "bold", color: '#888'}}>
                            The page you are looking for might have been removed, had its name changed, or is
                            temporarily
                            unavailable.
                        </small>
                        <br/>
                        <Button
                            type={'default'}
                            href={'/'}
                            style={{fontSize: 12, fontWeight: "bold", color: '#888', paddingTop: '6px'}}
                        >
                            Go to Homepage
                        </Button>
                    </div>
                </div>
            </div>
            <ArtadoFooter/>
        </>
    );
}

export default Error404;