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
    public class RegistroAccesoController : OperationController<RegistroAcceso, IRegistroAccesoService>
    {
        private readonly ITokenService _tokenService;
        public RegistroAccesoController(IRegistroAccesoService service, ITokenService tokenService) : base(service, tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("ConsultarPorClienteId/{clienteId}")]
        public async Task<IOperationResult<IEnumerable<RegistroAcceso>>> ConsultarPorClienteId(int clienteId)
        {
            _tokenService.ValidateToken(Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());
            return await _service.ConsultarPorClienteIdAsync(clienteId);
        }
    }
}
