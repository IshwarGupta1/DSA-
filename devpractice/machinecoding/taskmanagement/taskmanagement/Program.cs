using System;
using System.Collections.Generic;
using taskmanagement.Models;

namespace taskmanagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Users
            var user1 = new User
            {
                userId = 1,
                name = "Alice",
                tasks = new List<workTask>()
            };

            var user2 = new User
            {
                userId = 2,
                name = "Bob",
                tasks = new List<workTask>()
            };

            // Initialize task management system
            var taskManagement = new taskManagement();

            // Initialize UserManagement for each user
            var userManagement1 = new UserManagement(taskManagement, user1);
            var userManagement2 = new UserManagement(taskManagement, user2);

            // Create tasks for user1
            userManagement1.createTask("Task 1", "Description of Task 1", 5, Priority.High);
            userManagement1.createTask("Task 2", "Description of Task 2", 10, Priority.Medium);

            // Display user1's tasks
            Console.WriteLine($"Tasks for {user1.name}:");
            foreach (var task in user1.tasks)
            {
                Console.WriteLine($"Task ID: {task.id}, Title: {task.title}, Priority: {task.priority}");
            }

            // Update task title for Task 1
            userManagement1.updateTaskTitle(user1.tasks[0].id, "Updated Task 1");

            // Update task description for Task 2
            userManagement1.updateTaskDesc(user1.tasks[1].id, "Updated Description for Task 2");

            // Update task priority for Task 1
            userManagement1.updateTaskPriority(user1.tasks[0].id, Priority.Low);

            // Update task status for Task 2
            userManagement1.updateTaskStatus(user1.tasks[1].id, Status.Completed);

            // Display updated tasks for user1
            Console.WriteLine("\nUpdated Tasks for Alice:");
            foreach (var task in user1.tasks)
            {
                Console.WriteLine($"Task ID: {task.id}, Title: {task.title}, Status: {task.status}, Priority: {task.priority}");
            }

            // Assign Task 1 from user1 to user2
            userManagement1.assignTask(user2, user1.tasks[0]);

            // Display tasks for user2
            Console.WriteLine("\nTasks for Bob after assignment:");
            foreach (var task in user2.tasks)
            {
                Console.WriteLine($"Task ID: {task.id}, Title: {task.title}");
            }

            // Delete Task 2 from user1
            userManagement1.deleteTask(user1.tasks[1].id);

            // Display remaining tasks for user1
            Console.WriteLine("\nRemaining Tasks for Alice after deletion:");
            foreach (var task in user1.tasks)
            {
                Console.WriteLine($"Task ID: {task.id}, Title: {task.title}");
            }
        }
    }
}
