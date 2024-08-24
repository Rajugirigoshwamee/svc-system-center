using svc.system.center.domain.Interfaces.Assemblers.Public;

namespace svc.system.center.business.layer.Handler.Country;

public class CountryCommandHandler: ICommandHandler<AddCountryCommand, bool>
{
    public ICountryRepository _countryRepository { get; set; }
    public ICountryAssembler _countryAssembler { get; set; }
    
    public CountryCommandHandler(
        ICountryRepository countryRepository,
        ICountryAssembler countryAssembler
        )
    {
        _countryRepository = countryRepository;
        _countryAssembler = countryAssembler;
    }

    public async Task<bool> Handle(AddCountryCommand command)
    {
        var country = _countryAssembler.WriteEntity(command);
        await _countryRepository.AddAsync(country);
        return true;
    }
}
