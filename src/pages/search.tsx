import React from 'react';
import SearchHeader from '../components/Search/SearchHeader';

import './../assets/Index.css';

function Search() {
  return (
    <div className={'Artado-container is-fluid'} style={{ margin: '10px' }}>
      <SearchHeader />
    </div>
  );
}

export default Search;