using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public GroupController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(Group group)
        {
            _appDbContext.Groups.Add(group);
            await _appDbContext.SaveChangesAsync();

            return Ok(group);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            Group? group = await _appDbContext.Groups.FindAsync(id);

            if (group != null)
            {
                return Ok(await _appDbContext.Groups.FindAsync(id));
            }

            return NotFound("Group not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(Group field, int id)
        {
            Group? group = await _appDbContext.Groups.FindAsync(id);

            if (group != null)
            {
                group.Name = field.Name;
                group.Students = field.Students;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            Group? group = await _appDbContext.Groups.FindAsync(id);

            if (group != null)
            {
                _appDbContext.Groups.Remove(group);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(group);
        }
    }
}
