// import PostCommentList from "../../components/PostComment/PostCommentList/PostCommentList";
import SingleCommentPage from "../../components/PostComment/SingleCommentPage/SingleCommentPage";
// import PostCommentDetailPage from "../../components/PostComment/SingleCommentPage/SingleCommentPage";
import "./home.css"

function Home(){
    return <div className="my-container">
        <div className="title">
            <h1>Blogs</h1>
            <div>A simple blog built by devs in training.</div>
        </div>
        <div className="main-area">
            <div className="left-side">{<SingleCommentPage />}</div>
            <div className="right-side">Right side</div>
        </div>
    </div>
}

export default Home;