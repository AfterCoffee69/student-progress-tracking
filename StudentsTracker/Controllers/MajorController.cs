using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public MajorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddMajor(Major major)
        {
            _appDbContext.Majors.Add(major);
            await _appDbContext.SaveChangesAsync();

            return Ok(major);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMajorById(int id)
        {
            Major? major = await _appDbContext.Majors.FindAsync(id);

            if (major != null)
            {
                return Ok(await _appDbContext.Majors.FindAsync(id));
            }

            return NotFound("Major not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMajor(Major field, int id)
        {
            Major? major = await _appDbContext.Majors.FindAsync(id);

            if (major != null)
            {
                major.Name = field.Name;
                major.Groups = field.Groups;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(major);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajor(int id)
        {
            Major? major = await _appDbContext.Majors.FindAsync(id);

            if (major != null)
            {
                _appDbContext.Majors.Remove(major);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(major);
        }
    }
}
