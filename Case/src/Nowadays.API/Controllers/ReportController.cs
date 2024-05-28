using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Models.Report;
using Nowadays.Application.Services;

namespace Nowadays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("{id}")]
        public async Task<ReportDTO> GetReportByCompanyId(string id)
        {
            var report = await _reportService.GetReportByCompanyId(id);
            return report;
        }
    }
}
