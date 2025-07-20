using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Models
{
    public class Lorry
    {
        public int LorryID { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public decimal Capacity { get; set; }
        public string Status { get; set; }
    }
}
