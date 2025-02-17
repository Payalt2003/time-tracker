using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.JobType
{
    public class JobTypeRequestDto
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
    public class JobTypeResponseDto : JobTypeRequestDto
    {
        public int id { get; set; }

    }
}
