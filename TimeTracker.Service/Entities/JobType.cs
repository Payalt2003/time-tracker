using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
     public class JobType
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        



    }
}
