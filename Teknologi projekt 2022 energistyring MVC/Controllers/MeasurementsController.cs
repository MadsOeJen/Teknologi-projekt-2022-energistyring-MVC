using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Teknologi_projekt_2022_energistyring_MVC.Controllers {
    [ApiController]

    public class MeasurementsController : ControllerBase {

        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IResult> Get([FromServices]IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurements());
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IResult> Post([FromBody]MeasurementModel measurement, [FromServices] IMeasurementData data) {
            try {
                await data.InsertMeasurement(measurement);
                return Results.Ok();
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }


        [Route("api/[controller]/GetInterval")]
        [HttpGet]
        public async Task<IResult> GetInterval(DateTime start, DateTime end, [FromServices] IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurementsByTime(start, end));
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

    }
}
