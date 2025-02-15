using Configurations.BaseController;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformacionContactoController : OperationController<InformacionContacto, IInformacionContactoService>
    {
        public InformacionContactoController(IInformacionContactoService service) : base(service)
        {
        }
    }
}