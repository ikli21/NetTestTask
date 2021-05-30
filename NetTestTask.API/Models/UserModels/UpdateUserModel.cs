using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTestTask.API.Models
{
    public class UpdateUserModel
    {
        
        public string SurName { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        
    
    }
}
