using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class ViewModelTicket
    {
        [Key]
        public int ticket_id { get; set; }

        public int film_id { get; set; }

        public string user_id { get; set; }
        public int ses_id { get; set; }
        public string title { get; set; }

       public int hall_id { get; set; }

        public int hall { get; set; }

        public int? time { get; set; }

        public decimal price { get; set; }

        public DateTime? sessionDate { get; set; }

        public int seat { get; set; }
    }
}