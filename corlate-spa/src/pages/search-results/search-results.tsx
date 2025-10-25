import { useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import BlogCard from '../../components/blog/blog-card';
import BlogSearch from '../../components/blog/blog-search';
import { useBlogSearch } from '../../hooks/useBlogSearch';
import './search-results.css';

function SearchResults() {
	const [searchParams, setSearchParams] = useSearchParams();
	const searchTerm = searchParams.get('q') || '';
	const page = parseInt(searchParams.get('page') || '1');

	const { data, loading, error, searchBlogs } = useBlogSearch();

	// Fetch results when search term or page changes
	useEffect(() => {
		searchBlogs({
			searchTerm: searchTerm || undefined,
			pageNumber: page,
			pageSize: 10,
		});
	}, [searchTerm, page]);

	const handleSearch = (newSearchTerm: string) => {
		setSearchParams({ q: newSearchTerm, page: '1' });
	};

	const handlePageChange = (newPage: number) => {
		setSearchParams({ q: searchTerm, page: newPage.toString() });
	};

	return (
		<div className='my-container'>
			<div className='title'>
				<h1>Search Results</h1>
				{searchTerm && (
					<div>
						Results for "<strong>{searchTerm}</strong>"
					</div>
				)}
			</div>

			<div className='main-area'>
				<div className='flex flex-col gap-6 w-full'>
					{/* Loading State */}
					{loading && (
						<div className='text-center py-12 text-gray-500'>
							<div className='animate-pulse'>Searching blogs...</div>
						</div>
					)}

					{/* Error State */}
					{error && (
						<div className='bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded'>
							{error}
						</div>
					)}

					{/* No Results */}
					{!loading && data && data.data.length === 0 && (
						<div className='text-center py-12 text-gray-500'>
							<p className='text-lg mb-2'>No blogs found</p>
							{searchTerm && <p className='text-sm'>Try a different search term</p>}
						</div>
					)}

					{/* Search Results */}
					{!loading && data && data.data.length > 0 && (
						<>
							{/* Results info */}
							<div className='text-gray-600 text-sm mb-4'>
								Found {data.totalCount} blog{data.totalCount !== 1 ? 's' : ''} (Page{' '}
								{data.currentPage} of {data.totalPages})
							</div>

							{/* Blog Cards */}
							<div className='flex flex-col gap-8'>
								{data.data.map((blog) => (
									<BlogCard
										key={blog.id}
										postedAt='07 Nov'
										postedBy='John Doe'
										image={blog.postPhotoUrl || 'https://via.placeholder.com/600x400'}
										imageAlt='Blog post image'
										title={blog.postText.substring(0, 100) + '...'}
										description={blog.postText}
										likes={blog.postLikesCount}
										comments={blog.commentCount}
									/>
								))}
							</div>

							{/* Pagination */}
							{data.totalPages > 1 && (
								<div className='flex justify-center items-center gap-4 mt-8'>
									<button
										onClick={() => handlePageChange(data.currentPage - 1)}
										disabled={!data.hasPrevious || loading}
										className='px-4 py-2 bg-rose-700 text-white rounded disabled:bg-gray-300 disabled:cursor-not-allowed hover:bg-rose-800 transition-colors'
									>
										Previous
									</button>
									<span className='text-gray-700'>
										Page {data.currentPage} of {data.totalPages}
									</span>
									<button
										onClick={() => handlePageChange(data.currentPage + 1)}
										disabled={!data.hasNext || loading}
										className='px-4 py-2 bg-rose-700 text-white rounded disabled:bg-gray-300 disabled:cursor-not-allowed hover:bg-rose-800 transition-colors'
									>
										Next
									</button>
								</div>
							)}
						</>
					)}
				</div>

				<div className='right-side'>
					{/* Search Component in Right Sidebar */}
					<BlogSearch onSearch={handleSearch} />
				</div>
			</div>
		</div>
	);
}

export default SearchResults;
