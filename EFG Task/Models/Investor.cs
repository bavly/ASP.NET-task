using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFG_Task.Models
{
    public class Investor
    {
        [Key]
        public int idInvestor { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public int investorSectorID { get; set; }

        public virtual InvestorSector InvestorSector { get; set; }

    }
}