using static Nowadays.Models.Enum.BaseEnum;

namespace Nowadays.Models.DTOs
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
