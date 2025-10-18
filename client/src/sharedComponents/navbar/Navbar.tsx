import './Navbar.scss'
import { Outlet, useNavigate} from "react-router-dom";

interface INavbarProps {
    linkTo: string,
    children: React.ReactNode
}

function NavbarItem({linkTo, children}: INavbarProps) {
    const navigate = useNavigate();
    return(
        <button className={"navbarItem"}
                onClick={() => navigate(linkTo)}>
            {children}
        </button>
    )
}

function Navbar(){
    return(
        <nav className={"navbar"}>
            <NavbarItem linkTo="/">Home</NavbarItem>
            <NavbarItem linkTo="/about">About</NavbarItem>
            <NavbarItem linkTo={"/food"}>Food</NavbarItem>
        </nav>
    )
}

export function NavbarLayout(){
    return(
        <div>
            <Navbar/>
            <Outlet/>
        </div>
    )
}