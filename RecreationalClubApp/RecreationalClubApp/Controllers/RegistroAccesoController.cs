using Configurations.BaseController;
using Configurations.BaseReturn.Interface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroAccesoController : OperationController<RegistroAcceso, IRegistroAccesoService>
    {
        public RegistroAccesoController(IRegistroAccesoService service) : base(service)
        {
        }

        [HttpGet("ConsultarPorClienteId/{clienteId}")]
        public async Task<IOperationResult<IEnumerable<RegistroAcceso>>> ConsultarPorClienteId(int clienteId)
        {
            return await _service.ConsultarPorClienteIdAsync(clienteId);
        }
    }
}
