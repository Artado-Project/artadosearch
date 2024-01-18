import React from "react";
import './../assets/Index.css';
import {Button, Card, Avatar} from "antd";

const Meta = Card.Meta;

const Contributors: React.FC = () => {
    const teamMembers = [
        {
            avatar: "https://avatars.githubusercontent.com/u/90653146?s=64&v=4",
            name: "yasinldev",
            role: "Project Maintainer",
            social: "https://github.com/yasinldev"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/47920304?s=64&v=4",
            name: "ardatdev",
            role: "Project Maintainer",
            social: "https://github.com/ardatdev"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/79412062?s=64&v=4",
            name: "Arnolxu",
            role: "Project Maintainer",
            social: "https://github.com/Arnolxu"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/98576933?v=4",
            name: "Bylue",
            role: "Translator"
        }
    ];

    const communityMembers = [
        {
            avatar: "https://yt3.ggpht.com/qQpFe3FpnkE_e9U-Xnj6AyHjwCqdu51sm3K_OyMlwMrvQqbo4UVnl_84Zrb6d9OnG4CfScCp=s176-c-k-c0x00ffffff-no-rj-mo",
            name: "Yusuf İpek",
            role: "Special Thanks",
            social: "https://www.youtube.com/@yusufipk"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/72984140?v=4",
            name: "lareii",
            role: "Supporter",
            social: "https://github.com/lareii"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/44518454?s=96&v=4",
            name: "abulat189",
            role: "Contributor",
            social: "https://github.com/abulat189"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/143949134?s=96&v=4",
            name: "LinuxUsersLinuxMint",
            role: "Contributor",
            social: "https://github.com/LinuxUsersLinuxMint"
        },
        {
            avatar: "https://avatars.githubusercontent.com/u/136915671?s=96&v=4",
            name: "atakishiyev-yusif",
            role: "Contributor",
            social: "https://github.com/atakishiyev-yusif",
        }
    ];

    return (
        <>
            <div className="Artado-container">
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>Contributors</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                    >
                        Home
                    </Button>
                </div>
                <span style={{lineHeight: '30px'}}>
                    A heartfelt thank you to all the contributors who have played a vital role in making Artado Search the exceptional platform it is today. Your dedication, expertise, and passion have significantly contributed to the success of our project. We deeply appreciate your valuable efforts and commitment.
                </span>
                <br/><br/>
                <h2 className='bordered-subtitle'>Our Team</h2>
                <div className={'card-container'}>
                    {teamMembers.map((member, index) => (
                        <Card key={index} style={{width: 300, marginTop: 16, marginRight: 10, alignItems: 'center'}}>
                            <Meta
                                avatar={<Avatar src={member.avatar} />}
                                title={<a href={member.social}>{member.name}</a>}
                                description={member.role}
                            />
                        </Card>
                    ))}
                </div>
                <br/><br/>
                <h2 className='bordered-subtitle'>Community</h2>
                <div className={'card-container'}>
                    {communityMembers.map((member, index) => (
                        <Card key={index} style={{width: 300, marginTop: 16, marginRight: 10, alignItems: 'center'}}>
                            <Meta
                                avatar={<Avatar src={member.avatar} />}
                                title={<a href={member.social}>{member.name}</a>}
                                description={member.role}
                            />
                        </Card>
                    ))}
                </div>
            </div>
        </>
    )
}

export default Contributors;