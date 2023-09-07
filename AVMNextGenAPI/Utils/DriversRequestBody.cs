using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Drivers;
using System.Text.RegularExpressions;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class DriversRequestBody : APIHelper
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

        public VehicleTreeBody vehicletreeBody = new VehicleTreeBody()
        {
            UserName = "userName",
            forManagement = false // check
        };
        public VehicleStatusBody vehiclestatusBody = new VehicleStatusBody()//
        {
            //  userName = "userName",
            //    if (isDriver)
            //   driverIdCurrent = Id;
            //   else
            //  unitId = Id
        };
    public DriverGroupsResponsebody Drivergroupsresponsebody = new DriverGroupsResponsebody()
    {
        groupId = 0,
        driverCount = 0,
        groupName = "",
        description = "Test automation desc",
        color = "29b6f6"
    };
        public CreateDriverBody createDriverBody = new CreateDriverBody()
        {
            groupId = 6,
            address1 = "Test automation address",
            bloodType = "",
            dateJoined = DateTime.UtcNow.AddDays(-2).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"),
            driverUniqueId = "12345",
            email1 = "testautomation" + DateTime.Now.ToString("dd") + "@gtail.com",
            emergencyContactName = "",
            emergencyContactPhone1 = "",
            emergencyContactRelationship = "",
            firstName = "Test",
            gender = "",
            groupName = "",
            lastName = "AutoDriver",
            licenceNumber = "11111",
            licenseExpiryDate = DateTime.UtcNow.AddDays(2).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"),
            licenseState = "active",
            nationality = "",
            phone1 = "987654321",
            rfTagId = -1,
            unitId = 2727
        };
    public VehicleSearchBody vehiclesearchBody = new VehicleSearchBody()
    {
        pageNumber = 1,
        pageSize = 10,
        searchText = searchKey
    };
        public VehicleSearchBody vehicleSearchBody = new VehicleSearchBody()
        {
            pageNumber = 1,
            pageSize = 10,
            searchText = searchKey
        };


        public AssignDriverRequestBody assignDriverRequestBody = new AssignDriverRequestBody()
        {
            driverId = 5,
            unitId = 5
        };
        public EditDriverBody editdriverBody = new EditDriverBody()
        {
            driverId = 6,//check
            groupId = 5,//check
            address1 = "Test automation address edited",
            bloodType = "",
            dateJoined = DateTime.UtcNow.AddDays(-3).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"),
            driverUniqueId = "12345",
            email1 = "testautoedited" + DateTime.Now.ToString("dd") + "@gtail.com",
            emergencyContactName = "",
            emergencyContactPhone1 = "",
            emergencyContactRelationship = "",
            firstName = "TestEdit",
            gender = "",
            groupName = "",
            lastName = "AutoDriverEdit",
            licenceNumber = "22222",
            licenseExpiryDate = DateTime.UtcNow.AddDays(4).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"),
            licenseState = "inactive",
            nationality = "",
            phone1 = "123456789",
            rfTagId = -1,
            unitId = 2727,
        };
        public AssignDriversToGrpRequestBody assignDriversToGrpRequestBody = new AssignDriversToGrpRequestBody()
        {
            driverIds = [],
            groupId = 8
        };
        public DeleteDriversRequestBody deleteDriversRequestBody = new DeleteDriversRequestBody()
        {
            driverIds = []
        };
        public EditVehicleGroupBody editvehiclegroupBody = new EditVehicleGroupBody()
        {
            groupName = groupName + "Edited",
            description = "Test automation desc edited",
            color = "5e35b1",
            groupId = 5 //check
        };


}

