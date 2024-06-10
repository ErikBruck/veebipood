import { useEffect, useRef, useState } from 'react';
import './App.css';

function App() {
  const [tooted, setTooted] = useState([]);
  const nameRef = useRef();
  const ratingRef = useRef();
  const yearRef = useRef();

  useEffect(() => {
    fetch("https://localhost:4444/tooted")
      .then(res => res.json())
      .then(json => {
        if (Array.isArray(json)) {
          setTooted(json);
        } else {
          console.error('Expected an array but got:', json);
        }
      })
      .catch(error => console.error('Fetch error:', error));
  }, []);

  function kustuta(index) {
    fetch(`https://localhost:4444/tooted/kustuta/${index}`, {
      method: "DELETE"
    })
      .then(res => res.json())
      .then(json => {
        if (Array.isArray(json)) {
          setTooted(json);
        } else {
          console.error('Expected an array but got:', json);
        }
      })
      .catch(error => console.error('Delete error:', error));
  }

  function lisa() {
    const uusToode = {
      name: nameRef.current.value,
      rating: Number(ratingRef.current.value),
      year: Number(yearRef.current.value)
    };
    
    fetch("https://localhost:4444/tooted/lisa", {
      method: "POST",
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(uusToode)
    })
      .then(res => res.json())
      .then(json => {
        if (Array.isArray(json)) {
          setTooted(json);
        } else {
          console.error('Expected an array but got:', json);
        }
      })
      .catch(error => console.error('Add error:', error));
  }

  return (
    <div className="App">
      <label>Filmi nimi</label> <br />
      <input ref={nameRef} type="text" /> <br />
      <label>Rating</label> <br />
      <input ref={ratingRef} type="number" /> <br />
      <label>Aasta</label> <br />
      <input ref={yearRef} type="number" /> <br />
      <button onClick={lisa}>Lisa</button>
      {tooted.map((toode, index) => 
        <div key={toode.id}>
          <div>{toode.id}</div>
          <div>{toode.name}</div>
          <div>{toode.rating}</div>
          <div>{toode.year}</div>
          <button onClick={() => kustuta(index)}>x</button>
        </div>
      )}
    </div>
  );
}

export default App;
