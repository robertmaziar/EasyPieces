using EasyPieces.Middleware;
using EasyPieces.Services.Interfaces;

namespace EasyPieces.TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEasyAccessControlService, TestAccessControlService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Configure EasyPieces.Middleware
            var healthCheckOptions = new HealthCheckOptions
            {
                DbConnectionString = builder.Configuration.GetConnectionString("MyDatabase"),
                HealthCheckEndpoint = "/healthCheck"
                // Configure other options as needed
            };

            app.UseMiddleware<HealthCheckMiddleware>(healthCheckOptions);

            app.Run();
        }
    }
}
