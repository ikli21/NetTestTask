using NetTestTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetTestTask.DAL.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetManagerTasks(int userId);
        IEnumerable<Task> GetExecutorTasks(int userId);
        Task GetTaskById(int id);
        void UpdateTask(Task task);
        void SaveChangesAsync();

    }
}
