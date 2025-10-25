import React, { useState, useEffect } from "react";
import type { CommentResponse } from "../models/postCommentModels";
import { getAllComments } from "../services/postCommentService";
import CommentCard from "../PostCommentCard/PostCommentCard";


const SingleCommentPage: React.FC = () => {
  const [comment, setComment] = useState<CommentResponse | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchFirstComment = async () => {
      try {
        setIsLoading(true);
        setError(null);

        const response = await getAllComments(2, 1);

        if (response.data && response.data.length > 0) {
          setComment(response.data[0]);
        } else {
          setError("No comments found.");
        }
      } catch (err) {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError("An unknown error occurred.");
        }
      } finally {
        setIsLoading(false);
      }
    };

    fetchFirstComment();
  }, []); 

  if (isLoading) {
    return <div>Loading comment...</div>;
  }

  if (error) {
    return <div style={{ color: "red" }}>Error: {error}</div>;
  }
  
  return (
    <div>
      {comment ? (
        <CommentCard comment={comment} />
      ) : (
        <div>Comment not found.</div>
      )}
    </div>
  );
};

export default SingleCommentPage;