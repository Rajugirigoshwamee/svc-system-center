namespace svc.system.center.business.layer.Handler.Country;

public class CountryCommandHandler: ICommandHandler<AddCountryCommand, bool>
{
    public ICountryRepository _countryRepository { get; set; }
    public CountryCommandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    public async Task<bool> Handle(AddCountryCommand command)
    {
        _countryRepository.Add(new Countries()
        {
            Name = "hi"
        });
        return true;
    }
}
