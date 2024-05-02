import React, { useState } from 'react';
import {Modal} from 'antd';

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../../language/${language}/index-page.json`);

const headerStyle = {
    fontWeight: 600,
    color: '#000000',
    fontFamily: 'Assistant',
    lineHeight: '1.5',
    marginBottom: '1.5rem',
    borderLeft: '1px solid #3c3c3c',
    paddingLeft: '10px',
}

const ArtadoSection: React.FC = () => {
    const [isModalOpen, setIsModalOpen] = useState(false);

    const showArtadoModal = () => {
        setIsModalOpen(true);
    };

    const onModalCancel = () => {
        setIsModalOpen(false);
    };

    return (
        <>
            <div
                style={{
                    display: 'flex',
                    transition: 'visibility 0.7s linear',
                    justifyContent: 'center',
                    alignItems: 'center',
                    textAlign: 'center',
                }}
                className={'artado-section-arrow'}
            >
                <div
                    className={'arrow'}
                >
                    <svg xmlns="http://www.w3.org/2000/svg" style={{ cursor: 'pointer' }} onClick={showArtadoModal} width="16" height="16" fill="currentColor"
                         className="bi bi-arrows-angle-expand" viewBox="0 0 16 16">
                        <path fillRule="evenodd" d="M5.828 10.172a.5.5 0 0 0-.707 0l-4.096 4.096V11.5a.5.5 0 0 0-1 0v3.975a.5.5 0 0 0 .5.5H4.5a.5.5 0 0 0 0-1H1.732l4.096-4.096a.5.5 0 0 0 0-.707m4.344-4.344a.5.5 0 0 0 .707 0l4.096-4.096V4.5a.5.5 0 1 0 1 0V.525a.5.5 0 0 0-.5-.5H11.5a.5.5 0 0 0 0 1h2.768l-4.096 4.096a.5.5 0 0 0 0 .707"/>
                    </svg>
                </div>
            </div>
            <Modal title={languageData.modal.title} footer={null} onCancel={onModalCancel} open={isModalOpen}>
                <div style={{ maxHeight: 350, overflowX: 'auto' }}>
                    <h3 style={headerStyle}>
                        {languageData.modal.title_1} &nbsp; 🤔
                    </h3>
                    <p>
                        {languageData.modal.content_1}
                    </p>
                    <h3 style={headerStyle}>
                        {languageData.modal.title_2} &nbsp; 🎨
                    </h3>
                    <p>
                        {languageData.modal.content_2}
                    </p>
                    <h3 style={headerStyle}>
                        {languageData.modal.title_3} &nbsp; 📚
                    </h3>
                    <p>
                        {languageData.modal.content_3}
                    </p>
                    <h3 style={headerStyle}>
                        {languageData.modal.title_4} &nbsp; 🔒
                    </h3>
                    <p>
                        {languageData.modal.content_4}
                    </p>
                </div>
            </Modal>
        </>
    )
}

export default ArtadoSection;
