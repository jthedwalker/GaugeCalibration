using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GaugeCalibration.Models
{
    public class GaugeContext : DbContext
    {
        public DbSet<Gauge> Gauges { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}