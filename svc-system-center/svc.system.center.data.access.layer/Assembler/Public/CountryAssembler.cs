

using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using System.Collections.Generic;

namespace svc.system.center.data.access.layer.Assembler.Public;

public class CountryAssembler : ICountryAssembler
{
    public GetCountryDto WriteDTO(Countries command)
    {
        throw new NotImplementedException();
    }

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
