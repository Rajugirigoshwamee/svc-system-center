namespace svc.system.center.domain.Models.Dtos.V1.Public.State;

public class AddStateDto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required Guid CountryId { get; set; }
}
