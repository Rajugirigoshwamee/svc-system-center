using svc.birdcage.hawk.Commands;

namespace svc.system.center.domain.Commands.Country;

public class UpdateCountryCommand(Guid id, string name, string description, string code, string mobileCode, string flagUrl) : ICommand
{
    public Guid Id { get; } = id;

    public string Name { get; } = name;

    public string Description { get; } = description;

    public string Code { get; } = code;

    public string MobileCode { get; } = mobileCode;

    public string FlagUrl { get; } = flagUrl;

}
