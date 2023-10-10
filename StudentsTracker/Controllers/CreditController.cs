using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CreditController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(Credit credit)
        {
            _appDbContext.Credits.Add(credit);
            await _appDbContext.SaveChangesAsync();

            return Ok(credit);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditById(int id)
        {
            Credit? credit = await _appDbContext.Credits.FindAsync(id);

            if (credit != null)
            {
                return Ok(await _appDbContext.Credits.FindAsync(id));
            }

            return NotFound("Credit not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCredit(Credit field, int id)
        {
            Credit? credit = await _appDbContext.Credits.FindAsync(id);

            if (credit != null)
            {
                credit.Name = field.Name;
                credit.IsPassed = field.IsPassed;
                credit.Date = field.Date;
                credit.Teacher = field.Teacher;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(credit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCredit(int id)
        {
            Credit? credit = await _appDbContext.Credits.FindAsync(id);

            if (credit != null)
            {
                _appDbContext.Credits.Remove(credit);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(credit);
        }
    }
}
