using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models {
    public class MeasurementModel {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Unit { get; set; }
        public double Measurement { get; set; }
        public string EnergyType { get; set; }
        public string MeterId { get; set; }

    }
}
