import React from "react";
import "./PostCommentCard.css";
import type { CommentResponse } from "../models/postCommentModels";
import { User } from "lucide-react";
import PostReplyCard from "../PostReplyCard/PostReplyCard";

interface CommentCardProps {
  comment: CommentResponse;
}

const CommentCard: React.FC<CommentCardProps> = ({ comment }) => {
  return (
    <div className="top-level-comment-container">
      <article className="comment-card">
        <header className="comment-card-header">
          <User size={16} className="comment-user-icon" />
          <h3>{comment.user}</h3>
          {/* Placeholder for date/time */}
        </header>
        <div className="comment-card-body">
          <p>{comment.comment}</p>
        </div>
      </article>

      {comment.replies && comment.replies.length > 0 && (
        <div className="comment-replies-section">
          {comment.replies.map((reply) => (
            <PostReplyCard key={reply.id} reply={reply} level={1} />
          ))}
        </div>
      )}
    </div>
  );
};

export default CommentCard;
