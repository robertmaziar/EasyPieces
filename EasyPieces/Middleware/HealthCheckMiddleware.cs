using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace EasyPieces.Middleware
{
    public class HealthCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HealthCheckOptions _options;

        public HealthCheckMiddleware(RequestDelegate next, HealthCheckOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == _options.HealthCheckEndpoint)
            {
                var healthStatus = await CheckDatabaseConnection();
                context.Response.StatusCode = healthStatus ? 200 : 503;
                return;
            }

            await _next(context);
        }

        private async Task<bool> CheckDatabaseConnection()
        {
            using (var connection = new SqlConnection(_options.DbConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
