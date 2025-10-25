import React from 'react';
import './PostCommentCard.css';
import type { CommentResponse } from '../models/postCommentModels';

interface CommentCardProps {
  comment: CommentResponse;
}

const CommentCard: React.FC<CommentCardProps> = ({ comment }) => {
  return (
    <article className="comment-card">
      <header className="comment-card-header">
        <p>Comment from: {comment.user}</p>
      </header>
      <div className="comment-card-body">
        <p>{comment.comment}</p>
      </div>
    </article>
  );
};

export default CommentCard;