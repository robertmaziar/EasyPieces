namespace EasyPieces.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EasyFlagAttribute : Attribute
    {
        private EasyEnums.TestStatus _enumValue;

        public EasyFlagAttribute(EasyEnums.TestStatus enumValue)
        {
            _enumValue = enumValue;
        }
    }
}
