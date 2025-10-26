'use client';

import { useEffect, useState } from 'react';
import BlogCard from './blog/blog-card';


interface Blog {
	id: string;
	postText: string;
	postTitle: string;
	postPhotoUrl: string;
	postLikesCount: number;
	commentCount: number;
}

interface ApiResponse<T> {
	statusCode: number;
	message: string;
	total: number;
	totalPages: number;
	data: T[];
}

export default function BlogList() {
	const [data, setData] = useState<Blog[]>([]);
	const [page, setPage] = useState(1);
	const [totalPages, setTotalPages] = useState(1);
	const size = 10; // items per page

	useEffect(() => {
		async function fetchBlogs() {
			try {
				const res = await fetch(
					`http://localhost:5086/api/v1/Blog?page=${page}&size=${size}`
				);
				if (!res.ok) throw new Error('Failed to fetch blogs');
				const json: ApiResponse<Blog> = await res.json();
				setData(json.data);
				setTotalPages(json.totalPages);
			} catch (err) {
				console.error(err);
			}
		}
		fetchBlogs();
	}, [page]);

	return (
		<div className='flex flex-col items-center gap-8 p-6'>
			{/* Blog Cards */}
			<div className='grid gap-8 w-full max-w-5xl'>
				{data.map((blog) => (
					<BlogCard
						key={blog.id}
                        id={blog.id}
						postedAt={new Date().toLocaleDateString()} // Replace with real date when backend provides it
						postedBy='Admin' // Replace with real author if available
						comments={blog.commentCount}
						likes={blog.postLikesCount}
						title={blog.postTitle || 'Untitled Blog'}
						description={blog.postText}
						image={blog.postPhotoUrl}
						imageAlt={blog.postTitle || 'Blog image'}
						hasReadMoreButton
					/>
				))}
			</div>

			{/* Pagination Controls */}
			<div className='flex items-center gap-2 mt-4'>
				<button
					onClick={() => setPage((p) => Math.max(1, p - 1))}
					disabled={page === 1}
					className='px-3 py-1 border border-rose-700 text-rose-700 rounded disabled:opacity-40'>
					← Previous
				</button>

				{[...Array(totalPages)].map((_, i) => {
					const pageNumber = i + 1;
					return (
						<button
							key={i}
							onClick={() => setPage(pageNumber)}
							className={`px-3 py-1 rounded border transition ${
								page === pageNumber
									? 'bg-rose-700 text-white'
									: 'border-rose-700 text-rose-700 hover:bg-rose-100'
							}`}>
							{pageNumber}
						</button>
					);
				})}

				<button
					onClick={() => setPage((p) => Math.min(totalPages, p + 1))}
					disabled={page === totalPages}
					className='px-3 py-1 border border-rose-700 text-rose-700 rounded disabled:opacity-40'>
					Next →
				</button>
			</div>
		</div>
	);
}




//The following is the previous code before editing: a loading skeleton (e.g. shimmer effect while fetching)

// "use client";

// import { useEffect, useState } from "react";
// import BlogCard from "./blog/blog-card";

// interface Blog {
//   id: string;
//   postText: string;
//   postTitle: string;
//   postPhotoUrl: string;
//   postLikesCount: number;
//   commentCount: number;
// }

// interface ApiResponse<T> {
//   statusCode: number;
//   message: string;
//   total: number;
//   totalPages: number;
//   data: T[];
// }

// export default function BlogList() {
//   const [data, setData] = useState<Blog[]>([]);
//   const [page, setPage] = useState(1);
//   const [totalPages, setTotalPages] = useState(1);
//   const [loading, setLoading] = useState(true);
//   const size = 5; // items per page

//   useEffect(() => {
//     async function fetchBlogs() {
//       setLoading(true);
//       try {
//         const res = await fetch(
//           `http://localhost:5086/api/v1/Blog?page=${page}&size=${size}`
//         );
//         if (!res.ok) throw new Error("Failed to fetch blogs");
//         const json: ApiResponse<Blog> = await res.json();
//         setData(json.data);
//         setTotalPages(json.totalPages);
//       } catch (err) {
//         console.error(err);
//       } finally {
//         setLoading(false);
//       }
//     }
//     fetchBlogs();
//   }, [page]);

//   return (
//     <div className="flex flex-col items-center gap-8 p-6">
//       {/* Blog Cards */}
//       <div className="grid gap-8 w-full max-w-5xl">
//         {loading
//           ? // Show shimmer skeletons while loading
//             Array.from({ length: size }).map((_, i) => (
//               <div
//                 key={i}
//                 className="animate-pulse flex flex-col gap-4 p-4 border border-gray-200 rounded-md"
//               >
//                 <div className="bg-gray-300 h-4 w-1/4 rounded"></div>
//                 <div className="bg-gray-300 h-56 w-full rounded"></div>
//                 <div className="bg-gray-300 h-6 w-3/4 rounded"></div>
//                 <div className="bg-gray-300 h-4 w-full rounded"></div>
//                 <div className="bg-gray-300 h-10 w-32 rounded"></div>
//               </div>
//             ))
//           : // Show actual data
//             data.map((blog) => (
//               <BlogCard
//                 key={blog.id}
//                 postedAt={new Date().toLocaleDateString()}
//                 postedBy="Admin"
//                 comments={blog.commentCount}
//                 likes={blog.postLikesCount}
//                 title={blog.postTitle || "Untitled Blog"}
//                 description={blog.postText}
//                 image={blog.postPhotoUrl}
//                 imageAlt={blog.postTitle || "Blog image"}
//               />
//             ))}
//       </div>

//       {/* Pagination Controls */}
//       <div className="flex items-center gap-2 mt-4">
//         <button
//           onClick={() => setPage((p) => Math.max(1, p - 1))}
//           disabled={page === 1 || loading}
//           className="px-3 py-1 border border-rose-700 text-rose-700 rounded disabled:opacity-40"
//         >
//           ← Previous
//         </button>

//         {[...Array(totalPages)].map((_, i) => {
//           const pageNumber = i + 1;
//           return (
//             <button
//               key={i}
//               onClick={() => !loading && setPage(pageNumber)}
//               className={`px-3 py-1 rounded border transition ${
//                 page === pageNumber
//                   ? "bg-rose-700 text-white"
//                   : "border-rose-700 text-rose-700 hover:bg-rose-100"
//               }`}
//             >
//               {pageNumber}
//             </button>
//           );
//         })}

//         <button
//           onClick={() => setPage((p) => Math.min(totalPages, p + 1))}
//           disabled={page === totalPages || loading}
//           className="px-3 py-1 border border-rose-700 text-rose-700 rounded disabled:opacity-40"
//         >
//           Next →
//         </button>
//       </div>
//     </div>
//   );
// }
