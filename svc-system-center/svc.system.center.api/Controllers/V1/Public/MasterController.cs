using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.api.Filters;
using svc.system.center.data.access.layer.Repository;
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
        private readonly IStateRepository _stateRepository = stateRepository;

        [HttpGet("countries")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<GetCountriesDto>))]
        public async Task<IActionResult> GetCountries()
        {
            var list = await _countryRepository.GetListForDropdown();
            return SuccessResponseWithoutPagination(list);
        }

        [HttpGet("states")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<GetCountriesDto>))]
        public async Task<IActionResult> GetStates()
        {
            var list = await _countryRepository.GetListForDropdown();
            return SuccessResponseWithoutPagination(list);
        }
    }
}
