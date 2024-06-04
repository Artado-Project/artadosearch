import React from "react";
import { Button, Tabs } from "antd";
import './../assets/Index.css';
import Basic from "./../components/Settings/BasicSettings";
import Themes from "./../components/Settings/ThemeSettings";

const { TabPane } = Tabs;

const tabContents = [
    {
        key: '0',
        title: 'General',
        content: <Basic />,
        disabled: false,
    },
    {
        key: '1',
        title: 'Themes',
        content: <Themes />,
        disabled: false,
    },
    {
        key: '2',
        title: 'Extensions',
        content: 'Security Settings',
        disabled: false,
    },
    {
        key: '3',
        title: 'Profiles',
        content: 'Security Settings',
        disabled: false,
    },
    {
        key: '4',
        title: 'Widgets',
        content: 'lorem ipsum dolor sit amet',
        disabled: false,
    },
    {
        key: '5',
        title: 'Optics',
        content: 'lorem ipsum dolor sit amet',
        disabled: false,
    }
];

const Settings: React.FC = () => {
    return (
        <div className={'Artado-container'} style={{ lineHeight: '25px' }}>
            <div className={'Artado-container'} style={{lineHeight: '25px'}}>
                <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                    <h1 className='title'>Settings</h1>
                    <Button
                        type={'default'}
                        href={'/'}
                        style={{ textDecoration: 'none' }}
                    >
                        Home
                    </Button>
                </div>
            </div>
            <br />
            <Tabs tabPosition={'top'} type={'card'}>
                {tabContents.map((tabContent) => (
                    <TabPane disabled={tabContent.disabled} tab={tabContent.title} key={tabContent.key}>
                        {tabContent.content}
                    </TabPane>
                ))}
            </Tabs>
        </div>
    );
};

export default Settings;
