using System.Data;

namespace e_Shift.Business.Interface
{
    public interface IReportService
    {
        DataTable GenerateReport(string reportType);
    }
}