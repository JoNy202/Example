namespace IntegraCompanies.Api.Resources
{
    public class ConnectionResource
    {
        public string Source { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public bool IsRazdel { get; set; }
    }
}
