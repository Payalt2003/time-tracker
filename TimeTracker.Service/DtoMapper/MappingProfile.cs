using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Employee;
using TimeTracker.DTO.JobType;
using TimeTracker.DTO.Project;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.DtoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Employee, EmployeeRequestDto>().ReverseMap();
            CreateMap<Employee, EmployeeResponseDto>().ReverseMap();

            CreateMap<JobType, JobTypeRequestDto>().ReverseMap();
            CreateMap<JobType, JobTypeResponseDto>().ReverseMap();

            CreateMap<Project, ProjectRequestDto>().ReverseMap();
            CreateMap<Project, ProjectRequestDto>().ReverseMap();
            
            

            

        }

    }

    
}
