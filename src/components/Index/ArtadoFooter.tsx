import './../../assets/Index.css';
import React, {useEffect, useState} from "react";

type LinkProps = {
    title: string;
    link: string;
}

type TypeFooterLinks = Record<string, LinkProps>

const FooterLinks: TypeFooterLinks = {
    'Privacy Policy': { title: 'Privacy Policy', link: '#PrivacyPolicy' },
    'Manifest': { title: 'Manifest', link: '#Manifest' },
    'About Us': { title: 'About Us', link: '#About' },
    'GitHub': { title: 'GitHub', link: 'https://github.com/Artado-Project/artadosearch' },
}

const ArtadoFooter: React.FC = () => {
    const [isMobile, setIsMobile] = useState(false);

    const responsiveDesign = () => {
        const mq = window.matchMedia('(max-width: 600px)');
        setIsMobile(mq.matches);
    }

    useEffect(() => {
        responsiveDesign();
        window.addEventListener('resize', responsiveDesign);

        return () => {
            window.removeEventListener('resize', responsiveDesign);
        }
    }, []);

    return (
        <>
            <footer className={'footer'}>
                <a
                    href={'?ref=true'}
                    className={'font__assistant footer-content'}
                >
                    <img
                        src={'https://www.artadosearch.com/images/android-chrome-192x192.png'}
                        style={{
                            width: '20px',
                            height: '20px',
                            marginRight: '10px',
                            color: '#7c7c7c',
                            marginBottom: '-5px'
                        }}
                        alt={'artado logo'}
                    />
                    Artado Search
                </a>
                &nbsp;
                {isMobile && (
                    <>
                        <br />
                    </>
                )}
                <span
                    style={{
                        color: '#7c7c7c',
                        marginTop: '-10px'
                    }}
                >
                ~
            </span>
                {isMobile && (
                    <>
                        <br />
                    </>
                )}
                &nbsp;
                {Object.keys(FooterLinks).map((key,) => (
                    <a
                        href={FooterLinks[key].link}
                        className={'font__assistant footer-content'}
                        key={key}
                    >
                        {FooterLinks[key].title}
                    </a>
                ))}
            </footer>
        </>
    )
}

export default ArtadoFooter;
