using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using svc.birdcage.hawk.Commands;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.hawk.Response.Base;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.api.Filters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using Swashbuckle.AspNetCore.Annotations;

namespace svc.system.center.api.Controllers.V1.Public;


[AuthorizationFilter]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CountryController(
    ICommandHandler<AddCountryCommand, bool> commandHandler,
    ICommandHandler<DeleteCountryCommand, bool> deleteCommandHandler,
    ICommandHandler<UpdateCountryCommand, bool> updateCommandHandler,
    ICountryRepository countryRepository) : BaseController
{
    private readonly ICountryRepository _countryRepository = countryRepository;
    private readonly ICommandHandler<AddCountryCommand, bool> _commandHandler = commandHandler;
    private readonly ICommandHandler<DeleteCountryCommand, bool> _deleteCommandHandler = deleteCommandHandler;
    private readonly ICommandHandler<UpdateCountryCommand, bool> _updateCommandHandler = updateCommandHandler;

    [HttpGet]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<GetCountryDto>))]
    public async Task<IActionResult> Get([FromQuery] BaseListRequestDto request)
    {
        var list = await _countryRepository.GetCountryListWithPagination(request);
        return SuccessResponse(list);
    }

    [HttpPost]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
    public async Task<IActionResult> AddCountry([FromBody] AddCountryDto request)
    {
        await _commandHandler.Handle(new AddCountryCommand(request.Name, request.Description, request.Code, request.MobileCode, request.FlagUrl));
        return SuccessResponse();
    }

    [HttpDelete]
    [Route("{id}")]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
    public async Task<IActionResult> DeleteCountry([FromRoute] Guid id)
    {
        await _deleteCommandHandler.Handle(new DeleteCountryCommand(id));
        return SuccessResponse();
    }


    [HttpPut]
    [Route("{id}")]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
    public async Task<IActionResult> UpdateCountry([FromRoute] Guid id, [FromBody] AddCountryDto request)
    {
        await _updateCommandHandler.Handle(new UpdateCountryCommand(id, request.Name, request.Description, request.Code, request.MobileCode, request.FlagUrl));
        return SuccessResponse();
    }
}
