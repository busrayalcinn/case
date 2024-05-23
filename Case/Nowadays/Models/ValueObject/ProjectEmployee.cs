using Nowadays.Models.Base;

namespace Nowadays.Models.ValueObject
{
    public class ProjectEmployee : BaseEntity
    {
        public string ProjectId { get; set; }
        public Project? Project { get; set; }
        public string EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int CountAssignedIssues { get; set; }
        public int CountCompletedIssues { get; set; }

    }
}
