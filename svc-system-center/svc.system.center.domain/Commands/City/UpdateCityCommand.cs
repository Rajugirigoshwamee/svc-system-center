using svc.birdcage.hawk.Commands;

namespace svc.system.center.domain.Commands.City;

public class UpdateCityCommand(Guid id, string name, string code, Guid countryId, Guid stateId) : ICommand
{
    public Guid Id { get; } = id;

    public string Name { get; } = name;

    public string Code { get; } = code;

    public Guid CountryId { get; } = countryId;

    public Guid StateId { get; } = stateId;

}
