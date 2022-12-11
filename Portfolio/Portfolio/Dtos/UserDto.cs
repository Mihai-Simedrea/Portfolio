using Portofolio.Entities;

namespace Portofolio.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? CompanyId { get; set; }
    }
}
