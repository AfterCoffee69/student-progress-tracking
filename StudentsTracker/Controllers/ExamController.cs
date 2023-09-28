using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ExamController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(Exam exam)
        {
            _appDbContext.Exams.Add(exam);
            await _appDbContext.SaveChangesAsync();

            return Ok(exam);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            Exam? exam = await _appDbContext.Exams.FindAsync(id);

            if (exam != null)
            {
                return Ok(await _appDbContext.Exams.FindAsync(id));
            }

            return NotFound("Exam not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(Exam field, int id)
        {
            Exam? exam = await _appDbContext.Exams.FindAsync(id);

            if (exam != null)
            {
                exam.Name = field.Name;
                exam.Teacher = field.Teacher;
                exam.Grade = field.Grade;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(exam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            Exam? exam = await _appDbContext.Exams.FindAsync(id);

            if (exam != null)
            {
                _appDbContext.Exams.Remove(exam);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(exam);
        }
    }
}
