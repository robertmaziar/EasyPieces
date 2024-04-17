namespace EasyPieces.TestApi
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

       
        public static void Process()
        {
            Console.WriteLine("Processing...");

            Console.WriteLine("Processed successfully.");
        }

        public static async Task ProcessAsync()
        {
            Console.WriteLine("Processing payment...");
            
            // Simulating asynchronous operation
            await Task.Delay(3000);

            Console.WriteLine("Processed successfully.");
        }
    }
}
