import {Navigate, Outlet, Route, Routes} from "react-router-dom";
import {NavbarLayout} from "./sharedComponents/navbar/Navbar.tsx";
import {HomePage} from "./pages/home/HomePage.tsx";
import {AboutPage} from "./pages/about/AboutPage.tsx";
import {AuthPage} from "./pages/auth/AuthPage.tsx";
import {RecipeListPage} from "./pages/recipeList/RecipeList.tsx";


function LoggedInLayout() {
  const token = localStorage.getItem("token");

  if (!token)
    return <Navigate to={"/auth"} replace={true}/>

  return <Outlet/>
}

function LoggedOutLayout() {
  const token = localStorage.getItem("token");
  if (token)
    return <Navigate to={"/"} replace={true}/>

  return <Outlet/>
}

function App() {

  return (
    <Routes>
      <Route element={<LoggedInLayout/>}>
        <Route element={<NavbarLayout/>}>
          <Route path="/" element={<HomePage/>}/>
          <Route path="/about" element={<AboutPage/>}/>
          <Route path={"/recipes"} element={<RecipeListPage/>}/>
        </Route>
      </Route>

      <Route element={<LoggedOutLayout/>}>
        <Route path="/Auth" element={<AuthPage/>}/>
      </Route>
    </Routes>
  )
}

export default App
