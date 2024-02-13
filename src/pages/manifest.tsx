import React from "react";
import './../assets/Index.css';
import { Button } from "antd";

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../language/${language}/manifest-page.json`);

function Manifest() {
    return (
        <>
            <div className={'Artado-container'} style={{lineHeight: '25px'}}>
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>{ languageData.manifest }</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                    >
                        { languageData.home }
                    </Button>
                </div>
                <br/>
                { languageData.manifest_content }
                <br/> <br/>
                { languageData.manifest_content_2 }
                <br/><br/>
                <h2 className="bordered-subtitle">{ languageData.why_free_internet }</h2>
                { languageData.why_free_internet_content }
                <br/><br/>
                { languageData.why_free_internet_content_2 }
                <br/><br/>
                <h2 className='bordered-subtitle'>{languageData.embracing_anti_censorship}</h2>
                {languageData.embracing_anti_censorship_content}
                <br/><br/>
                {languageData.embracing_anti_censorship_content_2}
                <br/><br/>
                <h2 className="bordered-subtitle">{languageData.anonymity}</h2>
                {languageData.anonymity_content}
                <br/><br/>
                {languageData.anonymity_content_2}
                <br/><br/>
                {languageData.anonymity_content_3}
                <br/><br/>
                <h2 className="bordered-subtitle">{languageData.right_to_privacy}</h2>
                {languageData.right_to_privacy_content}
                <br/><br/>
                <h2 className="bordered-subtitle">{languageData.make_the_internet_a_better_place}</h2>
                {languageData.make_the_internet_a_better_place_content}
                <br/><br/>
            </div>
        </>
    )
}

export default Manifest;