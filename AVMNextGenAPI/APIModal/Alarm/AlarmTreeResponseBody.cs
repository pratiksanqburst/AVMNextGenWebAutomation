using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alarm
{


    public class AlarmTreeResponseBody
    {
        public Alarm[] alarms { get; set; }
        public int totalCount { get; set; }
    }

    public class Alarm
    {
        public int unitId { get; set; }
        public string unitName { get; set; }
        public int fleetId { get; set; }
        public int statusId { get; set; }
        public int alertId { get; set; }
        public int alarmType { get; set; }
        public int alertType { get; set; }
        public DateTime utcTime { get; set; }
        public string tzInfo { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string address { get; set; }
        public string alarmText { get; set; }
        public string detail { get; set; }
        public int driverId { get; set; }
        public string? driverName { get; set; }
        public string contactPhone { get; set; }
        public string headStr { get; set; }
        public float heading { get; set; }
        public float speed { get; set; }
        public bool ignition { get; set; }
        public bool alarmCleared { get; set; }
        public int vehicleStatusFlag { get; set; }
    }


    public class ClearAlarmResponseBody
    {
        public bool success { get; set; }
        public object error { get; set; }
        public string feedback { get; set; }
        public string _ref { get; set; }
    }

}
