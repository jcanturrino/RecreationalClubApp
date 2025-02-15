using Configurations.BaseController;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodigoUbicacionController : OperationController<CodigoUbicacion, ICodigoUbicacionService>
    {
        public CodigoUbicacionController(ICodigoUbicacionService service) : base(service)
        {
        }

    }
}
