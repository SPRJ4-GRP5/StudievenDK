using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StudievenDK.Models
{
    public class Case
    {
        [Key]
        public int CaseId { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public DateTime Deadline { get; set; }
        //public bool CaseIsDone { get; set; }

        public string UserHelper_fk { get; set; }
        public string UserSeeker_fk { get; set; }
        public string CourseName_fk { get; set; }

        public User UserHelper { get; set; }
        public User UserSeeker { get; set; }
        public Course Course { get; set; }

        [DisplayName("Filnavn")]
        public string PictureName { get; set; }

        [NotMapped]
        [DisplayName("Upload billede")]
        public IFormFile Picture { get; set; }

        
    }
}
