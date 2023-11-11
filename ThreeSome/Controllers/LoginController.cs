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
        public ActionResult AuthenLogin(string userName, string userPass)
        {
            var userStore = db.UserTables.Where(u => u.userName==userName
            && u.userPass == userPass).FirstOrDefault();
           
            //Session["Userrole"] = user.userRole;
            if (userStore == null)
            {
                ViewBag.ErrorLog = "Bạn đã nhập sai username hoặc password";
                return View("Login");
            }
            else
            {
                Session["Name"] = userStore.firstName;
                Session["Username"] = userStore.userName;
                return RedirectToAction("Index", "Home");

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
                    return RedirectToAction("Login");
                }
            }
            catch(Exception ex) 
            {

                return View("Register");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}