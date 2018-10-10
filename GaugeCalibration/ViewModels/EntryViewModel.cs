using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GaugeCalibration.Models;

namespace GaugeCalibration.ViewModels
{
    public class EntryViewModel
    {
        public Gauge Gauge { get; set; }
        public Comment Comments { get; set; }
    }
}