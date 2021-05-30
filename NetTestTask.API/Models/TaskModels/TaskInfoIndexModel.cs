using System;
using System.Collections.Generic;
using System.Linq;
using NetTestTask.Data.Entities;
using NetTestTask.API.Models.CommonModels;
using NetTestTask.Data.Extensions;

namespace NetTestTask.API.Models.TaskModels
{
    public class TaskInfoIndexModel
    {
        public TaskInfoIndexModel(IEnumerable<Task> tasks, int pageNum, int pageSize = 6)
        {
            if (tasks != null)
            {
                
                IEnumerable<Task> tasksForPage = tasks.Skip((pageNum - 1) * pageSize).Take(pageSize);
                Page = new PageInfoModel((int)Math.Round((double)tasks.Count() / pageSize),
                                         pageNum);
                Tasks = tasks.Select(t => new TaskShortInfoModel()
                {

                    TaskId = t.TaskId,
                    TaskName = t.TaskName,
                    Description = t.Description,
                    TaskStatus = t.TaskStatus,
                    CreationDate = t.CreationDate,
                    LastChangeDate = t.LastChangeDate,
                    ManagerId  =  (int) t.ManagerId,
                    ExecutorId = (int)t.ExecutorId


                });
            }
        }

        public PageInfoModel Page { get; set; }
        public IEnumerable<TaskShortInfoModel> Tasks { get; set; } = Enumerable.Empty<TaskShortInfoModel>();
    }
}
