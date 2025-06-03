namespace svc.system.center.domain.Models.Dtos.V1.Public.City;

public class GetCityDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string CountryName { get; set; }
    public required Guid CountryId { get; set; }
    public required string StateName { get; set; }
    public required Guid StateId { get; set; }
}
