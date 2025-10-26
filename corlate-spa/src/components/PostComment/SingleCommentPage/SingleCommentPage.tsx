import React, { useState, useEffect } from "react";
import type { CommentResponse } from "../models/postCommentModels";
import { getAllComments } from "../services/postCommentService";
import CommentCard from "../PostCommentCard/PostCommentCard";
// Import the getAllComments service
// import { getAllComments } from "../services/commentService";
// import { CommentResponse } from "../types/api";
// import CommentCard from "../components/CommentCard";

// This component fetches and displays just one comment
const SingleCommentPage: React.FC = () => {
  // State holds a *single* comment, even though the API returns an array
  const [comment, setComment] = useState<CommentResponse | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchFirstComment = async () => {
      try {
        setIsLoading(true);
        setError(null);

        // Call the service, explicitly asking for page 1, size 1
        //
        const response = await getAllComments(2, 1);

        // Check if the data array exists and has at least one item
        if (response.data && response.data.length > 0) {
          // Set the state to the *first* (and only) comment
          setComment(response.data[0]);
        } else {
          // Handle the case where the API returns 200 OK but an empty array
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
  }, []); // Empty array ensures this runs once on mount

  // 1. Handle loading
  if (isLoading) {
    return <div>Loading comment...</div>;
  }

  // 2. Handle error
  if (error) {
    return <div style={{ color: "red" }}>Error: {error}</div>;
  }

  // 3. Handle success or "not found"
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