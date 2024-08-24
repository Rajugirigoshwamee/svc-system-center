using Microsoft.AspNetCore.Mvc;
using svc.birdcage.model.Consts;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.domain.Interfaces.Repositories;

namespace svc.system.center.api.Controllers.V1.Public;

[ApiVersion(ApiVersionConst.ApiVersionOne)]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public class CountryController(ICountryRepository countryRepository) : BaseController
{
    private readonly ICountryRepository _countryRepository = countryRepository;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = _countryRepository.GetAll();
        return OkResponse(list);
    }
}
