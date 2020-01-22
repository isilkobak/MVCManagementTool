using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminUI.Models.EntityFramework;

namespace AdminUI.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities(); 
        // GET: Departman
        public ActionResult Index()
        {

            //var model = db.Departman.Include(x => x.Personel).ToList();
            var model = db.Departman.ToList();
            return View(model);
        }


        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm");
        }

        [HttpPost]
        public ActionResult Kaydet(Departman departman)
        {
            /* using (var transaction = db.Database.BeginTransaction())
                        {
                            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Departman] ON");


                            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Departman] OFF");
                            transaction.Commit();
                        } */

            if(departman.Id == 0)
            {
                db.Departman.Add(departman);
                
            }
            else
            {
                var guncelDep = db.Departman.Find(departman.Id);
                if (guncelDep == null)
                {
                    return HttpNotFound();
                }
                guncelDep.Ad = departman.Ad; 
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Departman");
        }

        public ActionResult Sil(int id)
        {
            var silinecekdepartman = db.Departman.Find(id);
            if (silinecekdepartman == null)
                return HttpNotFound();
            else
            {
                var Personeller = db.Personel.ToList();
                bool flag = true;
                foreach (Personel personel in Personeller)
                {
                    if (personel.DepartmanId.Equals(silinecekdepartman.Id))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    db.Departman.Remove(silinecekdepartman);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm", model);
        }


    }
}