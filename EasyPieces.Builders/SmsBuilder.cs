using EasyPieces.Builders.Models;

namespace EasyPieces.Builders
{
    public class SmsBuilder
    {
        private SmsMessage _smsMessage;

        public SmsBuilder()
        {
            _smsMessage = new SmsMessage();
        }

        public SmsBuilder From(string from)
        {
            _smsMessage.From = from;
            return this;
        }

        public SmsBuilder To(string to)
        {
            _smsMessage.To.Add(to);
            return this;
        }

        public SmsBuilder Body(string body)
        {
            _smsMessage.Body = body;
            return this;
        }

        public SmsMessage Build(Dictionary<string, string> replacements)
        {
            foreach (var replacement in replacements)
            {
                _smsMessage.Body = _smsMessage.Body.Replace($"{{{replacement.Key}}}", replacement.Value);
            }

            return _smsMessage;
        }
    }
}
