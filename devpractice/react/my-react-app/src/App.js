import React from 'react';
import Greeting from './props&usestate';
import Events from './events';
import useEffected from './useEffect';
function App(){
  return (
    <div>
      <h1>First App</h1>
      <p>First Para</p>
      <Greeting name = "Ishwar Gupta" age="27"/>
      <Events/>
      <useEffected name = "JohnDoe" />
    </div>
  );
}
export default App;