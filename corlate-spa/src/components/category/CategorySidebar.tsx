// src/components/category/CategorySidebar.tsx

import React, { useEffect, useState } from "react";
import { fetchCategories } from "../../lib/utils";
import "./category.css";

interface Category {
  id: string;
  postCategory: string;
  count?: number; // Optional field for demo (number of posts)
}

const CategorySidebar: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [showAll, setShowAll] = useState(false);

  useEffect(() => {
    fetchCategories()
      .then((data) => {
        const cats = Array.isArray(data.data) ? data.data : [];
        // Group categories by postCategory and count occurrences
        const grouped: { [key: string]: Category } = {};
        cats.forEach((cat: Category) => {
          if (grouped[cat.postCategory]) {
            grouped[cat.postCategory].count =
              (grouped[cat.postCategory].count || 1) + 1;
          } else {
            grouped[cat.postCategory] = { ...cat, count: 1 };
          }
        });
        setCategories(Object.values(grouped));
      })
      .catch((err) => {
        console.error("Failed to fetch categories:", err);
      });
  }, []);

  const displayedCategories = showAll ? categories : categories.slice(0, 4);

  return (
    <div className="category-container">
      <h3 className="category-title">CATEGORIES</h3>
      <ul className="category-list">
        {displayedCategories.map((cat) => (
          <li key={cat.id} className="category-item">
            <span className="category-name">{cat.postCategory}</span>
            <span className="category-count">
              {cat.count?.toString().padStart(2, "0")}
            </span>
          </li>
        ))}
      </ul>
      {categories.length > 4 && (
        <button
          className="show-more-btn"
          onClick={() => setShowAll((prev) => !prev)}
        >
          {showAll ? "Show Less" : "Show More"}
        </button>
      )}
    </div>
  );
};

export default CategorySidebar;
