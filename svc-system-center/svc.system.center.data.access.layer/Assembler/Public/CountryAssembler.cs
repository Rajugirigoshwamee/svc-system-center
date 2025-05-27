using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace svc.system.center.data.access.layer.Assembler.Public;

public class CountryAssembler : ICountryAssembler
{
    public GetCountryDto WriteDTO(Countries entity)
    {
        return new GetCountryDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Code = entity.Code,
            FlagUrl = entity.FlagUrl,
            MobileCode = entity.MobileCode
        };
    }

    public Countries WriteEntity(AddCountryCommand command)
    {
        if(command == null) return null;

        return new Countries()
        {
            Name = command.Name,
            Code = command.Code,
            FlagUrl = command.FlagUrl,
            MobileCode = command.MobileCode
        };
    }

    public Countries WriteEntity(UpdateCountryCommand command)
    {
        return new Countries()
        {
            Id = command.Id,
            Name = command.Name,
            Code = command.Code,
            FlagUrl = command.FlagUrl,
            MobileCode = command.MobileCode
        };
    }
}
