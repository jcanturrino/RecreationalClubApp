using Configurations.BaseController;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : OperationController<Modelo, IModeloService>
    {
        public ModeloController(IModeloService service) : base(service)
        {
        }
    }

}
