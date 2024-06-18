import React, {useState} from "react";
import {Divider, Drawer, Image} from "antd";

/**
 * @desc This section is designed and coded experimentally, if you discover a bug you can open an issue by tagging 'yasinldev' on GitHub.
 */
interface ImageProps {
    src: string,
    alt: string,
    onClick: () => void,
    title: string,
    desc: string,
}

const ArtadoImageCard: React.FC<ImageProps> = ({ src, alt, onClick, title, desc}) => {
    return (
        <>
            <div className={'container-item'} style={{display: "flex", flexDirection: "column"}}>
                <img
                    className="Artado-image"
                    src={src}
                    alt={alt}
                    onClick={onClick}
                />
                <b className={'font__assistant image-title'} style={{ fontSize: 14, marginTop: 5 }}>{title}</b>
                <small className={'font__assistant'} style={{ fontSize: 12, color: '#7e7e7e' }}>{desc}</small>
            </div>
        </>
    );
};

const SearchImageComp: React.FC = () => {
    const [open, setOpen] = useState(false);

    const showDrawer = () => {
        setOpen(true);
    };

    const onClose = () => {
        setOpen(false);
    };

    const images = [
        {
            src: 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png',
            alt: 'Flag of Turkey',
            title: 'Flag of Turkey',
            desc: 'Wikipedia'
        },
        {
            src: 'https://isbh.tmgrup.com.tr/sbh/2020/11/19/turkiye-haritasi-1605764713268.png',
            alt: 'Flag of Turkey',
            title: 'Turkey Map',
            desc: 'İstanbul Büyükşehir Belediyesi'
        },
        {
            src: 'https://turkiyemaarif.org/uploads/slider/original/16668530288f2e.webp',
            alt: 'Flag of Turkey',
            title: 'Türkiye Haritası',
            desc: 'Türkiye Maarif Vakfı'
        },
        {
            src: 'https://lh6.googleusercontent.com/proxy/DZV27Nc5H4ZdUSLEjL3KJjo2WaeJ6HAvuh4BD5kVstGusqh1li5txnAgJm5EL5Xdy5s5_9FrJ4rUvh049DfRfbC43hiWpZadwhNDCiScjN-6tkylraRl',
            alt: 'Flag of Turkey',
            title: 'Türkiye Haritası',
            desc: 'Google Maps'
        },
        {
            src: 'https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Turkey_%28orthographic_projection%29.svg/250px-Turkey_%28orthographic_projection%29.svg.png',
            alt: 'Flag of Turkey',
            title: 'Turkey Photographic Map',
            desc: 'Wikipedia'
        },
        {
            src: 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png',
            alt: 'Flag of Turkey',
            title: 'Flag of Turkey',
            desc: 'Wikipedia'
        },
        {
            src: 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png',
            alt: 'Flag of Turkey',
            title: 'Flag of Turkey',
            desc: 'Wikipedia'
        },
        {
            src: 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png',
            alt: 'Flag of Turkey',
            title: 'Flag of Turkey',
            desc: 'Wikipedia'
        },
    ];

    return (
        <div className="Artado-row">
            <div className="image-items">
                {images.map((image, index) => (
                    <ArtadoImageCard
                        key={index}
                        src={image.src}
                        alt={image.alt}
                        onClick={showDrawer}
                        title={image.title}
                        desc={image.desc}
                    />
                ))}
            </div>
            <Drawer
                title={'Flag of Turkey'}
                placement="right"
                closable={true}
                onClose={onClose}
                visible={open}
            >
               <Image style={{ borderRadius: 5 }} height={250} src={'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png'} />
               <div className={'image-buttons'}>Go to website</div>
               <div className={'image-buttons'}>Share this website</div>
               <Divider style={{ marginTop: 30 }} className={'font__assistant'}><small>website summary</small></Divider>
               <p style={{ lineHeight: 1.8, marginTop: 30 }}>
                   Lorem ipsum dolor sit amet, consectetur adipisicing elit. Atque dolorem ducimus laborum possimus, quam quasi soluta suscipit veniam. Ab at deserunt eos et iure laboriosam libero natus necessitatibus neque nulla porro, quae quas quidem quis quisquam quos rem saepe sed sint ullam veniam veritatis voluptatem. Nam repellendus reprehenderit temporibus vel! Beatae eveniet illo illum molestiae praesentium quod soluta tenetur voluptatum?
               </p>
            </Drawer>
        </div>
    );
}

export default SearchImageComp;
