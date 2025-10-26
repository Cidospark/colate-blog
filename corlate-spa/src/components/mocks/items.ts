// src/mocks/items.ts

export function getMockItems(page: number, limit: number) {
  const allItems = Array.from({ length: 50 }, (_, i) => ({
    id: i + 1,
    name: `Book ${i + 1}`,
  }));

  const start = (page - 1) * limit;
  const end = start + limit;
  const pagedItems = allItems.slice(start, end);

  return {
    data: pagedItems,
    total: allItems.length,
    page,
    limit,
  };
}
