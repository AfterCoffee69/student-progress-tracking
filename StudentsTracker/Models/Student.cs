using Microsoft.Identity.Client;

namespace StudentsTracker.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Group Group { get; set; }
        public List<Credit> Credits { get; set; } = new List<Credit>();
        public List<Exam> Exams { get; set; } = new List<Exam>();
    }
}
