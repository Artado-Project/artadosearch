import React from "react";
import {Select, Input, Button, Divider} from "antd";

const BasicSettings: React.FC = () => {
    return (
        <>
            <div style={{marginTop: 20}}>
                <div className={'settings-type'}>
                    <h2 className={'bordered-subtitle'} style={{marginBottom: 30}}>
                        Welcome to Artado Search Settings. <br/>
                        <small style={{fontSize: 15}}>Here you can customize your search engine as you wish.</small>
                    </h2>
                    <Button type={'default'}>Reset Settings</Button>
                </div>
                <Divider type={'horizontal'} className={'font__assistant'}><b>General Settings</b></Divider>
                <div className={'settings-type'}>
                    <h2 className={'bordered-subtitle'} style={{marginBottom: 20}}>
                        Themes<br/>
                        <small style={{fontSize: '12px'}}>
                            You can find more themes in Artado Store. <a href={'/store?type=themes'}>Learn more</a>
                        </small>
                    </h2>
                    <Select defaultValue={'default'} style={{width: 400, height: 38}}>
                        <Select.Option value={'default'}>Default</Select.Option>
                        <Select.Option value={'dark'}>Dark</Select.Option>
                        <Select.Option value={'light'}>Light</Select.Option>
                    </Select>
                </div>
                <br/><br/>
                <div className={'settings-type'}>
                    <h2 className={'bordered-subtitle'} style={{marginBottom: 20}}>
                        Language
                        <br/>
                        <small style={{fontSize: '12px'}}>
                            Change the language you are using Artado Search.
                        </small>
                    </h2>
                    <Select defaultValue={'default'} style={{width: 400, height: 38}}>
                        <Select.Option value={'default'}>Default</Select.Option>
                        <Select.Option value={'dark'}>Dark</Select.Option>
                        <Select.Option value={'light'}>Light</Select.Option>
                    </Select>
                </div>
                <br/><br/>
                <div className={'settings-type'}>
                    <h2 className={'bordered-subtitle'} style={{marginBottom: 20, lineHeight: 1.3}}>
                        Logo
                        <br/>
                        <small style={{fontSize: '12px'}}>
                            You can change Artado Search's logo as you wish. More logos can be found in the store. <a
                            href={'/store?type=logos'}>Learn more</a>
                        </small>
                    </h2>
                    <Select defaultValue={'default'} style={{width: 400, height: 38}}>
                        <Select.Option value={'default'}>Default</Select.Option>
                        <Select.Option value={'dark'}>Dark</Select.Option>
                        <Select.Option value={'light'}>Light</Select.Option>
                    </Select>
                </div>
                <br/><br/>
                <div className={'settings-type'}>
                    <h2 className={'bordered-subtitle'} style={{marginBottom: 20}}>
                        Categories
                        <br/>
                        <small style={{fontSize: '12px'}}>
                            You can change the location of the search categories.
                        </small>
                    </h2>
                    <Select defaultValue={'default'} style={{width: 400, height: 38}}>
                        <Select.Option value={'default'}>Default</Select.Option>
                        <Select.Option value={'dark'}>Dark</Select.Option>
                        <Select.Option value={'light'}>Light</Select.Option>
                    </Select>
                </div>
                <br/><br/>
                <div className={'settings-type'}>
                    <h2 className={'bordered-subtitle'} style={{marginBottom: 20}}>
                        Wallpapers
                        <br/>
                        <small style={{fontSize: '12px'}}>
                            You can change the background of the Artado Search. More wallpapers can be found in the
                            store. <a
                            href={'/store?type=wallpapers'}>Learn more</a>
                        </small>
                    </h2>
                    <div style={{display: "flex"}}>
                        <Input type={'link'} placeholder="Enter a wallpaper link or gif"
                               style={{width: 320, marginRight: 10}} variant="filled"/>
                        <Button type={'default'}>Apply</Button>
                    </div>
                </div>
            </div>
            <br/>
        </>
    )
}

export default BasicSettings;