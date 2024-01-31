import React from "react";
import {Avatar, Button, Card} from "antd";

const about: React.FC = () => {
    const teamMembers = [
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
            avatar: "https://avatars.githubusercontent.com/u/90653146?s=64&v=4",
            name: "yasinldev",
            role: "Project Maintainer",
            social: "https://github.com/yasinldev"
        },
        {
            avatar: "https://cdn-icons-png.flaticon.com/512/25/25231.png",
            name: "Contributors",
            role: "Thanks to all contributors",
            social: "https://github.com/Artado-Project/artadosearch/graphs/contributors"
        },
    ];

    const { Meta } = Card;

    return (
        <>
            <div className={'Artado-container'} style={{lineHeight: '25px'}}>
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>About Us</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                    >
                        Home
                    </Button>
                </div>
                <br/>
                Welcome (again) to Artado Search. We are a group of people who believe in the freedom of information and
                the internet. We believe that the internet should be accessible to everyone, without restrictions from
                any power or authority. Accessing the wealth of information on the internet is a fundamental right. We
                advocate for an internet where everyone can engage in free information exchange, where personal data is
                respected, and where ideas can be expressed without censorship.
                <br/><br/>
                <h2 className="bordered-subtitle">Our Mission</h2>
                Our mission is to create a search engine that is liberating, open, and available to all. Our vision is a
                search experience devoid of censorship, immune to intrusive data collection, and impervious to external
                control. We are committed to developing a search engine that thrives on transparency, embracing
                open-source principles.
                <br/><br/>
                🚀 We aspire to build a search engine that transcends borders and device limitations, ensuring
                accessibility for everyone. No matter where you are or what device you use, our search engine is
                designed to be your reliable companion.
                <br/><br/>
                ⚡️ Swift, dependable, and fortified with security, our search engine aims to redefine the user
                experience. Forget about ads and tracking – we're dedicated to delivering a clutter-free and private
                search environment.
                <br/><br/>
                🌐 Our goal is to empower users with information freedom, free from any centralized authority. Let's
                embark on this journey together to create a search engine that reflects the true spirit of openness and
                inclusivity!
                <br/><br/>
                <h2 className="bordered-subtitle">Artado Team</h2>
                Artado is a project that is being developed by a group of people who believe in the freedom of
                information and the internet. Here are the people who are currently working on the project:
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
                <h2 className="bordered-subtitle">Contributing</h2>
                We are open to contributions from anyone who believes in our mission and wants to help us achieve it. If you want to contribute to the project, you can check out our <a href={'https://github.com/Artado-Project/artadosearch/blob/main/CONTRIBUTING.md'}>contributing guidelines</a>.
                <br /><br />
            </div>
        </>
    );
}

export default about;