import { useEffect, useState } from 'react'
import List1 from './list1';
import Form1 from './simpleformcontrolledcomponents';
import Form2 from './Form2';
export function App() {
  useEffect(() => {
    console.log("Component rendered!");
  }, [count]);

  const [count, setCount] = useState(0);
  return(
    <div>
      <h2>{count}</h2>
      <button onClick={()=>setCount(count+1)}>Increase</button>
      <button onClick={()=>setCount(count*2)}>Double</button>
      <button onClick={()=>setCount(count>0 ?count-1: 0)}>Decrease</button>
      <List1/>
      <Form1/>
      <Form2/>
    </div>
  );
}
export default App;