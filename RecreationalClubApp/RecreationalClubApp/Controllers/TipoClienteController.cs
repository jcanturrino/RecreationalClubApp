using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoClienteController : OperationController<TipoCliente, ITipoClienteService>
    {
        public TipoClienteController(ITipoClienteService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}
