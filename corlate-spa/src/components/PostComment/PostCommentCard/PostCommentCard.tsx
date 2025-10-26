import React from 'react';
// import { CommentResponse } from '../types/api';
import './PostCommentCard.css'; // Import the CSS
import type { CommentResponse } from '../models/postCommentModels';

// The component receives the comment data as a prop
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
      {/* <footer className="comment-card-footer">
        {/* <small>Comment ID: {comment.id} | Blog ID: {comment.blogId}</small> */}
      {/* </footer> */} 
    </article>
  );
};

export default CommentCard;