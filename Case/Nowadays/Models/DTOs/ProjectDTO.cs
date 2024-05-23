using Nowadays.Models.ValueObject;

namespace Nowadays.Models.DTOs
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string ProjectLeader { get; set; }
        public string ProjectKey { get; set; }
        public Guid CompanyId { get; set; }
    }
}
