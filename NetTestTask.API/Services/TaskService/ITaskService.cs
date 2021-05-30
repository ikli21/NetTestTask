using System;
using System.Collections.Generic;
using System.Linq;
using NetTestTask.API.Models.CommonModels;
using NetTestTask.API.Models.TaskModels;
using NetTestTask.Data.Entities;

namespace NetTestTask.API.Services.TaskService
{
    public interface ITaskService
    {
        TaskInfoIndexModel GetPageTasksManager(int pageNum, int userId);
        TaskInfoIndexModel GetPageTasksExecutor(int pageNum, int userId);
        Task GetTask(int id);
        Task UpdateTask(int id,UpdateTaskModel updateTaskModel);
        string UpdateTaskStatus(int taskId,int taskStatus);
        TaskInfoModel SetTaskManager(int taskId, int userId);




    }
}
