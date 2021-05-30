using System;
using System.Collections.Generic;
using System.Linq;
using NetTestTask.Data.Entities;

namespace NetTestTask.API.Models.TaskModels
{
    public class TaskShortInfoModel
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public int ManagerId { get; set; }

        public int ExecutorId { get; set; }
    }
}
