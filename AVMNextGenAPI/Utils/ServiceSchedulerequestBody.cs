using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.ServiceSchedule.ServiceScheduleTreeBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class ServiceSchedulerequestBody:APIHelper
    {
        #region Properties
        static ResourceManager rm2 = new ResourceManager($"AVMNextGenWebAutomation.TestData{environment}", Assembly.GetExecutingAssembly());
        public static string userName = rm2.GetString("Username");
        public static string password = rm2.GetString("Password");
        public static string adminUser = rm2.GetString("AdminUser");
        public static string adminPassword = rm2.GetString("AdminPassword");
        public static string adminDev = rm2.GetString("AdminDev");
        public static string adminDevPassword = rm2.GetString("AdminDevPassword");
        static ResourceManager rm3 = new ResourceManager($"AVMNextGenWebAutomation.APITestData{environment}", Assembly.GetExecutingAssembly());
        public static string searchKey = rm3.GetString("Searchkey");

        #endregion

        public ServiceScheduleSavebody serviceschedulesavebody = new ServiceScheduleSavebody()
        {
         scheduleId =58,
        trackerId=1001,
        serviceType= 2,
        enabled=false,
        startDate="2000-01-01T00:00:00Z",
        interval= -1,
        reminder=-1,
        startOdometer= 0,
        intervalKm= -1,
        reminderKm= -1,
        created= null,
        lastModified=null,
        startEngineHours= 0,
        intervalEngineHours= 6700,
        reminderEngineHours= 8090,
        reminderSentEngineHours= 0,
        reminderSentKm= 0,
        contactId=-1,
        contactName="",
        notes="",
        reminderSentDate="2023-07-05T11:33:29.907Z",
        reminderTriggered=false,
        deleted= 0
        };

        public ServiceScheduleSavebody serviceSchedulesavebody = new ServiceScheduleSavebody()
        {
         scheduleId=78529264,
         trackerId=59166367,
         serviceType= 3,
         enabled=true,
         startDate="1958-11-19T20:03:42.415Z",
         interval=52758692,
          reminder=16062493,
         startOdometer=68785223,
         intervalKm=47167092,
         reminderKm=53387168,
         created="2021-11-29T19:08:00.098Z",
         lastModified="963-04-10T12:53:51.693Z",
         startEngineHours=84921581,
         intervalEngineHours=5521794,
         reminderEngineHours=13321946,
         reminderSentEngineHours=1669577,
         reminderSentKm=-35815429,
         contactId=-17892007,
         contactName="in voluptate irure",
         notes="veniam nisi laborum",
         reminderSentDate= "2003-06-19T06:29:46.789Z",
         reminderTriggered=true,
         deleted= -75187860
        };
        public ServiceScheduleSavebody serviceScheduleSavebody = new ServiceScheduleSavebody()
        {
            scheduleId = 78529264,
            trackerId = 59166367,
            serviceType = 3,
            enabled = true,
            startDate = "1958-11-19T20:03:42.415Z",
            interval = 52758692,
            reminder = 16062493,
            startOdometer = 68785223,
            intervalKm = 47167092,
            reminderKm = 53387168,
            created = "2021-11-29T19:08:00.098Z",
            lastModified = "963-04-10T12:53:51.693Z",
            startEngineHours = 84921581,
            intervalEngineHours = 5521794,
            reminderEngineHours = 13321946,
            reminderSentEngineHours = 1669577,
            reminderSentKm = -35815429,
            contactId = -17892007,
            contactName = "in voluptate irure",
            notes = "veniam nisi laborum",
            reminderSentDate = "2003-06-19T06:29:46.789Z",
            reminderTriggered = true,
            deleted = -75187860
        };
        public ServiceScheduleSavebody serviceSchedulesaveBody = new ServiceScheduleSavebody()
        {
            scheduleId = 78529264,
            trackerId = 59166367,
            serviceType = 3,
            enabled = true,
            startDate = "1958-11-19T20:03:42.415Z",
            interval = 52758692,
            reminder = 16062493,
            startOdometer = 68785223,
            intervalKm = 47167092,
            reminderKm = 53387168,
            created = "2021-11-29T19:08:00.098Z",
            lastModified = "963-04-10T12:53:51.693Z",
            startEngineHours = 84921581,
            intervalEngineHours = 5521794,
            reminderEngineHours = 13321946,
            reminderSentEngineHours = 1669577,
            reminderSentKm = -35815429,
            contactId = -17892007,
            contactName = "in voluptate irure",
            notes = "veniam nisi laborum",
            reminderSentDate = "2003-06-19T06:29:46.789Z",
            reminderTriggered = true,
            deleted = -75187860
        };
    }
}
