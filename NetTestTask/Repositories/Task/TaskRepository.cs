using NetTestTask.DAL.DataBase;

using NetTestTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTestTask.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private NetTestTaskDatabase db;

        public TaskRepository(NetTestTaskDatabase db)
        {
            this.db = db;
        }

        public IEnumerable<Task> GetExecutorTasks(int userId)
        => db.Tasks.Where(t => t.ExecutorId == userId).ToList();

        public IEnumerable<Task> GetManagerTasks(int userId)
        => db.Tasks.Where(t => t.ManagerId == userId).ToList();

        public Task GetTaskById(int id)
        => db.Tasks.FirstOrDefault(t => t.TaskId == id);

        public  void SaveChangesAsync()
        =>  db.SaveChanges();//Async

        public void UpdateTask(Task task)
        => db.Update(task);
    }
}
