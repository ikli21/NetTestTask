using NetTestTask.API.Models.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using NetTestTask.Data.Entities;
using NetTestTask.DAL.Repositories;
using NetTestTask.Data.Extensions;
using NetTestTask.API.Models;


namespace NetTestTask.API.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;

        public TaskService(IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public TaskInfoIndexModel GetPageTasksExecutor(int pageNum, int userId)
        {
            return new TaskInfoIndexModel(_taskRepository.GetExecutorTasks(userId), pageNum);
        }

        public TaskInfoIndexModel GetPageTasksManager(int pageNum, int userId)
        {
            return new TaskInfoIndexModel(_taskRepository.GetManagerTasks(userId),pageNum);
        }

        public Task GetTask(int id)
        => _taskRepository.GetTaskById(id);

        public TaskInfoModel SetTaskManager(int taskId, int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var task = _taskRepository.GetTaskById(taskId);
            if (user != null && task != null)
            {
                task.ManagerId = user.UserId;
                _taskRepository.SaveChangesAsync();
                return new TaskInfoModel(task)
                {
                //    TaskId = task.TaskId,
                //    TaskName = task.TaskName,
                //    TaskStatus = task.TaskStatus,
                //    Description = task.Description,
                //    Manager = new UserShortInfoModel()
                //    {
                //        UserId = task.Manager.UserId,
                //        Name = task.Manager.Name,
                //        SurName = task.Manager.SurName,
                //        UserStatus = UserExtensions.StatusTitle(task.Manager)


                //    },
                //    Executor = new Models.UserShortInfoModel()
                //    {
                //        UserId = task.Executor.UserId,
                //        Name = task.Executor.Name,
                //        SurName = task.Executor.SurName,
                //        UserStatus = UserExtensions.StatusTitle(task.Executor)

                //    }
                };
            }
            return null;
        }

        public Task UpdateTask(int id,UpdateTaskModel updateTaskModel)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task != null)
            {
                //if model update field equals null
                task.TaskName = updateTaskModel.TaskName ?? task.TaskName;
                task.Description = updateTaskModel.Description ?? task.Description;
                if (updateTaskModel.CreationDate != null)
                {
                    task.CreationDate = updateTaskModel.CreationDate;
                }
                if (updateTaskModel.LastChangeDate != null)
                {
                    task.LastChangeDate = updateTaskModel.LastChangeDate;
                }
                _taskRepository.SaveChangesAsync();

            }
            return task;
        }

        public string UpdateTaskStatus(int taskId,int taskStatus)
        {
            var task = _taskRepository.GetTaskById(taskId);
            if (task != null)
            {
                if (taskStatus >=(int) TaskStatus.NotStarted && taskStatus <= (int)TaskStatus.Rejected)
                {

                    task.TaskStatus = (TaskStatus)taskStatus;
                    _taskRepository.SaveChangesAsync();
                    return TaskExtensions.StatusTitle(task);
                }
                
            }
            return null;
            


        }
    }
}
