namespace svc.system.center.domain.Models.Dtos.V1.Public;

public class AddCountryDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Code { get; set; }
    public required string MobileCode { get; set; }
    public required string FlagUrl { get; set; }
}
