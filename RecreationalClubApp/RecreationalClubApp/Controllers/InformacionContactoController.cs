using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformacionContactoController : OperationController<InformacionContacto, IInformacionContactoService>
    {
        public InformacionContactoController(IInformacionContactoService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}