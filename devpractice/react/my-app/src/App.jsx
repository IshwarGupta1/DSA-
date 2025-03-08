import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Greeting from './Greeting'
import UserCard from './UserCard'
import Itemlist from './itemlist'

function App() {
  
  return (
    <div>
      <Greeting name="Ishwar" />
      <UserCard name="Ishwar" age="25" job="Software Engineer" />
      <Itemlist/>
    </div>
  );
}

export default App;
