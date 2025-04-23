import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import './style.css'


const Register = () => {
    const [formData, setFormData] = useState({
        Naam: "",
        Email: "",
        wachtwoord: "",
    });
    const [isLoading, setIsLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState("");
    const navigate = useNavigate(); // Voor navigatie na registratie

    const handleRegister = async (e) => {
        e.preventDefault();
        setIsLoading(true);
        setErrorMessage(""); // Reset de foutmelding bij nieuwe poging

        try {
            const response = await axios.post(
                "https://localhost:5033/api/Account/register-particulier",
                formData
            );

            alert("Registratie succesvol! Scan de QR-code om tweestapsverificatie in te schakelen.");

            // Stuur de gebruiker door naar de loginpagina
            navigate("/login");
        } catch (error) {
            setErrorMessage(
                error.response?.data?.message || "Serverfout, probeer later opnieuw."
            );
        } finally {
            setIsLoading(false);
        }
    };

    const handleInputChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleKeyPress = (e) => {
        if (e.key === "Enter") {
            e.preventDefault();
            handleRegister(e);
        }
    };

    return (
        <div>
            <h1 className="register-title">Registreer een nieuw account</h1>
            <form onSubmit={handleRegister} className="register-form">
                <input
                    type="text"
                    name="Naam"
                    placeholder="Naam"
                    value={formData.Naam}
                    onChange={handleInputChange}
                    required
                    className="register-input"
                />
                <input
                    type="email"
                    name="Email"
                    placeholder="E-mailadres"
                    value={formData.Email}
                    onChange={handleInputChange}
                    required
                    className="register-input"
                />
                <input
                    type="password"
                    name="wachtwoord"
                    placeholder="Wachtwoord"
                    value={formData.wachtwoord}
                    onChange={handleInputChange}
                    required
                    className="register-input"
                />
                <button type="submit" disabled={isLoading} className = "register-button">
                    {isLoading ? "Registreren..." : "Registreer"}
                </button>
            </form>
            {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
        </div>
    );
};

export default Register;
