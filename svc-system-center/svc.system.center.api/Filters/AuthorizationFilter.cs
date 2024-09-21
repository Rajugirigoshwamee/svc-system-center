using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using svc.birdcage.model.Response.Base;

namespace svc.system.center.api.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tenantId = context.HttpContext!.Request.Headers["X-Tenant-Id"].ToString();
            if (string.IsNullOrWhiteSpace(tenantId))
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult(new BaseErrorResponse
                {
                    Success = false,
                    Message = ""
                });
            }
        }
    }
}
