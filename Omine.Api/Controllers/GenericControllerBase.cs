using Microsoft.AspNetCore.Mvc;
using Omine.Domain.Entities.Base;
using Omine.Domain.Service;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericControllerBase<TEntity, TId> : ControllerBase where TEntity : EntidadeBase<TId>
    {
        protected readonly Service<TEntity, TId> _service;

        public GenericControllerBase(Service<TEntity, TId> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(TId id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Post([FromBody] TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(TId id, [FromBody] TEntity entity)
        {
            if (!ModelState.IsValid || !id.Equals(entity.Id))
            {
                return BadRequest(ModelState);
            }

            var existingEntity = await _service.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TId id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}