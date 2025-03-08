import React from 'react';

function clickMe()
{
    function handleClick()
    {
        console.log('hello to events');
    }
    return <button onClick={handleClick}>ClickMe</button>
}
export default clickMe;