using Configurations.BaseController;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ParqueoValetController : OperationController<ParqueoValet, IParqueoValetService>
    {
        public ParqueoValetController(IParqueoValetService service) : base(service)
        {
        }
    }
}