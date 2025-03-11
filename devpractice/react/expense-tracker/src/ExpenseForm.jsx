import { useState } from 'react';

function AddExpense({ onAddExpense }) {
    const [addexpense, setexpense] = useState({
        amount: "",
        expenseFor: ""
    });

    const handleChange = (event) => {
        const { name, value } = event.target;
        setexpense({
            ...addexpense,
            [name]: value
        });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        alert(`Expense Details Submitted`);

        const newExpense = {
            id: Date.now(),
            amount: parseFloat(addexpense.amount),
            expenseFor: addexpense.expenseFor
        };

        onAddExpense(newExpense);
        setexpense({ amount: "", expenseFor: "" });
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    name="amount"
                    value={addexpense.amount}
                    onChange={handleChange}
                    placeholder="Enter Amount"
                />
                <input
                    type="text"
                    name="expenseFor"
                    value={addexpense.expenseFor}
                    onChange={handleChange}
                    placeholder="Expense For"
                />
                <button type="submit">Add Expense</button>
            </form>
        </div>
    );
}

export default AddExpense;
