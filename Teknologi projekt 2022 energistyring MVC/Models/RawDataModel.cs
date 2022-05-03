namespace Teknologi_projekt_2022_energistyring_MVC.Models {
    public class RawDataModel {
        public DateTime TimeStart { get; set; }
        public string Unit { get; set; }
        public double[] Values { get; set; }
        public string EnergyType { get; set; }
        public string MeterId { get; set; }
    }
}
