import { ChevronRight, Heart, MessageCircle, User } from 'lucide-react';
import { Card, CardContent } from '../ui/card';

import { Link } from 'react-router-dom';
import { cn } from '../../lib/utils';

type Props = React.ComponentPropsWithRef<'div'> & {
	id: string;
	postedAt: string;
	postedBy: string;
	comments?: number;
	likes?: number;
	title: string;
	description: string;
	image: string;
	imageAlt: string;
	hasReadMoreButton?: boolean;
};

export default function BlogCard({
	id,
	postedAt,
	postedBy,
	comments,
	likes,
	title,
	description,
	image,
	imageAlt,
	className,
	hasReadMoreButton,
	...props
}: Readonly<Props>) {
	return (
		<Card
			className={cn(
				`flex md:flex-row flex-col bg-none shadow-none p-0 border-0 rounded-none w-full overflow-hidden`,
				className
			)}
			{...props}>
			{/* Left Sidebar */}
			<div className='flex flex-col text-gray-500 text-sm'>
				<div className='flex justify-center items-center bg-rose-700 mx-auto px-4 py-1 border-gray-800 border-b-4 rounded-t-sm w-full text-white text-center'>
					<div className='font-bold text-lg'>{postedAt}</div>
				</div>
				<div className='space-y-2 bg-gray-100 p-1.5'>
					<div className='flex items-center gap-1'>
						<User
							className='fill-gray-300 stroke-0'
							size={16}
						/>
						<span>{postedBy}</span>
					</div>
					{comments && (
						<div className='flex items-center gap-1'>
							<MessageCircle
								className='fill-gray-300 stroke-0'
								size={16}
							/>
							<span>{comments} Comments</span>
						</div>
					)}
					{likes && (
						<div className='flex items-center gap-1'>
							<Heart
								className='fill-gray-300 stroke-0'
								size={16}
							/>
							<span>{likes} Likes</span>
						</div>
					)}
				</div>
			</div>

			{/* Main Content */}
			<CardContent className='flex-1 shadow-none p-6 py-0 border-0'>
				{/* Image */}
				<img
					loading='lazy'
					src={image}
					alt={imageAlt}
					className='mb-4 rounded w-full h-56 object-cover'
				/>

				{/* Title */}
				<h2 className='mb-2 font-bold text-rose-700 text-2xl'>{title}</h2>

				{/* Excerpt */}
				<p className='mb-6 text-gray-700 leading-relaxed'>{description}</p>

				{/* Button */}
				{hasReadMoreButton && (
					<Link
						to={`/blog/${id}`}
						className='flex items-center gap-2 bg-rose-700 hover:bg-rose-700/90 px-4 py-1 border border-rose-700 rounded w-fit text-white'>
						Read More <ChevronRight size={16} />
					</Link>
				)}
			</CardContent>
		</Card>
	);
}
