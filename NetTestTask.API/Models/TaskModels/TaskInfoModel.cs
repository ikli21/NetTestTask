using System;
using System.Collections.Generic;
using System.Linq;
using NetTestTask.Data.Entities;
using NetTestTask.DAL;
using NetTestTask.Data.Extensions;

namespace NetTestTask.API.Models.TaskModels
{
    public class TaskInfoModel
    {
        

        public TaskInfoModel(Task task)
        {
            TaskId = task.TaskId;
            TaskName = task.TaskName;
            TaskStatus = task.TaskStatus;
            Description = task.Description;
            if(Manager!=null&&Executor!=null)
            Manager = new UserShortInfoModel()
            {
                UserId = task.Manager.UserId,
                Name = task.Manager.Name,
                SurName = task.Manager.SurName,
                UserStatus = UserExtensions.StatusTitle(task.Manager)


            };
            Executor = new UserShortInfoModel()
            {
                UserId = task.Executor.UserId,
                Name = task.Executor.Name,
                SurName = task.Executor.SurName,
                UserStatus = UserExtensions.StatusTitle(task.Executor)

            };
        }

        public int TaskId { get; set; }

        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public UserShortInfoModel Manager { get; set; }

        public UserShortInfoModel Executor { get; set; }

    }
}
