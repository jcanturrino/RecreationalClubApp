using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Configurations.BaseController
{
    namespace YourNamespace
    {
        [ApiController]
        [Route("api/[controller]")]
        public abstract class OperationController<TEntity, TService> : ControllerBase
            where TEntity : class
            where TService : IBaseService<TEntity>
        {
            protected readonly TService _service;

            protected OperationController(TService service)
            {
                _service = service;
            }

            [HttpGet("GetAll")]
            public async Task<IOperationResult<IEnumerable<TEntity>>> GetAll()
            {
                return await _service.GetAllAsync();
            }

            [HttpGet("GetById{id}")]
            public async Task<IOperationResult<TEntity>> GetById(int id)
            {
                return await _service.GetByIdAsync(id);
            }

            [HttpPost("Add")]
            public async Task<IOperationResult<bool>> Add([FromBody] TEntity entity)
            {
                return await _service.AddAsync(entity);
            }

            [HttpPut("Update")]
            public async Task<IOperationResult<bool>> Update([FromBody] TEntity entity)
            {
                return await _service.UpdateAsync(entity);
            }

            [HttpDelete("Delete{id}")]
            public async Task<IOperationResult<bool>> Delete(int id)
            {
                return await _service.DeleteAsync(id);
            }
        }
    }

}
