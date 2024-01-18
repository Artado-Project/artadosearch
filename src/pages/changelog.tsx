import React from "react";
import './../assets/Index.css';
import {Button} from "antd";

const Changelog: React.FC = () => {
    return (
        <>
            <div className="Artado-container">
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>Changelog</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                    >
                        Home
                    </Button>
                </div>
                <h3 className="bordered-subtitle" id="changelog-title" style={{ fontSize: '30px', lineHeight: '46px' }}>
                    Jan 16, 2024 - Quick Peek, Enhanced Local Business search, Usenet lens, GPT4-vision in Assistant, and Outage Post-Mortem <a style={{ color: '#3c3c3c' }} href={'#'}><i>#</i></a>
                </h3>
                <h3>
                    Announcements
                </h3>
                <ul>
                    <li className={'line-height'}>
                        We added "Quick Peek" widget to our results. With this addition you will find additional relevant results about the query you are searching. This feature can be easily enabled / disabled in the Search Settings.
                    </li>
                    <br />
                    <li className={'line-height'}>
                        We added additional sources for local businesses to our inline maps search results. Inline maps should be more responsive now when searching for specific local businesses. More improvements to come. Related issue: Local business / open hours #2477 @partlycloudy
                    </li>
                    <br />
                    <li className={'line-height'}>
                        Artado Assistant (available as open beta for Ultimate members) now leverages GPT4-vision model to better understand and describe images. You can test this improved functionality by uploading images or providing image URLs for the Artado Assistant to analyse.
                        <br />
                        Edit: A member just emailed saying "the example you have is wrong about 7 of the 10 "Key Points" (only the restaurant name, VAT amount, and amount tendered are correct)." Yes that can be the case with LLMs, we are not trying to present this as grounbreaking, we just integrated a model and the example is as good as the underlying model. This is clearly demonstrating its limitations and it is what it is. We are currently using the best commercially available vision model on the market and it is our desire to emphasize that access to this and other world's cutting edge LLM's are all included in the Assistant with one Artado subscription. No doubt they will get better in the future.
                    </li>
                </ul>
            </div>
        </>
    );
}

export default Changelog;