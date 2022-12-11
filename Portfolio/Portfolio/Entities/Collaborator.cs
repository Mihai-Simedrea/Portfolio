using Portofolio.Entities;

namespace Portfolio.Entities
{
    public class Collaborator : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
