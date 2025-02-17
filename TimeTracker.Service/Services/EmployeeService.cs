using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Employee;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public EmployeeService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<EmployeeRequestDto> Add(EmployeeRequestDto emoloyeeRequestDto)
        {
            var empolyee = _mapper.Map<Employee>(emoloyeeRequestDto);
            _context.Employees.Add(empolyee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeRequestDto>(emoloyeeRequestDto);
           
            
        }
        public async Task<EmployeeRequestDto> Update(int id, EmployeeRequestDto emoloyeeRequestDto)
        {
            var employees = await _context.Employees.FindAsync(id); // find entity and tack the entity
            if (employees != null)
            {
                _mapper.Map(emoloyeeRequestDto, employees);// modify the existing tracked id record
                await _context.SaveChangesAsync(); //save  change and update database accordingly
            }
            return _mapper.Map<EmployeeRequestDto>(employees);
        }


        public async Task<IEnumerable<EmployeeResponseDto>> GetAll()
        {
            var employees = await _context.Employees.AsNoTracking().ToListAsync();
            return employees.Select(employees => _mapper.Map<Employee, EmployeeResponseDto>(employees));
        }



        public async Task<EmployeeResponseDto> GetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee != null ? _mapper.Map<EmployeeResponseDto>(employee) : null;
        }

        public async Task<bool> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
