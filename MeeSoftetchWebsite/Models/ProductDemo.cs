using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace MeeSoftetchWebsite.Models
{
    public class ProductDemo
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Enter Full Name")]
        public string Name { get; set; }

        [Display(Name = "Designation :")]
        [Required(ErrorMessage = "Please Enter Your Designation")]
        public string Designation { get; set; }


        [Display(Name = "Company Name :")]
        [Required(ErrorMessage = "Please Enter Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Country Name :")]
        [Required(ErrorMessage = "Please Enter Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "State :")]
        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter contact number.")]
        [Display(Name = "Contact Number:")]
        [RegularExpression("^((\\+91-?)|0)?[0-9]{10}$", ErrorMessage = "Start your phone number eith with +91 or 0")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }

        public DateTime? SubmitDate { get; set; }

        public IEnumerable<ProductDemo> ProductDemos { get; set; }
        

    }

    public class ProductDemoDbContext : DbContext
    {
        public ProductDemoDbContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<ProductDemo> RequestDemoDb { get; set; }
    }
}