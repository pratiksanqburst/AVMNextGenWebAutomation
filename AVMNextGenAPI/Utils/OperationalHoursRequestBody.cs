using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.OperationalHours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class OperationalHoursRequestBody: APIHelper
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

        public OperationalHoursResponseBody operationalHoursresponseBody = new OperationalHoursResponseBody()
        {
           name = "",
          description = "Test Automation description",
           monday = true,
          mondayStart = 540,
          mondayStop = 1080,
           tuesday = false,
           tuesdayStart = 0,
           tuesdayStop = 0,
           wednesday = true,
           wednesdayStart = 540,
           wednesdayStop = 1080,
           thursday = false,
           thursdayStart = 0,
            thursdayStop = 0,
           friday = true,
          fridayStart = 540,
          fridayStop = 1080,
          saturday = false,
          saturdayStart = 0,
          saturdayStop = 0,
          sunday = false,
          sundayStart = 0,
          sundayStop = 0,
          timeZone = "AUS Eastern Standard Time"
        };
        public OperationalHoursResponseBody operationalhoursresponseBody = new OperationalHoursResponseBody()
        {
            name = "",
            description = "Automation description Edited",
            monday = false,
            mondayStart = 0,
            mondayStop = 0,
            tuesday = true,
            tuesdayStart =540,
            tuesdayStop = 1080,
            wednesday = false,
            wednesdayStart = 0,
            wednesdayStop = 0,
            thursday = true,
            thursdayStart = 540,
            thursdayStop = 1080,
            friday = false,
            fridayStart = 0,
            fridayStop = 0,
            saturday = true,
            saturdayStart = 540,
            saturdayStop = 1080,
            sunday = false,
            sundayStart = 0,
            sundayStop = 0,
            timeZone = "Cen. Australia Standard Time"
        };
    }
}
