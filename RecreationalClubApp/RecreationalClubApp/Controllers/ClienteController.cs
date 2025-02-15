using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : OperationController<Cliente, IClienteService>
    {
        public ClienteController(IClienteService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}