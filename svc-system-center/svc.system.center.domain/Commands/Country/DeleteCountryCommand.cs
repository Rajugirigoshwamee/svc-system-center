namespace svc.system.center.domain.Commands.Country
{
    public class DeleteCountryCommand(Guid id)
    {
        public Guid Id { get; } = id;
    }
}
