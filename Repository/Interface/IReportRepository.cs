using System.Data;

namespace e_Shift.Repository.Interface
{
    public interface IReportRepository
    {
        DataTable GetReportData(string reportType);
    }
}