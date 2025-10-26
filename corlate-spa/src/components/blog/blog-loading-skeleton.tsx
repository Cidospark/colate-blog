export function BlogLoadingSkeleton() {
	return (
		<div className='grid grid-cols-[auto_1fr]'>
			{/* Aside */}
			<div className='flex flex-col gap-2 p-4 border border-gray-200 rounded-md animate-pulse'>
				<div className='bg-gray-300 rounded w-32 h-6'></div>
				<div className='bg-gray-300 rounded w-32 h-6'></div>
				<div className='bg-gray-300 rounded w-32 h-6'></div>
				<div className='bg-gray-300 rounded w-32 h-6'></div>
			</div>
			<div className='flex flex-col items-center gap-8 p-6'>
				{/* Blog Cards */}
				<div className='gap-8 grid w-full max-w-5xl'>
					<div className='flex flex-col gap-4 p-4 border border-gray-200 rounded-md animate-pulse'>
						<div className='bg-gray-300 rounded w-1/4 h-4'></div>
						<div className='bg-gray-300 rounded w-full h-56'></div>
						<div className='bg-gray-300 rounded w-3/4 h-6'></div>
						<div className='bg-gray-300 rounded w-full h-4'></div>
						<div className='bg-gray-300 rounded w-32 h-10'></div>
					</div>
				</div>
			</div>
		</div>
	);
}
