using System;
using System.Data;
using e_Shift.Repository.Interface;
using e_Shift.Business.Interface;

namespace e_Shift.Business.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public DataTable GenerateReport(string reportType)
        {
            if (string.IsNullOrWhiteSpace(reportType))
                throw new ArgumentException("Report type cannot be empty.");

            return _reportRepository.GetReportData(reportType);
        }
    }
}