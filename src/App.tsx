import React from "react";
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Home from './pages';
import Search from './pages/search';
import Manifest from './pages/manifest';
import Contributors from './pages/contributors';
import Changelog from './pages/changelog';

function App() {
  return (
      <>
          <Router>
              <Routes>
                  <Route path={'/'} element={<Home />} />
                  <Route path={'/search'} element={<Search />} />
                  <Route path={'/manifest'} element={<Manifest/>} />
                  <Route path={'/contributors'} element={<Contributors/>} />
                  <Route path={'/changelog'} element={<Changelog/>} />
              </Routes>
          </Router>
      </>
  );
}

export default App;
