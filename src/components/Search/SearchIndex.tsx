import React from 'react';
import SearchWiki from "./sub-components/SearchWiki";
import SearchResult from "./sub-components/SearchResult";

function SearchIndex() {
  return (
      <div className={'Artado-row'} style={{marginTop: 15}}>
          <div className={'column-xs-12 column-sm-12 column-md-7 column-lg-7 column-xl-7'} id={'responsive-end'}>
              <SearchResult/>
          </div>
          <div className={'column-xs-12 column-sm-12 column-md-1 column-lg-1 column-xl-1'} id={'responsive-none'}></div>
          <div className={'column-xs-12 column-sm-12 column-md-4 column-lg-4 column-xl-4'} id={'responsive-first'}>
              <SearchWiki/>
          </div>
      </div>
  );
}

export default SearchIndex;