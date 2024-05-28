using Nowadays.Core.Common;
using Nowadays.Core.Entities;

namespace Nowadays.Core.ValueObject
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
