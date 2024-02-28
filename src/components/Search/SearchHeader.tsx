import React, {useEffect} from "react";
import reactDOM from "react-dom";
import {Button, Card, Divider, Input, Timeline} from "antd";
import { useNavigate } from "react-router-dom";
import ArtadoHeader from "../Index/ArtadoHeader";
import './../../assets/Index.css';

const searchParams = new URLSearchParams(window.location.search);
const search = searchParams.get('q');

const items = [
    {
        key: 1,
        label: 'web',
        url: '/search?q=' + search + '&type=web',
    },
    {
        key: 2,
        label: 'images',
        url: '/search?q=' + search + '&type=images',
    },
    {
        key: 3,
        label: 'videos',
        url: '/search?q=' + search + '&type=videos',
    },
    {
        key: 4,
        label: 'maps',
        url: '/search?q=' + search + '&type=maps',
    },
    {
        key: 5,
        label: 'repositories',
        url: '/search?q=' + search + '&type=repositories',
    },
    {
        key: 6,
        label: 'science',
        url: '/search?q=' + search + '&type=science',
    },
    {
        key: 7,
        label: 'news',
        url: '/search?q=' + search + '&type=news',
    },
    {
        key: 8,
        label: 'shopping',
        url: '/search?q=' + search + '&type=shopping',
    },
];

const SearchHeader: React.FC = () => {
    const navigate = useNavigate();

    useEffect(() => {
        if (!search) {
            navigate('/?ret_no=empty-url');
        }
    }, [search, navigate]);

    const searchInput = document.getElementById('searchInput');
    if (searchInput) {
        searchInput.addEventListener('focus', () => {
            const onSearchFocus = document.getElementById('onSearchFocus');
            if (onSearchFocus) {
                reactDOM.render(<Card className={'animation'} style={{width: '100%', height: '250px', overflowY: 'auto'}}>
                        <div className={'Artado-row'}>
                            <div className={'column-xs-12 column-sm-12 column-md-6 column-lg-6 column-xl-6'} style={{ display: 'flex' }}>
                                <Timeline
                                    style={{marginBottom: 0, width: '100%'}}
                                    items={[
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-arrow-clockwise"
                                                         viewBox="0 0 16 16">
                                                        <path fill-rule="evenodd"
                                                              d="M8 3a5 5 0 1 0 4.546 2.914.5.5 0 0 1 .908-.417A6 6 0 1 1 8 2z"/>
                                                        <path
                                                            d="M8 4.466V.534a.25.25 0 0 1 .41-.192l2.36 1.966c.12.1.12.284 0 .384L8.41 4.658A.25.25 0 0 1 8 4.466"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'Turkey',
                                        },
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-arrow-clockwise"
                                                         viewBox="0 0 16 16">
                                                        <path fill-rule="evenodd"
                                                              d="M8 3a5 5 0 1 0 4.546 2.914.5.5 0 0 1 .908-.417A6 6 0 1 1 8 2z"/>
                                                        <path
                                                            d="M8 4.466V.534a.25.25 0 0 1 .41-.192l2.36 1.966c.12.1.12.284 0 .384L8.41 4.658A.25.25 0 0 1 8 4.466"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'How can i find a job in Turkey?',
                                        },
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-arrow-clockwise"
                                                         viewBox="0 0 16 16">
                                                        <path fill-rule="evenodd"
                                                              d="M8 3a5 5 0 1 0 4.546 2.914.5.5 0 0 1 .908-.417A6 6 0 1 1 8 2z"/>
                                                        <path
                                                            d="M8 4.466V.534a.25.25 0 0 1 .41-.192l2.36 1.966c.12.1.12.284 0 .384L8.41 4.658A.25.25 0 0 1 8 4.466"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'YÖK Atlas',
                                        },
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                                                        <path
                                                            d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'Turkey wikipedia',
                                        },
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                                                        <path
                                                            d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'Istanbul Beykent University',
                                        },
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                                                        <path
                                                            d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'Bootstrap icon',
                                        },
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                                                        <path
                                                            d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'Artado Search Github',
                                        },
                                        {
                                            color: 'gray',
                                            dot: (
                                                <>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                                         fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                                                        <path
                                                            d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
                                                    </svg>
                                                </>
                                            ),
                                            children: 'Artado Search',
                                        },
                                    ]}
                                    />
                            </div>
                            <div className={'column-xs-12 column-sm-12 column-md-6 column-lg-6 column-xl-6'}>
                                <span style={{
                                    fontSize: 'small',
                                    textAlign: 'center',
                                    fontWeight: 'bolder',
                                    marginBottom: -10,
                                    color: '#5c5c5c',
                                }} className={'font__assistant'}>
                                    You may be interested in these
                                </span>
                                <Divider style={{marginBottom: 10}}/>
                                <Button type={'text'} style={{
                                    width: '100%',
                                    color: '#5c5c5c',
                                    marginBottom: 10,
                                    backgroundColor: '#f8f8f8'
                                }}>
                                    Turkey - Wikipedia
                                </Button>
                                <Button type={'text'} style={{
                                    width: '100%',
                                    color: '#5c5c5c',
                                    marginBottom: 10,
                                    backgroundColor: '#f8f8f8'
                                }}>
                                    Turkey's President Erdogan
                                </Button>
                                <Button type={'text'} style={{
                                    width: '100%',
                                    color: '#5c5c5c',
                                    marginBottom: 10,
                                    backgroundColor: '#f8f8f8'
                                }}>
                                    Turkey's Economy
                                </Button>
                            </div>
                        </div>
                    </Card>
                    , onSearchFocus);
            }
        });
        searchInput.addEventListener('blur', () => {
            const onSearchFocus = document.getElementById('onSearchFocus');
            if (onSearchFocus) {
                reactDOM.unmountComponentAtNode(onSearchFocus);
            }
        });
    }

    return (
        <>
            <div className={'Artado-row'} style={{marginBottom: 10}}>
                <div className={'column-xs-12 column-sm-12 column-md-7 column-lg-7 column-xl-7'}>
                    <form method={'GET'} action={'/search'}>
                        <Input.Group>
                            <Input
                                id={'searchInput'}
                                name={'q'}
                                defaultValue={search ?? ''}
                                placeholder={'Let\'s find something...'}
                                style={{width: '100% !important', height: '35px'}}
                                suffix={<img src={'https://www.artadosearch.com/images/android-chrome-192x192.png'}
                                             alt={'Artado Search'} width={20} height={20}/>}
                            />
                        </Input.Group>
                    </form>
                    <div id={'onSearchFocus'}></div>
                </div>
                <div className={'column-xs-12 column-sm-12 column-md-5 column-lg-5 column-xl-5'}>
                    <ArtadoHeader/>
                </div>
            </div>
            <div className={'search-types'} style={{paddingRight: 0}}>
                {items.map((item) => (
                    <a
                        key={item.key}
                        href={item.url}
                        className={item.key === 1 ? 'search-buttons active' : 'search-buttons'}
                    >
                        {item.label}
                    </a>
                ))}
            </div>
        </>
    );
}

export default SearchHeader;
