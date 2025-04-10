import React, { useState } from "react";

const AddTask = ({ onAdd }) => {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [dueDate, setDueDate] = useState("");
  const [status, setStatus] = useState("Pending");

  const handleSubmit = (e) => {
    e.preventDefault();

    const newTask = {
      title,
      description,
      dueDate,
      status,
    };

    onAdd(newTask);

    // Clear form
    setTitle("");
    setDescription("");
    setDueDate("");
    setStatus("Pending");
  };

  return (
    <div>
      <h2>Add Task</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          required
        />
        <br />
        <input
          type="text"
          placeholder="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          required
        />
        <br />
        <input
          type="date"
          value={dueDate}
          onChange={(e) => setDueDate(e.target.value)}
          required
        />
        <br />
        <select value={status} onChange={(e) => setStatus(e.target.value)}>
          <option value="Pending">Pending</option>
          <option value="Completed">Completed</option>
        </select>
        <br />
        <button type="submit">Add Task</button>
      </form>
    </div>
  );
};

export default AddTask;
