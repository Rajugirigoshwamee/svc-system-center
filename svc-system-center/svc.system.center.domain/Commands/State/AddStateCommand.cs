using svc.birdcage.hawk.Commands;

namespace svc.system.center.domain.Commands.Country;

public class AddStateCommand(string name, string code, Guid countryId) : ICommand
{
    public string Name { get; } = name;

    public string Code { get; } = code;

    public Guid CountryId { get; } = countryId;

}