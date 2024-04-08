namespace EasyPieces.Middleware
{
    public class HealthCheckOptions
    {
        public string DbConnectionString { get; set; }
        public string HealthCheckEndpoint { get; set; } = "/health";
    }
}
