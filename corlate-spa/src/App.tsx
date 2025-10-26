import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/home/home';
import BlogDetails from './components/BlogDetails';


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/blog/:id" element={<BlogDetails />} />
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
