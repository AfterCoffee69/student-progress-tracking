﻿namespace StudentsTracker.Models
{
    public class Major
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
