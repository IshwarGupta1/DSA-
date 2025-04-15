import React, { useState } from "react";
function Display(props){
    const [isVisible, setVisibility] = useState(true);
    return(
        <div>
            <h1>{isVisible && props.Text}</h1>
            <button onClick={()=>setVisibility(true)}>Show</button>
            <button onClick={()=>setVisibility(false)}>Hide</button>
        </div>
    )
}
export default Display;