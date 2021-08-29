import React, { useState } from 'react';

function InputForm(props) {
    const [name, setName] = useState('');
    const [address, setAddress] = useState('');
    const [number, setNumber] = useState('');

    // POSTs the data to the backend, and logs the status to the console
    const handleClick = () => {
        let variables = {
            name: name,
            address: address,
            number: number
        }
        let jsonvariables = JSON.stringify(variables)
        fetch('/api/persons', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: jsonvariables
        }).then(
            r => {
                console.log(r.status)
                if(r.ok){
                    console.log("Success!")
                } else {
                    console.log("Something failed.")
                }
            }
        )
    }

    const handleNameChange = (e) => {
        setName(e.target.value)
    }

    const handleAddressChange = (e) => {
        setAddress(e.target.value)
    }

    const handleNumberChange = (e) => {
        setNumber(e.target.value)
    }

    return (
        <div>
            <form onSubmit={handleClick}>
                <label>
                    Name:
                    <input type="text" value={name} onChange={handleNameChange} />
                </label>
                <label>
                    Address:
                    <input type="text" value={address} onChange={handleAddressChange} />
                </label>
                <label>
                    Number:
                    <input type="text" value={number} onChange={handleNumberChange} />
                </label>
            </form>
            <button onClick={handleClick}>
                Add Entry
            </button>
        </div>
    );
}

export default InputForm;