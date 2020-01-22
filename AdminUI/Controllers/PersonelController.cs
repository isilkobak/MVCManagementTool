using AdminUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AdminUI.ViewModels;
using System.IO;

namespace AdminUI.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Personel
        public ActionResult Index()
        {

            //var model = db.Personel.Include(x => x.Departman).ToList(); //Eager Loading  
            var model = db.Personel.ToList();
            return View(model);
        }

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Personel = new Personel(),
                Departmanlar = db.Departman.ToList(),
                Personeller = db.Personel.ToList()

             
            };
            
            return View("PersonelForm", model);
        }
        [HttpPost]
        public ActionResult Kaydet(Personel personel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personeller = db.Personel.ToList(),
                    Personel = personel
                };
                return View("PersonelForm",model);
            }
            Fotograf fotograf = new Fotograf();
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                fotograf.PersonelId = personel.Id;
                fotograf.Fotograf1 = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(fileName);
            }



            if (personel.Id == 0) //Ekleme
            {
                if (fotograf != null) { db.Fotograf.Add(fotograf); }
                db.Personel.Add(personel);
                
            }
            else  //Guncelleme
            {
                if(fotograf != null) { db.Fotograf.Add(fotograf); }       
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personeller = db.Personel.ToList(),
                Personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }

        
        public ActionResult Sil(int id)
        {
            var silPer = db.Personel.Find(id);
            if (silPer == null)
            {
                return HttpNotFound();
            }
            if (silPer.YoneticiMi)
            {
                return RedirectToAction("Index");
            }
            else
            {
                db.Personel.Remove(silPer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }

}