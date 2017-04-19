using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class ViewModelFilm
    {
        [Key]
        public int film_id { get; set; }

        public string title { get; set; }

        public string about { get; set; }

        public string starring { get; set; }

        public DateTime? sesDate { get; set; }
        public int ses_id { get; set; }
        public string director { get; set; }

        public DateTime? BeginDate { get; set; }

        public int photo_id { get; set; }

        public string pathPhoto { get; set; }

        public bool? isMain { get; set; }

        public string trailer { get; set; }
        public bool? catalog { get; set; }
    }
}