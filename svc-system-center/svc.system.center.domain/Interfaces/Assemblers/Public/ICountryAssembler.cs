using svc.system.center.domain.Commands.Country;

namespace svc.system.center.domain.Interfaces.Assemblers.Public;

public interface ICountryAssembler
{
    Countries WriteEntity(AddCountryCommand command);
}
