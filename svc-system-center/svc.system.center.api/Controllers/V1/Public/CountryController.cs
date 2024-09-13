using Microsoft.AspNetCore.Mvc;
using svc.birdcage.model.Commands;
using svc.birdcage.model.Consts;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;

namespace svc.system.center.api.Controllers.V1.Public;

[ApiVersion(ApiVersionConst.ApiVersionOne)]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public class CountryController : BaseController
{
    private readonly ICountryRepository _countryRepository;
    private readonly ICountryAssembler _countryAssembler;
    private readonly ICommandHandler<AddCountryCommand, bool> _commandHandler;

    public CountryController(
        ICommandHandler<AddCountryCommand, bool> commandHandler,
        ICountryRepository countryRepository,
        ICountryAssembler countryAssembler)
    {
        _commandHandler = commandHandler;
        _countryRepository = countryRepository;
        _countryAssembler = countryAssembler;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list =await _countryRepository.GetCountryListWithPagination();
        return OkResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddCountry([FromBody] AddCountryDto request)
    {
        await _commandHandler.Handle(new AddCountryCommand(request.Name, request.Description, request.Code, request.MobileCode, request.FlagUrl));
        return OkResponse();
    }
}
