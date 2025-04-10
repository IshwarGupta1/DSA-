import React, { useState, useEffect } from "react";
import axios from "axios";
import TaskTable from "./Components/TaskTable";
import AddTask from "./Components/AddTask";
import EditTask from "./Components/EditTask";
import ConfirmDelete from "./Components/ConfirmDelete";

import "./App.css";


const App = () => {
  const [tasks, setTasks] = useState([]);
  const [editingTask, setEditingTask] = useState(null);
  const [deletingTask, setDeletingTask] = useState(null);

  const API_URL = "https://localhost:7138/api/task";
  // backend api url

  const fetchTasks = async () => {
    try {
      const response = await axios.get(API_URL);
      setTasks(response.data);
    } catch (error) {
      alert("Error fetching tasks");
    }
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  const handleAddTask = async (task) => {
    try {
      await axios.post(API_URL, task);
      fetchTasks();
      alert("Task added successfully");
    } catch (error) {
      alert("Error adding task");
    }
  };

  const handleUpdateTask = async (task) => {
    try {
      await axios.put(`${API_URL}/${task.id}`, task);
      fetchTasks();
      setEditingTask(null);
      alert("Task updated successfully");
    } catch (error) {
      alert("Error updating task");
    }
  };

  const handleDeleteTask = async (taskId) => {
    try {
      await axios.delete(`${API_URL}/${taskId}`);
      fetchTasks();
      setDeletingTask(null);
      alert("Task deleted successfully");
    } catch (error) {
      alert("Error deleting task");
    }
  };

  return (
    <div className="App">
      <h1>Task Manager</h1>

      {editingTask ? (
        <EditTask
          task={editingTask}
          onUpdate={handleUpdateTask}
          onCancel={() => setEditingTask(null)}
        />
      ) : (
        <AddTask onAdd={handleAddTask} />
      )}

      <TaskTable
        tasks={tasks}
        onEdit={setEditingTask}
        onDelete={setDeletingTask}
      />

      {deletingTask && (
        <ConfirmDelete
          onConfirm={() => handleDeleteTask(deletingTask.id)}
          onCancel={() => setDeletingTask(null)}
        />
      )}
    </div>
  );
};

export default App;
