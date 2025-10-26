export const baseUrl = "http://localhost:5086/Gallery";

const photosEndpoint = "/photos";

// 🖼 Get featured photos (no pagination params)
export async function getFeaturedPhotos() {
  const res = await fetch(`${baseUrl}${photosEndpoint}`);
  const data = await res.json();
  return data.data;
}

// 🖼 Get all photos with pagination
export async function getAllPhotos(page = 1, size = 12) {
  const res = await fetch(
    `${baseUrl}${photosEndpoint}?page=${page}&size=${size}`
  );
  const data = await res.json();
  console.log("Raw API response:", data);
  return data.data;
}
