using System.Threading.Tasks;
using TimeTracker.DTO.Employee;

namespace TimeTracker.Service.Services.IServices
{
    public interface IEmployeeService
    {
        Task<EmployeeRequestDto> Add(EmployeeRequestDto employeeRequestDto);
        Task<EmployeeRequestDto> Update(int id, EmployeeRequestDto employeeRequestDto);
        Task<IEnumerable<EmployeeResponseDto>> GetAll();
        Task<EmployeeResponseDto> GetById(int id);
        Task<bool> Delete(int id);
    }
}
