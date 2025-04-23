/* eslint-disable no-unused-vars */
import React, { useState } from "react";
import './style.css'

const CompressPage = () => {
    const [message, setMessage] = useState("");
    const [compressedVideoURL, setCompressedVideoURL] = useState(null);

    const handleFileUpload = async (event) => {
        const file = event.target.files[0];
        if (!file) return;

        const formData = new FormData();
        formData.append("videoFile", file);

        try {
            const response = await fetch("http://localhost:7063/api/Compress/compress", {
                method: "POST",
                body: formData,
            });

            if (response.ok) {
                const blob = await response.blob();
                setCompressedVideoURL(URL.createObjectURL(blob));
                setMessage("Video succesvol gecomprimeerd!");
            } else {
                setMessage("Compressie mislukt.");
            }
        } catch (error) {
            console.error("Fout bij uploaden:", error);
            setMessage("Er is een fout opgetreden.");
        }
    };

    return (
        <div className = "compress-container">
            <h1 className = "compress-title">Video Uploader</h1>
            <input type="file" accept="video/*" onChange={handleFileUpload}
             className="compress-file-input" />
            <p className = "compress-message">{message}</p>
            {compressedVideoURL && (
                <video
                    controls
                    src={compressedVideoURL}
                    className="compress-video" />
            )}
        </div>
    );
};

export default CompressPage;