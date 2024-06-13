import ArtadoHeader from "../components/Index/ArtadoHeader";
import ArtadoFooter from "../components/Index/ArtadoFooter";
import ArtadoSearchBar from "../components/Index/ArtadoSearchBar";
import ArtadoSection from "../components/Index/ArtadoSection";
import ArtadoAlerts from "../components/Index/ArtadoAlerts";

import './../assets/Index.css';

import React from "react";
import {Alert} from "antd";

function Index() {
    return (
        <>
            <div className="Artado-container is-fluid" style={{margin: "10px"}}>
                <ArtadoHeader/>
                <div style={{marginTop: '100px'}}>
                    <ArtadoSearchBar/>
                </div>
                <ArtadoAlerts/>
                <ArtadoSection/>
                <ArtadoFooter/>
            </div>
        </>
    );
}

export default Index;
