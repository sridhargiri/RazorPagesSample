using System;
using System.Collections.Generic;

namespace W1.Models
{
    public partial class StudentData
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public virtual StudentCourse StudentCourse { get; set; }
    }
}
