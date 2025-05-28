namespace svc.system.center.domain.Models.Dtos.V1.Public.Master;

public class GetCountriesDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
}
