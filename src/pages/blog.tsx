import React from "react";
import {Avatar, Button, Image, Input, Tabs, TabsProps, Tag} from "antd";

const blogItems: TabsProps['items'] = [
    {
        key: '1',
        label: [
            'Latest' // TODO: translation to be added
        ],
        children: [
            <>
                <div style={{width: '100%'}}>
                    <Input placeholder={'Search a blog title'}/>
                    <div style={{marginTop: 30, borderRadius: 5, display: 'flex', marginBottom: 40}}>
                        <Image
                            width={300}
                            height={150}
                            style={{borderRadius: 5}}
                            src={'https://cdn.evrimagaci.org/9I0eJ3dSrAMm5soda0gojqXRutU=/728x0/filters:format(webp)/storage.evrimagaci.org%2Fpost%2Fface2d79-a272-4299-ad05-8d30913c970a.png'}
                        />
                        <div style={{
                            display: 'flex',
                            flexDirection: 'column',
                            width: '100%',
                            marginLeft: 10
                        }}>
                            <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                                <div style={{display: 'flex', alignItems: 'center'}}>
                                    <Avatar size={'small'}
                                            src={'https://avatars.githubusercontent.com/u/90653146?v=4'}/>
                                    <b className={'font__assistant'} style={{marginLeft: 5}}>M. Yasin Özkaya</b>
                                </div>
                                <Tag bordered={false}>EN</Tag>
                            </div>
                            <b style={{marginTop: 10}} className={'font__assistant'}>Artificial Intelligence Helps Us
                                Learn More About Oropharyngeal Cancer!</b><br/>
                            <a href={'#'} className={'link'}>See more</a>
                        </div>
                    </div>
                    <div style={{marginTop: 30, borderRadius: 5, display: 'flex', marginBottom: 40}}>
                        <Image
                            width={300}
                            height={150}
                            style={{borderRadius: 5}}
                            src={'https://cdn.evrimagaci.org/3FctySUkVEpsy7_fEqkkEuetuDk=/825x0/filters:format(webp)/storage.evrimagaci.org%2Fold%2Fcontent_media%2Fd3a14f6d8a2f572ffa91fc819c00ab31.jpg'}
                        />
                        <div style={{
                            display: 'flex',
                            flexDirection: 'column',
                            width: '100%',
                            marginLeft: 10
                        }}>
                            <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                                <div style={{display: 'flex', alignItems: 'center'}}>
                                    <Avatar size={'small'}
                                            src={'https://i.pinimg.com/236x/37/ff/22/37ff22cd57f134b13281b197d6604066.jpg'}/>
                                    <b className={'font__assistant'} style={{marginLeft: 5}}>Meryem Ceren Kaplan</b>
                                </div>
                                <Tag bordered={false}>EN</Tag>
                            </div>
                            <b style={{marginTop: 10}} className={'font__assistant'}>What is the Uncanny Valley? Why Do Robots with Human Appearance Annoy Us?</b><br/>
                            <a href={'#'} className={'link'}>See more</a>
                        </div>
                    </div>
                </div>
            </>
        ],
    },
    {
        key: '2',
        label: [
            'Popular' // TODO: translation to be added
        ],
        children: [
            <h2>Popular</h2>
        ]
    }
]

const Blog: React.FC = () => {
    return (
        <div className={'Artado-container'} id={'textContainer'} style={{marginBottom: 30}}>
            <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                <h1 className='title'>Blog</h1>
                <Button
                    type={'default'}
                    href={'/'}
                >
                    Home
                </Button>
            </div>
            <br/>
            <div className={'Artado-row'}>
                <div className={'column-xs-12 column-sm-12 column-md-6 column-lg-6 column-xl-6'}>
                    <Tabs defaultActiveKey="1" items={blogItems}/>
                </div>
                <div
                    className={'column-xs-12 column-sm-12 column-md-5 column-lg-5 column-xl-5 offset-lg-1 offset-md-1 offset-xl-1'}>
                    <div style={{display: 'flex', alignItems: 'center', marginBottom: 30}}>
                        <Avatar size={'large'} src={'https://avatars.githubusercontent.com/u/90653146?v=4'}/>
                        <div style={{
                            display: 'flex',
                            justifyContent: 'space-between',
                            alignItems: 'center',
                            width: '100%',
                            marginLeft: 10
                        }}>
                            <div style={{display: 'flex', alignItems: 'center'}}>
                                <b className={'font__assistant'}>M. Yasin Özkaya</b>
                                <Tag bordered={false} style={{marginLeft: 10}}>Maintainer</Tag>
                            </div>
                            <Tag>Latest blog post</Tag>
                        </div>
                    </div>
                    <Image
                        height={300}
                        width={'100%'}
                        style={{borderRadius: 5}}
                        src="https://cdn.evrimagaci.org/07S3MKZA4EcytnC0OcI5sBewu1k=/825x0/filters:format(webp)/storage.evrimagaci.org%2Fold%2Fcontent_media%2F6c6e05bddf018b6943528d4e5e845901.jpg"/>
                    <p>
                        Kuantum fiziği, genellikle baştan sona göz korkutucu bir saha olarak görülür. Her gün
                        bunlarla uğraşan fizikçilere bile alandaki bazı konular hem ilginç hem de mantıksız gibi
                        görünebilir; fakat kuantum, özünde anlaşılamaz, sınanmamış veya tutarsız bir saha değildir.
                        Tam tersine, insanlığın geliştirdiği en güçlü teorilerden birisi, Kuantum Teorisi'dir.
                        <br/><br/>
                        Eğer kuantum fiziğine ilgi duyuyorsanız ve bilginizi zenginleştirmek istiyorsanız, bu sahada
                        mutlaka haberdar olmanız gereken 6 anahtar kavram olduğunu söyleyebiliriz. Eğer bunları
                        iyice kavrayabilirseniz, kuantum fiziğini daha anlaşılabilir bulmaya başlayacaksınız. Ama
                        uyaralım: Richard Feynman'ın da dediği gibi: "Rahatlıkla söyleyebilirim ki hiç kimse kuantum
                        mekaniğini anlamamaktadır."
                    </p>
                    <b className={'font__assistant bordered-subtitle'}>Tags</b>
                    <div style={{display: 'flex', marginBottom: 20, marginTop: 10}}>
                        <Tag>Quantum</Tag> <Tag>Physic</Tag> <Tag>Computing</Tag>
                    </div>
                    <Button style={{width: '100%'}}> See More </Button>
                </div>
            </div>
        </div>
    );
}

export default Blog;