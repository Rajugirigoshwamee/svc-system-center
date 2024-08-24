

namespace svc.system.center.data.access.layer.Assembler.Public;

public class CountryAssembler : ICountryAssembler
{
    public Countries WriteEntity(AddCountryCommand command)
    {
        return new Countries()
        {
            Name = command.Name,
            Description = command.Description,
            Code = command.Code,
            FlagUrl = command.FlagUrl,
            MobileCode = command.MobileCode
        };
    }
}
