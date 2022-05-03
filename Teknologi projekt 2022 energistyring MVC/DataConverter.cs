using Teknologi_projekt_2022_energistyring_MVC.Models;

namespace Teknologi_projekt_2022_energistyring_MVC {
    public static class DataConverter {

        public static MeasurementModel ConvertFromRaw(RawDataModel RawData) {
            MeasurementModel Measurement = new MeasurementModel();
            double Totalenergy = 0;
            if(RawData.Unit == "W") {
                if (RawData.Values.Length == 360) {
                    foreach (double value in RawData.Values) {
                        //E[kWh] = (P[W] * t[s]) * (J / kWh)
                        Totalenergy += (value * 10.0) * (1.0 / 3600000.0);
                    }
                }
            }
            else if (RawData.Unit == "kW") {
                if (RawData.Values.Length == 360) {
                    foreach (double value in RawData.Values) {
                        //E[kWh] = (P[W] * t[s] * (kW / W)) * (J / kWh)
                        Totalenergy += (value * 10000.0) * (1.0 / 3600000.0);
                    }
                }
            }

            Measurement.TimeStart = RawData.TimeStart;
            Measurement.TimeEnd = RawData.TimeStart.AddHours(1);
            Measurement.Unit = "kWh";
            Measurement.Measurement = Totalenergy;
            Measurement.EnergyType = RawData.EnergyType;
            Measurement.MeterId = RawData.MeterId;

            return Measurement;
        }

    }
}
