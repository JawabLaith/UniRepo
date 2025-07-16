using Microsoft.AspNetCore.Mvc;
using University.Repositories;
using University.Repositories.Interfaces;

namespace UniversityAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _InstructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _InstructorRepository = instructorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetAll()
        {
            var instructors = await _InstructorRepository.GetAllAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetById(int id)
        {
            var instructor = await _InstructorRepository.GetByIdAsync(id);
            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Instructor instructor)
        {
            await _InstructorRepository.AddAsync(instructor);
            return CreatedAtAction(nameof(GetById), new { id = instructor.InstructorId }, instructor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Instructor updatedInstructor)
        {
            if (id != updatedInstructor.InstructorId)
                return BadRequest();

            await _InstructorRepository.UpdateAsync(updatedInstructor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _InstructorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
