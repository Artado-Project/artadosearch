import React from "react";
import {Avatar, Button, Card} from "antd";

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../language/${language}/about-page.json`);

const about: React.FC = () => {
    const teamMembers = [
        {
            avatar: "https://avatars.githubusercontent.com/u/47920304?s=64&v=4",
            name: "Arda Tahtacı",
            role: languageData.role,
            social: "https://github.com/ardatdev"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/79412062?s=64&v=4",
            name: "Çınar Yılmaz",
            role: languageData.role,
            social: "https://github.com/Arnolxu"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/90653146?s=64&v=4",
            name: "M. Yasin Özkaya",
            role: languageData.role,
            social: "https://github.com/yasinldev"
        },
        {
            avatar: "https://cdn-icons-png.flaticon.com/512/25/25231.png",
            name: languageData.contributors,
            role: <small>{languageData.contributors_content}</small>,
            social: "https://github.com/Artado-Project/artadosearch/graphs/contributors"
        },
    ];

    const { Meta } = Card;

    return (
        <>
            <div className={'Artado-container'} id={'textContainer'} style={{lineHeight: '25px'}}>
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>{ languageData.about_us }</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                    >
                        {languageData.home}
                    </Button>
                </div>
                <br/>
                {languageData.about_content}
                <br/><br/>
                <h2 className="bordered-subtitle">{languageData.our_mission}</h2>
                   {languageData.mission_content}
                <br/><br/>
                🚀 {languageData.mission_content_1}
                <br/><br/>
                ⚡️ {languageData.mission_content_2}
                <br/><br/>
                🌐 {languageData.mission_content_3}
                <br/><br/>
                <h2 className="bordered-subtitle">{languageData.team}</h2>
                {languageData.team_content}
                <br /><br />
                <div className={'card-container'}>
                    {teamMembers.map((member, index) => (
                        <Card key={index} style={{width: 300, marginTop: 16, marginRight: 10, alignItems: 'center'}}>
                            <Meta
                                avatar={<Avatar src={member.avatar}/>}
                                title={<a href={member.social}>{member.name}</a>}
                                description={member.role}
                            />
                        </Card>
                    ))}
                </div>
                <br /><br />
                <h2 className="bordered-subtitle">{languageData.contributing}</h2>
                {languageData.contributing_content} <a href={'https://github.com/Artado-Project/artadosearch/blob/main/CONTRIBUTING.md'}>contributing guidelines</a>.
                <br /><br />
            </div>
        </>
    );
}

export default about;