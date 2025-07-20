namespace e_Shift.Models
{
    public class Load
    {
        public int LoadID { get; set; }
        public string LoadNumber { get; set; }
        public int JobID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; }
    }
}