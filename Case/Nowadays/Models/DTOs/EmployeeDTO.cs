using System.ComponentModel.DataAnnotations;

namespace Nowadays.Models.DTOs
{
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        [StringLength(11)]
        public string IdentityNo { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int BirthDateYear { get; set; }
    }
}
