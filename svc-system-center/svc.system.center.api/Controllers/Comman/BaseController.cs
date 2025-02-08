using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using svc.birdcage.model.Response.Base;
using svc.system.center.api.Filters;

namespace svc.system.center.api.Controllers.Comman
{
    [EnableCors("CorsPolicy")]
    [ServiceFilter(typeof(ExceptionFilters))]
    public class BaseController : ControllerBase
    {
        #region Ok Response

        protected IActionResult SuccessResponse() => SuccessResponse("Your request submit successfully.");

        protected IActionResult SuccessResponse(string message) => Ok(new BaseErrorResponse { Success = true, Message = "Your request submit successfully." });

        protected IActionResult SuccessResponse(dynamic data) => Ok(data);

        protected IActionResult SuccessResponse(IEnumerable<dynamic> details)
        {
            int total = 0;


            if (details != null && details.Any())
            {
                total = details.FirstOrDefault()!.Total;
            }

            Response.Headers.Append("X-Count", total.ToString());

            return Ok(details);
        }

        #endregion Ok Response

        #region Failed Response

        protected IActionResult ErrorResponse() => throw new ApiException("Error Something went Wrong.", 400);

        protected IActionResult ErrorResponse(string message) => throw new ApiException(message, 400);

        protected IActionResult ErrorResponse(string message, int statusCode) => throw new ApiException(message, statusCode);

        protected IActionResult ErrorResponse(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState)
        {
            string message = string.Join("; ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
            throw new ApiException(message, 400);
        }

        #endregion Failed Response
    }
}
