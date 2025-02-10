/* eslint-disable no-unused-vars */
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

const Index = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const [userId, setUserId] = useState(null);
    const navigate = useNavigate(); // Hook voor navigatie

    const handleLogin = async (e) => {
        e.preventDefault();
        setIsLoading(true);
        try {
            const payload = { email, password };
            const response = await axios.post("http://localhost:7063/api/User/login", payload);

            if (response.data && response.data.userId) {
                setUserId(response.data.userId);
                navigate("/CompressPage"); // Doorsturen naar compressPage.jsx
            } else {
                alert("Inloggen mislukt.");
            }
        } catch (error) {
            console.error("Fout bij inloggen:", error);
            alert("Inloggen is gefaald, Probeer Opnieuw.");
        } finally {
            setIsLoading(false);
        }
    };

    const handleKeyPress = (e) => {
        if (e.key === "Enter") {
            e.preventDefault();
            handleLogin(e);
        }
    };

    return (
        <div>
            <h1>Welkom bij TransferCompress!</h1>

            <div className="login-container-wrapper">
                <div className="login-container">
                    {!userId ? (
                        <form onSubmit={handleLogin} className="login-form">
                            <h2>Log hier in</h2>
                            <input
                                type="email"
                                placeholder="E-mailadres"
                                value={email}
                                onInput={(e) => setEmail(e.target.value)}
                                className="login-input"
                                onKeyDown={handleKeyPress}
                                aria-label="Vul Emailadres in"
                            />
                            <div className="password-input-wrapper">
                                <input
                                    type="password"
                                    placeholder="Wachtwoord"
                                    value={password}
                                    onInput={(e) => setPassword(e.target.value)}
                                    className="login-input"
                                    onKeyDown={handleKeyPress}
                                    aria-label="Vul wachtwoord in"
                                />
                            </div>
                            <button type="submit" disabled={isLoading}>
                                {isLoading ? "Inloggen..." : "Login"}
                            </button>
                        </form>
                    ) : (
                        <div></div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default Index;
