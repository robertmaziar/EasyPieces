using EasyPieces.Builders;

namespace EasyPieces.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var jsonObject = new JsonBuilder()
                .AddProperty("name", "John Doe")
                .AddProperty("age", 30)
                .AddArray("hobbies", "programming", "reading", "hiking")
                .AddObject("address", address =>
                {
                    address
                        .AddProperty("street", "123 Main St")
                        .AddProperty("city", "Anytown")
                        .AddProperty("zip", "12345");
                })
                .Build();

            Console.WriteLine(jsonObject.ToString());
        }
    }
}
