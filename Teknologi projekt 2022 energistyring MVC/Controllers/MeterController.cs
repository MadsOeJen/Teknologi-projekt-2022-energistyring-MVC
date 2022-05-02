using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teknologi_projekt_2022_energistyring_MVC.Controllers {
    [ApiController]
    public class MeterController : ControllerBase {
        
        /********************************************************************************
        *                                HTTP GET
        * ******************************************************************************/
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IResult> GetMeters([FromServices] IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeters());
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        [Route("api/[controller]/Measurements/{MeterId}")]
        [HttpGet]
        public async Task<IResult> GetMeasurementsByMeterId(string MeterId, [FromServices] IMeasurementData data) {
            try {
                return Results.Ok(await data.GetMeasurementsByMeterId(MeterId));
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
        public async Task<IResult> DeleteMeasurementsByMeterId(string MeterId, [FromServices] IMeasurementData data) {
            try {
                await data.DeleteMeasurementsByMeterId(MeterId);
                return Results.Ok();
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }



    }
}
