import React, { useEffect, useState } from 'react';
import ReactDOM from "react-dom";
import {Segmented, Divider, Button} from 'antd';
import { searchWikipedia } from "../../backend/api/wikipedia/wikipedia";
import SearchOpenStreetMap from "./SearchOpenStreetMap";
import { SegmentedValue } from 'antd/es/segmented';

const searchParams = new URLSearchParams(window.location.search);
const search = searchParams.get('q');

const theme = localStorage.getItem('theme') ?? 'light';

const SearchWiki: React.FC = () => {
    const [imgUrl, setImgUrl] = useState<string | undefined>('');
    const [selectedSegment, setSelectedSegment] = useState<SegmentedValue>('wiki');
    const [isMobile, setIsMobile] = useState(false);

    const setResponsive = () => {
        const mq = window.matchMedia('(max-width: 720px)');
        setIsMobile(mq.matches);
    }

    useEffect(() => {
        const country_code = navigator.language.split('-')[0].toLowerCase();
        const query: string | null = search;

        setResponsive();
        window.addEventListener('resize', setResponsive);

        searchWikipedia(country_code, query ?? '').then((url) => {
            setImgUrl(url);
        });
    }, [search]);

    useEffect(() => {
        const checkSeeMore = document.getElementById('seeMoreWiki');
        if (checkSeeMore) {
            checkSeeMore.style.display = 'block';
        }
    });

    const ant_description = document.getElementsByClassName('ant-card-meta-description');
    ant_description.item(0)?.setAttribute('style', theme === 'night' ? 'color: #d0d0d0' : 'color: #3c3c3c');

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

            const checkSeeMore = document.getElementById('seeMoreWiki');
            checkSeeMore?.addEventListener('click', () => {
                checkSeeMore.style.display = 'none';
                const moreInfo = (
                    <Divider orientation={'center'} plain={true} className={'artado-divider'}>More Information</Divider>
                );

                const moreInfoDiv = document.createElement('div');
                moreInfoDiv.style.display = 'flex';
                moreInfoDiv.style.flexDirection = 'row';
                moreInfoDiv.style.flexWrap = 'wrap';
                moreInfoDiv.style.justifyContent = 'space-between';
                moreInfoDiv.style.marginTop = '5px';
                moreInfoDiv.id = 'more';

                about.map((item, index) => {
                    const div = document.createElement('div');
                    div.className = 'more-info'
                    div.innerHTML = `<span class="labels">${item.label}: </span><span style="color: #5c5c5c; font-size: 14px;">${item.value}</span>`;
                    moreInfoDiv.appendChild(div);
                });

                const moreInfoContainer = document.createElement('div');
                ReactDOM.render(moreInfo, moreInfoContainer);

                checkSeeMore.parentElement?.appendChild(moreInfoContainer);
                checkSeeMore.parentElement?.appendChild(moreInfoDiv);
            });

            return (
               <>
                   {isMobile ?
                       <>
                           <h3 className={'wiki-title'}>Republic of Turkey</h3>
                           <span className={'wiki-desc'}>
                                The Republic of Turkey, is a transcontinental country located mainly on the Anatolian Peninsula in Western Asia, with a smaller portion on the Balkan Peninsula in Southeastern Europe. Turkey is bordered on its northwest by Greece and Bulgaria; north by the Black Sea; northeast by Georgia; east by Armenia, Azerbaijan, and Iran; southeast by Iraq; south by Syria and the Mediterranean Sea; and west by the Aegean Sea. Approximately 70 to 80 percent of the country's citizens identify as Turkish, while Kurds are the largest minority, at between 15 to 20 percent of the population.
                           </span> <br/><br/>
                           <Button style={{ width: '100%' }} id={'seeMoreWiki'} type={'default'}>See More</Button>
                       </>
                       :
                       <>
                           <h3 className={'wiki-title'}>Republic of Turkey</h3>
                           <span className={'wiki-desc'}>
                                The Republic of Turkey, is a transcontinental country located mainly on the Anatolian Peninsula in Western Asia, with a smaller portion on the Balkan Peninsula in Southeastern Europe. Turkey is bordered on its northwest by Greece and Bulgaria; north by the Black Sea; northeast by Georgia; east by Armenia, Azerbaijan, and Iran; southeast by Iraq; south by Syria and the Mediterranean Sea; and west by the Aegean Sea. Approximately 70 to 80 percent of the country's citizens identify as Turkish, while Kurds are the largest minority, at between 15 to 20 percent of the population.
                            </span>
                           <Divider orientation={'center'} plain={true} className={'artado-divider'}>More Information</Divider>
                           <div className={'wiki-child'}>
                               {about.map((item, index) => {
                                   return (
                                       <div key={index} className={'child-header'}>
                                           <span className={'child-title'}>{item.label}: </span>
                                           <span className={'child-desc'}>{item.value}</span>
                                       </div>
                                   );
                               })}
                           </div>
                       </>
                   }
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
            <div id={'search-wiki'}>
                <Segmented className={'segmented'} options={segmented_options} onChange={handleSegmentChange} block />
                <div style={{ display: "flex", marginTop: '10px' }}>
                    <img src={'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png'} alt={'Flag of Turkey'} style={{ width: '200px', borderBottomLeftRadius: '3px', borderTopLeftRadius: '3px'}} />
                    <SearchOpenStreetMap />
                </div>
                {checking_segmented_value()}
            </div>
        </>
    );
}

export default SearchWiki;
