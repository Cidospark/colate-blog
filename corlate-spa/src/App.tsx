import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/home/home';
import SearchResults from './pages/search-results/search-results';

function App() {
	return (
		<Router>
			<Routes>
				<Route path='/' element={<Home />} />
				<Route path='/search' element={<SearchResults />} />
			</Routes>
		</Router>
	);
}

export default App;
