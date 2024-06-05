import React from "react";
import {Button} from "antd";

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../../language/${language}/donation-page.json`);

const donation: React.FC = () => {
    return (
        <>
            <div className={'Artado-container'} id={'textContainer'} style={{lineHeight: '25px'}}>
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>{languageData.donation}</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                        style={{ textDecoration: 'none' }}
                    >
                        { languageData.home }
                    </Button>
                </div>
                <br/>
                {languageData.donation_text_1}
                <br/><br/>
                <h2 className="bordered-subtitle">{languageData.subtitle_1}</h2>
                <br/>
                <b style={{color: '#4c4c4c'}}>{languageData.list_title_1}</b> <br/><br/> {languageData.list_desc_1}
                <br/><br/><br/>
                <b style={{color: '#4c4c4c'}}>{languageData.list_title_2}</b> <br/><br/> {languageData.list_desc_2}
                <br/><br/><br/>
                <b style={{color: '#4c4c4c'}}>{languageData.list_title_3}</b> <br/><br/> {languageData.list_desc_3}
                <br/><br/><br/>
                {languageData.donation_text_2} <br/><br/>
                <h2 className="bordered-subtitle">{languageData.subtitle_2}</h2> <br/>
                <b style={{color: '#4c4c4c'}}>{languageData.list_card_1}</b> {languageData.list_card_desc_1}
                <br/><br/>
                {languageData.donation_text_3} <br /> {languageData.donation_text_4} <br/><br/>
            </div>
        </>
    );
}

export default donation;