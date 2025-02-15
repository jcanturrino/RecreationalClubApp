using Configurations.BaseController;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoClienteController : OperationController<TipoCliente, ITipoClienteService>
    {
        public TipoClienteController(ITipoClienteService service) : base(service)
        {
        }
    }
}
