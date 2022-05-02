using DataAccess.Models;

namespace DataAccess.Data {
    public interface IMeasurementData {
        Task DeleteMeasurement(int id);
        Task DeleteMeasurementsByMeterId(string MeterId);
        Task<MeasurementModel?> GetMeasurement(int id);
        Task<IEnumerable<MeasurementModel>> GetMeasurements();
        Task<IEnumerable<MeasurementModel>> GetMeasurementsByMeterId(string MeterId);
        Task<IEnumerable<MeasurementModel>> GetMeasurementsByTime(DateTime TimeStart, DateTime TimeEnd);
        Task<IEnumerable<MeasurementModel>> GetMeters();
        Task InsertMeasurement(MeasurementModel measurement);
    }
}