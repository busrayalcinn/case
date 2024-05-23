using Nowadays.Models.Base;
using Nowadays.Models.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Nowadays.Models
{
    public class Employee : BaseEntity
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string IdentityNo { get; set; }
        public string? Email { get; set; } 
        public string? Phone { get; set; }
        public int BirthDateYear { get; set; }
        public List<Issue>? Issues { get; set; } 
        public List<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
