using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeeSoftetchWebsite.Models;

namespace MeeSoftetchWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var newsDbInstance = new NewsDbContext();

            var selectTopTwoNews = (from n in newsDbInstance.NewsDb
                                    orderby n.CreationDate descending
                                    select n).Take(2);

            ViewBag.TopTwoNews = selectTopTwoNews;


            if (Session["FirstVisit"] == null)
            {
                try
                {
                    Random randomNumber = new Random();
                    int generatedNo = randomNumber.Next(100, int.MaxValue);
                    Session["FirstVisit"] = generatedNo;
                    var submitstat = new VisitStatistics
                    {

                        sessionGuid = Guid.NewGuid(),
                        BrowserDetails = Request.Browser.Browser + "-" + Request.Browser.MajorVersion.ToString() + " " + Request.Browser.MinorVersion.ToString(),
                        IsMobileDevice = Request.Browser.IsMobileDevice.ToString(),
                        IpAddress = System.Web.HttpContext.Current.Request.UserHostAddress,
                        BrowserOs = Request.Browser.Platform,
                        Accesstime = DateTime.Now
                    };
                    VisitStatisticsDbContext dbInstance = new VisitStatisticsDbContext();
                    dbInstance.VisitDb.Add(submitstat);
                    dbInstance.SaveChangesAsync();
                    return View();
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);
                    throw;
                }
            }
            else
            {
                return View();
            }  

            
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        [HttpGet]
        public ActionResult Contact()
        {
            var lists = new ContactUs();
            ViewBag.CountryList = lists.GetCountryName();


            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactUs Modeldata)
        {
            var lists = new ContactUs();
            ViewBag.CountryList = lists.GetCountryName();
            if (ModelState.IsValid)
            {
             using(var dbinstance=new ContactUsDbContext())
             {
                 dbinstance.ContactsUsDb.Add(Modeldata);
                 dbinstance.SaveChanges();
                 TempData["ThankMessage"] = "Thank you for your interest in MEE Softtech. We will get in touch with you Soon.";
                 return RedirectToAction("SubmitSuccess", "Home");

             }
             
            }
            else
            {

                ModelState.AddModelError("", "Unable to process your request at this moment.");
            }



            return View(Modeldata);
        }


        public ActionResult SubmitSuccess()
        {
            ViewBag.ThanksMessage = TempData["ThankMessage"];
            return View();
        }


        public ActionResult ErpDetails()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
       
    }
}