using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamTest1.Models
{
    public class ViewModelSess
    {
        [Key]
       
        public int ses_id;

        public string name ;

        public int statuss;


        public int seats;

    }
}