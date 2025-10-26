import axios, { AxiosError } from 'axios';
import type { BlogSearchResponse, BlogSearchParams } from '../types/blog.types';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5086';
const BLOG_SEARCH_ENDPOINT = `${API_BASE_URL}/api/v1/BlogSearch`;

export class BlogSearchService {
  /**
   * Search for blogs with optional filters and pagination
   */
  static async searchBlogs(params: BlogSearchParams = {}): Promise<BlogSearchResponse> {
    try {
      const { searchTerm, pageNumber = 1, pageSize = 10 } = params;

      const response = await axios.get<BlogSearchResponse>(BLOG_SEARCH_ENDPOINT, {
        params: {
          searchTerm: searchTerm || undefined, // Don't send if empty
          pageNumber,
          pageSize,
        },
      });

      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error)) {
        const axiosError = error as AxiosError<{ message: string }>;
        throw new Error(
          axiosError.response?.data?.message || 'Failed to search blogs'
        );
      }
      throw error;
    }
  }
}
