import React, { useEffect, useState } from 'react';
import { Card, Segmented } from 'antd';
import { searchWikipedia } from "../../backend/api/wikipedia/wikipedia";
import SearchOpenStreetMap from "./SearchOpenStreetMap";
import './../../assets/Index.css';

const searchParams = new URLSearchParams(window.location.search);
const search = searchParams.get('q');

const SearchWiki: React.FC = () => {
    const [imgUrl, setImgUrl] = useState<string | undefined>('');
    const [selectedSegment, setSelectedSegment] = useState<string>('wiki');

    useEffect(() => {
        const country_code = navigator.language.split('-')[0].toLowerCase();
        const query: string | null = search;

        searchWikipedia(country_code, query ?? '').then((url) => {
            setImgUrl(url);
        });
    }, [search]);

    const { Meta } = Card;

    const ant_description = document.getElementsByClassName('ant-card-meta-description');
    ant_description.item(0)?.setAttribute('style', 'color: #5c5c5c !important');

    const segmented_options = [
        { label: 'Wikipedia', value: 'wiki' },
        { label: 'Open Street Map', value: 'openstreetmap' },
    ];

    const handleSegmentChange = (value: string) => {
        setSelectedSegment(value);
    }

    const checking_segmented_value = () => {
        if (selectedSegment === 'wiki') {
            return (
                <Meta
                    title={'Republic of Turkey'}
                    description={'The Republic of Turkey, is a transcontinental country located mainly on the Anatolian Peninsula in Western Asia, with a smaller portion on the Balkan Peninsula in Southeastern Europe. Turkey is bordered on its northwest by Greece and Bulgaria; north by the Black Sea; northeast by Georgia; east by Armenia, Azerbaijan, and Iran; southeast by Iraq; south by Syria and the Mediterranean Sea; and west by the Aegean Sea. Approximately 70 to 80 percent of the country\'s citizens identify as Turkish, while Kurds are the largest minority, at between 15 to 20 percent of the population.'}
                />
            );
        } else if (selectedSegment === 'openstreetmap') {
            return (
                'nuh uh'
            );
        }
    }

    return (
        <>
            <Card
                className={'card-style'}
                cover={
                    <div style={{ display: "flex", marginTop: '2px' }}>
                        <img style={{ borderRadius: 0, width: 300 }} src={'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/200px-Flag_of_Turkey.svg.png'}  alt={'img'}/>
                        <SearchOpenStreetMap />
                    </div>
                }
                title={
                    <Segmented options={segmented_options} onChange={handleSegmentChange} block />
                }
            >
                {checking_segmented_value()}
            </Card>
        </>
    );
}

export default SearchWiki;
