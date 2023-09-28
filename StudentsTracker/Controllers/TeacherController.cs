using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public TeacherController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(Teacher teacher)
        {
            _appDbContext.Teachers.Add(teacher);
            await _appDbContext.SaveChangesAsync();

            return Ok(teacher);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherId(int id)
        {
            Teacher? teacher = await _appDbContext.Teachers.FindAsync(id);

            if (teacher != null)
            {
                return Ok(await _appDbContext.Teachers.FindAsync(id));
            }

            return NotFound("Teacher not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(Teacher field, int id)
        {
            Teacher? teacher = await _appDbContext.Teachers.FindAsync(id);

            if (teacher != null)
            {
                teacher.Name = field.Name;
                teacher.Surname = field.Surname;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            Teacher? teacher = await _appDbContext.Teachers.FindAsync(id);

            if (teacher != null)
            {
                _appDbContext.Teachers.Remove(teacher);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(teacher);
        }
    }
}
