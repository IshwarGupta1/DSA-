import React from "react";

const ConfirmDelete = ({ onConfirm, onCancel }) => {
  return (
    <div style={{ border: "1px solid black", padding: "20px", marginTop: "10px" }}>
      <p>Are you sure you want to delete this task?</p>
      <button onClick={onConfirm}>Yes</button>
      <button onClick={onCancel} style={{ marginLeft: "10px" }}>
        No
      </button>
    </div>
  );
};

export default ConfirmDelete;
