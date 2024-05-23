using System.ComponentModel.DataAnnotations;

namespace Nowadays.Models.DTOs
{
    public class EmployeeSettingDTO
    {
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? Phone { get; set; }
    }
}
