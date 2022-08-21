using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intro2._0.Models;

namespace Intro2._0.Controllers
{
    public class IntroductionsController : Controller
    {
        private Intro db = new Intro();

        // GET: Introductions
        public ActionResult Index()
        {
            var introductions = db.Introductions.Include(i => i.Department).Include(i => i.Program).Include(i => i.University).Include(i => i.Faculty).Include(i => i.Session);
            return View(introductions.ToList());
        }

        // GET: Introductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Introduction introduction = db.Introductions.Find(id);
            if (introduction == null)
            {
                return HttpNotFound();
            }
            return View(introduction);
        }

        // GET: Introductions/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName");
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName");
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName");
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName");
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "SessionName");
            return View();
        }

        // POST: Introductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IntroductionId,ProgramId,SessionId,DepartmentId,FacultyId,UniversityId,DeptContacts,FacultyMembers,Intro,MessageofVc,MessageofChairman")] Introduction introduction)
        {
            if (ModelState.IsValid)
            {
                db.Introductions.Add(introduction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName", introduction.DepartmentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName", introduction.ProgramId);
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName", introduction.UniversityId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", introduction.FacultyId);
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "SessionName", introduction.SessionId);
            return View(introduction);
        }

        // GET: Introductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Introduction introduction = db.Introductions.Find(id);
            if (introduction == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName", introduction.DepartmentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName", introduction.ProgramId);
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName", introduction.UniversityId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", introduction.FacultyId);
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "SessionName", introduction.SessionId);
            return View(introduction);
        }

        // POST: Introductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IntroductionId,ProgramId,SessionId,DepartmentId,FacultyId,UniversityId,DeptContacts,FacultyMembers,Intro,MessageofVc,MessageofChairman")] Introduction introduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(introduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName", introduction.DepartmentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName", introduction.ProgramId);
            ViewBag.UniversityId = new SelectList(db.Universities, "UniversityId", "UniversityName", introduction.UniversityId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", introduction.FacultyId);
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "SessionName", introduction.SessionId);
            return View(introduction);
        }

        // GET: Introductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Introduction introduction = db.Introductions.Find(id);
            if (introduction == null)
            {
                return HttpNotFound();
            }
            return View(introduction);
        }

        // POST: Introductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Introduction introduction = db.Introductions.Find(id);
            db.Introductions.Remove(introduction);
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
