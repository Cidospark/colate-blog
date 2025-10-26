import React, { useState, useEffect } from "react";
import type {
  CommentResponse,
  ReplyResponse,
} from "../models/postCommentModels";
import {
  getCommentsByBlogId,
  getRepliesByBlogId,
} from "../services/postCommentService";
import CommentCard from "../PostCommentCard/PostCommentCard";
import "./PostCommentList.css";

interface CommentListProps {
  blogId: string;
}

const nestReplies = (
  comments: CommentResponse[],
  replies: ReplyResponse[]
): CommentResponse[] => {
  const repliesByParent = replies.reduce((acc, reply) => {
    const parentId = reply.postCommentId;
    if (!acc[parentId]) {
      acc[parentId] = [];
    }
    acc[parentId].push({
      id: reply.id,
      comment: reply.message,
      user: reply.user,
      blogId: reply.blogId,
      replies: [],
    } as CommentResponse);
    return acc;
  }, {} as Record<string, CommentResponse[]>);

  return comments.map((comment) => {
    const nestedReplies = repliesByParent[comment.id] || [];

    return {
      ...comment,
      replies: nestedReplies,
    };
  });
};

const PostCommentList: React.FC<CommentListProps> = ({ blogId }) => {
  const [comments, setComments] = useState<CommentResponse[]>([]);
  const [commentsLoading, setCommentsLoading] = useState(true);
  const [commentsError, setCommentsError] = useState<string | null>(null);

  useEffect(() => {
    if (!blogId) {
      setCommentsLoading(false);
      setCommentsError("No Blog ID provided.");
      return;
    }

    const fetchAllData = async () => {
      try {
        setCommentsLoading(true);
        setCommentsError(null);

        const [commentsResponse, repliesResponse] = await Promise.all([
          getCommentsByBlogId(blogId),
          getRepliesByBlogId(blogId),
        ]);

        const topLevelComments = commentsResponse.data || [];
        const allReplies = repliesResponse.data || [];

        const nestedComments = nestReplies(topLevelComments, allReplies);

        setComments(nestedComments);
      } catch (err) {
        if (err instanceof Error) {
          setCommentsError(err.message);
        } else {
          setCommentsError("Failed to load comments and replies.");
        }
      } finally {
        setCommentsLoading(false);
      }
    };

    fetchAllData();
  }, [blogId]);

  if (commentsLoading) {
    return <div>Loading comments...</div>;
  }

  if (commentsError) {
    return <div style={{ color: "red" }}>Error: {commentsError}</div>;
  }

  const totalComments = comments.reduce((count, comment) => {
    return count + 1 + (comment.replies?.length || 0);
  }, 0);

  return (
    <div className="comment-list">
      <h3 className="comment-count-header">
        {totalComments} {totalComments === 1 ? "Comment" : "Comments"}
      </h3>

      {comments.length > 0 ? (
        comments.map((comment) => (
          <CommentCard key={comment.id} comment={comment} />
        ))
      ) : (
        <div>No comments found for this post.</div>
      )}
    </div>
  );
};

export default PostCommentList;
