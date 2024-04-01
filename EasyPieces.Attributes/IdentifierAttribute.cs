namespace EasyPieces.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IdentifierAttribute : Attribute
    {
        private object _enumValue;

        public IdentifierAttribute(object enumValue)
        {
            if (!enumValue.GetType().IsEnum)
            {
                throw new ArgumentException("Value provided is not an enum.");
            }

            _enumValue = enumValue;
        }

        public bool IsValid()
        {
            Type enumType = _enumValue.GetType();
            return Enum.IsDefined(enumType, _enumValue);
        }
    }
}
