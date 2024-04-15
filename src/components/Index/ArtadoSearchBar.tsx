import React, { useState, useEffect} from 'react';
import './../../assets/Index.css';
import {AutoComplete, Button} from 'antd';

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../../language/${language}/index-page.json`);

const mockVal = (str: string, repeat = 1) => ({
    value: str.repeat(repeat),
});

const getInputClassName = () => {
    const input: HTMLCollectionOf<Element> = document.getElementsByClassName('ant-select-selector');
    input.item(0)?.setAttribute('style', 'border-radius: 60px !important');
}

declare global {
    interface Window {
        SpeechRecognition: any,
        webkitSpeechRecognition: any,
        mozSpeechRecognition: any,
        msSpeechRecognition: any,
    }
}

const recognition = () => {
    const start = document.getElementById('speech');
    const out = document.getElementById('searchInput');

    const recognition = new (window.SpeechRecognition || window.webkitSpeechRecognition || window.mozSpeechRecognition || window.msSpeechRecognition)();
    recognition.lang = 'en-US';

    recognition.onstart = () => {
        console.log('listening...');
    };

    recognition.onresult = (event: any) => {
        const transcript = event.results[0][0].transcript;
        out!.textContent = transcript;
    };

    recognition.onend = () => {
        console.log('listening end');
    };

    start!.addEventListener('click', () => {
        recognition.start();
    });
}

const ArtadoSearchBar: React.FC = () => {
    const [options, setOptions] = useState<{ value: string }[]>([]);
    const [isMobile, setIsMobile] = useState(false);
    const [isHover, setIsHover] = useState(false);
    const [selectedValue, setSelectedValue] = useState('');

    useEffect(() => {
        const checkResponsiveDesign = () => {
            const mq = window.matchMedia('(max-width: 600px)');
            setIsMobile(mq.matches);
        };

        const handleMouseOver = () => {
            setIsHover(true);
        };

        const handleMouseOut = () => {
            setIsHover(false);
        };

        checkResponsiveDesign();
        getInputClassName();

        // Add event listeners
        window.addEventListener('resize', checkResponsiveDesign);
        const searchBar = document.getElementById('searchBar');
        if (searchBar) {
            searchBar.addEventListener('mouseover', handleMouseOver);
            searchBar.addEventListener('mouseout', handleMouseOut);
        }

        return () => {
            window.removeEventListener('resize', checkResponsiveDesign);
            if (searchBar) {
                searchBar.removeEventListener('mouseover', handleMouseOver);
                searchBar.removeEventListener('mouseout', handleMouseOut);
            }
        };
    }, []);


    const getPanelValue = (searchText: string) =>
        !searchText ? [] : [mockVal(searchText), mockVal(searchText, 2), mockVal(searchText, 3), mockVal(searchText, 4), mockVal(searchText, 5), mockVal(searchText, 6), mockVal(searchText, 7)];

    const onSelect = (data: string) => {
        setSelectedValue(data);
    };

    const inputDesign = {
        boxShadow: isHover
            ? 'rgba(149, 157, 165, 0.2) 0px 8px 24px'
            : 'rgba(100, 100, 111, 0.2) 0px 7px 29px 0px',
        transition: '0.3 ease-in-out',
        ...(isMobile ? {
            width: 350,
            height: 35,
            borderRadius: 60,
        } : {
            width: 600,
            height: 35,
            borderRadius: 60,
        })
    }

    return (
        <>
            <form
                method={'GET'}
                action={'/search'}
            >
                <div
                    style={{
                        justifyContent: 'center',
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center'
                    }}>
                    <img
                        src={'https://www.artadosearch.com/images/android-chrome-192x192.png'}
                        style={isMobile ? {width: 150} : {width: 170}}
                        alt={'artado logo'}
                    />
                    <br/>
                    <AutoComplete
                        id={'searchBar'}
                        options={options}
                        style={inputDesign}
                        onSelect={onSelect}
                        onSearch={(text) => setOptions(getPanelValue(text))}
                        placeholder={languageData.input}
                    />
                    <Button
                        type="default"
                        shape="circle"
                        id={'speech'}
                        size={'middle'}
                        style={{
                            marginTop: 10,
                            display: "flex",
                            textAlign: "center",
                            alignItems: "center",
                            alignContent: "center",
                            justifyContent: "center",
                            color: '#8c8c8c',
                        }}
                    >
                        <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" fill="currentColor"
                             className="bi bi-mic" viewBox="0 0 16 16">
                            <path
                                d="M3.5 6.5A.5.5 0 0 1 4 7v1a4 4 0 0 0 8 0V7a.5.5 0 0 1 1 0v1a5 5 0 0 1-4.5 4.975V15h3a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1h3v-2.025A5 5 0 0 1 3 8V7a.5.5 0 0 1 .5-.5"/>
                            <path
                                d="M10 8a2 2 0 1 1-4 0V3a2 2 0 1 1 4 0zM8 0a3 3 0 0 0-3 3v5a3 3 0 0 0 6 0V3a3 3 0 0 0-3-3"/>
                        </svg>
                    </Button>
                    <input
                        id={'searchInput'}
                        style={{borderRadius: '60px !important'}}
                        name={'q'}
                        type={'hidden'}
                        value={selectedValue}
                    />
                </div>
            </form>
        </>
    );
};

export default ArtadoSearchBar;