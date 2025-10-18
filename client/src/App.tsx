import {Route, Routes} from "react-router-dom";
import {NavbarLayout} from "./sharedComponents/navbar/Navbar.tsx";
import {HomePage} from "./pages/home/HomePage.tsx";
import {AboutPage} from "./pages/about/AboutPage.tsx";
import {AuthPage} from "./pages/auth/AuthPage.tsx";
import {FoodLayout} from "./pages/food/FoodLayout.tsx";
import {FoodFeed} from "./pages/food/FoodFeed.tsx";

function App() {

  return (
      <Routes>
          <Route element={<NavbarLayout />}>
              <Route path="/" element={<HomePage />} />
              <Route path="/about" element={<AboutPage />} />

              <Route element={<FoodLayout/>}>
                  <Route path={"/food"} element={<FoodFeed/>}/>
              </Route>
          </Route>
          <Route path ="/Auth" element={<AuthPage/>}/>
      </Routes>
  )
}

export default App
