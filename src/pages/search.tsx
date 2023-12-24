import React from 'react';
import SearchHeader from '../components/Search/SearchHeader';
import SearchWiki from "../components/Search/SearchWiki";

import './../assets/Index.css';

function Search() {
  return (
    <div className={'Artado-container is-fluid'} style={{ margin: '10px' }}>
      <SearchHeader />
      <div className={'Artado-row'} style={{ marginTop: 50 }}>
          <div className={'column-xs-12 column-sm-12 column-md-8 column-lg-8 column-xl-8'}>
          </div>
          <div className={'column-xs-12 column-sm-12 column-md-4 column-lg-4 column-xl-4'}>
              <SearchWiki />
          </div>
      </div>
    </div>
  );
}

export default Search;