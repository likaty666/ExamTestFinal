using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class ViewModelSess
    {
        [Key]
       
        public int ses_id;

        public string name ;

        public int statuss;

        public DateTime sesDate;

        public int? time;

        public int seats;

    }
}