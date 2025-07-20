using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Models
{
    public class ApprovedJob
    {
        public int JobID { get; set; }
        public string JobNumber { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }
        public DateTime PreferredDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
