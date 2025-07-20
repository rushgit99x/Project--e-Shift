using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Models
{
    public class TransportUnitView
    {
        public int TransportUnitID { get; set; }
        public string LicensePlate { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public string AssistantFirstName { get; set; }
        public string AssistantLastName { get; set; }
        public string ContainerNumber { get; set; }
        public string Status { get; set; }
    }
}
