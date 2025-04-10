const addTaskInput = document.getElementById('addtaskInput');
const addButton = document.getElementById('addTaskBtn');
const taskList = document.getElementById('taskList');

addButton.addEventListener('click', () => {
    const newTaskInput = addTaskInput.value.trim();
    if (newTaskInput === "") return;

    // Create task element
    const newTask = document.createElement('li');
    newTask.textContent = newTaskInput;

    // Create Update button
    const updateBtn = document.createElement('button');
    updateBtn.textContent = "✏️";
    updateBtn.style.marginLeft = "10px";

    // Create Delete button
    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = "❌";
    deleteBtn.style.marginLeft = "10px";

    // Update task on button click
    updateBtn.addEventListener('click', () => {
        const editInput = document.createElement('input');
        editInput.type = "text";
        editInput.value = newTask.textContent;
        
        const saveBtn = document.createElement('button');
        saveBtn.textContent = "💾";
        saveBtn.style.marginLeft = "5px";

        // Save the updated task
        saveBtn.addEventListener('click', () => {
            newTask.textContent = editInput.value;
            newTask.appendChild(updateBtn);
            newTask.appendChild(deleteBtn);
        });

        newTask.textContent = "";
        newTask.appendChild(editInput);
        newTask.appendChild(saveBtn);
    });

    // Remove task on button click
    deleteBtn.addEventListener('click', () => {
        newTask.remove();
    });

    // Append buttons to task
    newTask.appendChild(updateBtn);
    newTask.appendChild(deleteBtn);

    // Append task to taskList
    taskList.appendChild(newTask);

    // Clear input field
    addTaskInput.value = "";
});
