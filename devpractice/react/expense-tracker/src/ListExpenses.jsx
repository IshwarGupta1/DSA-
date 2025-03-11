function ListExpenses({ expenses }) {
    return (
      <div>
        <h2>Expense List</h2>
        <ul>
          {expenses.map((expense) => (
            <li key={expense.id}>
              {expense.amount} - {expense.expenseFor}
            </li>
          ))}
        </ul>
      </div>
    );
  }
  
  export default ListExpenses;
  