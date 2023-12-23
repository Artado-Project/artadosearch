import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Home from './pages/index';
import Search from './pages/search';

function App() {
  return (
      <>
          <Router>
              <Routes>
                  <Route path={'/'} element={<Home />} />
                  <Route path={'/search'} element={<Search />} />
              </Routes>
          </Router>
      </>
  );
}

export default App;
