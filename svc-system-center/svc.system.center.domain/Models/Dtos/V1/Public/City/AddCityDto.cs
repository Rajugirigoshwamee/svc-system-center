namespace svc.system.center.domain.Models.Dtos.V1.Public.City;

public class AddCityDto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required Guid CountryId { get; set; }
    public required Guid StateId { get; set; }
}
