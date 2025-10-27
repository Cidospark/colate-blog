export interface ReplyResponse {
  id: string;
  message: string;
  user: string;
  postCommentId: string;
  blogId: string;
}

export interface CommentResponse {
  id: string;
  comment: string;
  user: string;
  blogId: string;
  replies?: CommentResponse[];
}

export interface ApiResponse<T> {
  statusCode: number;
  message: string;
  errors: string[];
  data: T | null;
}
