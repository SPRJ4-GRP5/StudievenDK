using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace StudievenDK.Models.Login
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string Name { get; set; }

        [Required]
        [PersonalData]
        [DisplayName("Fødselsdag")]
        public string Birthday { get; set; }

        [Required]
        [PersonalData]
        public string FieldOfStudy { get; set; }

        [Required]
        [PersonalData]
        [DisplayName("Fakultet")]
        public string Faculty { get; set; }

        [PersonalData]
        public int Term { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Om mig")]
        public string Description { get; set; }


        //Image model 
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        ////Nav props added by Alexa
        //public List<Case> MyCases { get; set; }
        //public List<Case> HelpinggCases { get; set; }
    }
}
