using Microsoft.AspNetCore.Mvc;
using University.Repositories.Interfaces;
using UniversityAPI.Repositories.Interfaces;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetAll()
        {
            var universities = await _universityRepository.GetAllAsync();
            return Ok(universities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetById(int id)
        {
            var university = await _universityRepository.GetByIdAsync(id);
            if (university == null)
                return NotFound();

            return Ok(university);
        }

        [HttpPost]
        public async Task<ActionResult> Add(University university)
        {
            await _universityRepository.AddAsync(university);
            return CreatedAtAction(nameof(GetById), new { id = university.UniversityId }, university);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, University updatedUniversity)
        {
            if (id != updatedUniversity.UniversityId)
                return BadRequest();

            await _universityRepository.UpdateAsync(updatedUniversity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _universityRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}