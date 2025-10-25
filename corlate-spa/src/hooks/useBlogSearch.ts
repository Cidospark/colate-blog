import { useState, useCallback } from 'react';
import type { BlogSearchResponse, BlogSearchParams } from '../types/blog.types';
import { BlogSearchService } from '../services/blogSearch.service';

interface UseBlogSearchResult {
  data: BlogSearchResponse | null;
  loading: boolean;
  error: string | null;
  searchBlogs: (params: BlogSearchParams) => Promise<void>;
  refetch: () => Promise<void>;
}

export const useBlogSearch = (initialParams?: BlogSearchParams): UseBlogSearchResult => {
  const [data, setData] = useState<BlogSearchResponse | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const [currentParams, setCurrentParams] = useState<BlogSearchParams>(
    initialParams || { pageNumber: 1, pageSize: 10 }
  );

  const searchBlogs = useCallback(async (params: BlogSearchParams) => {
    setLoading(true);
    setError(null);
    setCurrentParams(params);

    try {
      const result = await BlogSearchService.searchBlogs(params);
      setData(result);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
      setData(null);
    } finally {
      setLoading(false);
    }
  }, []);

  const refetch = useCallback(async () => {
    await searchBlogs(currentParams);
  }, [currentParams, searchBlogs]);

  return { data, loading, error, searchBlogs, refetch };
};
