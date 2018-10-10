using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace GaugeCalibration.Models
{
    public class Comment
    {
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Gauge Gauge { get; set; }
        [DisplayName("Serial")]
        public int GaugeId { get; set; }
        [DisplayName("Comment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [DisplayName("Inspector Name")]
        public string Name { get; set; }
        [DisplayName("Comment")]
        public string Text { get; set; }
    }
}