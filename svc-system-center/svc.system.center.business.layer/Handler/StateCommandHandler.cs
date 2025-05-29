using svc.birdcage.hawk.Commands;
using svc.system.center.domain.Commands.Country;
using svc.system.center.domain.Interfaces.Assemblers.Public;
using svc.system.center.domain.Interfaces.Repositories;

namespace svc.system.center.business.layer.Handler;

public class StateCommandHandler :
    ICommandHandler<AddStateCommand, bool>,
    ICommandHandler<DeleteStateCommand, bool>,
    ICommandHandler<UpdateStateCommand, bool>
{

    public IStateRepository _stateRepository { get; set; }
    public IStateAssembler _stateAssembler { get; set; }

    public StateCommandHandler(IStateRepository stateRepository, IStateAssembler stateAssembler)
    {
        _stateAssembler = stateAssembler;   
        _stateRepository = stateRepository;
    }

    public async Task<bool> Handle(AddStateCommand command)
    {
        var entity = _stateAssembler.WriteEntity(command);
        await _stateRepository.AddAsync(entity);
        return true;
    }

    public async Task<bool> Handle(DeleteStateCommand command)
    {
        var deleteEntry = await _stateRepository.FindByIdAsync(command.Id);

        if (deleteEntry == null)
            return false;

        await _stateRepository.DeleteAsync(deleteEntry);
        return true;
    }

    public async Task<bool> Handle(UpdateStateCommand command)
    {
        var entity = _stateAssembler.WriteEntity(command);
        await _stateRepository.UpdateAsync(entity);
        return true;
    }
}
