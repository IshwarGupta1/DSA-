import React from "react";
import '../styles.css';

export default function Footer(){
    const currentYear = new Date().getFullYear();
    return (
        <div className = 'Footer'>
            <footer className = 'footer'>
            <p className = 'footer-text'>
                {currentYear} moviedux, All Rights Reserved.
            </p>
            </footer>
        </div>
    )
};