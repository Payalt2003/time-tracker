using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Employee;
using TimeTracker.DTO.JobType;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class JobTypeService : IJobTypeService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public JobTypeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<JobTypeRequestDto> Add(JobTypeRequestDto jobtypeRequestDto)
        {
            var jobtype = _mapper.Map<JobType>(jobtypeRequestDto);
            _context.JobTypes.Add(jobtype);
            await _context.SaveChangesAsync();
            return _mapper.Map<JobTypeRequestDto>(jobtypeRequestDto);


        }

        
        public async Task<JobTypeRequestDto> Update(int id, JobTypeRequestDto jobTypeRequestDto)
        {
            var jobtype = await _context.JobTypes.FindAsync(id);

            if (jobtype == null)
            {
                _mapper.Map(jobTypeRequestDto, jobtype);
                await _context.SaveChangesAsync();

            }
            return _mapper.Map<JobTypeResponseDto>(jobtype);

        }
        public async Task<IEnumerable<JobTypeResponseDto>> GetAll()
        {
            var jobtype =await _context.JobTypes.AsNoTracking().ToListAsync();
            return jobtype.Select( jobtype =>_mapper.Map<JobType, JobTypeResponseDto>(jobtype));
        }


        public async Task<JobTypeResponseDto> GetById(int id)
        {
            var jobtype=await _context.JobTypes.FindAsync( id);
            return jobtype != null ? _mapper.Map< JobTypeResponseDto>(jobtype) : null;
           

        }
        public async Task<bool> Delete(int id)
        {
            var jobtype = await _context.JobTypes.FindAsync(id);
            if(jobtype != null)
            {
                _context.JobTypes.Remove(jobtype);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }

}
