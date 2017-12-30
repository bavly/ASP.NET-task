using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFG_Task.Models
{
    public class Investee
    {
        [Key]
        public int idInvestee { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public int investorSecteeID { get; set; }

        public virtual InvesteeSector InvesteeSector { get; set; }
    }
}