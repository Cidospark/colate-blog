import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Search } from 'lucide-react';

interface BlogSearchProps {
  onSearch?: (searchTerm: string) => void;
}

export default function BlogSearch({ onSearch }: BlogSearchProps) {
  const [searchTerm, setSearchTerm] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const trimmedSearchTerm = searchTerm.trim();

    if (trimmedSearchTerm) {
      // If onSearch prop is provided, call it (for search results page)
      if (onSearch) {
        onSearch(trimmedSearchTerm);
      } else {
        // Otherwise navigate to search results page (for home page)
        navigate(`/search?q=${encodeURIComponent(trimmedSearchTerm)}`);
      }
    }
  };

  return (
    <form onSubmit={handleSubmit} className="w-full">
      <div className="relative">
        <input
          type="text"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search Here"
          className="w-full px-4 py-3 pr-10 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-rose-700 focus:border-transparent"
        />
        <button
          type="submit"
          className="absolute right-3 top-1/2 transform -translate-y-1/2 text-gray-400 hover:text-gray-600"
        >
          <Search size={20} />
        </button>
      </div>
    </form>
  );
}
