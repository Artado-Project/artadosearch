/**
 * @file ArtadoFooter.js
 * @brief Footer for Artado (For all pages)
 * @contains Footer
 * @author [yasinldev](https://github.com/yasinldev)
 */

import './../../assets/Index.css';
import React from "react";

const FooterStyle = {
    position: 'fixed',
    left: '0',
    bottom: '0',
    width: '100%',
    textAlign: 'center',
    alignItems: 'center',
    justifyItems: 'center',
    marginBottom: '20px',
}

const FooterContentStyle = {
    textAlign: 'center',
    fontSize: '12px',
    color: '#7c7c7c',
    fontWeight: 'bold',
    marginRight: '10px',
    marginLeft: '10px',
    marginTop: '20px !important',
    textDecoration: 'none',
}

const FooterLinks = {
    'Privacy Policy': {
        title: 'Privacy Policy',
        link: '#PrivacyPolicy', // TODO: Add Link
    },

    'Manifesto': {
        title: 'Manifesto',
        link: '#Manifesto', // TODO: Add Link
    },

    'About Us': {
        title: 'About Us',
        link: '#AboutUs', // TODO: Add Link
    },

    'GitHub': {
        title: 'GitHub',
        link: 'https://github.com/artado-project/artadosearch',
    },
}

const ArtadoFooter: React.FC = () => {
    return (
        <footer style={FooterStyle}>
            <a href={'?ref=true'} className={'font__assistant'} style={FooterContentStyle}>
                <img src={'https://www.artadosearch.com/images/android-chrome-192x192.png'} style={{width: '20px', height: '20px', marginRight: '10px', color: '#7c7c7c', marginBottom: '-5px'}} alt={'artado logo'}/>
                Artado Search all rights reserved 2023 ©
            </a>
            &nbsp;
            <span style={{color: '#7c7c7c', marginTop: '-10px'}}>
                ~
            </span>
            &nbsp;
            {Object.keys(FooterLinks).map((key,) => (
                <a href={FooterLinks[key].link} className={'font__assistant'} style={FooterContentStyle}
                   key={key}>{FooterLinks[key].title}</a>
            ))}
        </footer>
    )
}

export default ArtadoFooter;