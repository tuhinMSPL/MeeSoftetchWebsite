using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;
namespace MeeSoftetchWebsite.Models
{
    public class Careers
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Job Title:")]
        [Required(ErrorMessage = "Please enter Job Title.")]
        public string OpeningTitle { get; set; }

        [Display(Name = "Experience(Years):")]
        [Required(ErrorMessage = "Please enter experience in years.")]
        [Range(0, 3, ErrorMessage = "Invalid input.")]
        public int ExperienceYear { get; set; }

        [Display(Name = "Experience(Months):")]
        [Required(ErrorMessage = "Please enter experience in months.")]
        [Range(0, 11, ErrorMessage = "Invalid input.")]
        public int ExperienceMonth { get; set; }

        [Display(Name = "Skills:")]
        [Required(ErrorMessage = "Please enter required skills.")]
        public string SkillsRequired { get; set; }

        [Display(Name = "Job Description:")]
        [Required(ErrorMessage = "Please enter Job Description.")]
        public string Description { get; set; }

        [Display(Name = "Position is Open:")]
        [Required(ErrorMessage = "Please select.")]
        public string IsOpen { get; set; }

        public DateTime? JobPostingDate { get; set; }

        public string PostedByEmployee { get; set; }
        public IEnumerable<Careers> CareersList { get; set; }

        public IEnumerable<SelectListItem> GetOpenList()
        {
            var openlist = new List<SelectListItem>();
            openlist.Add(new SelectListItem { Value = "Open", Text = "Open" });
            openlist.Add(new SelectListItem { Value = "Close", Text = "Close" });
            return openlist;
        }
    }

    public class CareersDbContext : DbContext
    {
        public CareersDbContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Careers> CareersDb { get; set; }

        public System.Data.Entity.DbSet<MeeSoftetchWebsite.Models.CareersRegistration> CareersRegistrations { get; set; }
    }
}