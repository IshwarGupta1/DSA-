import React from "react";

function TodoList(props) {
    if (props.tasks.length === 0) {
        return <h1>No Items</h1>;
    }

    return (
        <ul>
            {props.tasks.map((task, index) => (
                <li key={index}>{task}</li>
            ))}
        </ul>
    );
}

export default TodoList;
