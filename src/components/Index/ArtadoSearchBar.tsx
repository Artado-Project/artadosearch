import React, { useState, useEffect} from 'react';
import './../../assets/Index.css';
import {AutoComplete} from 'antd';

const language = localStorage.getItem('language') ?? 'en';
const languageData = require(`./../../language/${language}/index-page.json`);

const mockVal = (str: string, repeat = 1) => ({
    value: str.repeat(repeat),
});

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