using Microsoft.AspNetCore.Mvc;
using TaskManagerServer.DTOs;
using TaskManagerServer.Service;
using TaskManagerServer.Services;
using TaskManagerServer.Strategies;
using TaskManagerServer.Wrappers;

namespace TaskManagerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET All Tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(new ApiResponse<object>(true, "Tasks fetched successfully", tasks));
        }

        // POST Add Task
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskEntityDTO taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(false, "Validation Failed", ModelState));

            await _taskService.AddTask(taskDto);
            return Ok(new ApiResponse<object>(true, "Task Added Successfully"));
        }

        // PUT Update Task
        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] TaskEntityDTO taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(false, "Validation Failed", ModelState));

            var updateStrategy = new UpdateFullTaskStrategy();

            try
            {
                await _taskService.UpdateTask(taskId, taskDto, updateStrategy);
                return Ok(new ApiResponse<object>(true, "Task Updated Successfully"));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new ApiResponse<object>(false, ex.Message));
            }
        }

        // DELETE Task
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            try
            {
                await _taskService.DeleteTask(taskId);
                return Ok(new ApiResponse<object>(true, "Task Deleted Successfully"));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new ApiResponse<object>(false, ex.Message));
            }
        }
    }
}
