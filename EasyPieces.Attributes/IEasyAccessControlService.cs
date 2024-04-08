namespace EasyPieces.Attributes
{
    public interface IEasyAccessControlService
    {
        public bool HasEasyAccess(List<string> allowedAccessors, int? userId = null);
        public bool HasEasyAccess(List<string> allowedAccessors, string? userId = null);
    }
}
