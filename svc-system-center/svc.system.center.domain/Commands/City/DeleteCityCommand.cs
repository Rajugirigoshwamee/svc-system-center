namespace svc.system.center.domain.Commands.City;

public class DeleteCityCommand(Guid id)
{
    public Guid Id { get; } = id;
}
