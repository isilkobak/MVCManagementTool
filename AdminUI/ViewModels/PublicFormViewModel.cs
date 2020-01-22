using AdminUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.ViewModels
{
    public class PublicFormViewModel
    {
        public List<Fotograf> fotograflar { get; set; }
        public Personel Personel { get; set; }
    }
}