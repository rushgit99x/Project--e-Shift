using System;

namespace e_Shift.Models
{
    public class TransportUnit
    {
        public int TransportUnitID { get; set; }
        public int LorryID { get; set; }
        public int DriverID { get; set; }
        public int AssistantID { get; set; }
        public int ContainerID { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}