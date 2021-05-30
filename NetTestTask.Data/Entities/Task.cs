using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetTestTask.Data.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
     
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }

        public TaskStatus TaskStatus { get; set; }

       
        [ForeignKey("User")]
        public int? ManagerId { get; set; }
        [ForeignKey("User")]
        public int? ExecutorId { get; set; }
        public virtual User Manager { get; set; }
        public virtual User Executor { get; set; }
        
        
        

    }
    /// <summary>
    /// Не начата, В процессе,
    /// Выполнен, Отменен, Отклонен
    /// </summary>
    public enum TaskStatus
        
    {
        NotStarted, InProcess, Completed, Canceled, Rejected
    }

}
