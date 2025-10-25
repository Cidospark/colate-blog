import type { ApiResponse, CommentResponse } from "../models/postCommentModels";

export const API_BASE_URL = "http://localhost:5086";

export const getAllComments = async (
  page: number = 2,
  size: number = 1
): Promise<ApiResponse<CommentResponse[]>> => {
  const response = await fetch(
    `${API_BASE_URL}/comment?page=${page}&size=${size}`
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