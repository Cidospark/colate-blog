import React, { useEffect, useState } from "react";
import axios from "axios";
import { Card, CardContent } from "../ui/card";
import { User } from "lucide-react";

interface CommentItem {
  id: string;
  comment: string;
  user: string;
  blogId: string;
}

interface ApiResponse {
  statusCode: number;
  message: string;
  errors: string[];
  total: number | null;
  currentPage: number | null;
  totalPages: number | null;
  data: CommentItem[];
}

const RecentComments: React.FC = () => {
  const [comments, setComments] = useState<CommentItem[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchComments = async () => {
      try {
        const response = await axios.get<ApiResponse>(
          "http://localhost:5086/Comment/recent?page=1&size=4"
        );

        if (response.status === 200 && response.data.data) {
          // Show only the first 3 comments
          setComments(response.data.data.slice(0, 3));
        } else {
          setError("No recent comments found.");
        }
      } catch (err) {
        console.error(err);
        setError("Failed to fetch recent comments.");
      } finally {
        setLoading(false);
      }
    };

    fetchComments();
  }, []);

  if (loading)
    return <p className="text-gray-500 text-sm">Loading comments...</p>;

  if (error)
    return (
      <p className="text-red-500 text-sm font-medium bg-red-50 p-2 rounded">
        {error}
      </p>
    );

  return (
    <div className="w-full max-w-md mt-6">
      <h2 className="text-sm font-semibold text-gray-700 uppercase tracking-wide">
        Recent Comments
      </h2>
      <div className="mt-4 space-y-4">
        {comments.map((comment) => (
          <Card key={comment.id} className="shadow-none border-none p-0">
            <CardContent className="flex items-start space-x-3 p-0">
              <div className="flex-shrink-0 bg-gray-300 rounded-sm p-1">
                <User className="size-12 text-gray-400 mt-1 fill-gray-100 stroke-gray-100" />
              </div>
              <div>
                <p className="text-sm text-gray-700">{comment.comment}</p>
                <p className="text-xs text-gray-500 mt-1">
                  By{" "}
                  <span className="text-red-500 font-medium">
                    {comment.user}
                  </span>{" "}
                  on{" "}
                  <span className="text-red-500 font-medium">
                    Blog ID: {comment.blogId.slice(0, 6)}...
                  </span>
                </p>
              </div>
            </CardContent>
          </Card>
        ))}
      </div>
    </div>
  );
};

export default RecentComments;
