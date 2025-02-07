using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using svc.birdcage.model.Response.Base;
using svc.system.center.api.Controllers.Comman;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace svc.system.center.api.Filters;

public class ExceptionFilters : ExceptionFilterAttribute
{

    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is ApiException)
        {
            var exception = context.Exception as ApiException;
            context.HttpContext.Response.StatusCode = exception.StatusCode;

            context.Result = new JsonResult(new BaseErrorResponse
            {
                Success = false,
                Message = exception.Message.Split(";").FirstOrDefault()
            });
        }
        else if (context.Exception is SqlException)
        {
            var exception = context.Exception as SqlException;
            context.HttpContext.Response.StatusCode = 400;
            context.Result = new JsonResult(new BaseErrorResponse
            {
                Success = false,
                Message = exception.Message
            });
        } 
        else if (context.Exception is DbUpdateException)
        {
            var exception = context.Exception as DbUpdateException;
            context.HttpContext.Response.StatusCode = 400;
            context.Result = new JsonResult(new BaseErrorResponse
            {
                Success = false,
                Message = exception.Message
            });
        }
        else
        {
            var exception = context.Exception as Exception;
            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(new BaseErrorResponse
            {
                Success = false,
                Message = exception.Message
            });
        }
    }
}

#region API Exception class declaration.

public class ApiException : Exception
{
    public int StatusCode { get; set; }
    public IEnumerable<string>? Errors { get; }

    public ApiException(string message, int statusCode = 500, IEnumerable<string>? Errors = null) : base(message)
    {
        StatusCode = statusCode;
        this.Errors = Errors;
    }

    public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
    {
        StatusCode = statusCode;
    }
}

#endregion API [global::System.Serializable]
public class MyException : Exception
{
    public MyException() { }
    public MyException(string message) : base(message) { }
    public MyException(string message, Exception inner) : base(message, inner) { }
    protected MyException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}