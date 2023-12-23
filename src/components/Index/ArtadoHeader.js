import React, {useState, useEffect} from 'react';
import './../../assets/Index.css';
import {Button, Divider, Drawer, Select, Switch,} from "antd";

const LinkStyle = {
    color: 'black',
    fontSize: '12px',
    marginRight: '10px',
    textDecoration: 'underline',
}

const Options = {
    'Settings': {
        title: 'Settings',
        link: '#Settings' // TODO: Add Link
    },

    'Help': {
        title: 'Help',
        link: '#Help', // TODO: Add Link
    },

    'Feedback': {
        title: 'Feedback',
        link: '#Feedback' // TODO: Add Link
    },
}

const MutedText = {
    color: "gray",
    fontSize: "12px",
    fontFamily: "Open Sans",
    fontWeight: "bold",
    marginBottom: "5px"
}

const DividerLinks = {
    'Workshop': {
        title: "Workshop",
        link: "#WorkShop" // TODO: Add Link
    },

    'Forum': {
        title: "Forum",
        link: "#Forum" // TODO: Add Link
    },

    'Manifesto': {
        title: "Manifesto",
        link: "#Manifesto" // TODO: Add Link
    },

    'Privacy Policy': {
        title: "Privacy Policy",
        link: "#PrivacyPolicy" // TODO: Add Link
    },

    'Terms of Service': {
        title: "Terms of Service",
        link: "#TermsOfService" // TODO: Add Link
    },

    'Discord': {
        title: "Discord",
        link: "#Discord" // TODO: Add Link
    },
}

const ArtadoHeader: React.FC = () => {
    const [open, setOpen] = useState(false);
    const [isMobile, setIsMobile] = useState(false);
    const showSidebar = () => {
        setOpen(true);
    }
    const closeSidebar = () => {
        setOpen(false);
    }

    const responsiveDesign = () => {
        const mq = window.matchMedia('(max-width: 600px)');
        setIsMobile(mq.matches);
    }

    useEffect(() => {
        responsiveDesign();
        window.addEventListener('resize', responsiveDesign);

        return () => {
            window.removeEventListener('resize', responsiveDesign);
        }
    }, []);

    return (
        <div
            style={{
                display: "flex",
                justifyContent: "end",
                alignItems: "center"
        }}
        >
            {Object.keys(Options).map((key, ) => (
                <a
                    href={Options[key].link}
                    style={
                    isMobile
                        ? {display: 'none'}
                        : LinkStyle}
                    className="font__open-sans"
                >
                    {Options[key].title}
                </a>
            ))}

            <Button
                onClick={showSidebar}
                style={{
                    paddingTop: "6px",
                    marginLeft: "20px"
                }}
            >
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                     className="bi bi-list" viewBox="0 0 16 16">
                    <path fillRule="evenodd"
                          d="M2.5 12a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5m0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5m0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5"/>
                </svg>
            </Button>

            <Drawer
                title="Artado Settings"
                placement={"right"}
                titleStyle={{textAlign: "center"}}
                closable={true}
                onClose={closeSidebar}
                open={open}
                width={300}
                >
                <Select
                    defaultValue="Select a Theme"
                    style={{ width: "100%", height: "35px", marginBottom: "20px" }}
                    options={[
                        { value: 'night', label: 'Night' },
                        { value: 'light', label: 'Light' },
                        { value: 'auto', label: 'Auto' },
                        { value: 'disabled', label: 'Select a Theme', disabled: true },
                    ]}
                />
                <Select
                    defaultValue="Select a Language"
                    style={{ width: "100%", height: "35px", marginBottom: "20px"}}
                    options={[
                        { value: 'eng', label: 'English' },
                        { value: 'tr', label: 'Turkish' },
                        { value: 'jp', label: 'Japanese' },
                        { value: 'disabled', label: 'Select a Language', disabled: true },
                    ]}
                />

                <Divider
                    plain
                    orientation={"center"}
                    style={{
                        marginBottom: "20px"
                    }}
                >
                    Safe Search
                </Divider>

                <Switch
                    checkedChildren="On"
                    unCheckedChildren="Off"
                    style={{
                        marginBottom: "10px"
                    }}
                />


                <div
                    style={MutedText}
                >
                    Omits sensitive material from general search results.
                </div>

                <Divider
                    plain
                    orientation={"center"}
                    style={{
                        marginBottom: "20px"
                    }}
                >
                    <svg style={{ paddingTop: "9px" }} xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                         className="bi bi-gear" viewBox="0 0 16 16">
                        <path
                            d="M8 4.754a3.246 3.246 0 1 0 0 6.492 3.246 3.246 0 0 0 0-6.492zM5.754 8a2.246 2.246 0 1 1 4.492 0 2.246 2.246 0 0 1-4.492 0z"/>
                        <path
                            d="M9.796 1.343c-.527-1.79-3.065-1.79-3.592 0l-.094.319a.873.873 0 0 1-1.255.52l-.292-.16c-1.64-.892-3.433.902-2.54 2.541l.159.292a.873.873 0 0 1-.52 1.255l-.319.094c-1.79.527-1.79 3.065 0 3.592l.319.094a.873.873 0 0 1 .52 1.255l-.16.292c-.892 1.64.901 3.434 2.541 2.54l.292-.159a.873.873 0 0 1 1.255.52l.094.319c.527 1.79 3.065 1.79 3.592 0l.094-.319a.873.873 0 0 1 1.255-.52l.292.16c1.64.893 3.434-.902 2.54-2.541l-.159-.292a.873.873 0 0 1 .52-1.255l.319-.094c1.79-.527 1.79-3.065 0-3.592l-.319-.094a.873.873 0 0 1-.52-1.255l.16-.292c.893-1.64-.902-3.433-2.541-2.54l-.292.159a.873.873 0 0 1-1.255-.52l-.094-.319zm-2.633.283c.246-.835 1.428-.835 1.674 0l.094.319a1.873 1.873 0 0 0 2.693 1.115l.291-.16c.764-.415 1.6.42 1.184 1.185l-.159.292a1.873 1.873 0 0 0 1.116 2.692l.318.094c.835.246.835 1.428 0 1.674l-.319.094a1.873 1.873 0 0 0-1.115 2.693l.16.291c.415.764-.42 1.6-1.185 1.184l-.291-.159a1.873 1.873 0 0 0-2.693 1.116l-.094.318c-.246.835-1.428.835-1.674 0l-.094-.319a1.873 1.873 0 0 0-2.692-1.115l-.292.16c-.764.415-1.6-.42-1.184-1.185l.159-.291A1.873 1.873 0 0 0 1.945 8.93l-.319-.094c-.835-.246-.835-1.428 0-1.674l.319-.094A1.873 1.873 0 0 0 3.06 4.377l-.16-.292c-.415-.764.42-1.6 1.185-1.184l.292.159a1.873 1.873 0 0 0 2.692-1.115l.094-.319z"/>
                    </svg>
                </Divider>

                {Object.keys(DividerLinks).map((key) => (
                    <Button
                        href={DividerLinks[key].link}
                        style={{
                            width: "100%",
                            marginBottom: "15px"
                        }}
                        className="font__open-sans"
                    >
                        {DividerLinks[key].title}
                    </Button>
                ))}

                {isMobile && (
                    <>
                        <Divider
                            plain
                            orientation={"center"}
                            style={{
                                marginBottom: "20px"
                            }}
                        >
                            Others
                        </Divider>

                        {Object.keys(Options).map((key, ) => (
                            <Button
                                href={Options[key].link}
                                style={{
                                    width: '100%',
                                    marginBottom: '15px'
                                }}
                                className="font__open-sans"
                            >
                                {Options[key].title}
                            </Button>
                        ))}
                    </>
                )}

            </Drawer>
        </div>
    );
};

export default ArtadoHeader;