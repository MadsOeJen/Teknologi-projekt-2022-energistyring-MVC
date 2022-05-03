using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Teknologi_projekt_2022_energistyring_MVC.Models;

namespace Teknologi_projekt_2022_energistyring_MVC.Controllers {
    [ApiController]

    public class MeasurementsController : ControllerBase {

        /********************************************************************************
        *                                HTTP GET
        * ******************************************************************************/
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IResult> GetMeasurements([FromServices]IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurements());
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        [Route("api/[controller]/GetInterval/{start}/{end}")]
        [HttpGet]
        public async Task<IResult> GetMeasurementsByInterval(DateTime start, DateTime end, [FromServices] IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurementsByTime(start, end));
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        [Route("api/[controller]/specific/{Id}")]
        [HttpGet]
        public async Task<IResult> GetMeasurementById(int Id, [FromServices] IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurement(Id));
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        /********************************************************************************
        *                                HTTP POST
        * ******************************************************************************/
        [Route("api/[controller]/{rawData}")]
        [HttpPost]
        public async Task<IResult> InsertMeasurement([FromBody]RawDataModel rawData, [FromServices] IMeasurementData data) {
            try {
                MeasurementModel measurement = DataConverter.ConvertFromRaw(rawData);
                await data.InsertMeasurement(measurement);
                return Results.Ok();
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        [Route("api/[controller]/DirectInsert/{measurement}")]
        [HttpPost]
        public async Task<IResult> InsertMeasurement([FromBody] MeasurementModel measurement, [FromServices] IMeasurementData data) {
            try {
                await data.InsertMeasurement(measurement);
                return Results.Ok();
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }


        /********************************************************************************
        *                                HTTP DELETE
        * ******************************************************************************/

        [Route("api/[controller]/{Id}")]
        [HttpDelete]
        public async Task<IResult> DeleteMeasurementById(int Id, [FromServices] IMeasurementData data) {
            try {
                await data.DeleteMeasurement(Id);
                return Results.Ok();
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }
        

    }
}
