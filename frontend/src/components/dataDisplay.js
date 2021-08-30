import React, { useState } from 'react';

function DataDisplay(props) {
    const [data, setData] = useState([]);

    const handleClick = () => {
        fetch('/api/persons', {
            method: 'get',
        }).then(r => r.json())
        .then(r => {
            setData(r)
        })
    }

    return (
        <div>
            <button onClick={handleClick}>
                Fetch Data
            </button>
            <ul>
                {data.map((entry, i) => {
                    //console.log(entry)
                    return(
                        <li key={i}>{entry.name}, {entry.address}, {entry.number}</li>
                    )
                })}
            </ul>
        </div>
    );
}

export default DataDisplay;