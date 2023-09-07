using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class VehicleRequestBody : APIHelper
    {
        #region Properties
        static ResourceManager rm2 = new ResourceManager($"AVMNextGenWebAutomation.TestData{environment}",
                   Assembly.GetExecutingAssembly());
        public static string userName = rm2.GetString("Username");
        public static string password = rm2.GetString("Password");
        public static string adminUser = rm2.GetString("AdminUser");
        public static string adminPassword = rm2.GetString("AdminPassword");
        public static string adminDev = rm2.GetString("AdminDev");
        public static string adminDevPassword = rm2.GetString("AdminDevPassword");
        static ResourceManager rm3 = new ResourceManager($"AVMNextGenWebAutomation.APITestData{environment}",
                  Assembly.GetExecutingAssembly());
        public static string searchKey = rm3.GetString("Searchkey");
        #endregion

        public VehicleTreeBody vehicleTreeRequestBody = new VehicleTreeBody()
        {
            UserName = adminUser
        };
        public VehicleSearchBody VehicleSearchRequestBody = new VehicleSearchBody()
        {
            pageNumber = 1,
            pageSize = 10,
            forManagement = true,
            searchText = searchKey
        };
        public VehicleStatusBody VehicleStatusRequestBody = new VehicleStatusBody()
        {
            userName = adminUser,
            unitId = 3,
            driverIdCurrent = 4
        };
        public CreateVehicleGroupBody VehicleCreateVehicleGroupRequestBody = new CreateVehicleGroupBody()
        {
            groupName = "groupname",
            description = "Test automation desc",
            groupColor = "29B6F6",
            groupId = 3
        };
        public CreateVehicleGroupBody VehicleEditVehicleGroupRequestBody = new CreateVehicleGroupBody()
        {
            groupName = "groupname",
            description = "Test desc",
            groupColor = "29B6F6",
            groupId = 3
        };
        public ManageVehiclesResponseBody ManageVehiclesRequestBody = new ManageVehiclesResponseBody()
        {
            unitId = 3,
            chassisVin = "VIN123Edit",
            driverId = 0,
            engHoursReading = 0,
            engHoursReadingDateUtc = "2022-02-22T03:42:00.243Z",
            engHoursReadingSeconds = 0,
            engineNumber = "EN123Edit",
            groupId = 388,
            isCalibratingEngHours = false,
            isCalibratingOdo = false,
            licensesRequired = "ReqTestLicenseEdit",
            manufacturer = "TestManufacEdit",
            model = "2019",
            odometerReading = 0,
            odometerReadingDateUtc = "2022-12-01T15:14:00.090Z",
            operatingHours = 81,
            registration = "RG7357Edit",
            serialNumber = "string",
            trackerId = 61562,
            type = "TestTypeEdit",
            vehicleCategory = "TestCatEdit",
            vehicleId = "2727",
            vehicleName = "AutoVehicleEdit",



        };
        public ManageVehiclesResponseBody ManageVehiclesEditRequestBody = new ManageVehiclesResponseBody()
        {
            unitId = 3,
            chassisVin = "VIN123Edit",
            driverId = 0,
            engHoursReading = 0,
            engHoursReadingDateUtc = "2022-02-22T03:42:00.243Z",
            engHoursReadingSeconds = 0,
            engineNumber = "EN123Edit",
            groupId = 388,
            isCalibratingEngHours = false,
            isCalibratingOdo = false,
            licensesRequired = "ReqTestLicenseEdit",
            manufacturer = "TestManufacEdit",
            model = "2019",
            odometerReading = 0,
            odometerReadingDateUtc = "2022-12-01T15:14:00.090Z",
            operatingHours = 81,
            registration = "RG7357Edit",
            serialNumber = "string",
            trackerId = 61562,
            type = "TestTypeEdit",
            vehicleCategory = "TestCatEdit",
            vehicleId = "2727",
            vehicleName = "AutoVehicleEdit",



        };
        public GetOdoRequestBody GetOdoRequestRequestBody = new GetOdoRequestBody()
        {
            userName = adminUser,
            unitId = 5,
            driverIdCurrent = -1

        };
        public AddvehiclesToGroupRequestBody AddvehiclesToGroupRequestRequestBody = new AddvehiclesToGroupRequestBody()
        {
            unitIds = [],
            groupId = 4
        };
        public VehicleContactUnitIdResponseBody VehicleContactUnitIdResponseResponseBody = new VehicleContactUnitIdResponseBody()
        { 
        contactGroupId = 3,
        contactGroupShortName="random",
        warning = "Warning automation"
        };
        public FindNowRequstBody FindNowReRequstBody = new FindNowRequstBody()
        {
          userName = adminUser,
          unitId =5
        };
        public VehicleHistoryRequestBody VehicleHistoryReRequestBody = new VehicleHistoryRequestBody()
        {
            unitId = 1,
            start = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ"),
            stop = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ"),
            extent = 0,///doubt
            width = 0,
            zoom = 0,
            height = 0,
            maxPoints = 500,
            addAlerts = false
        };
    
        


    }