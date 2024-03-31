namespace EasyPieces.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BuilderAttribute : Attribute
    {
        public BuilderType Type { get; set; }

        public BuilderAttribute(BuilderType type)
        {
            Type = type;
        }
    }

    // TODO: something generic but useful here?
    public enum BuilderType
    {
    }
}
