import React, { useEffect, useState } from "react";
import ConfirmDelete from "./ConfirmDelete";

const TaskTable = ({ tasks, onEdit, onDelete }) => {
  const [sortedTasks, setSortedTasks] = useState([]);
  const [sortField, setSortField] = useState(null);
  const [sortOrder, setSortOrder] = useState("asc");
  const [deleteTaskId, setDeleteTaskId] = useState(null);

  const [currentPage, setCurrentPage] = useState(1);
  const tasksPerPage = 5;

  useEffect(() => {
    setSortedTasks(tasks);
  }, [tasks]);

  const handleSort = (field) => {
    const order = sortField === field && sortOrder === "asc" ? "desc" : "asc";
    const sorted = [...tasks].sort((a, b) => {
      if (a[field] < b[field]) return order === "asc" ? -1 : 1;
      if (a[field] > b[field]) return order === "asc" ? 1 : -1;
      return 0;
    });
    setSortedTasks(sorted);
    setSortField(field);
    setSortOrder(order);
  };

  const confirmDelete = (id) => {
    setDeleteTaskId(id);
  };

  const handleDeleteConfirmed = () => {
    onDelete(deleteTaskId);
    setDeleteTaskId(null);
  };

  // Pagination Logic
  const indexOfLastTask = currentPage * tasksPerPage;
  const indexOfFirstTask = indexOfLastTask - tasksPerPage;
  const currentTasks = sortedTasks.slice(indexOfFirstTask, indexOfLastTask);
  const totalPages = Math.ceil(tasks.length / tasksPerPage);

  return (
    <div>
      <h2>Task List</h2>
      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>Title</th>
            <th>Description</th>
            <th onClick={() => handleSort("dueDate")}>Due Date</th>
            <th onClick={() => handleSort("status")}>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {currentTasks.map((task) => (
            <tr key={task.id}>
              <td>{task.title}</td>
              <td>{task.description}</td>
              <td>{task.dueDate}</td>
              <td>{task.status}</td>
              <td>
                <button onClick={() => onEdit(task)}>Edit</button>
                <button onClick={() => confirmDelete(task.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Pagination */}
      <div style={{ marginTop: "10px" }}>
        {Array.from({ length: totalPages }, (_, i) => i + 1).map((page) => (
          <button
            key={page}
            onClick={() => setCurrentPage(page)}
            style={{ margin: "0 5px", background: page === currentPage ? "lightgray" : "white" }}
          >
            {page}
          </button>
        ))}
      </div>

      {/* Confirm Delete Modal */}
      {deleteTaskId && (
        <ConfirmDelete
          onConfirm={handleDeleteConfirmed}
          onCancel={() => setDeleteTaskId(null)}
        />
      )}
    </div>
  );
};

export default TaskTable;
