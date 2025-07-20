using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface INotificationRepository
    {
        bool CreateNotification(Notification notification);
    }
}