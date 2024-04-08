namespace EasyPieces.Services.Interfaces
{
    public interface IEasyAccessControlService
    {
        public bool HasEasyAccess(List<string> allowedAccessors, string userId);
    }
}
