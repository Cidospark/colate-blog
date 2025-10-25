import { clsx, type ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}

// Fetch categories from backend API
export async function fetchCategories() {
  const response = await fetch("http://localhost:5086/Category/all");
  if (!response.ok) {
    throw new Error("Failed to fetch categories");
  }
  return response.json();
}
