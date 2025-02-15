using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : OperationController<Marca, IMarcaService>
    {
        public MarcaController(IMarcaService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}
