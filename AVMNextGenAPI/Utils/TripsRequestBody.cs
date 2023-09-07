using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class TripsRequestBody:APIHelper
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

        public VehicleTripBody vehicleTripBody = new VehicleTripBody()
        {
           unitId = vehicleUnitId, //value to be provided
            tripStartTime = DateTime.Now.AddDays(-88),
           tripEndTime = DateTime.Now,
           page = 1,
           pageSize = 10,
           isAssignedTrip = true
        };
        public SingleTriprequestBody singleTriprequestBody = new SingleTriprequestBody()
        {
         driverId = 6,
         startDate = startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ssZ"),
         tripId = 5

        };
        
    }
}
