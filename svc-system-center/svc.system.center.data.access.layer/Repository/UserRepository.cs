using svc.birdcage.hawk.Implementation.Repositories;
using svc.birdcage.hawk.Interfaces.Dapper;
using svc.birdcage.hawk.Interfaces.Encryption;
using svc.birdcage.parrot.Authorization;
using svc.system.center.domain.Interfaces.Repositories;
using svc.system.center.domain.Models.Constants.SPConstant;
using svc.system.center.domain.Models.Dtos.Comman;
using svc.system.center.migration.DbContexts;

namespace svc.system.center.data.access.layer.Repository;

public class UserRepository : Repository<Users>, IUserRepository
{
    private readonly IDapperService _dapperService;
    private readonly IEncryption _encryption;

    public UserRepository(IDapperService dapperService, IEncryption encryption, MasterDbContext dbContext) : base(dbContext)
    {
        _dapperService = dapperService;
        _encryption = encryption;
    }

    public async Task<LoginUserDto> LoginUser(string username, string password)
    {
        var eny = _encryption.EncryptData(password, username, username);
        var user = await _dapperService.FindAsync<LoginUserDto>(UserSpConst.ValidateLogin, new
        {
            Username = username,
            Password = _encryption.EncryptData(password,username,username)
        });
        return user;
    }
}
