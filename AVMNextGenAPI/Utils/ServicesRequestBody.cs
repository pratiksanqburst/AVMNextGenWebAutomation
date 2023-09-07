using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Services;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class ServicesRequestBody:APIHelper
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

        public GetServiceByIdRequest getServiceByIdRequest = new GetServiceByIdRequest()
        {
            serviceId = serviceId,
            userName = userName
        };
        public GetServicesByUserNameRequest GetServicesByUserNameRequest = new GetServicesByUserNameRequest()
        {
            unitId = vehicleId,
            userName = userName,
            pageSize = 10,
            pageNumber = 1
        };
        public CreateServiceRequestBody createServiceRequestBody = new CreateServiceRequestBody()
        {
            cost = 1000,
            engineHours = 12345,
            notes = "Test Automation notes",
            odometer = 4444,
            serviceType = 0,
           serviceDate = DateTime.UtcNow.AddDays(-2).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"),
           unitId = vehicleId,
           userName = userName
        };
        public CreateServiceRequestBody cReateServiceRequestBody = new CreateServiceRequestBody()
        {
            cost = 2000,
        engineHours = 54321,
          notes = "Test Automation notes edited",
           odometer = 5555,
            serviceType = 1,
          serviceDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"),
          unitId = vehicleId,
          userName = userName
        };
    }


}
