import React from 'react';

function fruitsList(){
    const fruits = ['apple', 'banana', 'orange'];
    return <ul>
        {fruits.map((fruit)=>
        <li key = {fruit}>{fruit}</li>)
        }
    </ul>
}

export default fruitsList;