using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Commands.City;

namespace svc.system.center.domain.Interfaces.Assemblers.Public;

public interface ICityAssembler
{
    Cities WriteEntity(AddCityCommand command);

    Cities WriteEntity(UpdateCityCommand command);
}
