import './FoodLayout.scss'
import {Outlet} from "react-router-dom";

export function FoodLayout() {

    return(
        <div className="container">
            <Outlet />
        </div>
    )
}
