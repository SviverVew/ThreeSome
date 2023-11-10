using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class LoginController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AuthenLogin(UserTable user)
        {
            var check = db.UserTables.Where(u => u.userName.Equals(user.userName)
            && u.userPass == user.userPass).FirstOrDefault();
            Session["Username"] = user.userName;
            Session["Password"] = user.userPass;
            //Session["Userrole"] = user.userRole;
            if (check == null)
            {
                ViewBag.ErrorLog = "Bạn đã nhập sai username hoặc password";
                return View("Login");
            }
            else
            {
                var check_user = db.UserTables.FirstOrDefault(u => u.userName == user.userName);
                return RedirectToAction("Homepage", "Home");

            }
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult AuthenRegister(UserTable user)
        {
            try
            {
                if (user.userPass != user.userRepass)
                {
                    ViewBag.ErrPass = "Repass not match";
                }
                var check = db.UserTables.FirstOrDefault(u => u.userName == user.userName);
                var checkEMail = db.UserTables.FirstOrDefault(u => u.userEmail == user.userEmail);
                if (check != null || checkEMail != null)
                {
                    if (check != null)
                    {
                        ViewBag.ErrName = "Username already exist";
                    }
                    if (checkEMail != null)
                    {
                        ViewBag.ErrEmail = "Email already exist";
                    }
                    return View("Register");
                }
                else
                {
                    db.UserTables.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Login");
                }
            }
            catch
            {
                return View("Register");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Homepage", "Home");
        }
    }
}