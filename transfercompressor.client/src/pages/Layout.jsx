import { Outlet, Link } from "react-router-dom";
import './style.css'



const Layout = () => {
    return (
        <div className="layout-container">
            <nav className = "sidebar">
                <ul className = "nav-list">
                    <li>
                        <Link to="/">Home</Link>
                    </li>
                    <li>
                        <Link to="/Register">Aanmelden</Link>
                    </li>
                    <li>
                        <Link to="/CompressPage">Compress Pagina</Link>
                    </li>
                </ul>
            </nav>

            <Outlet />
        </div>
    )
};

export default Layout;