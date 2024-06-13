import React from 'react';
import SearchHeader from '../components/Search/sub-components/SearchHeader';
import SearchIndex from "../components/Search/SearchIndex";
import SearchImage from "../components/Search/SearchImage";

const Search: React.FC = () => {
    const urlParams = new URLSearchParams(window.location.search);
    const search = urlParams.get('type');

    let searchContent;
    if (search === 'images') {
        searchContent = <SearchImage />;
    } else {
        searchContent = <SearchIndex />;
    }

    return (
        <>
            <div className={'Artado-container is-fluid'} style={{margin: "10px"}}>
                <SearchHeader />
                {searchContent}
            </div>
        </>
    )
}

export default Search;
