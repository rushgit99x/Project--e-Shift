using System;

namespace e_Shift.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int RecipientID { get; set; }
        public string RecipientType { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}