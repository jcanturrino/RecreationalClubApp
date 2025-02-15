using Configurations.BaseController;
using Configurations.BaseReturn.Interface;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : OperationController<Vehiculo, IVehiculoService>
    {
        public VehiculoController(IVehiculoService service) : base(service)
        {
        }

        [HttpGet("ConsultarPorClienteId/{clienteId}")]
        public async Task<IOperationResult<IEnumerable<Vehiculo>>> ConsultarPorClienteId(int clienteId)
        {
            return await _service.ConsultarPorClienteIdAsync(clienteId);
        }
    }
}
