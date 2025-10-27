export interface ArchiveResponse {
  statusCode: number;
  message: string;
  errors: string[];
  data: {
    year: number;
    month: string;
    count: number;
  }[];
}

export const fetchArchives = async (): Promise<ArchiveResponse> => {
  const response = await fetch("http://localhost:5086/archive", {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  });

  if (!response.ok) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }

  const data: ArchiveResponse = await response.json();
  return data;
};
