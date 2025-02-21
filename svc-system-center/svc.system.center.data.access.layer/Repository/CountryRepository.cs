using svc.birdcage.hawk.Implementation.Repositories;
using svc.birdcage.hawk.Interfaces.Dapper;
using svc.birdcage.hawk.Request.Base;
using svc.birdcage.parrot.Masters;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Constants.SPConstant;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using svc.system.center.migration.DbContexts;

namespace svc.system.center.data.access.layer.Repository;

public class CountryRepository : Repository<Countries>, ICountryRepository
{
    private readonly IDapperService _dapperService;

    public CountryRepository(IDapperService dapperService, MasterDbContext dbContext) : base(dbContext)
    {
        _dapperService = dapperService;
    }

    public async Task<IEnumerable<GetCountryDto>> GetCountryListWithPagination(BaseListRequestDto request)
    {
        var list = await _dapperService.GetTableAsync<GetCountryDto>(CounrtySpConst.GetCountryList, request);
        return list;
    }
}
