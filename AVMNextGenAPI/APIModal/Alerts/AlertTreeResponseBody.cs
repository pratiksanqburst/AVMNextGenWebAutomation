using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alerts
{
    public class AlertTreeResponseBody
    {
        public int alertId { get; set; }
        public int unitId { get; set; }
        public string? unitName { get; set; }
        public int? fleetId { get; set; }
        public DateTime utcTime { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string? address { get; set; }
        public string? alertText { get; set; }
        public string? detail { get; set; }
        public int? driverId { get; set; }
        public decimal speed { get; set; }
        public string? driverName { get; set; }
        public string? contactPhone { get; set; }
        public string? tzInfo { get; set; }
        public bool ignition { get; set; }
        public string headStr { get; set; }
    }
}
