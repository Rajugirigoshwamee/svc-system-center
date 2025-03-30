using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.api.Filters;

namespace svc.system.center.api.Controllers.V1.Public
{
    [AuthorizationFilter]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MasterController : BaseController
    {
    }
}
