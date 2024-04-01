namespace EasyPieces.Builders.Models
{
    public class SmsMessage
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Body { get; set; }

        public SmsMessage()
        {
            To = new List<string>();
        }
    }
}
