using svc.birdcage.model.Interfaces.Dapper;
using svc.system.center.domain.Models.Dtos.V1.Public.Country;
using svc.system.center.migration.DbContexts;

namespace svc.system.center.data.access.layer.Repository;

public class CountryRepository : Repository<Countries>, ICountryRepository
{
    private IDapperService _dapperService;

    public CountryRepository(IDapperService dapperService, MasterDbContext dbContext) : base(dbContext)
    {
        _dapperService = dapperService;
    }

    public async Task<IEnumerable<GetCountryDto>> GetCountryListWithPagination()
    {
        var list = await _dapperService.GetTableAsync<GetCountryDto>("stp_GetCountryList", new { });
        return list;
    }
}
