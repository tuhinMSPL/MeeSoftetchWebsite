using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeeSoftetchWebsite.Models;
namespace MeeSoftetchWebsite.Controllers
{
    public class ProductDemoController : Controller
    {
        //
        // GET: /ProductDemo/
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(ProductDemo modelData)
        {
            if (ModelState.IsValid)
            {
                //TODO: 1. Save to database. 2. Send an email. 3. Redirect to ProductDemo/SubmitSuccess
                try
                {
                    using (var dbInstance = new ProductDemoDbContext())
                    {
                        modelData.SubmitDate = DateTime.Now;
                        dbInstance.RequestDemoDb.Add(modelData);
                        dbInstance.SaveChanges();
                        TempData["ThankMessage"] = "Thank you for your interest in MEE Softtech. Our sales team will get in touch with you.";
                        return RedirectToAction("SubmitSuccess", "ProductDemo");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Your request cannot be processed at this time due to an error.");
                    throw;
                }
            }
            return View(modelData);
        }

        public ActionResult SubmitSuccess()
        {
            ViewBag.ThanksMessage = TempData["ThankMessage"];
            return View();
        }

        //TODO:Remove Authorize tag (ViewRequestDemo can only have access to regtered users)
        [Authorize]
        public ActionResult ViewRequestedDemo()
        {
            var dbInstance = new ProductDemoDbContext();

            var selectAllData = from n in dbInstance.RequestDemoDb
                                orderby n.SubmitDate descending
                                select n;

            ViewBag.ViewAllData = selectAllData;

            return View();
        }


        //TODO:Remove Authorize tag (ViewRequestDemo can only have access to regtered users)
        [HttpPost]
        [Authorize]
        public ActionResult ViewRequestedDemo(string searchString)
        {
            var dbInstance = new ProductDemoDbContext();
            
                

                var selectAllData = from n in dbInstance.RequestDemoDb
                                    orderby n.SubmitDate descending
                                    where
                                    n.State.Contains(searchString) || n.Name.Contains(searchString) || n.EmailAddress.Contains(searchString)
                                    select n;

                ViewBag.ViewAllData = selectAllData; 
            

            return View();
        }


    }
}