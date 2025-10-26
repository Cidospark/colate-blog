import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";

import { ArrowLeft } from "lucide-react";
import BlogCard from "./blog/blog-card";
import { Button } from "./ui/button";


export default function BlogDetails() {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [blog, setBlog] = useState<any>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchBlog = async () => {
      try {
        const res = await fetch(`http://localhost:5086/api/v1/Blog/${id}`);
        const data = await res.json();
        setBlog(data.data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };
    fetchBlog();
  }, [id]);

  if (loading) return <p className="text-center py-10">Loading...</p>;
  if (!blog) return <p className="text-center py-10">No blog found.</p>;

  return (
    <div className="max-w-5xl mx-auto px-4 py-10">
      <Button
        onClick={() => navigate(-1)}
        className="mb-6 bg-rose-700 hover:bg-rose-700/90 text-white"
      >
        <ArrowLeft size={16} className="mr-2" /> Back
      </Button>

      <BlogCard
        id={blog.id}
        postedAt="Today"
        postedBy="Admin"
        comments={blog.commentCount}
        likes={blog.postLikesCount}
        title={blog.postTitle || "Untitled"}
        description={blog.postText}
        image={blog.postPhotoUrl}
        imageAlt={blog.postTitle}
      />
    </div>
  );
}

