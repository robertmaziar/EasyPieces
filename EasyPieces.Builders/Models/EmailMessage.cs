namespace EasyPieces.Builders.Models
{
    public class EmailMessage
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Attachments { get; set; }

        public EmailMessage()
        {
            To = new List<string>();
            Cc = new List<string>();
            Bcc = new List<string>();
            Attachments = new List<string>();
        }
    }
}
