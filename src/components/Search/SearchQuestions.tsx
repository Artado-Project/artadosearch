import React from "react";
import type { CSSProperties } from 'react';
import {Avatar, CollapseProps} from 'antd';
import { Collapse, theme } from 'antd';

const text = `
  A dog is a type of domesticated animal.
  Known for its loyalty and faithfulness,
  it can be found as a welcome guest in many households across the world.
`;

const getItems: (panelStyle: CSSProperties) => CollapseProps['items'] = (panelStyle) => [
    {
        key: '1',
        label: <span style={{ color: '#5c5c5c' }}>
            What makes Turkey the only country in the world?
        </span>,
        children: <p style={{marginBottom: -3, color: '#6c6c6c'}}>
            Unitary character of the state
            <br/><br/>
            The indivisible unity of the State with its territory and nation means that it is a "unitary state". The
            State of Turkey is a unitary state, meaning that it does not have different administrative regions with
            different laws.
            <br/><br/>
            <div className={'source'}>
                <Avatar
                    style={{border: '1px solid #d0d0d0'}}
                    src={<img
                        src={'https://play-lh.googleusercontent.com/htBUaqvBQR9UQ3b1-ouSHFhDGttQkH-eWetEErspYXVa8hOsfmOmj5ZanGg9GF7XAGc'}/>}
                    size={25}
                /> &nbsp;
                <a href={'#'} style={{textDecoration: 'none'}}>
                    &nbsp; Turkey - Wikipedia
                </a>
            </div>
            <div className={'source'} style={{ marginLeft: 33 }}>en.wikipedia.org › wiki › Turkey</div>
        </p>,
        style: panelStyle,
    },
    {
        key: '2',
        label: <span style={{ color: '#5c5c5c' }}>
            Where does Turkey rank in medicine in 2023?
        </span>,
        children: <p style={{marginBottom: -3, color: '#6c6c6c'}}>
            News URAP (University Ranking by Academic Performance), one of the 8 institutions that rank world universities according to their fields of science, announced the 2022-2023 rankings. Our university ranked 13th among the UNIVERSITIES WITH MEDICAL FACULTY in URAP 2022-2023 Turkey Ranking.
            <br/><br/>
            <div className={'source'}>
                <Avatar
                    style={{border: '1px solid #d0d0d0'}}
                    src={<img
                        src={'https://ktu.edu.tr/image/tr_bg.png'}/>}
                    size={25}
                /> &nbsp;
                <a href={'#'} style={{textDecoration: 'none'}}>
                    &nbsp; Üniversitemiz, URAP 2022-2023 Türkiye Sıralamasında Tıp Fakültesi ...
                </a>
            </div>
            <div className={'source'} style={{ marginLeft: 33 }}>https://ktu.edu.tr › med › haber › universitemiz-urap-20...</div>
        </p>,
        style: panelStyle,
    },
];

const SearchQuestions: React.FC = () => {
    const {token} = theme.useToken();

    const panelStyle: React.CSSProperties = {
        marginBottom: 10,
        background: token.colorFillAlter,
        borderRadius: token.borderRadiusLG,
        border: 'none',
        fontFamily: 'Assistant, sans-serif',
        fontWeight: 'bolder',
    };

    return (
        <>
            <div className={'space-between'}>
                <h3 className={'more-questions'}>More Questions</h3>
                <a href={'#'} className={'links'}>feedback</a>
            </div>
            <Collapse
                bordered={false}
                defaultActiveKey={['1']}
                expandIcon={({isActive}) =>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" rotate={isActive ? 90 : 0}
                         fill="currentColor" className="bi bi-arrow-right-short"
                         viewBox="0 0 16 16">
                        <path fillRule="evenodd"
                              d="M4 8a.5.5 0 0 1 .5-.5h5.793L8.146 5.354a.5.5 0 1 1 .708-.708l3 3a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708-.708L10.293 8.5H4.5A.5.5 0 0 1 4 8"/>
                    </svg>
                }
                style={{background: token.colorBgContainer}}
                items={getItems(panelStyle)}
            />
        </>
    );
};

export default SearchQuestions;