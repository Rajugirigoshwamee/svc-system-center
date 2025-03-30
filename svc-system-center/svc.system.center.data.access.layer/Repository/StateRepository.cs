using svc.birdcage.hawk.Implementation.Repositories;
using svc.birdcage.hawk.Interfaces.Dapper;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Constants.SPConstant;
using svc.system.center.domain.Models.Dtos.V1.Public.State;
using svc.system.center.migration.DbContexts;

namespace svc.system.center.data.access.layer.Repository;

public class StateRepository : Repository<States>, IStateRepository
{
    private readonly IDapperService _dapperService;

    public StateRepository(IDapperService dapperService, MasterDbContext dbContext) : base(dbContext)
    {
        _dapperService = dapperService;
    }

    public async Task<IEnumerable<GetStateDto>> GetList(BaseListRequestDto request)
    {
        var list = await _dapperService.GetTableAsync<GetStateDto>(StateSpConst.GetStateList, request);
        return list;
    }
}
