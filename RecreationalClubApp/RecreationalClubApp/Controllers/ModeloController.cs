using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : OperationController<Modelo, IModeloService>
    {
        public ModeloController(IModeloService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }

}
