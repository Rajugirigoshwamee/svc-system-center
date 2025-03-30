namespace svc.system.center.domain.Commands.Country
{
    public class DeleteStateCommand(Guid id)
    {
        public Guid Id { get; } = id;
    }
}
