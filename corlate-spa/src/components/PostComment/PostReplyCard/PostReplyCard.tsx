import React from "react";
import type { CommentResponse } from "../models/postCommentModels";
import { User } from "lucide-react";
import "../PostCommentCard/PostCommentCard.css";

interface ReplyCardProps {
  reply: CommentResponse;
  level: number;
}

const PostReplyCard: React.FC<ReplyCardProps> = ({ reply, level }) => {
  const indentationStyle = {
    marginLeft: `${level * 40}px`,
    marginTop: "16px",
  };

  return (
    <div style={indentationStyle} className="reply-container">
      <article className="comment-card reply-card">
        <header className="comment-card-header">
          <User size={16} className="comment-user-icon" />
          <h3>{reply.user}</h3>
        </header>
        <div className="comment-card-body">
          <p>{reply.comment}</p>
          <button className="reply-action-button">Reply</button>
        </div>
      </article>

      {reply.replies && reply.replies.length > 0 && (
        <div className="nested-replies-section">
          {reply.replies.map((nestedReply) => (
            <PostReplyCard
              key={nestedReply.id}
              reply={nestedReply}
              level={level + 1}
            />
          ))}
        </div>
      )}
    </div>
  );
};

export default PostReplyCard;
