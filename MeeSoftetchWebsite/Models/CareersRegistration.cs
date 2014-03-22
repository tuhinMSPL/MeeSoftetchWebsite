using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;
//using ;
namespace MeeSoftetchWebsite.Models
{
    
    public class CareersRegistration
    {
        [Key]
       public int CandidateId { get; set; }

        [Display(Name = "Application for:")]
        [Required(ErrorMessage = "Please select position applied for.")]
        public string AppliedFor { get; set; }


        [Display (Name="Name:")]
        [Required (ErrorMessage="Please enter name.")]
        public string Name {get; set;}

        [Display(Name = "Select Gender:")]
        [Required(ErrorMessage = "Please select gender.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter contact number.")]
        [Display(Name = "Contact Number:")]
        [RegularExpression("^((\\+91-?)|0)?[0-9]{10}$", ErrorMessage = "Start your phone number eith with +91 or 0")]
       // [Range(11,13,ErrorMessage=("Invalid contact number."))]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter email address.")]
        [EmailAddress (ErrorMessage="Invalid email address.")]
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set;}

        [Display(Name = "Highest Qualification:")]
        [Required(ErrorMessage="Please enter highest qualification.")]

        public string SelectedHighestQualification { get; set; }

        [Display(Name = "Experience in Years:")]
        [Required(ErrorMessage = "Please enter exp. in years.")]
        [Range(0, 3)]
        public int ExperienceYear { get; set; }


        [Display(Name = "Experience in Month:")]
        [Required(ErrorMessage = "Please enter exp. in month.")]
        [Range(0,11)]
        public int ExperienceMonth { get; set; }

        
        [Display(Name = "Key Skills:")]
        [Required(ErrorMessage="Please enter some key skills:")]
        public string KeySkills { get; set; }

        [Display(Name = "Paste your resume here:")]
        [Required(ErrorMessage = "This cannot be empty.")]
        public string ResumePlainText { get; set; }

        public DateTime? AppliedDate { get; set; }

        public IEnumerable<CareersRegistration> CareerRegistrations { get; set; }

        public CareersRegistration()
        {
          //  HighestQualification = new List<SelectListItem>();
        }

        public IEnumerable<SelectListItem> GetQualifications()
        {
            var qualifications = new List<SelectListItem>();
            qualifications.Add(new SelectListItem { Value = "Masters-MCA", Text = "Masters-MCA" });
            qualifications.Add(new SelectListItem { Value = "Masters-Msc-IT", Text = "Masters-Msc-IT" });
            qualifications.Add(new SelectListItem { Value = "Masters-Msc-CS", Text = "Masters-Msc-CS" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-B.Tech-IT", Text = "Bachelors-B.Tech-IT" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-B.Tech-CS", Text = "Bachelors-B.Tech-CS" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-B.Tech-Other", Text = "Bachelors-B.Tech-Other" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-BCA", Text = "Bachelors-BCA" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-BSc-Hons", Text = "Bachelors-BSc-Hons" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-BSc-IT", Text = "Bachelors-BSc-IT" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-BSc-CS", Text = "Bachelors-BSc-CS" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-BSc-Other", Text = "Bachelors-BSc-Other" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-BA-Hons", Text = "Bachelors-BA-Hons" });
            qualifications.Add(new SelectListItem { Value = "Bachelors-BA-Other", Text = "Bachelors-BA-Other" });
            qualifications.Add(new SelectListItem { Value = "Diploma-CS/IT", Text = "Diploma-CS/IT" });
            qualifications.Add(new SelectListItem { Value = "Diploma-Hardware/Netwoking", Text = "Diploma-Hardware/Netwoking" });
            return qualifications;
        }

        public IEnumerable<SelectListItem> GetGender()
        {
            var genderlist = new List<SelectListItem>();
            genderlist.Add(new SelectListItem { Value = "Male", Text = "Male" });
            genderlist.Add(new SelectListItem { Value = "Female", Text = "Female" });
            genderlist.Add(new SelectListItem { Value = "Other", Text = "Other" });
            return genderlist;

        }

        public IEnumerable<SelectListItem> GetYear()
        {
           var year = new List<SelectListItem>();
           year.Add(new SelectListItem { Value = "0", Text = "0" });
           year.Add(new SelectListItem { Value = "1", Text = "1" });
           year.Add(new SelectListItem { Value = "2", Text = "2" });
           year.Add(new SelectListItem { Value = "3", Text = "3" });
            return year;

        }

        public IEnumerable<SelectListItem> GetMonth()
        {
            var year = new List<SelectListItem>();
            year.Add(new SelectListItem { Value = "0", Text = "0" });
            year.Add(new SelectListItem { Value = "1", Text = "1" });
            year.Add(new SelectListItem { Value = "2", Text = "2" });
            year.Add(new SelectListItem { Value = "3", Text = "3" });
            year.Add(new SelectListItem { Value = "4", Text = "4" });
            year.Add(new SelectListItem { Value = "5", Text = "5" });
            year.Add(new SelectListItem { Value = "6", Text = "6" });
            year.Add(new SelectListItem { Value = "7", Text = "7" });
            year.Add(new SelectListItem { Value = "8", Text = "8" });
            year.Add(new SelectListItem { Value = "9", Text = "9" });
            year.Add(new SelectListItem { Value = "10", Text = "10" });
            year.Add(new SelectListItem { Value = "11", Text = "11" });
            year.Add(new SelectListItem { Value = "12", Text = "12" });
            return year;

        }

        public IEnumerable<SelectListItem> GetOpenPositions()
        {
            var openlingList = new MeeSoftetchWebsite.Models.CareersDbContext();
            var openPositionsList = new List<SelectListItem>();
            var openings = from n in openlingList.CareersDb
                           orderby n.JobPostingDate descending
                           where n.IsOpen == "Open" || n.IsOpen == "OPEN"
                           select n;

            foreach (var item in openings)
            {
                openPositionsList.Add(new SelectListItem { Value = item.OpeningTitle, Text = item.OpeningTitle });
            }
            return openPositionsList;

        }

            public class CareersRegistrationDbContext:DbContext
        {
          public  CareersRegistrationDbContext()
                : base("DefaultConnection")
        {

        }
            public DbSet<CareersRegistration> careersDb { get; set; }
        }

    }
}