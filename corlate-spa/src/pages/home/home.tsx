import "./home.css";
import Gallery from "../../components/gallery/gallery";

function Home() {
  return (
    <div className="my-container">
      <div className="title">
        <h1>Blogs</h1>
        <div>A simple blog built by devs in training.</div>
      </div>
      <div className="main-area">
        <div className="left-side">Left side</div>
        <div className="right-side">
          <p>Right side</p>
          <Gallery />
        </div>
      </div>
    </div>
  );
}

export default Home;
