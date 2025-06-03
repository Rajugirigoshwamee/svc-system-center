using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using svc.birdcage.hawk.Commands;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.hawk.Response.Base;
using svc.system.center.api.Controllers.Comman;
using svc.system.center.api.Filters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Dtos.V1.Public.State;
using Swashbuckle.AspNetCore.Annotations;

namespace svc.system.center.api.Controllers.V1.Public
{
    [AuthorizationFilter]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class StateController(
        ICommandHandler<AddStateCommand, bool> commandHandler,
        ICommandHandler<DeleteStateCommand, bool> deleteCommandHandler,
        ICommandHandler<UpdateStateCommand, bool> updateCommandHandler,
        IStateRepository stateRepository) : BaseController
    {

        private readonly IStateRepository _stateRepository = stateRepository;
        private readonly ICommandHandler<AddStateCommand, bool> _commandHandler = commandHandler;
        private readonly ICommandHandler<DeleteStateCommand, bool> _deleteCommandHandler = deleteCommandHandler;
        private readonly ICommandHandler<UpdateStateCommand, bool> _updateCommandHandler = updateCommandHandler;

        [HttpGet]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<GetStateDto>))]
        public async Task<IActionResult> Get([FromQuery] BaseListRequestDto request)
        {
            var list = await _stateRepository.GetList(request);
            return SuccessResponse(list);
        }


        [HttpPost]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
        public async Task<IActionResult> AddState([FromBody] AddStateDto request)
        {
            if (request == null)
                return BadRequest();

            await _commandHandler.Handle(new AddStateCommand(request.Name, request.Code, request.CountryId));
            return SuccessResponse();
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
        public async Task<IActionResult> DeleteState([FromRoute] Guid id)
        {
            await _deleteCommandHandler.Handle(new DeleteStateCommand(id));
            return SuccessResponse();
        }


        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(BaseErrorResponse))]
        public async Task<IActionResult> UpdateState([FromRoute] Guid id, [FromBody] AddStateDto request)
        {
            await _updateCommandHandler.Handle(new UpdateStateCommand(id, request.Name, request.Code, request.CountryId));
            return SuccessResponse();
        }
    }
}
