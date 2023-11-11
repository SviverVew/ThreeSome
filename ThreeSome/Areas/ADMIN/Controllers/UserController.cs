using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ThreeSome.Models;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class UserController : Controller
    {
        // GET: ADMIN/User
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        public ActionResult UserList()
        {
            return View(db.UserTables.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserTable user)
        {
            try
            {   
                var checkUser = db.UserTables.Where(u => u.userName == user.userName).FirstOrDefault();
                var checkEmail = db.UserTables.Where(u=>u.userEmail == user.userEmail).FirstOrDefault();   
                if(checkUser != null || checkUser != null) 
                {
                    if(checkUser != null) 
                    {
                        ModelState.AddModelError("userName","Tên đăng nhập đã tồn tại");
                    }
                    if(checkEmail != null) 
                    {
                        ModelState.AddModelError("userEmail","Email đã tồn tại");
                    }
                    return View("Create");
                }
                else
                {
                    db.UserTables.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("UserList");
                }
            }
            catch
            {
                return View("Create");
            }
        }

        #region "XOA USER"
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id, UserTable user)
        {
            try
            {
                user = db.UserTables.Where(u => u.userID== id).FirstOrDefault();
                db.UserTables.Remove(user);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            catch
            {
                return View("Delete");
            }
        }
        #endregion
        #region "THONG TIN USER"
        public ActionResult Details(int id)
        {
            return View(db.UserTables.Where(u=> u.userID == id).FirstOrDefault());
        }
        #endregion
        #region "SUA USER"
        public ActionResult Edit(int id) 
        {
            return View(db.UserTables.Where(u=>u.userID==id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, UserTable _user)
        {
            try
            {
                db.Entry(_user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Edit");
            }
        }
        #endregion
    }
}