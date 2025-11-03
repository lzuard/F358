import './Navbar.scss'
import { NavLink, Outlet } from "react-router-dom";

function Navbar(){
  return(
    <nav className="navbar">
      <div className="navbar-content">
        <div className="navbar-logo">
          <span className="logo-text">F358</span>
        </div>

        <div className="navbar-items">
          <NavLink to="/" className={({ isActive }) => isActive ? "navbar-item active" : "navbar-item"}>
            Главная
          </NavLink>
          <NavLink to="/recipes" className={({ isActive }) => isActive ? "navbar-item active" : "navbar-item"}>
            Рецепты
          </NavLink>
          <NavLink to="/about" className={({ isActive }) => isActive ? "navbar-item active" : "navbar-item"}>
            О системе
          </NavLink>
        </div>
      </div>
    </nav>
  )
}

export function NavbarLayout(){
  return(
    <div className="navbar-layout">
      <Navbar/>
      <main className="navbar-page">
        <Outlet/>
      </main>
    </div>
  )
}