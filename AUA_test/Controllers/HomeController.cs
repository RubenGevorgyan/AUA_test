using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AUA_test.Models;
namespace AUA_test.Controllers
{
    public class HomeController : Controller
    {


        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDetails objUser)
        {
            if (ModelState.IsValid)
            {
                using (AuaDbContext db = new AuaDbContext())
                {
                    var obj = db.LoginDetails.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserPosition"] = obj.UserPosition.ToString();
                        return RedirectToAction("Index", "Classes");
                    }
                }
            }
            return View("Index");
        }
        //[HttpPost]
        //public ActionResult Index(LoginDetail model)
        //{
        //    var a = model.
        //    var item = s.FirstOrDefault();
        //    if (item == "Success")
        //    {

        //        return View("UserLandingView");
        //    }
        //    else if (item == "User Does not Exists")

        //    {
        //        ViewBag.NotValidUser = item;

        //    }
        //    else
        //    {
        //        ViewBag.Failedcount = item;
        //    }

        //    return View("Index");
        //}
    }
}
