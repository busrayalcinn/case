namespace Nowadays.Application.Models.Report
{
    public class ReportCompanyDTO
    {
        public string Name { get; set; }
        public List<ReportProjectDTO>? Project { get; set; }
    }
}
