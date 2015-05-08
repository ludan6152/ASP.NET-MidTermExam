using System;

namespace KuasCore.Models
{
    public class Course
    {
        public Int32 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return "Name = " + Name + ", Description = " + Description + ".";
        }

    }
}
