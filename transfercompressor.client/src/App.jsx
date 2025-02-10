import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./pages/Layout";
import Index from "./Index";
import Register from "./pages/Register";
import CompressPage from "./pages/CompressPage";
import './App.css';

function App() {


    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<Index />} />
                    <Route path="Register" element={<Register />} />
                    <Route path="CompressPage" element={<CompressPage />} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

export default App;