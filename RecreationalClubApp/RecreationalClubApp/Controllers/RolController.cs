using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : OperationController<Rol, IRolService>
    {
        public RolController(IRolService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}
