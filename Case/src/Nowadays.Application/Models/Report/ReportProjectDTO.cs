namespace Nowadays.Application.Models.Report
{
    public class ReportProjectDTO
    {
        public string Name { get; set; }
        public string ProjectLeader { get; set; }
        public string ProjectKey { get; set; }
        public int CountIssue { get; set; }
        public int CountCompletedIssues { get; set; }
        public int CountEmployee { get; set; }
        public List<ReportEmployeeDTO>? Employee { get; set; }
    }
}
