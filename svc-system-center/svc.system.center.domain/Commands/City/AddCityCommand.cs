using svc.birdcage.hawk.Commands;

namespace svc.system.center.domain.Commands.City;

public class AddCityCommand(string name, string code, Guid countryId, Guid stateId) : ICommand
{
    public string Name { get; } = name;

    public string Code { get; } = code;

    public Guid CountryId { get; } = countryId;

    public Guid StateId { get; } = stateId;

}
