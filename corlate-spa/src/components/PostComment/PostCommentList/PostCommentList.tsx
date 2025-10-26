import React, { useState, useEffect } from 'react';
import type { CommentResponse } from '../models/postCommentModels';
import { getCommentsByBlogId } from '../services/postCommentService';
import CommentCard from '../PostCommentCard/PostCommentCard';
import './PostCommentList.css';

interface CommentListProps {
  blogId: string;
}

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

    const fetchComments = async () => {
      try {
        setCommentsLoading(true);
        setCommentsError(null);
        

        const response = await getCommentsByBlogId(blogId);
        
        if (response.data) {
          setComments(response.data);
        }
      } catch (err) {
        if (err instanceof Error) {
          setCommentsError(err.message);
        } else {
          setCommentsError("Failed to load comments.");
        }
      } finally {
        setCommentsLoading(false);
      }
    };

    fetchComments();
  }, [blogId]); 

  if (commentsLoading) {
    return <div>Loading comments...</div>;
  }

  if (commentsError) {
    return <div style={{ color: 'red' }}>Error: {commentsError}</div>;
  }

  return (
    <div className="comment-list">

        <h3 className="comment-count-header">
        {comments.length} {comments.length === 1 ? 'Comment' : 'Comments'}
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