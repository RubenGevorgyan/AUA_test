using AUA_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AUA_test.Controllers
{
    public class DashboardController : Controller
    {
        private AuaDbContext db = new AuaDbContext();
        // GET: Dashboard
        public ActionResult Index()
        {

            int role = Convert.ToInt32(Session["UserPosition"]);
            int userId = Convert.ToInt32(Session["UserID"]);
            
            using (AuaDbContext db = new AuaDbContext())
            {
                var userClases = db.UserClasses.Where(item => item.fk_User == userId).ToList();
                List<Class> Class = new List<Class>();
                foreach (var item in userClases)
                {
                    var b = db.Classes.Where(a => a.Id == item.fk_Class).FirstOrDefault();
                    Class.Add(b);
                }
                ViewBag.Class = Class;
            }
            if (role == 0)
            {
                return View("Class");
            }
            else if (role == 1)
            {
                return View("TeacherClass");
            }
            else
            {
                return View("Error");
            }
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

    }
}