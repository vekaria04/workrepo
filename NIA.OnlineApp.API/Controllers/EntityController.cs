using Microsoft.AspNetCore.Mvc;
using NIA.OnlineApp.Data.Entities;
using NIA.OnlineApp.Data.Repositories;

namespace NIA.OnlineApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityRepository _repo;
        private readonly IErrorLoggerRepository _logger;

        public EntityController(IEntityRepository repo, IErrorLoggerRepository logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] Entity entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                var result = await _repo.AddAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _logger.LogAsync(ex);
                return StatusCode(500, "An error occurred.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repo.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Entity updated)
        {
            if (id != updated.Id)
                return BadRequest("ID in URL and body must match.");

            var result = await _repo.UpdateAsync(updated);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

