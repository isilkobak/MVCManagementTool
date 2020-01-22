using AdminUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AdminUI.Controllers
{
    public class PublicController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Public
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
            
        }

        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }
    }
}