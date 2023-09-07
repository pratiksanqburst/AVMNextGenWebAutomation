using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI
{
    public class DriverRightPanelResponseBody
    {
        public int unitId { get; set; }
        public string unitName { get; set; }
        public int fleetId { get; set; }
        public DateTime utcTime { get; set; }
        public string tzInfo { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public decimal speed { get; set; }
        public decimal heading { get; set; }
        public string headStr { get; set; }
        public string address { get; set; }
        public int driverId { get; set; }
        public string driverName { get; set; }
        public string driverStatus { get; set; }
        public string vehId { get; set; }
        public string rego { get; set; }
        public string contactPhone { get; set; }
        public decimal odoKm { get; set; }
        public decimal engineHours { get; set; }
        public string status { get; set; }
        public string gpsState { get; set; }
        public decimal lastStopLat { get; set; }
        public decimal lastStopLon { get; set; }
        public string lastStopAddress { get; set; }
        public decimal lastStopDuration { get; set; }
        public string terminalState { get; set; }
        public DateTime? alarmTimeUtc { get; set; }
        public string run { get; set; }
        public bool ign { get; set; }
        public DateTime lastStopTime { get; set; }
        public string? lights { get; set; }
        public string? power { get; set; }
        public string backupPower { get; set; }
        public int vehicleStatusFlag { get; set; }
        public bool isPrivate { get; set; }
    }
}
