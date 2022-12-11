namespace Portofolio.Entities
{
    public class Company : BaseEntity
    {  
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
