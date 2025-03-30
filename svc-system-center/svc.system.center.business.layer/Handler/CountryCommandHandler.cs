using svc.birdcage.hawk.Commands;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Interfaces.Repositories;

namespace svc.system.center.business.layer.Handler;

public class CountryCommandHandler :
    ICommandHandler<AddCountryCommand, bool>,
    ICommandHandler<DeleteCountryCommand, bool>,
    ICommandHandler<UpdateCountryCommand, bool>
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

    public async Task<bool> Handle(DeleteCountryCommand command)
    {
        var deleteEntry = await _countryRepository.GetByIdAsync(command.Id);

        if (deleteEntry == null)
            return false;

        await _countryRepository.DeleteAsync(deleteEntry);
        return true;
    }

    public async Task<bool> Handle(UpdateCountryCommand command)
    {
        var country = _countryAssembler.WriteEntity(command);
        await _countryRepository.UpdateAsync(country);
        return true;
    }
}
