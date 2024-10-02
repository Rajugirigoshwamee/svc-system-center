using svc.birdcage.model.Request.Base;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;

namespace svc.system.center.domain.Interfaces.Repositories;

public interface ICountryRepository : IRepository<Countries>
{
    public Task<IEnumerable<GetCountryDto>> GetCountryListWithPagination(BaseListRequestDto request);
}
