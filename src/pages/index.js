import ArtadoHeader from "./../components/Index/ArtadoHeader";
import ArtadoFooter from "./../components/Index/ArtadoFooter";
import ArtadoSearchBar from "./../components/Index/ArtadoSearchBar";
import ArtadoSection from "./../components/Index/ArtadoSection";

import './../assets/Index.css';

function Index() {
    return (
        <div className="Artado-container is-fluid" style={{ margin: "10px" }}>
            <ArtadoHeader />
            <div style={{marginTop: '100px'}}>
                <ArtadoSearchBar/>
            </div>
            <ArtadoSection />
            <ArtadoFooter />
        </div>
    );
}

export default Index;
