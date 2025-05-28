using svc.birdcage.hawk.Repositories;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using svc.system.center.domain.Models.Dtos.V1.Public.Master;

namespace svc.system.center.domain.Interfaces.Repositories;

public interface ICountryRepository : IRepository<Countries>
{
    public Task<IEnumerable<GetCountryDto>> GetList(BaseListRequestDto request);

    public Task<IEnumerable<GetCountriesDto>> GetListForDropdown();
}
