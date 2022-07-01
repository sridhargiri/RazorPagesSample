using System;
using System.Collections.Generic;

namespace W1.Models
{
    public partial class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual StudentData Student { get; set; }
    }
}
