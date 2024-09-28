using Microsoft.AspNetCore.Mvc;
using svc.birdcage.model.Response.Base;

namespace svc.system.center.api.Controllers.Comman
{
    public class BaseController : ControllerBase
    {
        #region Ok Response

        protected IActionResult OkResponse() => OkResponse("Your request submit successfully.");

        protected IActionResult OkResponse(string message) => Ok(new BaseErrorResponse { Success = true, Message = "Your request submit successfully." });

        protected IActionResult OkResponse(object data) => Ok(new BaseErrorResponse { Success = true, Message = "Your request submit successfully.", Data = data });

        protected IActionResult OkResponse<T>(IEnumerable<T> details, int? pageSize)
        {
            BasePaginationResponse<T> pagination = new BasePaginationResponse<T>() {
                Details=details,
                Offset=
            };
            int total = 0, totalPages = 0, offset = 0;

            if (pageSize == null) pageSize = 10;

            if (details != null && details.Count() > 0)
            {
                total = details.FirstOrDefault().Total;
                totalPages = 10; //GenericHelper.CalculateTotalPages(total, pageSize);
                offset = details.FirstOrDefault().OffSet;
            }
            var data = new { total, totalPages, pageSize, offset, details };

            return Ok(new BaseErrorResponse { Success = true, Message = "Your request submit successfully.", Data = data });
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
