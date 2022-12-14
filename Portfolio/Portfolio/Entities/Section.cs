namespace Portfolio.Entities
{
    public class Section : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Summary { get; set; }
    }
}
