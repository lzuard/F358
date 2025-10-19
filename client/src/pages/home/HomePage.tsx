import {Button} from "../../sharedComponents/button/Button.tsx";
import {useNavigate} from "react-router-dom";

export function HomePage() {
  const navigate = useNavigate();

  function onClick(){
    localStorage.removeItem("token");
    navigate("/auth");
  }

  return (
    <>
      <h1>Home page</h1>
      <Button text={"Выйти из аккаунта"} onClick={onClick}/>
    </>
  )
}