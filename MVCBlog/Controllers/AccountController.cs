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
        public ICollection<UserModel> GetUsers
        {
            get
            {
                if (Session["MyUsers"] == null)
                {
                    return new HashSet<UserModel>();
                }
                return (ICollection<UserModel>)Session["MyUsers"];
            }
        }

        //Sessiona kullanıcı ekler
        public void AddUserToSession(UserModel model)
        {
            Session["MyUsers"] = GetUsers;
            GetUsers.Add(model);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            //Kullanıcı kontrolü. Kullanıcı var ise oturum aç, cookie oluştur
            using (var context = new MVCBlog.Models.BlogContext())
            {

                var blog= context.UserTable.Where(b=>b.Email== "candin@h.com");
                var tester = context.UserTable.Any(x => x.Email == model.Email && x.Password == model.Password);
                if (context.UserTable.Any(x => x.Email == model.Email && x.Password == model.Password))
                {

                    return RedirectToAction("BlogEditor", "Editor");

                }
                else
                {

                    return RedirectToAction("Index", "Home");

                }
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            //ModelState.IsValid; RegisterVM içine yazdığımız DataAnnotationsa göre bool dönücek
            if (ModelState.IsValid)
            {
                UserModel m = new UserModel();
                m.Email = model.Email;
                m.Password = model.Password;
                AddUserToSession(m);

                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult Logout()
        {
            //cookie sil, oturumu kapat, logine redirect
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}