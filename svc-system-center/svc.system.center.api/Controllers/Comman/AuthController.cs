using Asp.Versioning;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using svc.system.center.api.Filters;
using svc.system.center.domain.Config;
using svc.system.center.domain.Models.Dtos.Comman;

namespace svc.system.center.api.Controllers.Comman;

[AuthorizationFilter]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class AuthController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto request, [FromServices] IOptions<AuthConfig> AuthConfigOptions)
    {
        if (request == null) return ErrorResponse("error_empty_request");

        var UniqueId = Guid.NewGuid().ToString();
        //var user = await DapperRepository.FindAsync<ProfileResponse>(SpConsts.Account.Login, new { request.UserName, Password = Crypto.Encrypt(request.Password), UniqueId });
        //if (user == null) throw new ApiException("error_invalid_login");
        //await ValidateUserAsync(user, user.UserRole);
        //var user_token = new TokenHelpers(DapperRepository, Crypto).GetAccessToken(AuthConfigOptions.Value, user, UniqueId);
        //Cache.SetDataInCache(user.Id.ToString(), user);
        return SuccessResponse();
    }
}
