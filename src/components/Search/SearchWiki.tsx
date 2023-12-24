import React, { useEffect, useState } from 'react';
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

    return (
        <>
            <div className={'wiki'}>
                <div style={{display: "flex"}}>
                    <img style={{height: 200, width: '50%', borderTopLeftRadius: 3, borderBottomLeftRadius: 3}} className={'contain'}
                         src={'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png'} />
                    <SearchOpenStreetMap/>
                </div>
            </div>
        </>
    );
}

export default SearchWiki;