using svc.birdcage.hawk.Repositories;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Models.Dtos.V1.Public.City;

namespace svc.system.center.domain.Interfaces.Repositories
{
    public interface ICityRepository : IRepository<Cities>
    {
        Task<IEnumerable<GetCityDto>> GetList(BaseListRequestDto request);
    }
}
