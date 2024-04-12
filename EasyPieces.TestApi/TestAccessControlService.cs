using EasyPieces.Services.Interfaces;

namespace EasyPieces.TestApi
{
    public class TestAccessControlService : IEasyAccessControlService
    {
        public bool HasEasyAccess(List<string> allowedAccessors, string userId)
        {
            // Your logic goes here...

            return true;
        }
    }
}
