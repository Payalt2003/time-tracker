using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.JobType;

namespace TimeTracker.Service.Services.IServices
{
    public interface IJobTypeService
    {
        Task<JobTypeRequestDto> Add(JobTypeRequestDto jobTypeRequestDto);
        Task<JobTypeRequestDto> Update( int id ,JobTypeRequestDto jobTypeRequestDto);
        Task<IEnumerable<JobTypeResponseDto>> GetAll();
        Task<JobTypeResponseDto> GetById(int id);
        Task<bool> Delete(int id);

    }
}
