using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data {
    public class MeasurementData : IMeasurementData {

        private readonly ISqlDataAccess _db;

        public MeasurementData(ISqlDataAccess db) {
            _db = db;
        }

        public Task<IEnumerable<MeasurementModel>> GetMeasurements() {
            return _db.LoadData<MeasurementModel, dynamic>("dbo.spMeterData_GetAll", new { });
        }

        public async Task<MeasurementModel?> GetMeasurementsByTime(DateTime TimeStart, DateTime TimeEnd) {
            var results = await _db.LoadData<MeasurementModel, dynamic>(
                "dbo.spMeterData_GetByInterval",
                new { TimeStart, TimeEnd });

            return results.FirstOrDefault();
        }

        public Task InsertMeasurement(MeasurementModel measurement) {
            return _db.SaveData("dbo.spMeterData_Insert", new {
                measurement.TimeStart,
                measurement.TimeEnd,
                measurement.Unit,
                measurement.Measurement,
                measurement.EnergyType,
                measurement.MeterId
            });
        }


    }
}
