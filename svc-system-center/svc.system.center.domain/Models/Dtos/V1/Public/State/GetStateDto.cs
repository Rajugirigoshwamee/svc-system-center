using svc.birdcage.hawk.Response.Base;

namespace svc.system.center.domain.Models.Dtos.V1.Public.State;

public class GetStateDto : BaseListResponseDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string CountryName { get; set; }
    public required Guid CountryId { get; set; }
}
