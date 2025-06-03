using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Commands.City;
using svc.system.center.domain.Interfaces.Assemblers.Public;

namespace svc.system.center.data.access.layer.Assembler.Public;

public class CityAssembler : ICityAssembler
{
    public Cities WriteEntity(AddCityCommand command)
    {
        if (command == null) return null;

        return new Cities()
        {
            Name = command.Name,
            Code = command.Code,
            CountryId = command.CountryId,
            StateId = command.StateId,
        };
    }

    public Cities WriteEntity(UpdateCityCommand command)
    {
        if (command == null) return null;

        return new Cities()
        {
            Id = command.Id,
            Name = command.Name,
            Code = command.Code,
            CountryId = command.CountryId,
            StateId = command.StateId,
        };
    }
}
