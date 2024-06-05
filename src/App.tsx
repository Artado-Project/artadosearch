import React from "react";
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Home from './pages';
import Search from './pages/search';

// Static Pages
import Manifest from './pages/statics/manifest';
import Settings from './pages/settings';
import About from './pages/statics/about';
import Help from './pages/statics/help';
import PrivacyPolicy from "./pages/statics/privacy-policy";
import Donation from "./pages/statics/donation";
import Blog from "./pages/blog";
import Error404 from './pages/errors/404';

function App() {
  return (
      <>
          <Router>
              <Routes>
                  <Route path={'/'} element={<Home />} />
                  <Route path={'/search'} element={<Search />} />
                  <Route path={'/donation'} element={<Donation />} />
                  <Route path={'/manifest'} element={<Manifest/>} />
                  <Route path={'/settings'} element={<Settings />} />
                  <Route path={'/about'} element={<About />} />
                  <Route path={'/help'} element={<Help />} />
                  <Route path={'/privacy-policy'} element={<PrivacyPolicy />} />
                  <Route path={'/blog'} element={<Blog />} />
                  <Route path={'*'} element={<Error404 />} />
              </Routes>
          </Router>
      </>
  );
}

export default App;
