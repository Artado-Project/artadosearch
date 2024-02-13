import React, { useState } from "react";
import {Alert, Button, Card, Checkbox, List} from "antd";

const data = [
    {
        title: 'Oppenheimer Theme',
        description: [
            <>
                This theme is created by <a href={'/'}>yasinldev</a>. You can find more themes in artado store or write your costum css file and upload it to Artado Search.
            </>
        ]
    },
    {
        title: 'Turkish Theme',
        description: [
            <>
                This theme is created by <a href={'/'}>yasinldev</a>. You can find more themes in artado store or write your costum css file and upload it to Artado Search.
            </>
        ]
    },
    {
        title: 'Ultra Dark Theme',
        description: [
            <>
                This theme is created by <a href={'/'}>yasinldev</a>. You can find more themes in artado store or write your costum css file and upload it to Artado Search.
            </>
        ]
    },
    {
        title: 'Ultra Light Theme',
        description: [
            <>
                This theme is created by <a href={'/'}>yasinldev</a>. You can find more themes in artado store or write your costum css file and upload it to Artado Search.
            </>
        ]
    },
];

const { Meta } = Card;

const ThemeSettings: React.FC = () => {
    const [code, setCode] = React.useState<string>(
        `function add(a, b) {\n  return a + b;\n}`
    );

    return (
        <>
            <Alert
                message="Information"
                description="You can find more themes in artado store or write your costum css file and upload it to Artado Search."
                type="info"
                showIcon
            />
            <div style={{marginTop: 20}}>
                <div className={'settings-type'}>
                    <Card title="Themes currently used" style={{ minWidth: 550, overflowY: "scroll",  }} bordered={true} actions={[
                        <Button color={'orange'} type={'primary'}>Use Theme</Button>,
                        <Button color={'red'} type={'dashed'}>Delete Theme</Button>,
                        <Button type={'default'}>Create Theme</Button>,
                    ]}>
                        <div
                            style={{ maxHeight: 300,  overflowY: "scroll" }}
                        >
                            <List
                                style={{ marginTop: '-15px' }}
                                itemLayout="horizontal"
                                dataSource={data}
                                renderItem={(item, index) => (
                                    <List.Item
                                        actions={[
                                            <Checkbox value={'check'} />,
                                        ]}
                                    >
                                        <List.Item.Meta
                                            title={<a href={'/'}>{item.title}</a>}
                                            description={item.description}
                                        />
                                    </List.Item>
                                )}
                            />
                        </div>
                    </Card>
                    <Card style={{ minWidth: 550, }} actions={[
                        <Button color={'orange'} style={{ width: '90%' }} type={'dashed'}>Artado IDE</Button>,
                    ]}>
                        <Meta
                            title="Artado IDE"
                            description="Creating stunning themes in Artado has never been easier, thanks to the user-friendly Artado IDE. If you're eager to craft your own unique theme effortlessly, simply access the IDE screen by clicking on the link below!"
                        />
                    </Card>
                </div>
            </div>
        </>
    );
}

export default ThemeSettings;