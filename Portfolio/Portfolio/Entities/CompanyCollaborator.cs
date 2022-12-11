using Portfolio.Entities;

namespace Portfolio.Entities
{
    public class CompanyCollaborator
    {
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public int CollaboratorId { get; set; }
        public Collaborator? Collaborator { get; set; }
    }
}
