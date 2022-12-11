namespace Portfolio.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
