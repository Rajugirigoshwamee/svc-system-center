using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;

namespace svc.system.center.domain.Interfaces.Assemblers.Public;

public interface ICountryAssembler
{
    Countries WriteEntity(AddCountryCommand command);

    Countries WriteEntity(UpdateCountryCommand command);

    GetCountryDto WriteDTO(Countries command);
}
