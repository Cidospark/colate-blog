import React from 'react';
import './PostCommentCard.css'; 
import type { CommentResponse } from '../models/postCommentModels';
import { User } from 'lucide-react';

interface CommentCardProps {
  comment: CommentResponse;
}

const CommentCard: React.FC<CommentCardProps> = ({ comment }) => {
  return (
    <article className="comment-card">
      <header className="comment-card-header">
        <User size={16} className="comment-user-icon" />
        <h3>{comment.user}</h3>
      </header>
      <div className="comment-card-body">
        <p>{comment.comment}</p>
      </div>
    </article>
  );
};

export default CommentCard;