import React, { useState, useEffect} from 'react';
import './../../assets/Index.css';
import {AutoComplete} from 'antd';

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../../language/${language}/index-page.json`);

const mockVal = (str: string, repeat = 1) => ({
    value: str.repeat(repeat),
});

const getInputClassName = () => {
    const input = document.getElementsByClassName('ant-select-selector');
    input.item(0)?.setAttribute('style', 'border-radius: 60px !important');
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
                        suffixIcon={
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                 className="bi bi-search-heart" viewBox="0 0 16 16">
                                <path d="M6.5 4.482c1.664-1.673 5.825 1.254 0 5.018-5.825-3.764-1.664-6.69 0-5.018"/>
                                <path
                                    d="M13 6.5a6.47 6.47 0 0 1-1.258 3.844q.06.044.115.098l3.85 3.85a1 1 0 0 1-1.414 1.415l-3.85-3.85a1 1 0 0 1-.1-.115h.002A6.5 6.5 0 1 1 13 6.5M6.5 12a5.5 5.5 0 1 0 0-11 5.5 5.5 0 0 0 0 11"/>
                            </svg>
                        }
                    />
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