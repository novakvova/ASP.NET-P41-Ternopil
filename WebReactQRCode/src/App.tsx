import {Route, Routes} from "react-router";
import Main from "./screens/main/Main.tsx";

const App = () => {
  return (
      <>
          <Routes>
              <Route path="/">
                  <Route index element={<Main/>}/>
              </Route>
          </Routes>
      </>
  );
}

export default App;