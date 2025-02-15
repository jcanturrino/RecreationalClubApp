using Configurations.BaseController;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : OperationController<Marca, IMarcaService>
    {
        public MarcaController(IMarcaService service) : base(service)
        {
        }
    }
}
