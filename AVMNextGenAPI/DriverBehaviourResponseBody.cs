using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI
{
    public class DriverBehaviourResponseBody
    {
        public Report[] report { get; set; }
        public string pageState { get; set; }
        public int totalCount { get; set; }
        public object additionalParameters { get; set; }
        public bool cassandraPagination { get; set; }
        public object resultMessage { get; set; }
    }

    public class Report
    {
        public string Date { get; set; }
        public string Vehicle { get; set; }
        public string Driver { get; set; }
        [JsonProperty("Distance Travelled")]
        public int DistanceTravelled { get; set; }
        public int Score { get; set; }
        public int Speeding { get; set; }
        [JsonProperty("Excessive Idling")]
        public int ExcessiveIdling { get; set; }
        [JsonProperty("Harsh Acceleration")]
        public int HarshAcceleration { get; set; }
        [JsonProperty("Harsh Cornering")]
        public int HarshCornering{ get; set; }
        [JsonProperty("Harsh Braking")]
        public int HarshBraking { get; set; }
        [JsonProperty("Crash Detected")]
        public int CrashDetected { get; set; }
        [JsonProperty("Fatigue Alerts")]
        public int FatigueAlerts { get; set; }
        [JsonProperty("Fatigue Alarms")]
        public int FatigueAlarms { get; set; }
    }



    public class DriverBehaviourRequestBody
    {
        public int reportType { get; set; }
        public string reportName { get; set; }
        public DateTime startTime { get; set; }
        public DateTime stopTime { get; set; }
        public string selectedTimeZone { get; set; }
        public int reportBy { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public int sortOrder { get; set; }
        public string sortColumn { get; set; }
        public string searchText { get; set; }
        public double browserOffset { get; set; }
        public int[] selectedIds { get; set; }
        public string pageState { get; set; }
        public int reportSubType { get; set; }
    }

}
