namespace svc.system.center.domain.Commands.Country
{
    public class DeleteCountryCommand
    {
        public Guid Id { get; set; }

        public DeleteCountryCommand(Guid id)
        {
            Id = id;
        }

    }
}
