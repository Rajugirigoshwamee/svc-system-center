using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using svc.system.center.domain.Models.Dtos.V1.Public.State;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
