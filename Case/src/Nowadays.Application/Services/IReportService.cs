using Nowadays.Application.Models.Report;
using Nowadays.Core.Entities;

namespace Nowadays.Application.Services
{
    public interface IReportService : IBaseService<Report>
    {
        public Task<ReportDTO> GetReportByCompanyId(string id);
    }
}
