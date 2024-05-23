namespace Nowadays.Models.DTOs
{
    public class ReportCompanyDTO
    {
        public string Name { get; set; }
        public List<ReportProjectDTO>? Project { get; set; }
    }
}
