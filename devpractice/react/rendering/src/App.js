import React from 'react';
import TodoList from './TodoList';

function App() {
  const tasks = ["Apple", "Banana", "Cherry"];
  return (

    <div>
      <TodoList tasks ={tasks}/>
    </div>
  );
}

export default App;
