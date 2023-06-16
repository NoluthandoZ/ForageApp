namespace Forage.Entities
{
    public class Freelancer
    {
        public Guid Freelancer_id { get; set; }
        public string Location { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
