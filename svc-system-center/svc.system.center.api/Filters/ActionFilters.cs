using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using svc.birdcage.hawk.Response.Base;
using svc.system.center.api.Controllers.Comman;

namespace svc.system.center.api.Filters;

public class ActionFilters : IActionFilter
{

    public IStringLocalizer<BaseController> Localizer { get; }

    public ActionFilters(IStringLocalizer<BaseController> Localizer)
    {
        this.Localizer = Localizer;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.HttpContext.Response.StatusCode = 400;
            context.Result = new JsonResult(new BaseErrorResponse
            {
                Success = false,
                Message = Localizer[context.ModelState.Values.FirstOrDefault().Errors[0].ErrorMessage].Value
            });
        }
    }
}
