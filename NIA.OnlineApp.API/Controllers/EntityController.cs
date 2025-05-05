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

        public EntityController(IEntityRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] Entity entity)
        {
            var result = await _repo.AddAsync(entity);
            return Ok(result);
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

