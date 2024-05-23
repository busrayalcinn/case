using Nowadays.Models.Base;
using Nowadays.Models.ValueObject;

namespace Nowadays.Models
{
    public class Project : BaseEntity
    {
        public string? Name { get; set; }
        public string? ProjectLeader { get; set; }
        public string? ProjectKey { get; set; }
        public List<Issue>? Issues { get; set; }
        public List<ProjectEmployee>? ProjectEmployees { get; set; }
        public string CompanyId { get; set; }
        public int CountIssue { get; set; }
        public int CountCompletedIssues { get; set; }
        public int CountEmployee { get; set; }
    }
}
