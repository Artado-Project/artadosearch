import React, { useEffect, useState } from 'react';
import { Card } from 'antd';
import { searchWikipedia } from "../../backend/api/wikipedia/wikipedia";
import SearchOpenStreetMap from "./SearchOpenStreetMap";
import './../../assets/Index.css';

const searchParams = new URLSearchParams(window.location.search);
const search = searchParams.get('q');

const SearchWiki: React.FC = () => {
    const [imgUrl, setImgUrl] = useState<string | undefined>('');

    useEffect(() => {
        const country_code = navigator.language.split('-')[0].toLowerCase();
        const query: string | null = search;

        searchWikipedia(country_code, query ?? '').then((url) => {
            setImgUrl(url);
        });
    }, [search]);

    const { Meta } = Card;

    return (
        <>
            <Card
                hoverable
                style={{ width: '100%'}}
                cover={
                    <div style={{ display: "flex"}}>
                        <img style={{ }} src={'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/200px-Flag_of_Turkey.svg.png'} />
                        <SearchOpenStreetMap />
                    </div>
                }
            >
                <Meta title={'Republic of Turkey'}></Meta>
            </Card>

        </>
    );
}

export default SearchWiki;