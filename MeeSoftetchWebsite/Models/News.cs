using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace MeeSoftetchWebsite.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Display(Name="News Header:")]
        [Required(ErrorMessage="Please enter News Header.")]
        public string NewsHeader { get; set; }

        [Display(Name = "News Message:")]
        [Required(ErrorMessage = "Please enter News Message.")]
        public string NewsString { get; set; }

       
        public DateTime? CreationDate { get; set; }

        
        public string CreatedBy { get; set; }


        public IEnumerable<News> AllNews { get; set; }
    }

    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<News> NewsDb { get; set; }
    }
}