using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Models.Dtos.V1.Public.State;

namespace svc.system.center.domain.Interfaces.Assemblers.Public;

public interface IStateAssembler
{
    States WriteEntity(AddStateCommand command);

    States WriteEntity(UpdateStateCommand command);
}
