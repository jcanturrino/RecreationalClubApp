using Configurations.BaseController;
using Configurations.BaseInterface;
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
        private readonly ITokenService _tokenService;
        public UsuarioController(IUsuarioService service, ITokenService tokenService) : base(service, tokenService)
        {
            _usuarioService = service;
            _tokenService = tokenService;
        }



        [HttpPost("Authenticate")]
        public async Task<IOperationResult<string>> Authenticate([FromBody] AuthenticateModel model)
        {
            return await _usuarioService.AuthenticateAsync(model.Username, model.Password);
        }
    }
}
