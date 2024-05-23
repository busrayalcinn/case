using Nowadays.Models.Base;

namespace Nowadays.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public List<Project>? Project { get; set; }
    }
}
