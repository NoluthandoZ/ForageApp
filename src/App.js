import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Navbar from "./component/Navbar";
import Freelancer from "./pages/freelancer";
import Signup from "./pages/signup";
import Vacancy from "./pages/vacancy";
import CreateVacancy from "./pages/createVacancy";
import CreateFreelancer from "./pages/createFreelancer";
import Login from "./pages/login";
function App() {
  return (
    <Router>
      <Navbar />
          <Routes>
              <Route path="/freelancer" element={<Freelancer />} />
              <Route path="/" element={<Login />} />
              <Route path="/vacancy" element={<Vacancy />} />
              <Route path="/signup" element={<Signup />} />
              <Route path="/createVacancy" element={<CreateVacancy />} />
              <Route path="/createFreelancer" element={<CreateFreelancer />} />
          </Routes>
    </Router>
  );
}
export default App;