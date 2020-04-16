using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudievenDK.Models
{
    public class Programme
    {
        [Key] public string ProgrammeName { get; set; }
    }
}
