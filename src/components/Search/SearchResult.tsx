import React, { useState } from 'react';
import {Tag, Modal, Segmented, Alert, Button} from 'antd';


const SearchResult: React.FC = () => {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [selectedSegmented, setSelectedSegmented] = useState<string>('summary');

    const showModal = () => {
        setIsModalVisible(true);
    }

    const closeModal = () => {
        setIsModalVisible(false);
    }

    const segmentedOptions = [
        { label: 'Summary', value: 'summary' },
        { label: 'Safety', value: 'safety' },
    ];

    const handleSegmentedChange = (value: string) => {
        setSelectedSegmented(value);
    }

    const checkSegmentedValue = () => {
        if (selectedSegmented === 'summary') {
            return (
                <span style={{ color: '#5c5c5c', marginTop: '10px' }}>
                    <div style={{ marginTop: 10 }}></div>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Autem doloremque eaque enim error in laborum magni nesciunt repellendus. Exercitationem iure laudantium obcaecati officiis porro possimus quae quidem quis, rem repellat! Alias aliquid consectetur debitis delectus dolores eaque enim eos eveniet ex explicabo fuga illo in itaque iusto, magnam magni molestias, nemo nulla numquam pariatur perspiciatis porro rem repudiandae sapiente sequi sunt tempora ullam unde veniam veritatis. Ab ad, commodi consequatur facilis fugiat fugit, maiores nihil possimus quisquam quo tempora veniam!
                </span>
            );
        }
        else if (selectedSegmented === 'safety') {
            return (
                <>
                    <div style={{ marginTop: 10 }}></div>
                    <Alert
                        message="This website is safe"
                        description="This website uses the HTTPS protocol. This means that all communications that users carry out on the site are encrypted and transmitted securely. Encryption of data prevents third parties from intercepting users' personal information, passwords and other sensitive data."
                        type="success"
                        showIcon
                    />
                </>
            );
        }
        else {
            console.error('Error: handleSegmentedChange()');
        }
    }

    return (
        <>
            <Modal
                title={
                    <>
                        <span>Turkey - Wikipedia</span> <br />
                        <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                            <small style={{ color: '#7c7c7c' }}>en.wikipedia.org  › wiki › Turkey</small>
                            <Tag color={'green'}>Encyclopedia ~ Verified</Tag>
                        </div>
                    </>
                }
                open={isModalVisible}
                footer={
                    <>
                        <br />
                        <div style={{ display: "flex", justifyContent: 'center' }}>
                            If you think there is an error &nbsp; &nbsp;
                            <Button type={'dashed'}>
                                Send Error
                            </Button>
                        </div>
                    </>
                }
                onCancel={closeModal}
                >
                <Segmented options={segmentedOptions} onChange={handleSegmentedChange} block />
                { checkSegmentedValue() }
            </Modal>
            <div className={'artado-result-card'}>
                <div className={'result-header'} onClick={showModal}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                         className="bi bi-question-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                        <path
                            d="M5.255 5.786a.237.237 0 0 0 .241.247h.825c.138 0 .248-.113.266-.25.09-.656.54-1.134 1.342-1.134.686 0 1.314.343 1.314 1.168 0 .635-.374.927-.965 1.371-.673.489-1.206 1.06-1.168 1.987l.003.217a.25.25 0 0 0 .25.246h.811a.25.25 0 0 0 .25-.25v-.105c0-.718.273-.927 1.01-1.486.609-.463 1.244-.977 1.244-2.056 0-1.511-1.276-2.241-2.673-2.241-1.267 0-2.655.59-2.75 2.286m1.557 5.763c0 .533.425.927 1.01.927.609 0 1.028-.394 1.028-.927 0-.552-.42-.94-1.029-.94-.584 0-1.009.388-1.009.94"/>
                    </svg>
                </div>
                <h3 className={'result-title'}>Turkey - Wikipedia</h3>
                <div className={'result-url'}>en.wikipedia.org  › wiki › Turkey</div> <br />
                <span className={'result-desc'}>
                    <Tag color={'#a1a1a1'}>Encyclopedia</Tag> Lorem ipsum dolor sit amet, consectetur adipisicing elit. A consequatur consequuntur culpa deserunt doloremque eligendi illo illum ipsa laboriosam laudantium nesciunt nostrum, officiis quibusdam quos sequi sunt, totam vitae voluptate.
                </span>
                <div className={'result-subtitle'}>
                    <h6 className={'subtitle'}>Turkey (bird) - Wikipedia</h6>
                    <span className={'desc'}>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aperiam dolorem laudantium modi, praesentium sed totam voluptatibus! Cupiditate inventore tempora tempore.
                </span>
                    <h6 className={'subtitle'}>History of Turkey - Wikipedia</h6>
                    <span className={'desc'}>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                </span>
                    <h6 className={'subtitle'}>Istanbul - Wikipedia</h6>
                    <span className={'desc'}>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                </span>
                </div>
            </div>
            <div className={'artado-result-card'}>
                <div className={'result-header'}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                         className="bi bi-question-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                        <path
                            d="M5.255 5.786a.237.237 0 0 0 .241.247h.825c.138 0 .248-.113.266-.25.09-.656.54-1.134 1.342-1.134.686 0 1.314.343 1.314 1.168 0 .635-.374.927-.965 1.371-.673.489-1.206 1.06-1.168 1.987l.003.217a.25.25 0 0 0 .25.246h.811a.25.25 0 0 0 .25-.25v-.105c0-.718.273-.927 1.01-1.486.609-.463 1.244-.977 1.244-2.056 0-1.511-1.276-2.241-2.673-2.241-1.267 0-2.655.59-2.75 2.286m1.557 5.763c0 .533.425.927 1.01.927.609 0 1.028-.394 1.028-.927 0-.552-.42-.94-1.029-.94-.584 0-1.009.388-1.009.94"/>
                    </svg>
                </div>
                <h3 className={'result-title'}>Turkey Consciousness</h3>
                <div className={'result-url'}>gurneyjourney.blogspot.com  › 2023 › 12 › turkey-consciousness.html</div><br />
                <span className={'result-desc'}>
                    But their ability to understand the world goes much further than just communication. He raises a bunch of wild turkeys, allowing them to imprint on him so that he's their parent. The exercise—which must have taken total commitment for the better part of a year—gives us a rare insight into the umwelt of some very impressive wild animals.
                </span>
            </div>
        </>
    );
}

export default SearchResult;
