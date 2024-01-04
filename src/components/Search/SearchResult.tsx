import React, {  } from 'react';
import { Tag } from 'antd';

const SearchResultStyle = {
    card: {
        padding: '10px',
        borderRadius: '5px',
        marginBottom: '20px',
    },
    cardTitle: {
        fontSize: '20px',
        fontWeight: 'bold',
        color: '#5c5c5c',
        marginTop: '10px',
        fontFamily: 'assistant, sans-serif',
        marginBottom: '7px',
        textDecoration: 'underline',
        textUnderlineOffset: '6px',
        textDecorationColor: '#b4b4b4',
    },
    cardHeader: {
        float: 'right',
        color: '#5c5c5c',
        marginTop: '10px',
    },
    cardDesc: {
        fontSize: '13px',
        color: '#7c7c7c',
    },
    cardSubTitle: {
        marginTop: '20px',
        marginLeft: '30px',
        SubTitle: {
            fontSize: '15px',
            textDecoration: 'underline',
            textUnderlineOffset: '6px',
            textDecorationColor: '#b4b4b4',
            color: '#5c5c5c',
            fontFamily: 'assistant, sans-serif',
            marginBottom: '7px',
        },
        Desc: {
            fontSize: '13px',
            color: '#7c7c7c',
        }
    }
} as const;

const SearchResult: React.FC = () => {
    return (
        <>
            <div style={SearchResultStyle.card}>
                <div style={SearchResultStyle.cardHeader}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                         className="bi bi-question-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                        <path
                            d="M5.255 5.786a.237.237 0 0 0 .241.247h.825c.138 0 .248-.113.266-.25.09-.656.54-1.134 1.342-1.134.686 0 1.314.343 1.314 1.168 0 .635-.374.927-.965 1.371-.673.489-1.206 1.06-1.168 1.987l.003.217a.25.25 0 0 0 .25.246h.811a.25.25 0 0 0 .25-.25v-.105c0-.718.273-.927 1.01-1.486.609-.463 1.244-.977 1.244-2.056 0-1.511-1.276-2.241-2.673-2.241-1.267 0-2.655.59-2.75 2.286m1.557 5.763c0 .533.425.927 1.01.927.609 0 1.028-.394 1.028-.927 0-.552-.42-.94-1.029-.94-.584 0-1.009.388-1.009.94"/>
                    </svg>
                </div>
                <h3 style={SearchResultStyle.cardTitle}>Turkey - Wikipedia</h3>
                <span style={SearchResultStyle.cardDesc}>
                <Tag style={{ color: '#7c7c7c' }}>Document</Tag> Lorem ipsum dolor sit amet, consectetur adipisicing elit. A consequatur consequuntur culpa deserunt doloremque eligendi illo illum ipsa laboriosam laudantium nesciunt nostrum, officiis quibusdam quos sequi sunt, totam vitae voluptate.
            </span>
                <div style={SearchResultStyle.cardSubTitle}>
                    <h6 style={SearchResultStyle.cardSubTitle.SubTitle}>Turkey (bird) - Wikipedia</h6>
                    <span style={SearchResultStyle.cardSubTitle.Desc}>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aperiam dolorem laudantium modi, praesentium sed totam voluptatibus! Cupiditate inventore tempora tempore.
                </span>
                    <h6 style={SearchResultStyle.cardSubTitle.SubTitle}>History of Turkey - Wikipedia</h6>
                    <span style={SearchResultStyle.cardSubTitle.Desc}>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                </span>
                    <h6 style={SearchResultStyle.cardSubTitle.SubTitle}>Istanbul - Wikipedia</h6>
                    <span style={SearchResultStyle.cardSubTitle.Desc}>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci aperiam asperiores commodi culpa cumque dolorem, maxime qui quia sed similique vel vitae voluptas?
                </span>
                </div>
            </div>
            <div style={SearchResultStyle.card}>
                <div style={SearchResultStyle.cardHeader}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                         className="bi bi-question-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                        <path
                            d="M5.255 5.786a.237.237 0 0 0 .241.247h.825c.138 0 .248-.113.266-.25.09-.656.54-1.134 1.342-1.134.686 0 1.314.343 1.314 1.168 0 .635-.374.927-.965 1.371-.673.489-1.206 1.06-1.168 1.987l.003.217a.25.25 0 0 0 .25.246h.811a.25.25 0 0 0 .25-.25v-.105c0-.718.273-.927 1.01-1.486.609-.463 1.244-.977 1.244-2.056 0-1.511-1.276-2.241-2.673-2.241-1.267 0-2.655.59-2.75 2.286m1.557 5.763c0 .533.425.927 1.01.927.609 0 1.028-.394 1.028-.927 0-.552-.42-.94-1.029-.94-.584 0-1.009.388-1.009.94"/>
                    </svg>
                </div>
                <h3 style={SearchResultStyle.cardTitle}>Turkey Consciousness</h3>
                <span style={SearchResultStyle.cardDesc}>
                    But their ability to understand the world goes much further than just communication. He raises a bunch of wild turkeys, allowing them to imprint on him so that he's their parent. The exercise—which must have taken total commitment for the better part of a year—gives us a rare insight into the umwelt of some very impressive wild animals.
                </span>
            </div>
        </>
    );
}

export default SearchResult;
