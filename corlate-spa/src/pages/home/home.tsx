import "./home.css";

import PaginatedList from "../../components/PaginationClient";
import Gallery from "../../components/gallery/gallery";

function Home() {
  return (
    <div className="my-container">
      <div className="title">
        <h1>Blogs</h1>
        <div>A simple blog built by devs in training.</div>
      </div>
      <div className="main-area">
        <div className="left-side">
          <PaginatedList />
        </div>
        <div className="right-side">Right side</div>
        <Gallery />
      </div>
    </div>
  );
}

export default Home;
