using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI
{
    public class StoppedAtLocResponseBody
    {
        public ReportSAL[] report { get; set; }
        public string pageState { get; set; }
        public int totalCount { get; set; }
        public object additionalParameters { get; set; }
        public bool cassandraPagination { get; set; }
        public object resultMessage { get; set; }
    }

    public class ReportSAL
    {
        public string Date { get; set; }
        public string Vehicle { get; set; }
        public string Driver { get; set; }
        public string Address { get; set; }
        public string StopDuration { get; set; }
        public float KMstoStop { get; set; }
        public string DrivingDuration { get; set; }
    }


    public class SALRequestBody
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
        public object additionalParameters { get; set; }
        public string pageState { get; set; }
        public int reportSubType { get; set; }
    }



}
