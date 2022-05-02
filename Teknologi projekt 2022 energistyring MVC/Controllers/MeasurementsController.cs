using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [Route("api/[controller]/GetInterval")]
        [HttpGet]
        public async Task<IResult> GetMeasurementsByInterval(DateTime start, DateTime end, [FromServices] IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurementsByTime(start, end));
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IResult> GetMeasurementsByMeterId(string MeterId, [FromServices] IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurementsByMeterId(MeterId));
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        [Route("api/[controller]")]
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
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IResult> InserMeasurement([FromBody]MeasurementModel measurement, [FromServices] IMeasurementData data) {
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

        [Route("api/[controller]")]
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
