using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teknologi_projekt_2022_energistyring_MVC.Controllers;
    //[ApiController]
public static class MeteringController{

    //public enum EnergyTypes {
    //    Electric,
    //    DistrictHeating,
    //    Gas
    //}

    //string GasMeterId = "674fdhier586";
    //string ElectricMeterId = "348dyewyh208";

    //List<MeasurementModel> MeasurementModels = new List<MeasurementModel>();

    //public MeteringController() {
    //    MeasurementModels.Add(new MeasurementModel(1, new DateTime(2022, 4, 14), new DateTime(2022, 4, 15), "KWh", 40933, EnergyTypes.Gas.ToString(), GasMeterId));
    //    MeasurementModels.Add(new MeasurementModel(2, new DateTime(2022, 4, 13), new DateTime(2022, 4, 14), "KWh", 44993, EnergyTypes.Electric.ToString(), ElectricMeterId));
    //    MeasurementModels.Add(new MeasurementModel(3, new DateTime(2022, 4, 12), new DateTime(2022, 4, 13), "KWh", 40328, EnergyTypes.Gas.ToString(), GasMeterId));
    //    MeasurementModels.Add(new MeasurementModel(4, new DateTime(2022, 4, 11), new DateTime(2022, 4, 12), "KWh", 39279, EnergyTypes.Electric.ToString(), ElectricMeterId));
    //    MeasurementModels.Add(new MeasurementModel(5, new DateTime(2022, 4, 10), new DateTime(2022, 4, 11), "KWh", 50038, EnergyTypes.Electric.ToString(), ElectricMeterId));
    //}

    //[Route("api/[controller]")]
    //[HttpGet]
    public static void initApi(this WebApplication app) {
        app.MapGet("/api/metering", GetMeasurements);
        //app.MapPost("/api/metering", InsertMeasurement);
    }

    public static async Task<IResult> GetMeasurements(IMeasurementData data) {
        try {
            return Results.Ok(await data.GetMeasurements()); ;
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    //public static async Task<IResult> InsertMeasurement(IMeasurementData data) {
    //    try {
    //        await data.InsertMeasurement(new MeasurementModel() {
    //            TimeStart = new DateTime(2022, 4, 14, 4, 0, 0),
    //            TimeEnd = new DateTime(2022, 4, 14, 5, 0, 0),
    //            Unit = "kWh",
    //            Measurement = 0.67,
    //            EnergyType = "Electric",
    //            MeterId = "674fdhier586"
    //        });
    //        return Results.Ok(); ;
    //    }
    //    catch (Exception ex) {
    //        return Results.Problem(ex.Message);
    //    }
    //}

    //[Route("api/[controller]/{id}")]
    //public MeasurementModel Get(int id) {
    //    if(id >= 1 && id <= MeasurementModels.Count) {
    //        return MeasurementModels[id - 1];
    //    }
    //    else {
    //        return new MeasurementModel(0, new DateTime(1, 1, 1), new DateTime(1, 1, 1), "", 0, "", "");
    //    }
    //}

    //[Route("api/[controller]")]
    //[HttpPost]
    //public void Post(MeasurementModel MeasurementModel) {
    //    MeasurementModels.Add(MeasurementModel);
    //}
}

