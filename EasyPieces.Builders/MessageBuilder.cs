namespace EasyPieces.Builders
{
    public abstract class MessageBuilder
    {
        private string _message;
        private readonly Dictionary<string, string> _replacements;

        public MessageBuilder()
        {
            _message = string.Empty;
            _replacements = new Dictionary<string, string>();
        }

        public MessageBuilder WithMessage(string message)
        {
            _message = message;

            return this;
        }

        public MessageBuilder WithReplacement(string key, string value)
        {
            _replacements[key] = value;

            return this;
        }

        public MessageBuilder WithReplacements(Dictionary<string, string> replacements)
        {
            foreach (var replacement in replacements)
            {
                _replacements[replacement.Key] = replacement.Value;
            }

            return this;
        }

        public virtual string Build()
        {
            foreach (var replacement in _replacements)
            {
                _message  = _message.Replace($"{{{replacement.Key}}}", replacement.Value);
            }

            return _message;
        }
    }
}
