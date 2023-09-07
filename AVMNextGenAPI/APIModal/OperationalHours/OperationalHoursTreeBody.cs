using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.OperationalHours
{
    public class OperationalHoursTreeBody
    {
        public class CreateOHResponseBody
        {
            public bool success { get; set; }
            public string error { get; set; }
            public string feedback { get; set; }
            public string _ref { get; set; }
            public int id { get; set; }
        }
        public class OperationalHoursResponseBody
        {
            public int opHoursId { get; set; }
            public string name { get; set; }
            public int masterId { get; set; }
            public int departmentId { get; set; }
            public string description { get; set; }
            public int utcOffset { get; set; }
            public bool monday { get; set; }
            public int mondayStart { get; set; }
            public int mondayStop { get; set; }
            public bool tuesday { get; set; }
            public int tuesdayStart { get; set; }
            public int tuesdayStop { get; set; }
            public bool wednesday { get; set; }
            public int wednesdayStart { get; set; }
            public int wednesdayStop { get; set; }
            public bool thursday { get; set; }
            public int thursdayStart { get; set; }
            public int thursdayStop { get; set; }
            public bool friday { get; set; }
            public int fridayStart { get; set; }
            public int fridayStop { get; set; }
            public bool saturday { get; set; }
            public int saturdayStart { get; set; }
            public int saturdayStop { get; set; }
            public bool sunday { get; set; }
            public int sundayStart { get; set; }
            public int sundayStop { get; set; }
            public string timeZone { get; set; }
        }
    }
}
