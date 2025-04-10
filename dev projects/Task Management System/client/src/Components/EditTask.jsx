import React, { useState, useEffect } from "react";

const EditTask = ({ task, onUpdate, onCancel }) => {
  const [title, setTitle] = useState(task.title);
  const [description, setDescription] = useState(task.description);
  const [dueDate, setDueDate] = useState(task.dueDate);
  const [status, setStatus] = useState(task.status);

  const handleSubmit = (e) => {
    e.preventDefault();

    const updatedTask = {
      ...task,
      title,
      description,
      dueDate,
      status,
    };

    onUpdate(updatedTask);
  };

  useEffect(() => {
    setTitle(task.title);
    setDescription(task.description);
    setDueDate(task.dueDate);
    setStatus(task.status);
  }, [task]);

  return (
    <div>
      <h2>Edit Task</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          required
        />
        <br />
        <input
          type="text"
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
        <button type="submit">Update Task</button>
        <button type="button" onClick={onCancel} style={{ marginLeft: "10px" }}>
          Cancel
        </button>
      </form>
    </div>
  );
};

export default EditTask;
