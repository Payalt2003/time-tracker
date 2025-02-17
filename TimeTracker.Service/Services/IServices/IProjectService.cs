using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Employee;
using TimeTracker.DTO.Project;

namespace TimeTracker.Service.Services.IServices
{
    public interface IProjectService
    {

        Task<ProjectRequestDto> Add(ProjectRequestDto ProjectRequestDto);

    }

    
}
