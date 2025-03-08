import React, {useState} from 'react';

function Greeting(props){
    const [count, setCount] = useState(0);
    return(
    <div>
    <h1>Hello {props.name}! My Age is {props.age}</h1>
    <p>Count: {count}</p>
    
    <button onClick ={() => setCount(count + 1 )}>Increment</button>
    <button onClick ={() => setCount(count - 1 == 0 ?  1 : count - 1 )}>Decrement</button>
    </div>
    );
}
export default Greeting;