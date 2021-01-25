using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AUA_test;
using AUA_test.Models;

namespace AUA_test.Controllers
{
    public class ClassesController : Controller
    {
        private AuaDbContext db = new AuaDbContext();
        // GET: Classes
        public ActionResult Index()
        {
            int role = Convert.ToInt32(Session["UserPosition"]);
            int userId = Convert.ToInt32(Session["UserID"]);
            var classes = Class.GetClass(userId);
            if (role == 0)
            {

                return View("Index", classes);

            }
            else if (role == 1)
            {
                return View("ClassesTeacher",classes);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            dynamic list = new ExpandoObject();
            list.Class = @class;
            list.Students = Students.GetStudents( @class.Id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: Classes/Create
        public ActionResult Create(int? classId)
        {
            ViewBag.classId = classId;
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Section,StartTime,EndTime,Length,Days")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class); 
                UserClasses user = new UserClasses();
                user.fk_Class = db.Classes.Max(x => x.Id);
                user.fk_User = Convert.ToInt32(Session["UserID"]);
                db.UserClasses.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@class);
        }
       
        // GET: Classes/Edit/5
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

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Section,StartTime,EndTime,Length,Days")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@class);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
