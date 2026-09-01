import {Route, Routes} from "react-router";
import Main from "./screens/main/Main.tsx";
import Header from "./components/Header.tsx";
import Login from "./screens/login/Login.tsx";
import Register from "./screens/register/Register.tsx";
import Profile from "./screens/profile/Profile.tsx";
import QRCodeCreate from "./screens/qr-code/create/QRCodeCreate.tsx";

const App = () => {
  return (
      <>
          <Header/>
          <Routes>
              <Route path="/">
                  <Route index element={<Main/>}/>
                  <Route path={"login"} element={<Login/>}/>
                  <Route path={"register"} element={<Register/>}/>
                  <Route path={"profile"} element={<Profile/>}/>
                  <Route path={"qr-code"}>
                      <Route path={"create"} element={<QRCodeCreate/>}/>
                  </Route>
              </Route>
          </Routes>
      </>
  );
}

export default App;