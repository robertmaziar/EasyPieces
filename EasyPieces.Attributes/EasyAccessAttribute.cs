using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyPieces.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EasyAccessAttribute : Attribute, IAuthorizationFilter
    {
        private List<string> _allowedAccessors;

        //public EasyAccessAttribute(object enumValue)
        //{
        //    if (!enumValue.GetType().IsEnum)
        //    {
        //        throw new ArgumentException("Value provided is not an enum.");
        //    }

        //    _enumValue = enumValue;
        //}


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
            // Implement your access control logic here
            var accessControlService = context.HttpContext.RequestServices.GetService(typeof(IEasyAccessControlService)) as IEasyAccessControlService;
            var hasAccess = accessControlService.HasEasyAccess(_allowedAccessors, "userId");

            if (!hasAccess)
            {
                context.Result = new ForbidResult(); // Or any other appropriate action result
            }
        }
    }
}
