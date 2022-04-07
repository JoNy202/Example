namespace IntegraCompanies.Shared.Models
{
    public class ConnectionGrid
    {
        public Guid ConnectionId { get; set; }
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
        public bool IsRazdel { get; set; }
        public string? Note { get; set; }
    }
}
