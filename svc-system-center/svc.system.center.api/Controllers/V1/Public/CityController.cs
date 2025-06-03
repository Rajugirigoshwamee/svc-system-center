using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using svc.birdcage.hawk.Commands;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.hawk.Response.Base;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.api.Filters;
using svc.system.center.domain.Commands.City;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Dtos.V1.Public.City;
using Swashbuckle.AspNetCore.Annotations;

namespace svc.system.center.api.Controllers.V1.Public;

[AuthorizationFilter]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CityController(
        ICommandHandler<AddCityCommand, bool> commandHandler,
        ICommandHandler<DeleteCityCommand, bool> deleteCommandHandler,
        ICommandHandler<UpdateCityCommand, bool> updateCommandHandler,
        ICityRepository CityRepository) : BaseController
{

    private readonly ICityRepository _cityRepository = CityRepository;
    private readonly ICommandHandler<AddCityCommand, bool> _commandHandler = commandHandler;
    private readonly ICommandHandler<DeleteCityCommand, bool> _deleteCommandHandler = deleteCommandHandler;
    private readonly ICommandHandler<UpdateCityCommand, bool> _updateCommandHandler = updateCommandHandler;



    [HttpGet]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<GetCityDto>))]
    public async Task<IActionResult> Get([FromQuery] BaseListRequestDto request)
    {
        var list = await _cityRepository.GetList(request);
        return SuccessResponse(list);
    }


    [HttpPost]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
    public async Task<IActionResult> AddCity([FromBody] AddCityDto request)
    {
        if (request == null)
            return BadRequest();

        await _commandHandler.Handle(new AddCityCommand(request.Name, request.Code, request.CountryId, request.StateId));
        return SuccessResponse();
    }

    [HttpDelete]
    [Route("{id}")]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
    public async Task<IActionResult> DeleteCity([FromRoute] Guid id)
    {
        await _deleteCommandHandler.Handle(new DeleteCityCommand(id));
        return SuccessResponse();
    }


    [HttpPut]
    [Route("{id}")]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
    public async Task<IActionResult> UpdateCity([FromRoute] Guid id, [FromBody] AddCityDto request)
    {
        await _updateCommandHandler.Handle(new UpdateCityCommand(id, request.Name, request.Code, request.CountryId, request.StateId));
        return SuccessResponse();
    }
}
