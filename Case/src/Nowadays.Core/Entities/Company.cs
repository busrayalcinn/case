using Nowadays.Core.Common;

namespace Nowadays.Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public List<Project>? Project { get; set; }
    }
}
