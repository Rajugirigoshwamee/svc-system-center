using svc.birdcage.hawk.Implementation.Repositories;
using svc.birdcage.hawk.Interfaces.Dapper;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Constants.SPConstant;
using svc.system.center.domain.Models.Dtos.V1.Public.State;
using svc.system.center.migration.DbContexts;

namespace svc.system.center.data.access.layer.Repository;

public class StateRepository(IDapperService dapperService, MasterDbContext dbContext) : Repository<States>(dbContext), IStateRepository
{
    public async Task<IEnumerable<GetStateDto>> GetList(BaseListRequestDto request) => await dapperService.GetTableAsync<GetStateDto>(StateSpConst.GetStateList, request);
}
