import React, { useState } from 'react';
import './../../assets/Index.css';
import {Modal} from 'antd';


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
            <Modal title="Welcome the Artado Search!" footer={null} onCancel={onModalCancel} open={isModalOpen}>
                <div style={{ maxHeight: 350, overflowX: 'auto' }}>
                    <h3 style={headerStyle}>
                        What is Artado Search? &nbsp; 🤔
                    </h3>
                    <p>
                        Artado Search is a versatile and highly customizable search engine, designed to empower users with the ability to tailor their search experience to their unique needs. This project is based on the TypeScript and is proudly open source under the AGPL v3 license. It not only offers its own search results but also integrates results from other search engines, providing a comprehensive search solution.
                    </p>
                    <h3 style={headerStyle}>
                        Customise as you like &nbsp; 🎨
                    </h3>
                    <p>
                        Artado goes beyond traditional search engines by offering extensive customization options. You can create personalized themes and extensions to enhance the user interface and functionality. You can find new themes, apps and games from the store.
                    </p>
                    <h3 style={headerStyle}>
                        More than one source &nbsp; 📚
                    </h3>
                    <p>
                        In a departure from the norm, Artado Search doesn't rely solely on its own search algorithms. Instead, it combines results from other search engines, presenting users with a comprehensive perspective. This unique approach ensures that users have access to a wider range of information, making it a valuable tool for those who seek diverse search results.
                    </p>
                    <h3 style={headerStyle}>
                        Keep your data to yourself &nbsp; 🔒
                    </h3>
                    <p>
                        Artado does not collect any of your personal data. Artado protects your privacy as much as possible.
                    </p>
                </div>
            </Modal>
        </>
    )
}

export default ArtadoSection;
