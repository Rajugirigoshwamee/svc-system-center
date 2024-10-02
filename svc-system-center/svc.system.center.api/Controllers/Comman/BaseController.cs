using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using svc.birdcage.model.Response.Base;
using svc.system.center.api.Helpers;

namespace svc.system.center.api.Controllers.Comman
{
    [EnableCors("CorsPolicy")]
    public class BaseController : ControllerBase
    {
        #region Ok Response

        protected IActionResult SuccessResponse() => SuccessResponse("Your request submit successfully.");

        protected IActionResult SuccessResponse(string message) => Ok(new BaseErrorResponse { Success = true, Message = "Your request submit successfully." });

        protected IActionResult SuccessResponse(object data) => Ok(new BaseErrorResponse { Success = true, Message = "Your request submit successfully.", Data = data });

        protected IActionResult SuccessResponse(IEnumerable<dynamic> details, int? pageSize)
        {
            int total = 0, totalPages = 0, offset = 0;

            pageSize ??= 10;

            if (details != null && details.Any())
            {
                total = details.FirstOrDefault()!.Total;
                totalPages = GenericHelpers.CalculateTotalPages(total, pageSize);
                offset = details.FirstOrDefault()!.Offset;
            }

            var data = new { total, totalPages, pageSize, offset, details };

            Response.Headers.Append("X-Count", total.ToString());

            return Ok(new BaseErrorResponse { Success = true, Message = "ok response request performed successfully", Data = data });
        }

        #endregion Ok Response

        #region Failed Response

        //protected IActionResult ErrorResponse() => throw new ApiException("Error Something went Wrong.", 400);

        //protected IActionResult ErrorResponse(string message) => throw new ApiException(message, 400);

        //protected IActionResult ErrorResponse(string message, int statusCode) => throw new ApiException(message, statusCode);

        //protected IActionResult ErrorResponse(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState)
        //{
        //    string message = string.Join("; ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
        //    throw new ApiException(message, 400);
        //}

        #endregion Failed Response
    }
}
