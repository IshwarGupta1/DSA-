const items = ["Apple", "Banana", "Cherry"];

function FruitList() {
  return (
   <ul>
    {items.map((item,index)=>(
        <li key = {index}>{item}</li>
    ))}
   </ul>
  );
}

export default FruitList;
