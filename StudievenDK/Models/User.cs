using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StudievenDK.Models
{
    public class User
    {
        [Key] 
        public MailAddress Email { get; set; }

        public string Password { get; set; } //Snak med Nikolaj og Jonas om hvordan denne bliver seedet
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public List<Case> Cases { get; set; }
        public List<Case> CasesSeeker { get; set; }
    }
}
