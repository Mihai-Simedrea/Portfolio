using Portfolio.Entities;

namespace Portfolio.Entities
{
    public class Company : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<CompanyCollaborator>? CompanyCollaborators { get; set; }
    }
}
