using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFG_Task.Models
{
    public class Hotel
    {
        [Key]
        public int idInvestor { get; set; }
        public string name { get; set; }
        public virtual ConferencerRoom ConferencerRoom { get; set; }

    }
}