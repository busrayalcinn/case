using Nowadays.Models;
using Nowadays.Models.DTOs;
using Nowadays.Models.ResponseModels;
using Nowadays.Services.Abstract.Base;

namespace Nowadays.Services.Abstract
{
    public interface IReportService : IBaseService<Report>
    {
        public Task<ResponseModel<ReportDTO>> GetReportByCompanyId(string id);
    }
}
