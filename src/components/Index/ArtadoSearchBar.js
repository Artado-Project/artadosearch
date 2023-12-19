/**
 * @file ArtadoHeader.js
 * @brief Header for Artado Search Index Page
 * @contains Drawer and Links
 * @author [yasinldev](https://github.com/yasinldev)
 */

import React, { useState, useEffect } from 'react';
import './../../assets/Index.css';
import {AutoComplete, Form} from 'antd';

const ArtadoSearchBar: React.FC = () => {
    const [options, setOptions] = useState([]);
    const [isMobile, setIsMobile] = useState(false);

    const responsiveDesign = () => {
        const mq = window.matchMedia('(max-width: 600px)');
        setIsMobile(mq.matches);
    };

    useEffect(() => {
        responsiveDesign();
        window.addEventListener('resize', responsiveDesign);

        return () => {
            window.removeEventListener('resize', responsiveDesign);
        };
    }, []);

    const getPanelValue = (searchText) => {
        const autoCompleteResults = checkAutocomplete(searchText);

        if (autoCompleteResults) {
            return [autoCompleteResults, mockVal(searchText, 2), mockVal(searchText, 3), mockVal(searchText, 4), mockVal(searchText, 5)];
        } else {
            return [mockVal(searchText), mockVal(searchText, 2), mockVal(searchText, 3), mockVal(searchText, 4), mockVal(searchText, 5)];
        }
    };

    const checkAutocomplete = (value) => {
        if (value[0] === '!') {
            return {
                value: 'Shortcut detected please click for sites with shortcut available',
            };
        } else {
            return [];
        }
    };

    const mockVal = (str, repeat = 1) => ({
        value: str.repeat(repeat),
    });

    const onSelect = (data: string) => {
        console.log('onSelect', data);
    };

    return (
        <>
            <Form method="get" style={{ justifyContent: 'center', display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                <img src={'https://www.artadosearch.com/images/android-chrome-192x192.png'} style={isMobile ? { width: 150 } : null} alt={'artado logo'} />
                <br />
                <AutoComplete
                    name={'q'}
                    options={options}
                    style={isMobile ? { width: 300, height: 34 } : { width: 500, height: 34 }}
                    onSelect={onSelect}
                    onSearch={(text) => setOptions(getPanelValue(text))}
                    placeholder="Let's search the internet!"
                />
            </Form>
        </>
    );
};

export default ArtadoSearchBar;