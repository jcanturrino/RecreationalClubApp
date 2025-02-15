using Configurations.BaseController;
using Configurations.BaseInterface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ParqueoValetController : OperationController<ParqueoValet, IParqueoValetService>
    {
        public ParqueoValetController(IParqueoValetService service, ITokenService tokenService) : base(service, tokenService)
        {
        }
    }
}