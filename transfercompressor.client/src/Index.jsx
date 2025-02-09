import { useState } from "react";
import { Link } from "react-router-dom";

const Index = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const [userId, setUserId] = useState(null);

    const handleLogin = (e) => {
        e.preventDefault();
        // Add login logic here
    };

    const handleKeyPress = (e) => {
        if (e.key === "Enter") {
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
