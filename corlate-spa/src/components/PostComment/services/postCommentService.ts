// import { ApiResponse, CommentResponse } from "../types/api";

import type { ApiResponse, CommentResponse } from "../models/postCommentModels";

// API base URL from your Swagger UI
export const API_BASE_URL = "http://localhost:5086";

/**
 * Fetches a paginated list of all comments from the API.
 *
 */
export const getAllComments = async (
  page: number = 2,
  size: number = 1
): Promise<ApiResponse<CommentResponse[]>> => {
  // Call the "getAll" endpoint with pagination
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

  // The data type is an array: CommentResponse[]
  const result: ApiResponse<CommentResponse[]> = await response.json();

  if (result.statusCode !== 200 || !result.data) {
    throw new Error(result.message || "Comments not found");
  }

  return result;
};