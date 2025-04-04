const greeting = (name, age)=>{
    return (`Hello my ${name} is and my age is ${age}`);
};
let greetingMessage = greeting("Ishwar", 27);
console.log(greetingMessage); 

const manageTasks = (taskList, action, task = "unknown") => {
    if (task === "unknown") {
        console.log("Task name is required!");
        return taskList;
    }

    if (action === "add") {
        if (!taskList.includes(task)) {
            taskList.push(task);
            console.log(`Task "${task}" added.`);
        } else {
            console.log(`Task "${task}" already exists.`);
        }
    } else if (action === "remove") {
        let index = taskList.indexOf(task);
        if (index !== -1) {
            taskList.splice(index, 1);
            console.log(`Task "${task}" removed.`);
        } else {
            console.log(`Task "${task}" not found.`);
        }
    } else {
        console.log("Invalid action!");
    }

    return taskList;
};

// Sample Usage
let tasks = ["Buy groceries", "Clean room", "Workout"];

console.log(manageTasks(tasks, "add", "Read book")); 
// ["Buy groceries", "Clean room", "Workout", "Read book"]

console.log(manageTasks(tasks, "remove", "Clean room")); 
// ["Buy groceries", "Workout", "Read book"]

console.log(manageTasks(tasks, "remove", "Sleep")); 
// "Task "Sleep" not found."

console.log(manageTasks(tasks, "update", "Read book")); 
// "Invalid action!"

console.log(manageTasks(tasks, "add")); 
// "Task name is required!"



function Car(brand, speed){
    this.brand = brand;
    this.speed = speed;
    this.increase=function(val){
        speed=speed+val;
    }
    this.decrease=function (val){
        speed=speed-val;
    }
}