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


        /********************************************************************************
        *                                CONSTRUCTOR
        * ******************************************************************************/
        #region
        public MeasurementData(ISqlDataAccess db) {
            _db = db;
        }
        #endregion

        /********************************************************************************
        *                                GET DATA
        * ******************************************************************************/
        #region
        public Task<IEnumerable<MeasurementModel>> GetMeasurements() {
            return _db.LoadData<MeasurementModel, dynamic>("dbo.spMeterData_GetAll", new { });
        }

        public async Task<MeasurementModel?> GetMeasurement(int id) {
            var results = await _db.LoadData<MeasurementModel, dynamic>(
                "dbo.spMeterData_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<MeasurementModel>> GetMeasurementsByTime(DateTime TimeStart, DateTime TimeEnd) {
            var results = await _db.LoadData<MeasurementModel, dynamic>(
                "dbo.spMeterData_GetByInterval",
                new { TimeStart, TimeEnd });

            return results;
        }

        public async Task<IEnumerable<MeasurementModel>> GetMeasurementsByMeterId(string MeterId) {
            var results = await _db.LoadData<MeasurementModel, dynamic>(
                "dbo.sp_MeterData_GetAllByMeterId",
                new { MeterId });

            return results;
        }

        public Task<IEnumerable<string>> GetMeters() {
            return _db.LoadData<string, dynamic>("dbo.spMeterData_GetAllMeters", new { });
        }
        #endregion

        /********************************************************************************
        *                                DELETE DATA
        * ******************************************************************************/
        #region
        public Task DeleteMeasurement(int id) {
            return _db.SaveData("dbo.spMeterData_Delete", new { Id = id });
        }

        public Task DeleteMeasurementsByMeterId(string MeterId) {
            return _db.SaveData("dbo.spMeterData_DeleteByMeterId", new { MeterId });
        }

        #endregion

        /********************************************************************************
        *                                INSERT DATA
        * ******************************************************************************/
        #region

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
        #endregion

    }
}
