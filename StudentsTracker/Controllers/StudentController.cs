using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public StudentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _appDbContext.Students.Add(student);
            await _appDbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            Student? student = await _appDbContext.Students.FindAsync(id);

            if (student != null)
            {
                return Ok(await _appDbContext.Students.FindAsync(id));
            }

            return NotFound("Student not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Student field, int id)
        {
            Student? student = await _appDbContext.Students.FindAsync(id);

            if (student != null)
            {
                student.Name = field.Name;
                student.Surname = field.Surname;
                student.Group = field.Group;
                student.Credits = field.Credits;
                student.Exams = field.Exams;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student? student = await _appDbContext.Students.FindAsync(id);

            if (student != null)
            {
                _appDbContext.Students.Remove(student);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(student);
        }
    }
}
