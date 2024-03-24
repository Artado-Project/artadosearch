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

const getInputClassName = () => {
    const input = document.getElementsByClassName('ant-input-affix-wrapper css-dev-only-do-not-override-i1mju1 ant-input-outlined');
    input.item(0)?.setAttribute('style', 'border-radius: 60px !important; height: 35px;');
}

const SearchHeader: React.FC = () => {
    const navigate = useNavigate();

    useEffect(() => {
        if (!search) {
            navigate('/?ret_no=empty-url');
        }

        getInputClassName();
    }, [search, navigate]);

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
                                style={{width: '100% !important', height: '40px', borderRadius: '60px !important'}}
                                suffix={<img src={'https://www.artadosearch.com/images/android-chrome-192x192.png'}
                                             alt={'Artado Search'} width={20} height={20}/>}
                            />
                        </Input.Group>
                    </form>
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
