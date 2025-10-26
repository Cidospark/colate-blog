import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { ArrowLeft } from 'lucide-react';
import BlogCard from './blog/blog-card';
import { BlogLoadingSkeleton } from './blog/blog-loading-skeleton';
import { Button } from './ui/button';
import PostCommentList from './PostComment/PostCommentList/PostCommentList';

export default function BlogDetails() {
	const { id } = useParams<{ id: string }>();
	const navigate = useNavigate();
	const [blog, setBlog] = useState<any>(null);
	const [loading, setLoading] = useState(true);

	useEffect(() => {
		const fetchBlog = async () => {
			try {
				setLoading(true);
				const res = await fetch(`http://localhost:5086/api/v1/Blog/${id}`);
				const data = await res.json();
				setBlog(data.data);
			} catch (err) {
				console.error(err);
			} finally {
				setLoading(false);
			}
		};


		fetchBlog()
	}, [id]);

	if (loading) {
		return (
			<div className='mx-auto px-4 py-10 max-w-5xl'>
				<BlogLoadingSkeleton />
			</div>
		);
	}

	return (
		<div className='mx-auto px-4 py-10 max-w-5xl'>
			<Button
				onClick={() => navigate(-1)}
				className='bg-rose-700 hover:bg-rose-700/90 mb-6 text-white'>
				<ArrowLeft
					size={16}
					className='mr-2'
				/>{' '}
				Back
			</Button>

			<BlogCard
				id={blog.id}
				postedAt='Today'
				postedBy='Admin'
				comments={blog.commentCount}
				likes={blog.postLikesCount}
				title={blog.postTitle || 'Untitled'}
				description={blog.postText}
				image={blog.postPhotoUrl}
				imageAlt={blog.postTitle}
			/>

			<div className="comments-section" style={{ marginTop: '40px' }}>
                {id && <PostCommentList blogId={id} />}
                
            </div>

		</div>
	);
}
