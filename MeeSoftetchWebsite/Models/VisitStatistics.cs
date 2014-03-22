using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace MeeSoftetchWebsite.Models
{
    public class VisitStatistics
    {
        [Key]
        public Guid sessionGuid { get; set; }
        public string BrowserDetails { get; set; }

        public string IpAddress { get; set; }

        public string IsMobileDevice { get; set; }

        public string BrowserOs { get; set; }

        public DateTime? Accesstime { get; set; }

        public IEnumerable<VisitStatistics> AllStatistics { get; set; }

    }

    public class VisitStatisticsDbContext : DbContext
    {
      public   VisitStatisticsDbContext()
            : base("DefaultConnection")
        {

        }
      public DbSet<VisitStatistics> VisitDb { get; set; }
    }
}