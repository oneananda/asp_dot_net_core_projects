import React, { useState } from "react";
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [input, setInput] = useState("");
  const [result, setResult] = useState(null);

  const validateString = async () => {
    setResult(null);
    try {
        const response = await fetch("https://localhost:7107/api/validate/string", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(input)
      });

      let message;
      if (response.headers.get("content-type")?.includes("application/json")) {
        const data = await response.json();
        message = data.message || JSON.stringify(data);
      } else {
        message = await response.text();
      }

      if (!response.ok) {
        setResult(message || "Validation failed.");
      } else {
        setResult(message);
      }
    } catch (err) {
      setResult("Error connecting to validation service.");
    }
  };

  return (
    <div>
      <h1>String Validator</h1>
      <input
        type="text"
        value={input}
        onChange={e => setInput(e.target.value)}
        placeholder="Enter string to validate"
      />
      <button onClick={validateString} disabled={!input.trim()}>Validate</button>
      {result && <div>{result}</div>}
    </div>
  );
}

export default App;
