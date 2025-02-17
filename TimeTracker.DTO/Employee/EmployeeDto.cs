using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.Employee
{
    public class EmployeeRequestDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        public string PostalCode { get; set; }

        public bool? IsActive { get; set; }
        public string Country { get; set; }
    }
    public class EmployeeResponseDto: EmployeeRequestDto
    {
        public int Id { get; set; }
    }
}
