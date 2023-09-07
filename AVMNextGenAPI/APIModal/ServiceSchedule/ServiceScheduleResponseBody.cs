using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.ServiceSchedule
{
    public class ServiceScheduleResponseBody
    {
        public class ServiceSaveScheduleResponsebody
        {
            public int scheduleId { get; set; }
            public bool success { get; set; }
            public string error { get; set; }
            public object feedback { get; set; }
            public object @ref { get; set; }
        }
        public class ServiceGetScheduleResponsebody
        {
            public int scheduleId { get; set; }
            public int trackerId { get; set; }
            public int serviceType { get; set; }
            public bool enabled { get; set; }
            public DateTime startDate { get; set; }
            public int interval { get; set; }
            public int reminder { get; set; }
            public int startOdometer { get; set; }
            public int intervalKm { get; set; }
            public int reminderKm { get; set; }
            public object created { get; set; }
            public object lastModified { get; set; }
            public int startEngineHours { get; set; }
            public int intervalEngineHours { get; set; }
            public int reminderEngineHours { get; set; }
            public int reminderSentEngineHours { get; set; }
            public int reminderSentKm { get; set; }
            public int contactId { get; set; }
            public string contactName { get; set; }
            public string notes { get; set; }
            public DateTime reminderSentDate { get; set; }
            public bool reminderTriggered { get; set; }
            public int deleted { get; set; }
        }
    }
}
