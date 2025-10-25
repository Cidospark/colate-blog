import React, { useEffect, useState } from "react";
import ArchiveItem from "./ArchiveItem";
import "./ArchiveSection.css";
import { fetchArchives } from "./archiveApi";

interface Archive {
  year: number;
  month: string;
  count: number;
}

const ArchiveSection: React.FC = () => {
  const [archives, setArchives] = useState<Archive[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>("");

  useEffect(() => {
    const loadArchives = async () => {
      try {
        const result = await fetchArchives();

        if (result.statusCode === 200 && Array.isArray(result.data)) {
          setArchives(result.data);
        } else {
          setError("Unexpected response format");
        }
      } catch (err: unknown) {
        setError((err as Error).message || "Failed to fetch archives");
      } finally {
        setLoading(false);
      }
    };

    loadArchives();
  }, []);

  if (loading) {
    return (
      <section className="archive-section">
        <h3 className="archive-title">Archive</h3>
        <p className="loading-text">Loading...</p>
      </section>
    );
  }

  if (error) {
    return (
      <section className="archive-section">
        <h3 className="archive-title">Archive</h3>
        <p className="error-text">{error}</p>
      </section>
    );
  }

  return (
    <section className="archive-section">
      <h3 className="archive-title">Archive</h3>
      <ul className="archive-list">
        {archives.length > 0 ? (
          archives.map((item) => (
            <ArchiveItem
              key={`${item.month}-${item.year}`}
              month={`${item.month} ${item.year}`}
              count={item.count}
            />
          ))
        ) : (
          <p className="no-data-text">No archives found</p>
        )}
      </ul>
    </section>
  );
};

export default ArchiveSection;
