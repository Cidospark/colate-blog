import './home.css';

import BlogCard from '../../components/blog/blog-card';

function Home() {
	return (
		<div className='my-container'>
			<div className='title'>
				<h1>Blogs</h1>
				<div>A simple blog built by devs in training.</div>
			</div>
			<div className='main-area'>
				<BlogCard
					postedAt='07 Nov'
					postedBy='CEN Smart'
					image='https://plus.unsplash.com/premium_photo-1661770083125-beff7ecc7005?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8YmxvZyUyMGltYWdlJTIwd2l0aCUyMHBlb3BsZXxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&q=60&w=600'
					imageAlt='Meeting'
					title='Learning C# with Mr. Francis Ibeh'
					description='This is a blog post about learning C# with Francis Ibeh'
					likes={29}
					comments={12}
				/>

				<div className='right-side'>Right side</div>
			</div>
		</div>
	);
}

export default Home;
