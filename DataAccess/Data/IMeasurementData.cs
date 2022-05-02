using DataAccess.Models;

namespace DataAccess.Data {
    public interface IMeasurementData {
        Task<IEnumerable<MeasurementModel>> GetMeasurements();
        Task<MeasurementModel?> GetMeasurementsByTime(DateTime TimeStart, DateTime TimeEnd);
        Task InsertMeasurement(MeasurementModel measurement);
    }
}