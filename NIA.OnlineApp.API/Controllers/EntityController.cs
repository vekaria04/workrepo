using Microsoft.AspNetCore.Mvc;
using NIA.OnlineApp.Data.Entities;
using NIA.OnlineApp.Data.Repositories;

namespace NIA.OnlineApp.API.Controllers
{
    // Marks this class as an API controller and enables automatic model validation and routing
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ControllerBase
    {
        // Repository for performing CRUD operations on Entity
        private readonly IEntityRepository _repo;

        // Repository for logging exceptions to the ErrorLogs table
        private readonly IErrorLoggerRepository _logger;

        // Constructor with dependency injection of the repositories
        public EntityController(IEntityRepository repo, IErrorLoggerRepository logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // POST: api/entity
        // Creates a new entity and logs errors if any occur
        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] Entity entity)
        {
            try
            {
                // Set the current timestamp before saving
                entity.CreatedDate = DateTime.Now;

                // Add the entity using the repository
                var result = await _repo.AddAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 status code
                await _logger.LogAsync(ex);
                return StatusCode(500, "An error occurred.");
            }
        }

        // GET: api/entity
        // Retrieves all entities
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repo.GetAllAsync();
            return Ok(list);
        }

        // GET: api/entity/{id}
        // Retrieves a specific entity by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // PUT: api/entity/{id}
        // Updates an existing entity by its ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Entity updated)
        {
            // Ensure the ID in the route matches the ID in the body
            if (id != updated.Id)
                return BadRequest("ID in URL and body must match.");

            // Attempt to update the entity
            var result = await _repo.UpdateAsync(updated);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // DELETE: api/entity/{id}
        // Deletes an entity by its ID
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
