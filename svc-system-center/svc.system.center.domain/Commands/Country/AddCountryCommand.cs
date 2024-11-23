using svc.birdcage.model.Commands;

namespace svc.system.center.domain.Commands.Country;

public class AddCountryCommand : ICommand
{
    public AddCountryCommand(string name, string description, string code, string mobileCode, string flagUrl)
    {
        Name = name;
        Description = description;
        Code = code;
        MobileCode = mobileCode;
        FlagUrl = flagUrl;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Code { get; set; }

    public string MobileCode { get; set; }

    public string FlagUrl { get; set; }
    
}
