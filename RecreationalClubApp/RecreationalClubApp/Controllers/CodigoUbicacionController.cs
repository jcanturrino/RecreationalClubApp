using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodigoUbicacionController : OperationController<CodigoUbicacion, ICodigoUbicacionService>
    {
        public CodigoUbicacionController(ICodigoUbicacionService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}
