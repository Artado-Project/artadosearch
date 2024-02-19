import React, { useEffect, useState } from 'react';
import {Tag, Modal, Segmented, Alert, Avatar} from 'antd';
import { SegmentedValue } from 'antd/es/segmented';

const SearchResult: React.FC = () => {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [selectedSegmented, setSelectedSegmented] = useState<SegmentedValue>('summary');

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

    const handleSegmentedChange = (value: SegmentedValue) => {
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

    //Backend Part / Get the results
    const searchParams = new URLSearchParams(window.location.search);
    const q = searchParams.get('q');

    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
        try {
            console.log("fetching data. query: " + q);
            const response = await fetch('/api?q=' + q);
            const result = await response.json();
            setData(result);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
        };

        fetchData();
    }, []);
    //Backend Part / Get the results

    return (
        <>
            <Modal
                title={
                    <>
                        <span>Turkey - Wikipedia</span> <br />
                        <div style={{display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                            <small style={{ color: '#7c7c7c' }}>en.wikipedia.org  › wiki › Turkey</small>
                            <Tag color={'green'}>Verified</Tag>
                        </div>
                    </>
                }
                open={isModalVisible}
                footer={
                    <>
                        <br />
                        <div style={{ display: "flex", fontSize: '12px', color: '#6c6c6c', borderTop: '1px solid #d0d0d0' }}>
                            <span style={{ paddingTop: '15px' }}>
                                If you think there is an error &nbsp;
                                <a href={'/'}>report error</a>
                            </span>
                        </div>
                    </>
                }
                onCancel={closeModal}
                >
                <Segmented options={segmentedOptions} onChange={handleSegmentedChange} block />
                { checkSegmentedValue() }
            </Modal>
            {data.map((item: any) => (
                <div className={'artado-result-card'} style={{paddingLeft: 0}}>
                    <div className={'result-header'}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                            className="bi bi-question-circle" viewBox="0 0 16 16">
                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                            <path
                                d="M5.255 5.786a.237.237 0 0 0 .241.247h.825c.138 0 .248-.113.266-.25.09-.656.54-1.134 1.342-1.134.686 0 1.314.343 1.314 1.168 0 .635-.374.927-.965 1.371-.673.489-1.206 1.06-1.168 1.987l.003.217a.25.25 0 0 0 .25.246h.811a.25.25 0 0 0 .25-.25v-.105c0-.718.273-.927 1.01-1.486.609-.463 1.244-.977 1.244-2.056 0-1.511-1.276-2.241-2.673-2.241-1.267 0-2.655.59-2.75 2.286m1.557 5.763c0 .533.425.927 1.01.927.609 0 1.028-.394 1.028-.927 0-.552-.42-.94-1.029-.94-.584 0-1.009.388-1.009.94"/>
                        </svg>
                    </div>
                    <div className={'result-title-container'}>
                        <Avatar
                            style={{border: '1px solid #d0d0d0'}}
                            src={<img
                                src={item.favicon}/>}
                            size={25}
                        /> &nbsp;
                        <a href={item.url} style={{textDecoration: 'none'}} className={'result-title'}>
                            {item.title}
                        </a>
                    </div>
                    <div className={'result-url'} style={{marginTop: '5px'}}>{item.url}</div>
                    <br/>
                    <span className={'result-desc'}>
                       {item.decs}
                    </span>
                </div>
            ))}
            <div className={'artado-result-card'} style={{ paddingLeft: 0 }}>
                <div className={'result-header'} onClick={showModal}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                         className="bi bi-question-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                        <path
                            d="M5.255 5.786a.237.237 0 0 0 .241.247h.825c.138 0 .248-.113.266-.25.09-.656.54-1.134 1.342-1.134.686 0 1.314.343 1.314 1.168 0 .635-.374.927-.965 1.371-.673.489-1.206 1.06-1.168 1.987l.003.217a.25.25 0 0 0 .25.246h.811a.25.25 0 0 0 .25-.25v-.105c0-.718.273-.927 1.01-1.486.609-.463 1.244-.977 1.244-2.056 0-1.511-1.276-2.241-2.673-2.241-1.267 0-2.655.59-2.75 2.286m1.557 5.763c0 .533.425.927 1.01.927.609 0 1.028-.394 1.028-.927 0-.552-.42-.94-1.029-.94-.584 0-1.009.388-1.009.94"/>
                    </svg>
                </div>
                <div className={'result-title-container'}>
                    <Avatar
                        style={{ border: '1px solid #d0d0d0' }}
                        src={<img src={'https://play-lh.googleusercontent.com/htBUaqvBQR9UQ3b1-ouSHFhDGttQkH-eWetEErspYXVa8hOsfmOmj5ZanGg9GF7XAGc'} /> }
                        size={25}
                    /> &nbsp;
                    <a href={'#'} style={{ textDecoration: 'none' }} className={'result-title'}>
                        Turkey - Wikipedia
                    </a>
                </div>
                <div className={'result-url'} style={{ marginTop: '3px'}}>en.wikipedia.org  › wiki › Turkey</div> <br />
                <span className={'result-desc'}>
                    <Tag color="default" style={{ color: '#7c7c7c' }}>Encyclopedia</Tag> Lorem ipsum dolor sit amet, consectetur adipisicing elit. A consequatur consequuntur culpa deserunt doloremque eligendi illo illum ipsa laboriosam laudantium nesciunt nostrum, officiis quibusdam quos sequi sunt, totam vitae voluptate.
                </span>
                <div className={'result-subtitle'}>
                    <a href={'#'} style={{ textDecoration: 'none' }} className={'subtitle'}>Turkey (bird) - Wikipedia</a><br />
                    <span className={'desc'}>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aperiam dolorem laudantium modi, praesentium sed totam voluptatibus! Cupiditate inventore tempora tempore.
                    </span><br /><br /><br />
                    <a href={'#'} style={{ textDecoration: 'none' }} className={'subtitle'}>History of Turkey - Wikipedia</a><br />
                    <span className={'desc'}>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                    </span><br /><br /><br />
                    <a href={'#'} style={{ textDecoration: 'none' }} className={'subtitle'}>Istanbul - Wikipedia</a><br />
                    <span className={'desc'}>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                    </span>
                </div>
            </div>
        </>
    );
}

export default SearchResult;
