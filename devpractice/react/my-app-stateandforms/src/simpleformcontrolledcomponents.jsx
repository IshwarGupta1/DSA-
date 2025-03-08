import {useState} from 'react';
function simpleForm(){
    const [name, setName] = useState("");
    const handleChange = (event) =>{
        setName(event.target.value);
    }
    const handleSubmit = (event) =>{
        event.preventDefault();
        alert(`Submitted the name : ${name}`);
    }
    return(
        <div>
            <form onSubmit={handleSubmit}>
                <input type = "text" value = {name} onChange={handleChange}/>
                <button>Submit</button>    
            </form>
        </div>
    );
}
export default simpleForm;