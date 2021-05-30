using System;
using System.Collections.Generic;
using System.Text;

namespace NetTestTask.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public UserStatus UserStatus { get;set; }

        public ICollection<Task> ManagerTasks { get; set; }
        public ICollection<Task> ExecutorTasks { get; set; }
    }
   
    /// <summary>
    /// Возможные значения → Активен,
    /// Отключен, Заблокирован
    /// </summary>
    public enum UserStatus
    {
       
        Active,Offline, Blocked
    }
}
