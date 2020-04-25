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
    public class ImageModel
    {
        [Key]
        public int ImageId { get; set; }

        [NotMapped]
        [DisplayName("Upload billede")]
        public IFormFile Picture { get; set; }
        [DisplayName("Filnavn")]
        public string PictureName { get; set; }

        //navigates to case
        public Case Case { get; set; }
        [ForeignKey("Case")] public int CaseFk { get; set; }
    }
}
