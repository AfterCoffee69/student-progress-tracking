﻿namespace StudentsTracker.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
