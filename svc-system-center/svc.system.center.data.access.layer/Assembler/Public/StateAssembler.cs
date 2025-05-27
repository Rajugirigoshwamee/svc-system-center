using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;

namespace svc.system.center.data.access.layer.Assembler.Public;

public class StateAssembler : IStateAssembler
{
    public States WriteEntity(AddStateCommand command)
    {
        return new States()
        {
            Name = command.Name,
            Code = command.Code,
            CountryId = command.CountryId,
        };
    }

    public States WriteEntity(UpdateStateCommand command)
    {
        return new States()
        {
            Id = command.Id,
            Name = command.Name,
            Code = command.Code,
            CountryId = command.CountryId,
        };
    }
}
