using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolPermisoController : OperationController<RolPermiso, RolPermisoService>
    {
        public RolPermisoController(RolPermisoService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}
