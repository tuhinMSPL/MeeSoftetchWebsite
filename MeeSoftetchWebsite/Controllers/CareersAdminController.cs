using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeeSoftetchWebsite.Models;
using Microsoft.AspNet.Identity;
namespace MeeSoftetchWebsite.Controllers
{
     [Authorize]
    public class CareersAdminController : Controller
    {
        private CareersDbContext db = new CareersDbContext();

        
         // GET: /CareersAdmin/
         [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.CareersDb.ToList());
        }

        // GET: /CareersAdmin/Details/5
         [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Careers careers = db.CareersDb.Find(id);
            if (careers == null)
            {
                return HttpNotFound();
            }
            return View(careers);
        }

        // GET: /CareersAdmin/Create
         [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var careers = new Careers();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Careers careers)
        {
            if (ModelState.IsValid)
            {
                var newCareerTemp = new Careers
                {
                    OpeningTitle = careers.OpeningTitle,
                    IsOpen = careers.IsOpen,
                    Description = careers.Description,
                    ExperienceMonth = careers.ExperienceMonth,
                    ExperienceYear = careers.ExperienceYear,
                    //TODO: Change it to idendentity user
                    PostedByEmployee = (string)Session["ApplicationEmployeeName"],
                    JobPostingDate = DateTime.Now,
                    SkillsRequired = careers.SkillsRequired
                };
                db.CareersDb.Add(newCareerTemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(careers);
        }

        // GET: /CareersAdmin/Edit/5
         [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Careers careers = db.CareersDb.Find(id);
            if (careers == null)
            {
                return HttpNotFound();
            }
            return View(careers);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Careers careers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(careers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(careers);
        }

        // GET: /CareersAdmin/Delete/5
         [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Careers careers = db.CareersDb.Find(id);
            if (careers == null)
            {
                return HttpNotFound();
            }
            return View(careers);
        }

        // POST: /CareersAdmin/Delete/5
         [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Careers careers = db.CareersDb.Find(id);
            db.CareersDb.Remove(careers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Applicants()
        {
            var dbInstance = new MeeSoftetchWebsite.Models.CareersRegistration.CareersRegistrationDbContext();
            
            var selectApplicantGroup = dbInstance.careersDb.GroupBy(m => m.AppliedFor);


            ViewBag.ApplicantList = selectApplicantGroup;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AjaxRequestApplicants()
        {
            var dbInstance = new MeeSoftetchWebsite.Models.CareersRegistration.CareersRegistrationDbContext();

            var selectApplicantGroup = from n in dbInstance.careersDb
                                           select n;
            ViewBag.FilteredSearch = selectApplicantGroup;
               return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AjaxRequestApplicants(string searchString)
        {
            var dbInstance = new MeeSoftetchWebsite.Models.CareersRegistration.CareersRegistrationDbContext();

            var selectApplicants = from n in dbInstance.careersDb
                                   select n;

            var filterApplicants = from n in selectApplicants
                                   where n.KeySkills.Contains(searchString) ||
                                   n.ResumePlainText.Contains(searchString) || n.Name.Contains(searchString)
                                   select n;

            ViewBag.FilteredSearch = filterApplicants;
            return View();
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
