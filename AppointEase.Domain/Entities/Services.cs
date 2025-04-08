namespace AppointEase.Domain.Entities
{
    public class Services
    {
        public int Id { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
