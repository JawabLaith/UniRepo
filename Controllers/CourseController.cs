using Microsoft.AspNetCore.Mvc;
using University.Repositories.Interfaces;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _courseRepository.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Course course)
        {
            await _courseRepository.AddAsync(course);
            return CreatedAtAction(nameof(GetById), new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Course updatedCourse)
        {
            if (id != updatedCourse.CourseId)
                return BadRequest();

            await _courseRepository.UpdateAsync(updatedCourse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _courseRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}