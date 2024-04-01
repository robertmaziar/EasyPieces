using EasyPieces.Builders.Models;

namespace EasyPieces.Builders
{
    public class EmailBuilder
    {
        private EmailMessage _emailMessage;

        public EmailBuilder()
        {
            _emailMessage = new EmailMessage();
        }

        public EmailBuilder From(string from)
        {
            _emailMessage.From = from;
            return this;
        }

        public EmailBuilder To(string to)
        {
            _emailMessage.To.Add(to);
            return this;
        }

        public EmailBuilder Cc(string cc)
        {
            _emailMessage.Cc.Add(cc);
            return this;
        }

        public EmailBuilder Bcc(string bcc)
        {
            _emailMessage.Bcc.Add(bcc);
            return this;
        }

        public EmailBuilder Subject(string subject)
        {
            _emailMessage.Subject = subject;
            return this;
        }

        public EmailBuilder Body(string body)
        {
            _emailMessage.Body = body;
            return this;
        }

        public EmailBuilder Attach(string attachment)
        {
            _emailMessage.Attachments.Add(attachment);
            return this;
        }

        public EmailMessage Build(Dictionary<string, string> replacements)
        {
            foreach (var replacement in replacements)
            {
                _emailMessage.Body = _emailMessage.Body.Replace($"{{{replacement.Key}}}", replacement.Value);
            }

            return _emailMessage;
        }
    }
}
