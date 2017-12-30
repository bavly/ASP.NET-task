using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFG_Task.Models
{
    public class InvestorSector
    {
        [Key]
        public int investorSectorID { get; set; }
        public string interestedSector { get; set; }
        public DateTime timeSector { get; set; }

        public virtual ICollection<Investor> Investors { get; set; }


    }
}