using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetTestTask.API.Models;
using NetTestTask.API.Models.TaskModels;
using NetTestTask.API.Services;
using NetTestTask.API.Services.TaskService;
using NetTestTask.Data.Extensions;

namespace NetTestTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;

        private ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet("{taskId:int}")]
        public IActionResult GetTask(int taskId)
        {
            var taskInfoModel = _taskService.GetTask(taskId);
            if (taskInfoModel is null)
            {
                return BadRequest("Задача не найдена");
            }
          
            return Ok(taskInfoModel);

        }
        [HttpPut("{taskId:int}")]
        public IActionResult UpdateTask(int taskId, [FromBody]UpdateTaskModel updateTaskModel)
        {
            var task = _taskService.UpdateTask(taskId, updateTaskModel);
            if (task is null)
            {
                return BadRequest("Задача не найдена");
            }
            var taskInfoModel = new TaskShortInfoModel()
            {
                TaskId = task.TaskId,
                TaskName = task.TaskName,
                Description = task.Description,
                CreationDate = task.CreationDate,
                LastChangeDate = task.LastChangeDate,
                TaskStatus = task.TaskStatus
            };
            return Ok(taskInfoModel);

        }
        [HttpGet("executor/{userId:int}/{pageNum:int}")]
        public IActionResult GetPageTasksExecutor(int pageNum, int userId)
        {
            var page = _taskService.GetPageTasksExecutor(pageNum, userId);
            if (page is null)
            {
                return BadRequest("Страница или пользователь не найдены");
            }

            return Ok(page);

        }

        [HttpGet("manager/{userId:int}/{pageNum:int}")]
        public IActionResult GetPageTasksManager(int pageNum, int userId)
        {
            var page = _taskService.GetPageTasksManager(pageNum, userId);
            if (page is null)
            {
                return BadRequest("Страница или пользователь не найдены");
            }

            return Ok(page);

        }

        [HttpPut("{taskId:int}/manager/{userId:int}")]
        public IActionResult SetTaskManager(int taskId, int userId)
        {

            var task = _taskService.SetTaskManager(taskId, userId);
            if (task is null)
            {
                return BadRequest("Не найден пользователь или задача");

            }
            return Ok(task);

        }
        [HttpPut("{taskId:int}/status/{status:int}")]
        public IActionResult UpdateTaskStatus(int taskId, int status)
        {

            var statusTitle = _taskService.UpdateTaskStatus(taskId, status);
            if (statusTitle is null)
            {
                return BadRequest("Не найдена задача или ошибка изменения статуса");

            }
            return Ok(statusTitle);

        }


    }
}
