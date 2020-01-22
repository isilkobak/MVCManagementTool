using AdminUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminUI.Controllers
{
    public class SecurityController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        public ActionResult Login()
        {
            return View();
        }
        // GET: Security
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            kullanici.Sifre = MD5Secure(kullanici.Sifre);
            var kullaniciIndb = db.Kullanici.FirstOrDefault(x=>x.Ad==kullanici.Ad && x.Sifre==kullanici.Sifre);
            if (kullaniciIndb==null)
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(kullaniciIndb.Ad, false);
                return RedirectToAction("Index", "Personel");
            }
            
        }
        private string MD5Secure(string text)
        {

            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Public");
        }
    }
}