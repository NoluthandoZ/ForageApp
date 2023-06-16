namespace Forage.Entities
{
    public class Vacancy
    {
        public Guid Vacany_id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Vacany_type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public DateTime ClosingDate { get; set; } 
    }
}
