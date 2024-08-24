using svc.birdcage.model.Commands;

namespace svc.system.center.domain.Commands.Country;

public class AddCountryCommand : ICommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string MobileCode { get; set; }
    public string FlagUrl { get; set; }

    public AddCountryCommand(string name, string description,string code,string mobileCode, string flagUrl)
    {
        this.Name = name;
        this.Description = description;
        this.Code = code;
        this.MobileCode = mobileCode;
        this.FlagUrl = flagUrl;
    }
}
