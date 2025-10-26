export interface CommentResponse {
  id: string;
  comment: string;
  user: string;
  blogId: string;
}

export interface ApiResponse<T> {
  statusCode: number;
  message: string;
  errors: string[];
  data: T | null;
}