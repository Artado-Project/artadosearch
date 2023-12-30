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
                         className="bi bi-hand-index" viewBox="0 0 16 16">
                        <path
                            d="M6.75 1a.75.75 0 0 1 .75.75V8a.5.5 0 0 0 1 0V5.467l.086-.004c.317-.012.637-.008.816.027.134.027.294.096.448.182.077.042.15.147.15.314V8a.5.5 0 1 0 1 0V6.435a4.9 4.9 0 0 1 .106-.01c.316-.024.584-.01.708.04.118.046.3.207.486.43.081.096.15.19.2.259V8.5a.5.5 0 0 0 1 0v-1h.342a1 1 0 0 1 .995 1.1l-.271 2.715a2.5 2.5 0 0 1-.317.991l-1.395 2.442a.5.5 0 0 1-.434.252H6.035a.5.5 0 0 1-.416-.223l-1.433-2.15a1.5 1.5 0 0 1-.243-.666l-.345-3.105a.5.5 0 0 1 .399-.546L5 8.11V9a.5.5 0 0 0 1 0V1.75A.75.75 0 0 1 6.75 1M8.5 4.466V1.75a1.75 1.75 0 1 0-3.5 0v5.34l-1.2.24a1.5 1.5 0 0 0-1.196 1.636l.345 3.106a2.5 2.5 0 0 0 .405 1.11l1.433 2.15A1.5 1.5 0 0 0 6.035 16h6.385a1.5 1.5 0 0 0 1.302-.756l1.395-2.441a3.5 3.5 0 0 0 .444-1.389l.271-2.715a2 2 0 0 0-1.99-2.199h-.581a5.114 5.114 0 0 0-.195-.248c-.191-.229-.51-.568-.88-.716-.364-.146-.846-.132-1.158-.108l-.132.012a1.26 1.26 0 0 0-.56-.642 2.632 2.632 0 0 0-.738-.288c-.31-.062-.739-.058-1.05-.046zm2.094 2.025"/>
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
