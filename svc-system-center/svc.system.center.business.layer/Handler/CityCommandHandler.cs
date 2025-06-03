using svc.birdcage.hawk.Commands;
using svc.system.center.domain.Commands.City;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Interfaces.Repositories;

namespace svc.system.center.business.layer.Handler;

public class CityCommandHandler :
    ICommandHandler<AddCityCommand, bool>,
    ICommandHandler<DeleteCityCommand, bool>,
    ICommandHandler<UpdateCityCommand, bool>
{
    public ICityRepository _cityRepository { get; set; }
    public ICityAssembler _cityAssembler { get; set; }


    public CityCommandHandler(ICityRepository cityRepository, ICityAssembler cityAssembler)
    {
        _cityRepository = cityRepository;
        _cityAssembler = cityAssembler;
    }

    public async Task<bool> Handle(AddCityCommand command)
    {
        var country = _cityAssembler.WriteEntity(command);
        await _cityRepository.AddAsync(country);
        return true;
    }

    public async Task<bool> Handle(DeleteCityCommand command)
    {
        var deleteEntry = await _cityRepository.FindByIdAsync(command.Id);

        if (deleteEntry == null)
            return false;

        await _cityRepository.DeleteAsync(deleteEntry);
        return true;
    }

    public async Task<bool> Handle(UpdateCityCommand command)
    {
        var country = _cityAssembler.WriteEntity(command);
        await _cityRepository.UpdateAsync(country);
        return true;
    }
}
