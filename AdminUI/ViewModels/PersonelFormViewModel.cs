using AdminUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman> Departmanlar { get; set; }
        public IEnumerable<Personel> Personeller { get; set; }
        public Personel Personel { get; set; }
    }
}