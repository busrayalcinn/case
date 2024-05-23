using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models.ResponseModels;
using Nowadays.Models;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete;
using Nowadays.Models.DTOs;

namespace Nowadays.Controllers
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
        public async Task<ResponseModel<ReportDTO>> GetReportByCompanyId(string id)
        {
            var report = await _reportService.GetReportByCompanyId(id);
            return report;
        }
    }
}
