import React, { useEffect, useState } from 'react';
import {Tag, Modal, Segmented, Alert, Avatar} from 'antd';
import { SegmentedValue } from 'antd/es/segmented';
import TextArea from "antd/es/input/TextArea";

const SearchResult: React.FC = () => {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [isErrorModalVisible, setIsErrorModalVisible] = useState(false);
    const [selectedSegmented, setSelectedSegmented] = useState<SegmentedValue>('summary');

    const showModal = () => {
        setIsModalVisible(true);
    }

    const showErrorModal = () => {
        setIsErrorModalVisible(true);
    }

    const closeModal = () => {
        setIsModalVisible(false);
    }

    const closeErrorModal = () => {
        setIsErrorModalVisible(false);
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
                <>
                    <div style={{ marginTop: 10 }}></div>
                    <span className={'modal-summary'}>
                        <b className={'summary-title'}>Summary</b>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. A animi architecto aspernatur assumenda autem consectetur consequatur consequuntur dolores dolorum eligendi enim error esse est et exercitationem illum incidunt inventore ipsam ipsum magni maxime minus modi nemo perspiciatis quae quam quas quibusdam ratione repellendus repudiandae, vel vero voluptate voluptatem? Magni, reprehenderit!
                        <b className={'summary-title'}>Subtitles</b>
                        <span className={'summary-subtitle'}>#Turkey</span>
                        <span className={'summary-subtitle'}>#Sciene In Turkey</span>
                        <span className={'summary-subtitle'}>#Turkey's Education Model</span>
                        <span className={'summary-subtitle'}>#University Exam In Turkey</span>
                    </span>
                </>
            );
        } else if (selectedSegmented === 'safety') {
            return (
                <>
                    <div style={{marginTop: 10}}></div>
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
                        <span>Turkey - Wikipedia</span> <br/>
                        <div style={{display: 'flex', alignItems: 'center', justifyContent: 'space-between'}}>
                            <small style={{color: '#7c7c7c'}}>en.wikipedia.org › wiki › Turkey</small>
                            <Tag color={'green'}>Verified</Tag>
                        </div>
                    </>
                }
                open={isModalVisible}
                footer={
                    <>
                        <br/>
                        <div className={'modal-footer'}>
                            <span style={{paddingTop: '15px'}}>
                                If you think there is an error &nbsp;
                                <a onClick={showErrorModal}>report error</a>
                            </span>
                        </div>
                    </>
                }
                onCancel={closeModal}
            >
                <Segmented options={segmentedOptions} onChange={handleSegmentedChange} block/>
                {checkSegmentedValue()}
            </Modal>
            <Modal
                title={'Send Error'}
                open={isErrorModalVisible}
                onCancel={closeErrorModal}
            >
                <p>Hmm... We understand you encountered a bug that scared our developers. Can you tell us about the
                    problem?</p>
                <TextArea
                    showCount
                    maxLength={500}
                    placeholder="What is the problem?"
                    style={{height: 120, resize: 'none'}}
                />
                <br/><br/>
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
            <div className={'artado-result-card'} style={{paddingLeft: 0}}>
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
                        style={{border: '1px solid #d0d0d0'}}
                        src={<img
                            src={'https://play-lh.googleusercontent.com/htBUaqvBQR9UQ3b1-ouSHFhDGttQkH-eWetEErspYXVa8hOsfmOmj5ZanGg9GF7XAGc'}/>}
                        size={25}
                    /> &nbsp;
                    <a href={'#'} style={{textDecoration: 'none'}} className={'result-title'}>
                        Turkey - Wikipedia
                    </a>
                </div>
                <div className={'result-url'} style={{marginTop: '3px'}}>en.wikipedia.org › wiki › Turkey</div>
                <br/>
                <span className={'result-desc'}>
                    <Tag color="default" style={{color: '#7c7c7c'}}>Encyclopedia</Tag> Lorem ipsum dolor sit amet, consectetur adipisicing elit. A consequatur consequuntur culpa deserunt doloremque eligendi illo illum ipsa laboriosam laudantium nesciunt nostrum, officiis quibusdam quos sequi sunt, totam vitae voluptate.
                </span>
                <div className={'result-subtitle'}>
                    <a href={'#'} style={{textDecoration: 'none'}} className={'subtitle'}>Turkey (bird) -
                        Wikipedia</a><br/>
                    <span className={'desc'}>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aperiam dolorem laudantium modi, praesentium sed totam voluptatibus! Cupiditate inventore tempora tempore.
                    </span><br/><br/><br/>
                    <a href={'#'} style={{textDecoration: 'none'}} className={'subtitle'}>History of Turkey -
                        Wikipedia</a><br/>
                    <span className={'desc'}>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                    </span><br/><br/><br/>
                    <a href={'#'} style={{textDecoration: 'none'}} className={'subtitle'}>Istanbul - Wikipedia</a><br/>
                    <span className={'desc'}>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                    </span>
                </div>
            </div>
            <div className={'artado-result-card'} style={{paddingLeft: 0}}>
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
                        style={{border: '1px solid #d0d0d0'}}
                        src={<img
                            src={'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABwAAAAcCAMAAABF0y+mAAAAjVBMVEX////++Pj0ubvukJPukpbvmZzxpaj63+D//Pz98PDtgIX40tT+9fX85+j3x8nvnaDrcnf3y8340dLpaW72wsTyrrDfJy7siYziNT7kUVb0trn52tvnYWbreH3lWl/zr7LjRkzcAA3bAADdGSDcDBXpbnP86uvYAADdISbdERniPEPcNDTjQ0nmY2brfYE/o5LbAAABtklEQVR4AY3PB6LiIBQF0AsRCFIiCBZQY0j7ff/LG6b3mX/onYf3IbTZMF6LaPELybZUSS1gbLdz+InfWxNaxAOBsPp4JPguNhr0JCEFwM8EYY9vEhMGMDSE4JJrQbK6EHyWr+2NSUotT8r2qs/i5O0Wn10NTA49FSHy3qcQrGjBHCpQ3kIH27v7UEoZj75TCkTvWlRHcXGKcjqUYRimocyeJnKjXABYjpr7EP1hWB9uD8M0lSZaFZVjACwHauRNWZuF7+rqMFpGAbkBEC3ge3soV3JfyziWxxK1bQGGWvy5U949rtSu0zDlsBbWuPzkOQDuUnZ5Gdco1vqjzXYojHsZDQcQKaB8uJcnk55fDqUeT9wBbQMgd9AmhL6U55T29bfDU7aUtGYDQF/NCw1xuZS1qmvFcWdeou1RsZyksI14LUNVHiintqVmK1GJIwAXjiqexnG8+uCoBATDJywhWmc7j8XAsEBzJ9q9xCd6XrYcmfZaUKJS0MslNxRfyBuplTPW5ZCzB9B1+EbuEvoXicyB7kaWK8cPNHvLBqB3QIs0e/wss5kFl0O/vQb8jqie8S4sLd7lA8U2JWSGUY+cAAAAAElFTkSuQmCC'}/>}
                        size={25}
                    /> &nbsp;
                    <a href={'#'} style={{textDecoration: 'none'}} className={'result-title'}>
                        Republic of Türkiye Ministry of Foreign Affairs
                    </a>
                </div>
                <div className={'result-url'} style={{marginTop: '3px'}}>mfa.gov.tr</div>
                <br/>
                <span className={'result-desc'}>
                    <Tag color="default" style={{color: '#7c7c7c'}}>Government</Tag> Lorem ipsum dolor sit amet, consectetur adipisicing elit. A aspernatur corporis harum placeat, qui quod reiciendis reprehenderit? Autem cupiditate est ipsa maxime nobis omnis? Aperiam asperiores assumenda atque blanditiis cupiditate delectus deserunt dolore dolorem earum eius facilis fuga ipsa nobis nulla odit pariatur sapiente, sed, sunt ut veritatis voluptas voluptatem!
                </span>
            </div>
            <div className={'artado-result-card'} style={{paddingLeft: 0}}>
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
                        style={{border: '1px solid #d0d0d0'}}
                        src={<img
                            src={'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAPFBMVEVHcEwKPmwLQGwLQGwLQGsAOmkZTHVOb48pVHs5YISCma9yjKRhfpqQpbiwwM0AL2LN19/l6++escH+/v8tWRs0AAAABXRSTlMAILD/6JrywKcAAAGHSURBVHgBdJPhjgMhCIS3tYCICsj7v+vRbi9mez1+ycznxEA8jtu9/Fv3W/qPiwR4aR+343IfkQjrJePYAVCZmkhvjLAjju0TNW6VhQfxjtgA9EYI1AFpCHwBSpU6BkmftfM3AKirORZzIPoG6Jh1WFtz8lr6BwAeSC5szt2ZG8NnAvpAa7JmFy/i9Q8AfVjtQRlTTTq81QTOMODVbYETexXvk94qHNA6vJrmQ0aVxa0NXy8bmiRAMRsUwDGQA801OrRVAWDMyISiEd4LJugc7I5BFgQVe0RovgFnHmwqsNmSMWlO76rTUp74BDye1RRQuOhr5KrjJXpJ4H0OAwAdNpcCVDu1BgkUfHcTCkiKp+9P5RwU6PBsPEyBIgTUwmYiQ08gkZW4eIgmQCrhksLSPWqYkY55oXBCt/7MT38D0DOWvT8TxNnDCD7WrdUmSwLS6zTU6zbfKYySQOFzOxvYCLSIodu+Alk6fh+3gccFmBF2AR7Xr6cW4Rfg/vF5QRV+hpp5CWZ/AE8PHpOm8Wf2AAAAAElFTkSuQmCC'} />}
                        size={25}
                    /> &nbsp;
                    <a href={'#'} style={{textDecoration: 'none'}} className={'result-title'}>
                        Turkey | Location, Geography, People, Economy, Culture, & History
                    </a>
                </div>
                <div className={'result-url'} style={{marginTop: '3px'}}>britannica.com › place</div>
                <br/>
                <span className={'result-desc'}>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. A, ad amet asperiores commodi consequuntur esse eum, inventore libero, magnam modi reiciendis sed similique veniam! Consectetur consequatur, facere illum itaque libero obcaecati odit quia quidem sit tempora. Animi dolorem eum, fuga fugit maxime molestiae quos ratione reprehenderit repudiandae voluptatibus! Illo, obcaecati.
                </span>
            </div>
        </>
    );
}

export default SearchResult;
