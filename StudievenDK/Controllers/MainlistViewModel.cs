using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudievenDK.Models;

namespace StudievenDK.Controllers
{
    public class MainlistViewModel
    {

        public List<Case> Cases { get; set; }
        public List<string> Subject { get; set; }
        public List<string> Courses { get; set; }
        public List<string> Programme { get; set; }
        public List <string> Faculty { get; set; }

        //Test
    }
}
