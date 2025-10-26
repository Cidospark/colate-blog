import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/home/home";
import BlogDetails from "./components/BlogDetails";
import GalleryPage from "./pages/gallery/galleryPage";
import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/home/home";
import BlogDetails from "./components/BlogDetails";
import SearchResults from "./pages/search-results/search-results";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/blog/:id" element={<BlogDetails />} />
        <Route path="/gallery" element={<GalleryPage />} />
        <Route path="/search" element={<SearchResults />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;

// import './App.css'
// import Home from './pages/home/home'

// function App() {

//   return <Home />
// }

// export default App
