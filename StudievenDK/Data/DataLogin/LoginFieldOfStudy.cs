using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudievenDK.Data.DataLogin
{
    public class LoginFieldOfStudy
    {

        public List<SelectListItem> FosList { get; set; }

        public LoginFieldOfStudy()
        {
            FosList = new List<SelectListItem>();
            FosList.Add(new SelectListItem() { Text = "Softwareteknologi", Value = "Softwareteknologi" });
            FosList.Add(new SelectListItem() { Text = "Sundhedsteknologi", Value = "Sundhedsteknologi" });
            FosList.Add(new SelectListItem() { Text = "Elektronikteknologi", Value = "Elektronikteknologi" });
        }
    }
}
