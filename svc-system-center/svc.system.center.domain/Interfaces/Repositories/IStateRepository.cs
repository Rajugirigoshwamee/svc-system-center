using svc.birdcage.hawk.Repositories;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using svc.system.center.domain.Models.Dtos.V1.Public.State;

namespace svc.system.center.domain.Interfaces.Repositories;

public interface IStateRepository : IRepository<States>
{
    Task<IEnumerable<GetStateDto>> GetList(BaseListRequestDto request);
}
