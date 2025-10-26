// Individual blog item in search results
export interface BlogSearchItem {
  id: string;
  postText: string;
  postPhotoUrl: string;
  postLikesCount: number;
  commentsReplies: number;
  commentCount: number;
  postTags: string[];
  postCategories: string[];
}

// Paginated response from API
export interface BlogSearchResponse {
  data: BlogSearchItem[];
  currentPage: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  hasPrevious: boolean;
  hasNext: boolean;
}

// Search request parameters
export interface BlogSearchParams {
  searchTerm?: string;
  pageNumber?: number;
  pageSize?: number;
}
