using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public FacultyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(Faculty faculty)
        {
            _appDbContext.Faculties.Add(faculty);
            await _appDbContext.SaveChangesAsync();

            return Ok(faculty);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacultyById(int id)
        {
            Faculty? faculty = await _appDbContext.Faculties.FindAsync(id);

            if (faculty != null)
            {
                return Ok(await _appDbContext.Faculties.FindAsync(id));
            }

            return NotFound("Faculty not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFaculty(Faculty field, int id)
        {
            Faculty? faculty = await _appDbContext.Faculties.FindAsync(id);

            if (faculty != null)
            {
                faculty.Name = field.Name;
                faculty.Majors = field.Majors;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(faculty);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            Faculty? faculty = await _appDbContext.Faculties.FindAsync(id);

            if (faculty != null)
            {
                _appDbContext.Faculties.Remove(faculty);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(faculty);
        }
    }


}
