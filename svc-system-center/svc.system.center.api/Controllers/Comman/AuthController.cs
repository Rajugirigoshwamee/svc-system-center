using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using svc.system.center.api.Filters;
using svc.system.center.api.Helpers;
using svc.system.center.domain.Config;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Dtos.Comman;

namespace svc.system.center.api.Controllers.Comman;

[AuthorizationFilter]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class AuthController(IUserRepository userRepository) : BaseController
{
    private readonly IUserRepository _userRepository = userRepository;


    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto request, [FromServices] IOptions<AuthConfig> AuthConfigOptions)
    {
        if (request == null) return ErrorResponse("error_empty_request");

        var user = await _userRepository.LoginUser(request.Email, request.Password);
        if (user == null) throw new ApiException("error_invalid_login");
        var user_token = TokenHelpers.GetAccessToken(AuthConfigOptions.Value, JsonConvert.SerializeObject(user));
        return SuccessResponse(new { userDetails= user, token=user_token });
    }
}
