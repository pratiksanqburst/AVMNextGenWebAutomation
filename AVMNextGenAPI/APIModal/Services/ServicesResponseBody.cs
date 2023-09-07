using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Services
{
    public class ServicesResponseBody
    {
        public int serviceId { get; set; }
        public int unitId { get; set; }
        public int serviceType { get; set; }
        public string serviceDate { get; set; }
        public decimal cost { get; set; }
        public int odometer { get; set; }
        public string notes { get; set; }
        public int engineHours { get; set; }
        public int serviceCount { get; set; }

    }




    public class ServiceByUserNameResponseBody
    {
        public int trackerId { get; set; }
        public int unitId { get; set; }
        public int serviceId { get; set; }
        public int serviceType { get; set; }
        public string serviceDate { get; set; }
        public decimal cost { get; set; }
        public int odometer { get; set; }
        public object scheduleId { get; set; }
        public object status { get; set; }
        public object notifyStatus { get; set; }
        public string notes { get; set; }
        public object deleted { get; set; }
        public int engineHours { get; set; }
        public int serviceCount { get; set; }
    }


    public class CreateServiceResponseBody
    {
        public int serviceId { get; set; }
        public int unitId { get; set; }
        public bool success { get; set; }
    }

    public class ServiceTypeResponseBody
    {
        public int id { get; set; }
        public string serviceType { get; set; }
    }

    public class ServiceReadingResponseBody
    {
        public int serviceId { get; set; }
        public int odometer { get; set; }
        public int engineHours { get; set; }
    }


    public class ServiceScheduleResponseBody
    {
        public bool success { get; set; }
        public string error { get; set; }
        public string feedback { get; set; }
        public string _ref { get; set; }
        public int scheduleId { get; set; }
    }

    public class ServiceScheduleListResponseBody
    {
        public int scheduleId { get; set; }
        public int trackerId { get; set; }
        public int serviceType { get; set; }
        public bool enabled { get; set; }
        public string startDate { get; set; }
        public int interval { get; set; }
        public int reminder { get; set; }
        public int startOdometer { get; set; }
        public int intervalKm { get; set; }
        public int reminderKm { get; set; }
        public string created { get; set; }
        public string lastModified { get; set; }
        public int startEngineHours { get; set; }
        public int intervalEngineHours { get; set; }
        public int reminderEngineHours { get; set; }
        public int reminderSentEngineHours { get; set; }
        public int reminderSentKm { get; set; }
        public int contactId { get; set; }
        public string contactName { get; set; }
        public string notes { get; set; }
        public string reminderSentDate { get; set; }
        public bool reminderTriggered { get; set; }
        public int deleted { get; set; }
    }

}
