import { useState } from "react";
import AddExpense from "./ExpenseForm";
import ListExpenses from "./ListExpenses";

function App() {
  const [expenses, setExpenses] = useState([]);

  const handleAddExpense = (newExpense) => {
    setExpenses((prevExpenses) => [...prevExpenses, newExpense]);
  };

  return (
    <div>
      <h1>Expense Tracker</h1>
      <AddExpense onAddExpense={handleAddExpense} />
      <ListExpenses expenses={expenses} />
    </div>
  );
}

export default App;
