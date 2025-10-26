import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getFeaturedPhotos } from "../../services/gallery/galleryService";
import "./Gallery.css";

interface Photo {
  id: string;
  postPhotoUrl: string;
}

function Gallery() {
  const [photos, setPhotos] = useState<Photo[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchFeatured = async () => {
      try {
        const data = await getFeaturedPhotos();
        setPhotos(data || []);
      } catch (error) {
        console.error("Error fetching featured photos:", error);
      }
    };

    fetchFeatured();
  }, []);

  return (
    <div className="gallery-container">
      <h3>Our Gallery</h3>
      <div className="gallery-grid">
        {photos.slice(0, 6).map((photo) => (
          <img
            key={photo.id}
            src={photo.postPhotoUrl}
            alt="Gallery Photo"
            className="gallery-img"
          />
        ))}
      </div>
      <button className="view-more-btn" onClick={() => navigate("/gallery")}>
        View More
      </button>
    </div>
  );
}

export default Gallery;
