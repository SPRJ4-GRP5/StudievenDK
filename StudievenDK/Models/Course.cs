using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudievenDK.Models
{
    public class Course
    {
        [Key] public string CourseName { get; set; }
        [ForeignKey("Faculty")] public string FacultyName_fk { get; set; }
        [ForeignKey("Term")] public int TermYear_fk { get; set; }


        //Navigational properties
        public Term Term { get; set; }
        public Faculty Faculties { get; set; }
        public List<Case> Cases { get; set; }
        public List<CourseProgramme> CourseProgrammes { get; set; }
    }
}
