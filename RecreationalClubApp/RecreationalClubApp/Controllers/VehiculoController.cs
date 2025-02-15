using Configurations.BaseController;
using Configurations.BaseInterface;
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
        private readonly ITokenService _tokenService;
        public VehiculoController(IVehiculoService service, ITokenService tokenService) : base(service, tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("ConsultarPorClienteId/{clienteId}")]
        public async Task<IOperationResult<IEnumerable<Vehiculo>>> ConsultarPorClienteId(int clienteId)
        {
            _tokenService.ValidateToken(Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(), Request.Method);
            return await _service.ConsultarPorClienteIdAsync(clienteId);
        }
    }
}
