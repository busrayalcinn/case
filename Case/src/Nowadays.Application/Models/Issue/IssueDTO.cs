using static Nowadays.Core.Enum.BaseEnum;

namespace Nowadays.Application.Models.Issue
{
    public class IssueDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? ReportingEmployeeId { get; set; }
        public TagType Tag { get; set; }
        public string? IssueNo { get; set; }
        public Guid ProjectId { get; set; }
    }
}
