﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using svc.birdcage.model.Commands;
using svc.birdcage.model.Request.Base;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.api.Filters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;

namespace svc.system.center.api.Controllers.V1.Public;

[ApiVersion("1.0")]
[AuthorizationFilter]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public class CountryController : BaseController
{
    private readonly ICountryRepository _countryRepository;
    private readonly ICountryAssembler _countryAssembler;
    private readonly ICommandHandler<AddCountryCommand, bool> _commandHandler;
    private readonly ICommandHandler<DeleteCountryCommand, bool> _deleteCommandHandler;

    public CountryController(
        ICommandHandler<AddCountryCommand, bool> commandHandler,
        ICommandHandler<DeleteCountryCommand, bool> deleteCommandHandler,
        ICountryRepository countryRepository,
        ICountryAssembler countryAssembler)
    {
        _commandHandler = commandHandler;
        _deleteCommandHandler = deleteCommandHandler;
        _countryRepository = countryRepository;
        _countryAssembler = countryAssembler;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseListRequestDto request)
    {
        var list = await _countryRepository.GetCountryListWithPagination(request);
        return SuccessResponse(list);
    }

    [HttpPost]
    public async Task<IActionResult> AddCountry([FromBody] AddCountryDto request)
    {
        await _commandHandler.Handle(new AddCountryCommand(request.Name, request.Description, request.Code, request.MobileCode, request.FlagUrl));
        return SuccessResponse();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCountry([FromRoute] Guid id)
    {
        await _deleteCommandHandler.Handle(new DeleteCountryCommand(id));
        return SuccessResponse();
    }
}
