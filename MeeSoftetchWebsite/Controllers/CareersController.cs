using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Security;
using System.Web.Mvc;
using System.Configuration;
using MeeSoftetchWebsite.Models;
using System.Net;
using System.Web.Configuration;
namespace MeeSoftetchWebsite.Controllers
{
    public class CareersController : Controller
    {
        //
        // GET: /Careers/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Careers()
        {

            return View();


        }
        public ActionResult whymspl()
        {

            return View();

        }

        public ActionResult MotivestoJoin()
        {
            return View();
        }
        public ActionResult AdmirationforVariety()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CareersRegistration()
        {
            var selectGenderList = new CareersRegistration();
            ViewBag.GenderList = selectGenderList.GetGender();
            ViewBag.QualificationsList = selectGenderList.GetQualifications();
            ViewBag.YearList = selectGenderList.GetYear();
            ViewBag.MonthList = selectGenderList.GetMonth();
            ViewBag.GetPositionList = selectGenderList.GetOpenPositions();
            return View();
        }

        [HttpPost]
        public ActionResult CareersRegistration(CareersRegistration modelData)
        {
            var selectGenderList= new CareersRegistration();
            ViewBag.GenderList = selectGenderList.GetGender();
            ViewBag.QualificationsList = selectGenderList.GetQualifications();
            ViewBag.YearList = selectGenderList.GetYear();
            ViewBag.MonthList = selectGenderList.GetMonth();
            ViewBag.GetPositionList = selectGenderList.GetOpenPositions();
            modelData.AppliedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                //TODO: save submitted information to the database.
                bool checkFlag = false;
                var checkCandidate = new CareersRegistration();
                using (var dbforcarrer = new MeeSoftetchWebsite.Models.CareersRegistration.CareersRegistrationDbContext())
                {
                    checkCandidate.CareerRegistrations = from n in dbforcarrer.careersDb
                                                         where n.EmailAddress == modelData.EmailAddress
                                                         select n;
                    foreach (var item in checkCandidate.CareerRegistrations)
                    {
                        if (item.EmailAddress == modelData.EmailAddress)
                        {
                            checkFlag = true;
                            break;
                        }
                    }

                    if (!checkFlag)
                    {
                        dbforcarrer.careersDb.Add(modelData);
                        dbforcarrer.SaveChanges();
                        //TODO:Send email address to registered candidates.
                        try
                        {
                            //create the mail message
                            var mail = new MailMessage();

                            //set the addresses
                            mail.From = new MailAddress(WebConfigurationManager.AppSettings["CareersEmailAddress"].ToString());
                            mail.To.Add(modelData.EmailAddress);

                            //set the content
                            mail.Subject = "Careers Mee Softtech";
                            mail.Body = "You have successfully submitted your details to Mee Softtech. Our HR will get in touch with you.";

                            //send the message
                            var smtp = new SmtpClient(WebConfigurationManager.AppSettings["SMTPAddress"].ToString());
                            // smtp.Port = 587;
                            smtp.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["CareersEmailAddress"].ToString(),

                                WebConfigurationManager.AppSettings["CareersPassword"].ToString());



                            smtp.EnableSsl = false;
                            smtp.Send(mail);
                            //  ViewBag.MailMessage = "Mail sent to the specified email address.";
                            // throw new Exception("error occued.");
                        }
                        catch (Exception)
                        {
                            TempData["ErrorMessage"] = "Unable to send email due to an error!";
                            ModelState.AddModelError("", "Unable to send email.");
                            // return RedirectToAction("ApplicationError");
                            //   Response.Redirect("");
                            //   throw;// new Exception("Unable to send email due to an error!");

                        }
                        TempData["CandidateRegisTrationSuccess"] = "Your application has been submitted successfully. Our HR will get in touch with you.";
                        return RedirectToAction("Careers");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email address is already registered.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Registration is failed.Please correct errors before submit.");
            }
            //var candidate = new CareersRegistration();
            //candidate.HighestQualification = candidate.GetQualifications();
            return View(modelData);
        }

        
	}
}