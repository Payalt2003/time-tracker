using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.Project
{
    public class ProjectRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public DateTime Created { get; set; }







    }
     public class ProjectResponseDto: ProjectRequestDto

    {
        public int id { get; set; }

    }
}

