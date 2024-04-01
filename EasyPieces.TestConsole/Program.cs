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

            var smsReplacements = new Dictionary<string, string>
            {
                { "Name", "Jane" },
                { "Sender", "Jane Doe" }
            };

            var smsBuilder = new SmsBuilder()
                .Body("Hi {Name}, this is an SMS from {Sender}.")
                .Build(smsReplacements);

            Console.WriteLine("\nSMS Message:");
            Console.WriteLine(smsBuilder.Body.ToString());
        }
    }
}
