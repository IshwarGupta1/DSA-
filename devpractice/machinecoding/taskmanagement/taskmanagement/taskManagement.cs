using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskmanagement.Models;

namespace taskmanagement
{
    public class taskManagement
    {
        public workTask createTask(string taskName, string taskDesc, int deadline, Priority priority)
        {
            var newTask = new workTask();
            newTask.title = taskName;
            newTask.desc = taskDesc;
            newTask.dueDate = DateTime.Now.AddDays(deadline);
            newTask.status = Status.Progress;
            newTask.priority = priority;
            return newTask;
        }

        public workTask UpdateTask(workTask task, params IUpdateStrategy[] strategies)
        {
            foreach (var strategy in strategies)
            {
                strategy.Update(task);
            }

            return task;
        }
    }
}
