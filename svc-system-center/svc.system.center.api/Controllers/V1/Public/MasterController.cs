using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.api.Filters;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using svc.system.center.domain.Models.Dtos.V1.Public.Master;
using Swashbuckle.AspNetCore.Annotations;

namespace svc.system.center.api.Controllers.V1.Public
{
    [AuthorizationFilter]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MasterController(
    ICountryRepository countryRepository) : BaseController
    {

        private readonly ICountryRepository _countryRepository = countryRepository;

        [HttpGet("countries")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<GetCountriesDto>))]
        public async Task<IActionResult> Get()
        {
            var list = await _countryRepository.GetListForDropdown();
            return Ok(list);
        }
    }
}
