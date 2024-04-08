using EasyPieces.Services.Interfaces;

namespace EasyPieces.TestApi
{
    public class TestAccessControlService : IEasyAccessControlService
    {
        public bool HasEasyAccess(List<string> allowedAccessors, int? userId = null)
        {
            return true;
        }

        public bool HasEasyAccess(List<string> allowedAccessors, string? userId = null)
        {
            return true;
        }
    }
}
