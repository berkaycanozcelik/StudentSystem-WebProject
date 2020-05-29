using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class StudentDers
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int DersId { get; set; }
        public Ders Ders { get; set; }
    }
}
