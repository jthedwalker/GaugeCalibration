using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace GaugeCalibration.Models
{
    public class Gauge
    {
        public Gauge()
        {
            Comments = new HashSet<Comment>();
        }

        // Stripping the first word to the first space in the string
        [NotMapped]
        [DisplayName("Last Comment")]
        public string LastComment
        {
            get
            {
                var comment = Comments.OrderByDescending(c => c.Id).FirstOrDefault().Text;
                if (comment.Length > 0 && comment.Contains(" "))
                {
                    return comment.Substring(0, comment.IndexOf(" "));
                }

                return comment;
            }
        }

        private string _plant;
        [MaxLength(3, ErrorMessage = "Enter a 3 digit plant code.")]
        public string Plant
        {
            get => _plant;
            set => _plant = value.ToUpper();
        }

        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Range { get; set; }
        public string Frequency { get; set; }
        public Method Method { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastCal { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? NextCal { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}