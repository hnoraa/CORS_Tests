import React from 'react';
import { useState, useEffect } from 'react';
import logo from './logo.svg';
import './App.css';

interface Payload {
    route: string,
    message: string
}

function App() {
    const [data, setData] = useState<Payload>({ route: "", message: "" });
    const [error, setError] = useState<Error>();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetch("http://localhost:82/hello")
            .then((response) => {
                if (!response.ok) {
                    throw new Error(`Non-Ok Response from api. Code: ${response.status}. Text: ${response.statusText}`);
                }
                return response.json();
            })
            .then((json) => {
                setData(json);
            })
            .catch((err) => {
                console.error(`catch: ${err}`);
                setError(err);
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);
  return (
      <div className="App">
          {loading && <div className="Loading">Loading...</div> }
          {error && (
              <div className="Error">
                  Error:<br />
                  {error.message}<br />
                  {error.name}<br />
                  {error.stack}
              </div>
          )}
          
          {data.route.length > 0 && (
            <div className="Data">
                  Route: {data.route}<br />
                  Message: {data.message}
            </div>
          )}
    </div>
  );
}

export default App;
