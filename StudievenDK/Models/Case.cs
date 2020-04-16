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


        public User UserHelper { get; set; }
        public User UserSeeker { get; set; }
        public Course Course { get; set; }

        [NotMapped]
        [DisplayName("Upload file")]
        public IFormFile Picture { get; set; }
        public string PictureName { get; set; }
    }
}
