using svc.system.center.migration.DbContexts;

namespace svc.system.center.data.access.layer.Repository;

public class CountryRepository : Repository<Countries>, ICountryRepository
{
    public CountryRepository(MasterDbContext dbContext) : base(dbContext)
    {
    }
}
