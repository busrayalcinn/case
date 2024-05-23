using Nowadays.Models.Base;
using Nowadays.Models.DTOs;
using static Nowadays.Models.Enum.BaseEnum;

namespace Nowadays.Models
{
    public class Report : BaseEntity
    {
        public ReportCompanyDTO? Company { get; set; }

    }
}
