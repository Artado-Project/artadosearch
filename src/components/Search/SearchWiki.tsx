import React, { useEffect, useState } from 'react';
import { Segmented, Divider } from 'antd';
import { searchWikipedia } from "../../backend/api/wikipedia/wikipedia";
import SearchOpenStreetMap from "./SearchOpenStreetMap";
import './../../assets/Index.css';
import { SegmentedValue } from 'antd/es/segmented';

const searchParams = new URLSearchParams(window.location.search);
const search = searchParams.get('q');

const SearchWiki: React.FC = () => {
    const [imgUrl, setImgUrl] = useState<string | undefined>('');
    const [selectedSegment, setSelectedSegment] = useState<SegmentedValue>('wiki');

    useEffect(() => {
        const country_code = navigator.language.split('-')[0].toLowerCase();
        const query: string | null = search;

        searchWikipedia(country_code, query ?? '').then((url) => {
            setImgUrl(url);
        });
    }, [search]);

    const ant_description = document.getElementsByClassName('ant-card-meta-description');
    ant_description.item(0)?.setAttribute('style', 'color: #5c5c5c !important');

    const segmented_options = [
        { label: 'Wikipedia', value: 'wiki' },
        { label: 'Open In Open Street Map', value: 'openstreetmap' },
    ];

    const handleSegmentChange = (value: SegmentedValue) => {
        setSelectedSegment(value);
    }

    const checking_segmented_value = () => {
        if (selectedSegment === 'wiki') {
            const about = [
                { label: 'Capital', value: 'Ankara' },
                { label: 'Currency', value: 'Turkish Lira' },
                { label: 'Population', value: '83,614,362' },
                { label: 'Official Language', value: 'Turkish' },
                { label: 'President', value: 'Recep Tayyip Erdoğan' },
                { label: 'Area', value: '783,356 km²' },
                { label: 'Calling Code', value: '+90' },
                { label: 'Time Zone', value: 'UTC+03:00' },
                { label: 'Internet TLD', value: '.tr' },
            ];

            return (
               <>
                   <h3 style={{ color: '#3c3c3c', fontFamily: 'assistant, sans-serif' }}>Republic of Turkey</h3>
                   <span style={{ fontSize: '14px', lineHeight: '24px' ,color: '#5c5c5c' }}>
                        The Republic of Turkey, is a transcontinental country located mainly on the Anatolian Peninsula in Western Asia, with a smaller portion on the Balkan Peninsula in Southeastern Europe. Turkey is bordered on its northwest by Greece and Bulgaria; north by the Black Sea; northeast by Georgia; east by Armenia, Azerbaijan, and Iran; southeast by Iraq; south by Syria and the Mediterranean Sea; and west by the Aegean Sea. Approximately 70 to 80 percent of the country's citizens identify as Turkish, while Kurds are the largest minority, at between 15 to 20 percent of the population.
                   </span>
                   <Divider orientation={'center'} plain={true} style={{fontSize: '14px' }}>More Information</Divider>
                   <div style={{ display: 'flex', flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'space-between' }}>
                       {about.map((item, index) => {
                           return (
                               <div key={index} style={{ flexBasis: '48%', marginBottom: '10px' }}>
                                   <span style={{ color: '#5c5c5c', fontSize: '14px', fontWeight: 500 }}>{item.label}: </span>
                                   <span style={{ color: '#5c5c5c', fontSize: '14px' }}>{item.value}</span>
                               </div>
                           );
                       })}
                   </div>
               </>
            );
        } else if (selectedSegment === 'openstreetmap') {
            return (
                'nuh uh'
            );
        }
    }

    return (
        <>
            <Segmented style={{ color: '#5c5c5c' }} options={segmented_options} onChange={handleSegmentChange} block />
            <div style={{ display: "flex", marginTop: '10px' }}>
                <img src={'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png'} alt={'Flag of Turkey'} style={{ width: '200px', borderBottomLeftRadius: '3px', borderTopLeftRadius: '3px'}} />
                <SearchOpenStreetMap />
            </div>
            {checking_segmented_value()}
        </>
    );
}

export default SearchWiki;
