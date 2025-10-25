// Based on your CorlateBlog.Application.DTOs.Response.CommentResponse
export interface CommentResponse {
  id: string;
  comment: string;
  user: string;
  blogId: string;
}

// Based on your CorlateBlog.Application.Abstractions.ResponseObject
export interface ApiResponse<T> {
  statusCode: number;
  message: string;
  errors: string[];
  data: T | null;
}