using svc.birdcage.hawk.Commands;
using System.Xml.Linq;

namespace svc.system.center.domain.Commands.Country;

public class UpdateStateCommand(Guid id, string name, string code, Guid countryId) : ICommand
{
    public Guid Id { get; } = id;

    public string Name { get; } = name;

    public string Code { get; } = code;

    public Guid CountryId { get; } = countryId;

}