using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFG_Task.Models
{
    public class ConferencerRoom
    {
        [Key]
        public int conferencerRoomID { get; set; }
        public string roomNumber { get; set; }
        public DateTime timeSector { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}