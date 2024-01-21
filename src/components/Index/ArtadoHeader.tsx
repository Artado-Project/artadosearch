import React, {useState, useEffect} from 'react';
import './../../assets/Index.css';
import {Button, Divider, Drawer, Select, Switch,} from "antd";

const LinkStyle = {
    color: 'black',
    fontSize: '12px',
    marginRight: '10px',
    borderBottom: '0.01rem solid #9c9c9c',
    textDecoration: 'none',
}

const MutedText = {
    color: "gray",
    fontSize: "12px",
    fontFamily: "Open Sans",
    fontWeight: "bold",
    marginBottom: "5px"
}

interface OptionsItem{
    title: string;
    value: string;
}

interface OptionsProps {
    [key: string]: OptionsItem;
}

const Options: OptionsProps = {
    'Settings': {
        title: 'Settings',
        value: '#Settings' // TODO: Add Link
    },

    'Help': {
        title: 'Help',
        value: '#Help', // TODO: Add Link
    },

    'Feedback': {
        title: 'Feedback',
        value: '#Feedback' // TODO: Add Link
    }
}

const DividerLinks: OptionsProps = {
    'Workshop': {
        title: "Workshop",
        value: "#WorkShop" // TODO: Add Link
    },

    'Forum': {
        title: "Forum",
        value: "https://forum.artado.xyz/"
    },

    'Manifesto': {
        title: "Manifesto",
        value: "/manifest"
    },

    'Privacy Policy': {
        title: "Privacy Policy",
        value: "#PrivacyPolicy" // TODO: Add Link
    },

    'Terms of Service': {
        title: "Terms of Service",
        value: "#TermsOfService" // TODO: Add Link
    },

    'Discord': {
        title: "Discord",
        value: "https://discord.gg/FVSAycTsKT"
    },
}

const SearchEngines: OptionsProps = {
    'Artado' : {
        title: 'Artado',
        value: 'artado'
    },

    'Google' : {
        title: 'Google',
        value: 'google',
    },

    'Duckduckgo' : {
        title: 'Duckduckgo',
        value: 'duckduckgo'
    },

    'Bing' : {
        title: 'Bing',
        value: 'bing',
    },

    'Yahoo' : {
        title: 'Yahoo!',
        value: 'yahoo',
    },

    'Scholar' : {
        title: 'Scholar',
        value: 'scholar',
    }
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

    const checkDarkMode = () => {
        const selected = document.getElementById('theme') as HTMLSelectElement;
        const theme = selected.value;
        if (theme === 'dark') {
            // save theme to local storage
            localStorage.setItem('theme', 'Dark');
        } else if (theme === 'light') {
            localStorage.setItem('theme', 'Light');
        }
    }

    const checkUrl = () => {
        const url = window.location.href;
        return url.includes('search');
    }

    // @ts-ignore
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
                    href={Options[key].value}
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
                style={
                    /* checking url is search and isMobile true */
                    checkUrl() && isMobile ? {display: 'none'} : { paddingTop: "6px", marginLeft: "20px"}
                }
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
                closable={true}
                onClose={closeSidebar}
                open={open}
                width={300}
                footer={
                    <span style={{
                        textAlign: "center",
                        fontSize: "12px",
                        color: "#8c8c8c",
                        fontWeight: "bold",
                        fontFamily: "assistant, sans-serif"
                    }}>
                        Artado Search Contributors © 2023
                    </span>
                }
                >
                <Select
                    defaultValue="Select a Theme"
                    id={"theme"}
                    onChange={checkDarkMode}
                    style={{ width: "100%", height: "35px", marginBottom: "20px" }}
                    options={[
                        { value: 'night', label: 'Night' },
                        { value: 'light', label: 'Light' },
                        { value: 'auto', label: 'Auto' },
                        { value: 'disabled', label: 'Select a Theme', disabled: true },
                    ]}
                />
                <Select
                    defaultValue="Search Engine (Artado)"
                    id="engine"
                    style={{ width: "100%", height: "35px", marginBottom: "20px" }}
                    options={Object.keys(SearchEngines).map(key => ({
                        value: SearchEngines[key].value,
                        label: SearchEngines[key].title,
                    }))}
                />
                <Select
                    id={"language"}
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
                        href={DividerLinks[key].value}
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
                                href={Options[key].value}
                                id={'others'}
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
