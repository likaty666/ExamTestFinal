using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamTest1.Models
{
    public class ViewModelSessions
    {
        [Key]
        public int? film_id { get; set; }
        public int ses_id { get; set; }
        public DateTime? sesDate { get; set; }
        public string title { get; set; }
        public string pathPhoto { get; set; }
    }
}