using NetTestTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetTestTask.Data.Extensions
{
//    Не начата, В
//процессе, Выполнен, Отменен, Отклонен
    public static class TaskExtensions
    {
        public static string StatusTitle(this Task task)
        {
            switch (task.TaskStatus)
            {
                case TaskStatus.NotStarted:
                    return "Не начата";
                case TaskStatus.InProcess:
                    return "В процессе";
                case TaskStatus.Completed:
                    return "Выполнен";
                case TaskStatus.Canceled:
                    return "Отменен";
                case TaskStatus.Rejected:
                    return "Отклонен";
                default:
                    return "";
            }
        }
    }
}
