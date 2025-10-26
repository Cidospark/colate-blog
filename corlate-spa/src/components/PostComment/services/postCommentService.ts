import type {
  ApiResponse,
  CommentResponse,
  ReplyResponse,
} from "../models/postCommentModels";
import { API_BASE_URL } from "./apiBase";

export const getCommentsByBlogId = async (
  blogId: string,
  page: number = 1,
  size: number = 10
): Promise<ApiResponse<CommentResponse[]>> => {
  const response = await fetch(
    `${API_BASE_URL}/comment/blog/${blogId}?page=${page}&size=${size}`
  );

  if (!response.ok) {
    try {
      const errorData: ApiResponse<null> = await response.json();
      throw new Error(errorData.message || "Failed to fetch comments");
    } catch {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
  }

  const result: ApiResponse<CommentResponse[]> = await response.json();

  if (result.statusCode !== 200 || !result.data) {
    throw new Error(result.message || "Comments not found");
  }

  return result;
};

export const getRepliesByBlogId = async (
  blogId: string
): Promise<ApiResponse<ReplyResponse[]>> => {
  const response = await fetch(`${API_BASE_URL}/api/Reply?blogId=${blogId}`);

  if (!response.ok) {
    try {
      const errorData: ApiResponse<null> = await response.json();
      throw new Error(errorData.message || "Failed to fetch replies");
    } catch {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
  }

  const result: ApiResponse<ReplyResponse[]> = await response.json();

  if (result.statusCode !== 200 || !result.data) {
    return { ...result, data: [] } as ApiResponse<ReplyResponse[]>;
  }

  return result;
};
