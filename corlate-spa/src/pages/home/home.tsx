import './home.css';

import BlogSearch from '../../components/blog/blog-search';
import Gallery from '../../components/gallery/gallery';
import PaginatedList from '../../components/PaginationClient';
import TagsList from '../../components/Tags/TagsList';

function Home() {
	return (
		<div className='my-container'>
			<div className='title'>
				<h1>Blogs</h1>
				<div>A simple blog built by devs in training.</div>
			</div>
			<div className='main-area'>
				<div className='left-side'>
					<PaginatedList />
				</div>
				<div className='right-side'>
					<BlogSearch />
					<Gallery />
					<TagsList />
				</div>
			</div>
		</div>
	);
}

export default Home;
