namespace StudentsTracker.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public Teacher Teacher { get; set; }
    }
}
