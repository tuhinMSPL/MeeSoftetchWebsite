using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;

namespace MeeSoftetchWebsite.Models
{
    public class ContactUs
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter contact number.")]
        [Display(Name = "Contact Number:")]
        [RegularExpression("^((\\+91-?)|0)?[0-9]{10}$", ErrorMessage = "Start your phone number eith with +91 or 0")]
        // [Range(11,13,ErrorMessage=("Invalid contact number."))]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }


        [Display(Name = "Country Name:")]
        public string CountryName { get; set; }

        [Display(Name="Comment")]
        [Required(ErrorMessage = "Please Write Yours Requirement or Comment.")]
        public string RequirementComment { get; set; }


        public IEnumerable<ContactUs> ContactsUs { get; set; }
        public IEnumerable<SelectListItem> GetCountryName()
        {
            var qualifications = new List<SelectListItem>();
            qualifications.Add(new SelectListItem { Value = "Australia", Text = "Australia" });
            qualifications.Add(new SelectListItem { Value = "Bangladesh", Text = "Bangladesh" });
            qualifications.Add(new SelectListItem { Value = "Belgium", Text = "Belgium" });
            qualifications.Add(new SelectListItem { Value = "Bhutan", Text = "Bhutan" });
            qualifications.Add(new SelectListItem { Value = "Brazil", Text = "Brazil" });
            qualifications.Add(new SelectListItem { Value = "Burma", Text = "Burma" });
            qualifications.Add(new SelectListItem { Value = "Cambodia", Text = "Cambodia" });
            qualifications.Add(new SelectListItem { Value = "Canada", Text = "Canada" });
            qualifications.Add(new SelectListItem { Value = "China", Text = "China" });
            qualifications.Add(new SelectListItem { Value = "Colombia", Text = "Colombia" });
            qualifications.Add(new SelectListItem { Value = "Denmark", Text = "Denmark" });
            qualifications.Add(new SelectListItem { Value = "Egypt", Text = "Egypt" });
            qualifications.Add(new SelectListItem { Value = "England", Text = "England" });
            qualifications.Add(new SelectListItem { Value = "India", Text = "India" });
            qualifications.Add(new SelectListItem { Value = "Others", Text = "Others" });
            return qualifications;
        }
            
    }

    public class ContactUsDbContext : DbContext
    {
        public ContactUsDbContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<ContactUs> ContactsUsDb { get; set; }
    }
}