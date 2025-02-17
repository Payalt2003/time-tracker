using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.JobType;
using TimeTracker.DTO.Project;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class ProjectService : IProjectService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public ProjectService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectRequestDto> Add(ProjectRequestDto projectRequestDto)
        {
            var projects = _mapper.Map<Project>(projectRequestDto);
            _context.Projects.Add(projects);



            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectRequestDto>(projectRequestDto);


        }
    }

}


