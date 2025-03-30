using svc.birdcage.hawk.Repositories;
using svc.birdcage.parrot.Authorization;
using svc.system.center.domain.Models.Dtos.Comman;

namespace svc.system.center.domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<LoginUserDto> LoginUser(string username, string password);
    }
}
