
using svc.birdcage.hawk.Response.Base;

namespace svc.system.center.domain.Models.Dtos.V1.Public.Country;

public class GetCountryDto: BaseListResponseDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string MobileCode { get; set; }
    public required string FlagUrl { get; set; }
}
