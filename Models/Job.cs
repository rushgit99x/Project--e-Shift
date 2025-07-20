using System;

namespace e_Shift.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string JobNumber { get; set; }
        public int CustomerID { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime PreferredDate { get; set; }
        public string Description { get; set; }
        public int TransportUnitID { get; set; }
    }
}