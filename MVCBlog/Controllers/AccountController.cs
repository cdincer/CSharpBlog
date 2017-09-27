using MVCBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBlog.Controllers
{
    //Web.config => system.web içerisine 
    //
    //<authentication mode = "Forms" >
    //  < forms loginUrl="~/Account/Login"></forms>
    //</authentication>



    public class AccountController : Controller
    {
        public MVCBlog.Models.BlogContext db = new MVCBlog.Models.BlogContext();

        //Oturumu açık olan userlar listesi
        public UserModel GetUsers
        {
            get
            {
                if (Session["MyUsers"] == null)
                {
                    return new UserModel();
                }
                return (UserModel)Session["MyUsers"];
            }
        }

        //Sessiona kullanıcı ekler
        public void AddUserToSession(UserModel model)
        {
            
          
            
            Session["MyUsers"] = model;
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
           
            //Kullanıcı kontrolü. Kullanıcı var ise oturum aç, cookie oluştur
            using (var context = new BlogContext())
            {

               
                if (context.UserTable.Any(x => x.Email == model.Email && x.Password == model.Password))
                {
                    var kisi = context.UserTable.Where(x => x.Email == model.Email).First();
                    AddUserToSession(kisi);
                    /*First Way of Cookie Writing  */
                    FormsAuthentication.SetAuthCookie(kisi.Email, true);
                    /*Second Way of cookie writing */
                    HttpCookie ACookie = new HttpCookie("UserModelKeeper");
                    
                    ACookie.Value = kisi.ID.ToString();

                    Response.Cookies.Add(ACookie);
                    /*---*/


                    var takmaad = HttpContext.User.Identity.Name;
                    return RedirectToAction("Index", "Home");


                }
                else
                {
                    return RedirectToAction("Editor", "BlogEditor");


                }
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(RegisterVM model)
        //{
        //    //ModelState.IsValid; RegisterVM içine yazdığımız DataAnnotationsa göre bool dönücek
        //    if (ModelState.IsValid)
        //    {
        //        UserModel m = new UserModel();
        //        m.Email = model.Email;
        //        m.Password = model.Password;
        //        AddUserToSession(m);

        //        return RedirectToAction("Login", "Account");
        //    }
        //    return View();
        //}

        public ActionResult Logout()
        {
            //cookie sil, oturumu kapat, logine redirect
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}