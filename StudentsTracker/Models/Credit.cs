namespace StudentsTracker.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPassed { get; set; }
        public DateTime Date { get; set; }
        public Teacher Teacher { get; set; }
    }
}
