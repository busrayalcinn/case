namespace Nowadays.Models.DTOs
{
    public class ReportEmployeeDTO
    {
        public string FullName { get; set; } 
        public int CountAssignedIssues { get; set; }
        public int CountCompletedIssues { get; set; }

    }
}
