using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudievenDK.Models
{
    public class CourseProgramme
    {
        public string CourseName { get; set; }
        public Course Course { get; set; }
        public string ProgrammeName { get; set; }
        public Programme Programme { get; set; }
    }
}
