import { useEffect, useState } from "react";
import { getAllPhotos } from "../../services/gallery/galleryService";
import "./galleryPage.css";
import { useNavigate } from "react-router-dom";

const GalleryPage = () => {
  const [photos, setPhotos] = useState<any[]>([]);
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(true);
  const size = 12;
  const navigate = useNavigate();

  useEffect(() => {
    const fetchPhotos = async () => {
      setLoading(true);
      try {
        const data = await getAllPhotos(page, size); // backend returns 12 per page
        setPhotos(data || []);
      } catch (error) {
        console.error("Error fetching photos:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchPhotos();
  }, [page]);

  const handlePrevious = () => setPage((prev) => Math.max(prev - 1, 1));
  const handleNext = () => {
    if (photos.length === size) {
      setPage((prev) => prev + 1);
    }
  };

  return (
    <div className="gallerypage-container">
      <h2 className="gallery-title">Gallery</h2>

      <div className="gallery-grid">
        {loading ? (
          <p>Loading photos...</p>
        ) : photos.length > 0 ? (
          photos.map((photo) => (
            <div key={photo.id} className="gallery-item">
              <img
                src={photo.postPhotoUrl}
                alt={photo.title || "Gallery Photo"}
              />
            </div>
          ))
        ) : (
          <p>No photos available.</p>
        )}
      </div>

      <div className="gallery-footer">
        <button className="back-btn" onClick={() => navigate("/")}>
          ← Back to Home
        </button>

        <div className="pagination">
          <button onClick={handlePrevious} disabled={page === 1}>
            ← Previous
          </button>

          {[...Array(photos.length === size ? page + 1 : page)].map(
            (_, index) => {
              const pageNum = index + 1;
              return (
                <button
                  key={pageNum}
                  className={`page-btn ${page === pageNum ? "active" : ""}`}
                  onClick={() => setPage(pageNum)}
                >
                  {pageNum}
                </button>
              );
            }
          )}

          <button onClick={handleNext} disabled={photos.length < size}>
            Next →
          </button>
        </div>
      </div>
    </div>
  );
};

export default GalleryPage;
