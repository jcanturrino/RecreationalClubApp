using Configurations.BaseController.YourNamespace;
using Configurations.BaseReturn.Interface;
using Configurations.JWT;
using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace RecreationalClubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : OperationController<Usuario, IUsuarioService>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("authenticate")]
        public async Task<IOperationResult<string>> Authenticate([FromBody] AuthenticateModel model)
        {
            return await _usuarioService.AuthenticateAsync(model.Username, model.Password);
        }
    }
}
