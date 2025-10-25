import React from "react";
import "./ArchiveSection.css";

interface ArchiveItemProps {
  month: string;
  count: number;
}

const ArchiveItem: React.FC<ArchiveItemProps> = ({ month, count }) => {
  return (
    <li className="archive-item">
      <a href="#" className="archive-link">
        <span className="arrow">»</span> {month}
      </a>
      <span className="archive-count">({count.toString().padStart(2, "0")})</span>
    </li>
  );
};

export default ArchiveItem;
