using svc.birdcage.hawk.Consts;
using svc.birdcage.parrot.Authorization;
using svc.system.center.api.Controllers.V1.Public;

namespace svc.system.center.api.Authorization
{
    public class Policies
    {
        public Policies()
        {
            policies.Add(new Policies { version = ApiVersionConst.ApiVersionOne, controllerName = nameof(CountryController), permissions = new Permission[] { } });
        }

        private string version { get; set; }
        private string controllerName { get; set; }
        private Permission[] permissions { get; set; }
        public List<Policies> policies { get; set; }= new List<Policies>();
    }
}
