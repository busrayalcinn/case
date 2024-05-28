using System.ComponentModel.DataAnnotations;

namespace Nowadays.Application.Models.Employee
{
    public class EmployeeSettingDTO
    {
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? Phone { get; set; }
    }
}
