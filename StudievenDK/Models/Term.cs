using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudievenDK.Models
{
    public class Term
    {
        [Key]
        public string TermYear { get; set; }
        public List<Course> Courses { get; set; }
    }
}
