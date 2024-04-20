using EasyPieces.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EasyPieces.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EasyAccessAttribute : Attribute, IAuthorizationFilter
    {
        private List<string> _allowedAccessors;

        public EasyAccessAttribute(string allowedAccessor)
        {
            if (_allowedAccessors == null)
                _allowedAccessors = new List<string>();

            _allowedAccessors.Add(allowedAccessor);
        }

        public EasyAccessAttribute(List<string> allowedAccessors)
        {
            if (_allowedAccessors == null)
                _allowedAccessors = new List<string>();

            _allowedAccessors.AddRange(allowedAccessors);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            IEasyAccessControlService? accessControlService = context.HttpContext.RequestServices
                .GetService(typeof(IEasyAccessControlService)) as IEasyAccessControlService;
            
            if (!string.IsNullOrWhiteSpace(userId) && accessControlService != null)
            {
                var hasAccess = accessControlService.HasEasyAccess(_allowedAccessors, userId);

                if (!hasAccess)
                {
                    context.Result = new ForbidResult();
                }
            }
            
            // TODO: Test what happens when service or userId is null
        }
    }
}
