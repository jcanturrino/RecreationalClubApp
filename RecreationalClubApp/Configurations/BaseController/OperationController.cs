using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Configurations.BaseController
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class OperationController<TEntity, TService> : ControllerBase
            where TEntity : class
            where TService : IBaseService<TEntity>
    {
        protected readonly TService _service;
        private readonly ITokenService _tokenService;
        protected OperationController(TService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpGet("GetAll")]
        public async Task<IOperationResult<IEnumerable<TEntity>>> GetAll()
        {
            _tokenService.ValidateToken(Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(), Request.Method);
            return await _service.GetAllAsync();
        }

        [HttpGet("GetById{id}")]
        public async Task<IOperationResult<TEntity>> GetById(int id)
        {
            _tokenService.ValidateToken(Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(), Request.Method);
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("Add")]
        public async Task<IOperationResult<bool>> Add([FromBody] TEntity entity)
        {
            _tokenService.ValidateToken(Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(), Request.Method);
            return await _service.AddAsync(entity);
        }

        [HttpPut("Update")]
        public async Task<IOperationResult<bool>> Update([FromBody] TEntity entity)
        {
            _tokenService.ValidateToken(Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(), Request.Method);
            return await _service.UpdateAsync(entity);
        }

        [HttpDelete("Delete{id}")]
        public async Task<IOperationResult<bool>> Delete(int id)
        {
            _tokenService.ValidateToken(Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(), Request.Method);
            return await _service.DeleteAsync(id);
        }
    }
}
