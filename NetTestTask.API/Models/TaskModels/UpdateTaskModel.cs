using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTestTask.API.Models.TaskModels
{
    public class UpdateTaskModel
    {
      

        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public int ExecutorId { get; set; }

    }
}
