using Nowadays.Core.Common;
using static Nowadays.Core.Enum.BaseEnum;

namespace Nowadays.Core.Entities
{
    public class Issue : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public StatusType Status { get; set; }
        public string? EmployeeId { get; set; }
        public string? ReportingEmployeeId { get; set; }
        public TagType Tag { get; set; }
        public string? IssueNo { get; set; }
        public string ProjectId { get; set; }

    }
}
