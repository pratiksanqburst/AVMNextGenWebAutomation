using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading.Tasks;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alarm;

namespace AVMNextGenWebAutomation.AVMNextGenAPI
{
    public class APIBaseTest : GetAPIResponse
    {
        #region Properties
        public static ExtentReportHelper extent;
        public static ExtentTest test;
        public ExtentHtmlReporter? reporter;
        static ResourceManager rm2 = new ResourceManager($"AVMNextGenWebAutomation.TestData{environment}",
                Assembly.GetExecutingAssembly());
        public static string userName = rm2.GetString("Username");
        public static string password = rm2.GetString("Password");
        public static string adminUser = rm2.GetString("AdminUser");
        public static string adminPassword = rm2.GetString("AdminPassword");
        public static string adminDev = rm2.GetString("AdminDev");
        public static string adminDevPassword = rm2.GetString("AdminDevPassword");
        #endregion
        [OneTimeSetUp]
        public void ReportInitialization()
        {

            extent = new ExtentReportHelper();
            var dir = TestContext.CurrentContext.TestDirectory.Replace("bin\\Debug\\net6.0", "AVMNextGenReports") + "\\";
            var fileName = this.GetType().ToString().Replace("AVMNextGenWebAutomation.AVMNextGenTests.", "") + "\\" + "test.html";
            reporter = new ExtentHtmlReporter(dir + fileName);
            extent.AttachReporter(reporter);

        }

        [SetUp]
        public void StartUpTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            extent.Close();
        }

        #region Methods

        #region Vehicles API
        /// <summary>
        /// Verify Vehicle tree api
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyVehiclesByUserNameAPI(string userName, string password)
        {
            var vehicleTree = GetVehicleTree(userName, password);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(vehicleTree.Count != 0);
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }
        /// <summary>
        /// Verify vehicles tree using search key
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="searchKey"></param>
        public void VerifyVehiclesBySearchKeyword(string userName, string password, string searchKey)
        {
            var vehicleTree = GetVehicleInfoBySearchKeyword(userName, password, searchKey);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(vehicleTree.Count != 0);
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }
        /// <summary>
        /// Verify vehicles grouped using search key
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="searchKey"></param>
        public void VerifyVehiclesGroupedBySearchKeyword(string userName, string password, string searchKey)
        {
            var vehicleTree = GetVehicleGroupedInfoBySearchKeyword(userName, password, searchKey);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(vehicleTree.Count != 0);
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }
        /// <summary>
        /// Verifies the vehicle status by username
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="driverId"></param>
        public void VerifyVehicleStatusByUserName(string userName, string password, int unitId, int driverId)
        {
            var vehicleTree = GetVehicleStatusByUserName(userName, password, unitId, driverId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(vehicleTree.unitName == "AutoVehicle");
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }
        /// <summary>
        /// Creates new vehicle group and verifies the details in get vehicle groups
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyCreateVehicleGroup(string userName, string password, string groupName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleGroups = CreateVehicleGroup(userName, password, groupName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupName, vehicleGroups.groupName);
            Assert.AreEqual("Test automation desc", vehicleGroups.description);
            Assert.AreEqual("29B6F6", vehicleGroups.groupColor);
            extent.SetStepStatusPass($"Verified that the vehicle group is created correctly");
            var vehicleGroupLists = GetVehicleGroups(userName, password, token);

            foreach (var vehicleGrouplist in vehicleGroupLists)
                if (vehicleGrouplist.groupName == groupName)
                {
                    Assert.AreEqual(0, vehicleGrouplist.unitCount);
                    Assert.AreEqual("29B6F6", vehicleGrouplist.groupColor);
                }
        }
        /// <summary>
        /// Edit the vehicle group info and verify the response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyEditVehicleGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleGroupLists = GetVehicleGroups(userName, password, token);
            foreach (var vehicleGrouplist in vehicleGroupLists)
                if (vehicleGrouplist.groupName == groupName)
                    groupId = vehicleGrouplist.groupId;
            var editGroupInfo = EditVehicleGroupByID(userName, password, groupId, groupName + "Edited", token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupName + "Edited", editGroupInfo.groupName);
            Assert.AreEqual("Test automation desc edited", editGroupInfo.description);
            Assert.AreEqual("E91E63", editGroupInfo.groupColor);
            extent.SetStepStatusPass($"Verified that the edited vehicle group details are correct.");
        }
        /// <summary>
        /// Verify vehicle groups by Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyVehicleGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleGroupLists = GetVehicleGroups(userName, password, token);
            foreach (var vehicleGrouplist in vehicleGroupLists)
                if (vehicleGrouplist.groupName == groupName)
                    groupId = vehicleGrouplist.groupId;
            var vehicleGroupInfo = getVehicleGroupByID(groupId.ToString(), token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupId, vehicleGroupInfo.groupId);
            Assert.AreEqual(groupName, vehicleGroupInfo.groupName);
            Assert.AreEqual("Test automation desc edited", vehicleGroupInfo.description);
            Assert.AreEqual("E91E63", vehicleGroupInfo.groupColor);
            extent.SetStepStatusPass($"Verified that the location group details are correct.");
        }
        /// <summary>
        /// Deletes a vehicle group by id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDeleteVehicleGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleGroupLists = GetVehicleGroups(userName, password, token);
            foreach (var vehicleGrouplist in vehicleGroupLists)
                if (vehicleGrouplist.groupName == groupName)
                    groupId = vehicleGrouplist.groupId;
            DeleteVehicleGroupDetailsByID(token, groupId.ToString());
            extent.SetStepStatusPass($"Verified that the response is success.");
        }
        /// <summary>
        /// Verify Edit Vehicle Details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyEditVehicleDetails(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var editVehicleDetails = editVehicleDetailsByID(token, unitId);
            extent.SetStepStatusPass($"Verified that the response is success.");

            Assert.AreEqual(unitId, editVehicleDetails.unitId);
            Assert.AreEqual("VIN123Edit", editVehicleDetails.chassisVin);
            Assert.AreEqual(0, editVehicleDetails.driverId);
            Assert.AreEqual("", editVehicleDetails.driverName);
            Assert.AreEqual(0, editVehicleDetails.engHoursReadingSeconds);
            Assert.AreEqual("EN123Edit", editVehicleDetails.engineNumber);
            Assert.AreEqual(388, editVehicleDetails.groupId);
            Assert.AreEqual("ReqTestLicenseEdit", editVehicleDetails.licensesRequired);
            Assert.AreEqual("TestManufacEdit", editVehicleDetails.manufacturer);
            Assert.AreEqual("2019", editVehicleDetails.model);
            Assert.AreEqual(0, editVehicleDetails.odometerReading);
            Assert.AreEqual(81, editVehicleDetails.operatingHours);
            Assert.AreEqual("AUS Eastern Standard Time", editVehicleDetails.timeZone);
            Assert.AreEqual("test San Avm lite", editVehicleDetails.operatingHoursName);
            Assert.AreEqual("RG7357Edit", editVehicleDetails.registration);
            Assert.AreEqual("string", editVehicleDetails.serialNumber);
            Assert.AreEqual(61562, editVehicleDetails.trackerId);
            Assert.AreEqual("TestTypeEdit", editVehicleDetails.type);
            Assert.AreEqual("TestCatEdit", editVehicleDetails.vehicleCategory);
            Assert.AreEqual("2727", editVehicleDetails.vehicleId);
            Assert.AreEqual("AutoVehicleEdit", editVehicleDetails.vehicleName);
            Assert.AreEqual("AutomationGroup", editVehicleDetails.group);
            extent.SetStepStatusPass($"Verified that the edited vehicle details are correct.");
        }
        /// <summary>
        /// Get Vehicles by Unit Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetVehiclesByUnitId(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var getVehicleDetails = GetVehicleInfoByUnitIDAsync(unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(unitId, getVehicleDetails.unitId);
            Assert.AreEqual("VIN123Edit", getVehicleDetails.chassisVin);
            Assert.AreEqual(0, getVehicleDetails.driverId);
            Assert.AreEqual("", getVehicleDetails.driverName);
            Assert.AreEqual(0, getVehicleDetails.engHoursReadingSeconds);
            Assert.AreEqual("EN123Edit", getVehicleDetails.engineNumber);
            Assert.AreEqual(388, getVehicleDetails.groupId);
            Assert.AreEqual("ReqTestLicenseEdit", getVehicleDetails.licensesRequired);
            Assert.AreEqual("TestManufacEdit", getVehicleDetails.manufacturer);
            Assert.AreEqual("2019", getVehicleDetails.model);
            Assert.AreEqual(0, getVehicleDetails.odometerReading);
            Assert.AreEqual(81, getVehicleDetails.operatingHours);
            Assert.AreEqual("AUS Eastern Standard Time", getVehicleDetails.timeZone);
            Assert.AreEqual("test San Avm lite", getVehicleDetails.operatingHoursName);
            Assert.AreEqual("RG7357Edit", getVehicleDetails.registration);
            Assert.AreEqual("string", getVehicleDetails.serialNumber);
            Assert.AreEqual(61562, getVehicleDetails.trackerId);
            Assert.AreEqual("TestTypeEdit", getVehicleDetails.type);
            Assert.AreEqual("TestCatEdit", getVehicleDetails.vehicleCategory);
            Assert.AreEqual("2727", getVehicleDetails.vehicleId);
            Assert.AreEqual("AutoVehicleEdit", getVehicleDetails.vehicleName);
            Assert.AreEqual("AutomationGroup", getVehicleDetails.group);
            extent.SetStepStatusPass($"Verified that the vehicle details are correct.");
            var editVehicleDetails = editVehicleDetailsBackToNormal(token, unitId);
            Assert.AreEqual("AutoVehicle", editVehicleDetails.vehicleName);
            extent.SetStepStatusPass($"Verified that the response is success.");

        }
        /// <summary>
        /// Verify Operating hour details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetOperatingHours(string userName, string password)
        {
            bool passed = false;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var operatingHourDetails = getVehicleOperatingHours(token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var operatingHourDetail in operatingHourDetails)
                if (operatingHourDetail.name == "test San Avm lite")
                    passed = true;
            if (passed)
                extent.SetStepStatusPass($"Verified that the operating hours are correct.");
            else
                extent.SetTestStatusFail($"The operating hours are incorrect.");
        }
        /// <summary>
        /// Get Odometer and engine hour details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetOdoAndEngineHours(string userName, string password, int unitId)
        {
            bool passed = false;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var odoDetails = getOdoAndEngineHours(userName, unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            if (odoDetails.engineHours > 0 && odoDetails.odoKm > 0)
                passed = true;
            if (passed)
                extent.SetStepStatusPass($"Verified that the details are correct {odoDetails.engineHours} and {odoDetails.odoKm}.");
            else
                extent.SetTestStatusFail($"The details are incorrect.");
        }
        /// <summary>
        /// Verify add or remove vehicle
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupId"></param>
        /// <param name="unitId"></param>
        public void VerifyAssignRemoveVehicletoGroup(string userName, string password, int groupId, int unitId)
        {

            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            AddVehiclesToGroup(token, -1, unitId);
            extent.SetStepStatusPass($"Verified that the vehicle is removed.");
            AddVehiclesToGroup(token, groupId, unitId);
            extent.SetStepStatusPass($"Verified that the vehicle is added back.");
        }
        /// <summary>
        /// Verify vehicle contact details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyGetVehicleContactDetails(string userName, string password)
        {
            bool passed = false;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleContactDetails = getVehicleContacts(token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var vehicleContactDetail in vehicleContactDetails)
                if (vehicleContactDetail.shortName == "AutomationGroup")
                {
                    Assert.AreEqual("AutomationGroup", vehicleContactDetail.fullName);
                    Assert.AreEqual("Automation Description", vehicleContactDetail.comments);
                    passed = true;
                }

            if (passed)
                extent.SetStepStatusPass($"Verified that the contact details are correct.");
            else
                extent.SetTestStatusFail($"The contact details  are incorrect.");
        }
        /// <summary>
        /// Get vehicle contact details by Unit Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetVehicleContactDetailsByUnitId(string userName, string password, int unitId)
        {
            bool passed = false;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleContactDetails = getVehicleContactsByUnitId(token, unitId);
            extent.SetStepStatusPass($"Verified that the response is success.");

            if (vehicleContactDetails.contactGroupShortName == "AutomationGroup")
            {
                Assert.AreEqual(470, vehicleContactDetails.contactGroupId);
                passed = true;
            }

            if (passed)
                extent.SetStepStatusPass($"Verified that the contact details are correct {vehicleContactDetails.contactGroupShortName}.");
            else
                extent.SetTestStatusFail($"The contact details  are incorrect.");
        }
        /// <summary>
        /// Edit vehicle contacts by unit Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        public void VerifyEditVehicleContactDetailsByUnitId(string userName, string password, int unitId,int groupId, string groupName)
        {
            bool passed = false;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleContactDetails = EditVehicleContactsByUnitId(token, unitId, groupId,groupName);
            extent.SetStepStatusPass($"Verified that the response is success.");

            if (vehicleContactDetails.contactGroupShortName == "AutomationGroup")
            {
                Assert.AreEqual(groupId, vehicleContactDetails.contactGroupId);
                Assert.AreEqual("Warning automation", vehicleContactDetails.warning);
                passed = true;
            }

            if (passed)
                extent.SetStepStatusPass($"Verified that the contact details are correct {vehicleContactDetails.contactGroupShortName}.");
            else
                extent.SetTestStatusFail($"The contact details  are incorrect.");
        }
        /// <summary>
        /// Verify Find now
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyVehicleFindNowByUnitId(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var findnowDetails = VehicleFindNowByUnitId(token, unitId,userName);
            extent.SetStepStatusPass($"Verified that the response is success.");

            Assert.AreEqual(true, findnowDetails.success);
            Assert.AreEqual("Find Now request from user admin@safecom for mobile 'AutoVehicle'", findnowDetails.feedback);
            extent.SetStepStatusPass($"Verified that the find now details are correct.");
        }
        /// <summary>
        /// Get Vehicle History Details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyVehiclesHistory(string userName, string password,int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleHistory = VehicleHistoryDetails(token, unitId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(vehicleHistory != null);
            extent.SetStepStatusPass($"Verified that the api response count is not null.");
        }
        /// <summary>
        /// Verify vehicle alerts Details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyVehiclesAlerts(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleAlerts = VehicleAlertsDetails(token, unitId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(vehicleAlerts.alerts.Count() != 0);
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }


        #endregion

        #region Drivers API
        /// <summary>
        /// Create new driver Group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyCreateDriverGroup(string userName, string password, string groupName)
        {
            var driverGroups = CreateDriverGroup(userName, password, groupName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupName, driverGroups.groupName);
            Assert.AreEqual("Test automation desc", driverGroups.description);
            Assert.AreEqual("29B6F6", driverGroups.color);
            extent.SetStepStatusPass($"Verified that the driver group is created correctly");
        }
        /// <summary>
        /// Verify driver details by username
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDriverGroupByUser(string userName, string password, string groupName)
        {
            var driverGroups = GetDriverGroups(userName, password);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(driverGroups.Count != 0);
            foreach (var driverGroup in driverGroups)
                if (driverGroup.groupName == groupName)
                {
                    Assert.AreEqual("Test automation desc", driverGroup.description);
                    Assert.AreEqual("29B6F6", driverGroup.color);
                    Assert.AreEqual(0, driverGroup.driverCount);
                }
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }
        /// <summary>
        /// Create new driver
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyCreateDriver(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups = GetDriverGroups(userName, password, token);
            foreach (var driverGroup in driverGroups)
                if (driverGroup.groupName == groupName)
                    groupId = driverGroup.groupId;
            var createDriver = CreateDriver(userName, password, groupName, groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(true, createDriver.success);
            extent.SetStepStatusPass($"Verified that the Driver details are correct.");
        }
        /// <summary>
        /// VerifyDriver details by search key
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDriverInfobySearchKey(string userName, string password, string groupName, string driverName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;

            var driverGroups = GetDriverInfoBySearchKeyword(token, driverName);
            foreach (var driverGroup in driverGroups)
                if (driverGroup.groupName == groupName)
                {
                    Assert.AreEqual(groupId, driverGroup.groupId);
                    Assert.AreEqual("AutoVehicle", driverGroup.vehicleName);
                    //Assert.AreEqual(2727, driverGroup.unitId);
                    Assert.AreEqual("Test AutoDriver", driverGroup.driverShortName);
                    Assert.AreEqual(groupName, driverGroup.groupName);
                    Assert.AreEqual("29B6F6", driverGroup.groupColor);
                    //Assert.AreEqual("Test automation address", driverGroup.address);
                    extent.SetStepStatusPass($"Verified that the Driver details are correct.");
                }
        }
        /// <summary>
        /// VerifyDriverGroupedInfo
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="driverName"></param>
        public void VerifyDriverGroupedInfobySearchKey(string userName, string password, string groupName, string driverName)
        {
            Thread.Sleep(10000);
            int groupId = 0;
            int driverId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverInfoBySearchKeyword(token, driverName);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                {
                    groupId = driverGroup1.groupId;
                    driverId = driverGroup1.driverId;
                }
            var driverGroups = GetDriverGroupedInfoBySearchKeyword(token, driverName);
            foreach (var driverGroup in driverGroups)
                if (driverGroup.groupName == groupName)
                {
                    Assert.AreEqual(groupId, driverGroup.groupId);
                    Assert.AreEqual(groupName, driverGroup.groupName);
                    Assert.AreEqual("29B6F6", driverGroup.groupColor);
                    Assert.AreEqual(driverId, driverGroup.drivers[0].driverId);
                    Assert.AreEqual("Test AutoDriver", driverGroup.drivers[0].driverShortName);
                    Assert.AreEqual("987654321", driverGroup.drivers[0].driverContactPhone);
                    extent.SetStepStatusPass($"Verified that the Driver details are correct.");
                }
        }
        /// <summary>
        /// Verify griver info by group id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="driverName"></param>
        public void VerifyDriverInfobyGroupId(string userName, string password, string groupName, string driverName)
        {
            int groupId = 0;
            int driverId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");

            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;

            var driverTree = GetDriverTree(userName, password);
            foreach (var driverGroup2 in driverTree)
                if (driverGroup2.groupName == groupName)
                    driverId = driverGroup2.driverId  ;
            var driverGroup = getDriverByGroupID(groupId, token);
            Assert.AreEqual(groupId, driverGroup.groupId);
            Assert.AreEqual("Test automation desc", driverGroup.description);
            Assert.AreEqual(groupName, driverGroup.groupName);
            Assert.AreEqual("29B6F6", driverGroup.color);
            Assert.AreEqual(1, driverGroup.driverCount);
            Assert.AreEqual("AutoVehicle", driverGroup.driverList[0].vehicleName);
            Assert.AreEqual(2727, driverGroup.driverList[0].unitId);
            Assert.AreEqual(driverId, driverGroup.driverList[0].driverId);
            Assert.AreEqual("Test AutoDriver", driverGroup.driverList[0].driverShortName);
            Assert.AreEqual("987654321", driverGroup.driverList[0].driverContactPhone);
            Assert.AreEqual(groupId, driverGroup.driverList[0].groupId);
            Assert.AreEqual(groupName, driverGroup.driverList[0].groupName);
            Assert.AreEqual("29B6F6", driverGroup.driverList[0].groupColor);
            extent.SetStepStatusPass($"Verified that the Driver details are correct.");
        }
        /// <summary>
        /// Unassign Assign vehicle
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="driverName"></param>
        public void VerifyAssignUnassignvehicle(string userName, string password, string groupName, string driverName)
        {
            int groupId = 0;
            int driverId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;

            var driverTree = GetDriverTree(userName, password);
            foreach (var driverGroup2 in driverTree)
                if (driverGroup2.groupName == groupName)
                    driverId = driverGroup2.driverId;
            AssignVehicleToDriver(token, driverId, 0);
            extent.SetStepStatusPass($"Verified that the unassigning is success.");
            AssignVehicleToDriver(token, driverId, 2727);
            extent.SetStepStatusPass($"Verified that the assigning is success.");
        }
        /// <summary>
        /// Edit Driver details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="driverName"></param>
        public void VerifyEditDriver(string userName, string password, string groupName, string driverName)
        {
            int groupId = 0;
            int driverId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;

            var driverTree = GetDriverTree(userName, password);
            foreach (var driverGroup2 in driverTree)
                if (driverGroup2.groupName == groupName)
                    driverId = driverGroup2.driverId;
            var editDriver = EditDriverDetails(userName, token, groupName, groupId, driverId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(true, editDriver.success);
            extent.SetStepStatusPass($"Verified that the Driver details are correct.");
        }
        /// <summary>
        /// Get driver details by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="driverName"></param>
        public void VerifyDriverInfoId(string userName, string password, string groupName, string driverName)
        {
            int groupId = 0;
            int driverId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;

            var driverTree = GetDriverTree(userName, password);
            foreach (var driverGroup2 in driverTree)
                if (driverGroup2.groupName == groupName)
                    driverId = driverGroup2.driverId;
            var driverGroup = getDriverByID(driverId, token);
            Assert.AreEqual(2727, driverGroup.unitId);
            Assert.AreEqual("AutoVehicle", driverGroup.unitName);
            Assert.AreEqual(groupName, driverGroup.groupName);
            Assert.AreEqual(driverId, driverGroup.driverId);
            Assert.AreEqual("TestEdit", driverGroup.firstName);
            Assert.AreEqual("AutoDriverEdit", driverGroup.lastName);
            Assert.AreEqual("123456789", driverGroup.phone1);
            Assert.AreEqual("testautoedited" + DateTime.Now.ToString("dd") + "@gtail.com", driverGroup.email1);
            Assert.AreEqual("Test automation address edited", driverGroup.address1);
            Assert.AreEqual("22222", driverGroup.licenceNumber);
            Assert.AreEqual("12345", driverGroup.driverUniqueId);
            Assert.AreEqual(groupId, driverGroup.groupId);
            Assert.AreEqual("inactive", driverGroup.licenseState);
            extent.SetStepStatusPass($"Verified that the Driver details are correct.");
        }
        /// <summary>
        /// Assign driver to a group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="driverName"></param>
        public void VerifyAssignDriverToGroup(string userName, string password, string groupName, string driverName)
        {
            int[] driverIds = new int[] { 0 };
            int groupId = 0;
            int driverId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverInfoBySearchKeyword(token, driverName);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                {
                    groupId = driverGroup1.groupId;
                    driverId = driverGroup1.driverId;
                }
            driverIds[0] = driverId;
            AssignDriverToGroup(token, driverIds, 244);
            extent.SetStepStatusPass($"Verified that the Driver is assigned to new group");
            AssignDriverToGroup(token, driverIds, groupId);
            extent.SetStepStatusPass($"Verified that the Driver is assigned back to group");
        }
        /// <summary>
        /// VerifyDeleteDrivers
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDeleteDriverById(string userName, string password, string groupName, string driverName)
        {
            int[] driverIds = new int[] { 0 };
            int groupId = 0;
            int driverId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverInfoBySearchKeyword(token, driverName);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                {
                    groupId = driverGroup1.groupId;
                    driverId = driverGroup1.driverId;
                }
            driverIds[0] = driverId;
            DeleteDrivers(token, driverIds);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }
        /// <summary>
        /// Verify edit driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="driverName"></param>
        public void VerifyEditDriverGroup(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;
            var editDriverGroup = EditDriverGroup(userName, token, groupName, groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupName + "Edited", editDriverGroup.groupName);
            Assert.AreEqual("Test automation desc edited", editDriverGroup.description);
            Assert.AreEqual("5E35B1", editDriverGroup.color);
            Assert.AreEqual(groupId, editDriverGroup.groupId);
            Assert.AreEqual(0, editDriverGroup.driverCount);
            extent.SetStepStatusPass($"Verified that the Driver group details are correct.");
        }
        /// <summary>
        /// Verify driverGroup details by Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDriverGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;
            var driverGroups = getDriverGroupByID(groupId, token);
            Assert.AreEqual(groupName, driverGroups.groupName);
            Assert.AreEqual(groupId, driverGroups.groupId);
            Assert.AreEqual("Test automation desc edited", driverGroups.description);
            Assert.AreEqual("5E35B1", driverGroups.color);
            extent.SetStepStatusPass($"Verified that the api response is correct.");
        }
        /// <summary>
        /// Verify Delete driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDeleteDriverGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverGroups1 = GetDriverGroups(userName, password, token);
            foreach (var driverGroup1 in driverGroups1)
                if (driverGroup1.groupName == groupName)
                    groupId = driverGroup1.groupId;
            DeleteDriverGroupByID(token, groupId);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }

        #endregion

        #region Alarm APIs
        /// <summary>
        /// Verify response of alarm tree
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlarmsByUserNameAPI(string userName, string password)
        {
            var alarmTree = GetAlarmTree(userName, password);
            int alarmCount = alarmTree.alarms.Count();
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(alarmCount != 0);
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }

        /// <summary>
        /// Verify Clear alarm API response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void ClearAlarm(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var alarmTree = GetAlarmTree(userName, password, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            var requestBody = new ClearAlarmBody();
            requestBody.alarmToClear = new AlarmToClear();
            requestBody.UserName = userName;
            requestBody.isTestingAlarm = true;
            requestBody.isNonReportingMobile = true;
            requestBody.enteredName = "Automation user";
            requestBody.enteredReason = "Automated clear";
            requestBody.alarmToClear.unitId = alarmTree.alarms[0].unitId;
            requestBody.alarmToClear.unitName = alarmTree.alarms[0].unitName;
            requestBody.alarmToClear.fleetId = alarmTree.alarms[0].fleetId;
            requestBody.alarmToClear.statusId = alarmTree.alarms[0].statusId;
            requestBody.alarmToClear.alertId = alarmTree.alarms[0].alertId;
            requestBody.alarmToClear.alarmType = alarmTree.alarms[0].alarmType;
            requestBody.alarmToClear.lat = alarmTree.alarms[0].lat;
            requestBody.alarmToClear.lon = alarmTree.alarms[0].lon;
            requestBody.alarmToClear.address = alarmTree.alarms[0].address;
            requestBody.alarmToClear.alarmText = alarmTree.alarms[0].alarmText;
            requestBody.alarmToClear.detail = alarmTree.alarms[0].detail;
            requestBody.alarmToClear.driverId = alarmTree.alarms[0].driverId;
            requestBody.alarmToClear.driverName = alarmTree.alarms[0].driverName;
            requestBody.alarmToClear.contactPhone = alarmTree.alarms[0].contactPhone;
            requestBody.alarmToClear.utcTime = alarmTree.alarms[0].utcTime;
            requestBody.alarmToClear.alertType = alarmTree.alarms[0].alertType;
            ClearAlarmResponseBody clearAlarmResponse = ClearAlarmAPI(userName, password, requestBody, token);
            Assert.IsTrue(clearAlarmResponse.success);
            Assert.IsNull(clearAlarmResponse.error);
            Assert.AreEqual("Alarm Successfully Cleared", clearAlarmResponse.feedback);
            extent.SetStepStatusPass($"Verified that the clear alarm is working as expected with reference - " + clearAlarmResponse._ref);
        }
        #endregion

        #region Alerts API
        /// <summary>
        /// Verify Alert tree api response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlertsByUserNameAPI(string userName, string password)
        {
            var alertTree = GetAlertTree(userName, password);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(alertTree.Count != 0);
            extent.SetStepStatusPass($"Verified that the api response count is not 0.");
        }
        /// <summary>
        /// Verifies the response of alert APi by providing alert id.
        /// </summary>
        public void VerifyAlertsByAlertID(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var alarmTree = GetAlertTree(userName, password, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            var alertId = alarmTree.FirstOrDefault().alertId.ToString();
            var alertDetails = getAlertDetailsByAlertId(alertId, token);
            Assert.AreEqual(alertId, alertDetails.alertId.ToString());
            extent.SetStepStatusPass($"Verified that the response is success and the alert id matches the one provided.");
        }
        /// <summary>
        /// Delete Alert Details
        /// </summary>
        public void DeleteAlertDetails(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var alarmTree = GetAlertTree(userName, password, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            var alertId = alarmTree.FirstOrDefault().alertId;
            DeleteAlertsByCount(alertId,token);
        }
        #endregion

        #region Location API
        /// <summary>
        /// Verifies that the location groups API response is correct
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationsGroupByUser(string userName, string password, string groupName)
        {
            var locationGroups = GetLocationGroups(userName, password);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                {
                    Assert.AreEqual("Automation description", locationGroup.description);
                }
            extent.SetStepStatusPass($"Verified the api response");
        }
        /// <summary>
        /// Create new location group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyCreateLocationGroup(string userName, string password, string groupName)
        {
            var locationGroups = CreateLocationGroup(userName, password, groupName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupName, locationGroups.groupName);
            Assert.AreEqual("Automation description", locationGroups.description);
            extent.SetStepStatusPass($"Verified that the location group is created correctly");
        }
        /// <summary>
        /// Verify LocationGroup by providing group ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyLocationsGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;
            var locationGroupInfo = GetLocationGroupByID(userName, password, groupId.ToString(), token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupName, locationGroupInfo.groupName);
            Assert.AreEqual("Automation description", locationGroupInfo.description);
            extent.SetStepStatusPass($"Verified that the location group details are correct.");
        }
        /// <summary>
        /// Edit Location group details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyEditLocationsGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;
            var locationGroupInfo = EditLocationGroupByID(userName, password, groupId, groupName + "Edited", token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupName + "Edited", locationGroupInfo.groupName);
            Assert.AreEqual("Automation description edited", locationGroupInfo.description);
            extent.SetStepStatusPass($"Verified that the edited location group details are correct.");
        }
        /// <summary>
        /// Delete Location group By ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDeleteLocationsGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;
            DeleteLocationGroupDetailsByID(token, groupId.ToString());
            extent.SetStepStatusPass($"Verified that the response is success.");
        }

        /// <summary>
        /// Verifies that the location types API response is correct
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationsTypesByUser(string userName, string password, string typeName)
        {
            var locationTypes = GetLocationTypes(userName, password);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                {
                    Assert.AreEqual(typeName, locationType.name);
                    extent.SetStepStatusPass($"Verified that the location type name details are correct.");
                    Assert.AreEqual("Automation description", locationType.description);
                    extent.SetStepStatusPass($"Verified that the location type description is correct.");
                    Assert.AreEqual("Automation code", locationType.code);
                    extent.SetStepStatusPass($"Verified that the location type code is correct.");
                    Assert.AreEqual("29B6F6", locationType.colorHex);
                    extent.SetStepStatusPass($"Verified that the location type colorhex is correct.");
                    Assert.AreEqual(false, locationType.optionLogOnly);
                    extent.SetStepStatusPass($"Verified that the location type log only is correct.");
                    Assert.AreEqual(true, locationType.optionNotifyEntryExit);
                    extent.SetStepStatusPass($"Verified that the location type notify entry exit is correct.");
                    Assert.AreEqual(false, locationType.optionNotifyOnEntry);
                    extent.SetStepStatusPass($"Verified that the location type notify entry is correct.");
                    Assert.AreEqual(false, locationType.optionNotifyOnExit);
                    extent.SetStepStatusPass($"Verified that the location type notify exit is correct.");
                    Assert.AreEqual("https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg", locationType.iconUrl);
                    extent.SetStepStatusPass($"Verified that the location type icon url is correct.");
                }
            extent.SetStepStatusPass($"Verified that the location type details are verified.");
        }
        /// <summary>
        /// Get location type details by page number
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        public void VerifyLocationsTypesByPage(string userName, string password, string typeName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = getLocationTypeByPage(token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                {
                    Assert.AreEqual(typeName, locationType.name);
                    extent.SetStepStatusPass($"Verified that the location type name details are correct.");
                    Assert.AreEqual("Automation description", locationType.description);
                    extent.SetStepStatusPass($"Verified that the location type description is correct.");
                    Assert.AreEqual("Automation code", locationType.code);
                    extent.SetStepStatusPass($"Verified that the location type code is correct.");
                    Assert.AreEqual("29B6F6", locationType.colorHex);
                    extent.SetStepStatusPass($"Verified that the location type colorhex is correct.");
                    Assert.AreEqual(false, locationType.optionLogOnly);
                    extent.SetStepStatusPass($"Verified that the location type log only is correct.");
                    Assert.AreEqual(true, locationType.optionNotifyEntryExit);
                    extent.SetStepStatusPass($"Verified that the location type notify entry exit is correct.");
                    Assert.AreEqual(false, locationType.optionNotifyOnEntry);
                    extent.SetStepStatusPass($"Verified that the location type notify entry is correct.");
                    Assert.AreEqual(false, locationType.optionNotifyOnExit);
                    extent.SetStepStatusPass($"Verified that the location type notify exit is correct.");
                    Assert.AreEqual("https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg", locationType.iconUrl);
                    extent.SetStepStatusPass($"Verified that the location type icon url is correct.");

                }
            extent.SetStepStatusPass($"Verified that the location type details are verified.");
        }
        /// <summary>
        /// Verify whether the api repsonse is success
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        public void VerifyLocationsTypeIcons(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            GetLocationTypeIcon(token);
            extent.SetStepStatusPass($"Verified that the location type icons api response is success");
        }


        /// <summary>
        /// Verify creation of new location type
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        public void VerifyCreateLocationType(string userName, string password, string typeName)
        {
            var locationGroups = CreateLocationType(userName, password, typeName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(true, locationGroups.success);
            extent.SetStepStatusPass($"Verified that the location type is created correctly");
        }
        /// <summary>
        /// Verify edit location types
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        public void VerifyEditLocationsTypeById(string userName, string password, string typeName)
        {
            int typeId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;
            var locationTypeInfo = EditLocationTypeByID(userName, password, typeId, typeName + "Edited", token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(typeId, locationTypeInfo.id);
            Assert.AreEqual(true, locationTypeInfo.success);
            extent.SetStepStatusPass($"Verified that the edited location type details are correct.");
        }
        /// <summary>
        /// Verify the details of locations types by ID API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        public void VerifyLocationsTypesById(string userName, string password, string typeName)
        {
            int typeId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;
            var locationTypeInfo = GetLocationTypebyID(userName, password, typeId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                {
                    Assert.AreEqual(locationType.name, locationTypeInfo.name);
                    extent.SetStepStatusPass($"Verified that the location type name details are correct.");
                    Assert.AreEqual(locationType.id, locationTypeInfo.id);
                    extent.SetStepStatusPass($"Verified that the location type id is correct.");
                    Assert.AreEqual(locationType.description, locationTypeInfo.description);
                    extent.SetStepStatusPass($"Verified that the location type description is correct.");
                    Assert.AreEqual(locationType.code, locationTypeInfo.code);
                    extent.SetStepStatusPass($"Verified that the location type code is correct.");
                    Assert.AreEqual(locationType.colorHex, locationTypeInfo.colorHex);
                    extent.SetStepStatusPass($"Verified that the location type colorhex is correct.");
                    Assert.AreEqual(locationType.optionLogOnly, locationTypeInfo.optionLogOnly);
                    extent.SetStepStatusPass($"Verified that the location type log only is correct.");
                    Assert.AreEqual(locationType.optionNotifyEntryExit, locationTypeInfo.optionNotifyEntryExit);
                    extent.SetStepStatusPass($"Verified that the location type notify entry exit is correct.");
                    Assert.AreEqual(locationType.optionNotifyOnEntry, locationTypeInfo.optionNotifyOnEntry);
                    extent.SetStepStatusPass($"Verified that the location type notify entry is correct.");
                    Assert.AreEqual(locationType.optionNotifyOnExit, locationTypeInfo.optionNotifyOnExit);
                    extent.SetStepStatusPass($"Verified that the location type notify exit is correct.");
                    Assert.AreEqual(locationType.iconUrl, locationTypeInfo.iconUrl);
                    extent.SetStepStatusPass($"Verified that the location type icon url is correct.");
                }
            extent.SetStepStatusPass($"Verified that the location type details are correct.");
        }
        /// <summary>
        /// Create new location
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyCreateNewLocation(string userName, string password, string typeName, string groupName, string locName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var createLocation = CreateNewLocation(token, locName, groupId, typeId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(true, createLocation.success);
        }
        /// <summary>
        /// Verifies the location details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyLocationsByUser(string userName, string password, string typeName, string groupName, string locName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var locations = GetLocationTree(userName, password, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locations)
                if (location.locationName == locName)
                {
                    Assert.AreEqual(groupId, location.groupId);
                    Assert.AreEqual(groupName, location.groupName);
                    Assert.AreEqual(locName, location.locationName);
                    Assert.AreEqual("Test Automation desc", location.locationDescription);
                    Assert.AreEqual(typeId, location.locationTypeId);
                    Assert.AreEqual(typeName, location.locationTypeName);
                    Assert.AreEqual("Automation code", location.locationTypeCode);
                    Assert.AreEqual("https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg", location.locationTypeIconUrl);
                    Assert.AreEqual("29B6F6", location.colorHex);
                    Assert.AreEqual(true, location.isChecked);
                    extent.SetStepStatusPass($"Verified the location details are correct");
                }
            extent.SetStepStatusPass($"Verified the api response");
        }
        /// <summary>
        /// Get location details by search key
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyLocationsBySearchKey(string userName, string password, string typeName, string groupName, string locName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var locations = GetLocationBySearchKeyword(token, locName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locations)
                if (location.locationName == locName)
                {
                    Assert.AreEqual(groupId, location.groupId);
                    Assert.AreEqual(groupName, location.groupName);
                    Assert.AreEqual(locName, location.locationName);
                    Assert.AreEqual("Test Automation desc", location.locationDescription);
                    Assert.AreEqual(typeId, location.locationTypeId);
                    Assert.AreEqual(typeName, location.locationTypeName);
                    Assert.AreEqual("Automation code", location.locationTypeCode);
                    Assert.AreEqual("https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg", location.locationTypeIconUrl);
                    Assert.AreEqual("29B6F6", location.locationTypeColorHex);
                    Assert.AreEqual("Feature", location.featureData.type);
                    Assert.AreEqual("Point", location.featureData.geometry.type);
                    Assert.AreEqual(127.133804, location.featureData.geometry.coordinates[0]);
                    Assert.AreEqual(-23.624395, location.featureData.geometry.coordinates[1]);
                    Assert.AreEqual(100000, location.featureData.properties.locationRadius);
                    Assert.AreEqual(100000, location.locationRadiusMeters);
                    Assert.AreEqual(2, location.featureShape);
                    extent.SetStepStatusPass($"Verified the location details are correct");
                }
            extent.SetStepStatusPass($"Verified the api response");
        }

        /// <summary>
        /// Verify Locations groupedwith search keyword
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyLocationsGroupedBySearchKey(string userName, string password, string typeName, string groupName, string locName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var locationsList = GetLocationGroupedBySearchKeyword(token, locName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locationsList)
                if (location.groupName == groupName)
                {
                    Assert.AreEqual(groupId, location.groupId);
                    Assert.AreEqual(groupName, location.groupName);
                    Assert.AreEqual(locName, location.locations[0].locationName);
                    Assert.AreEqual("Test Automation desc", location.locations[0].locationDescription);
                    Assert.AreEqual(typeId, location.locations[0].locationTypeId);
                    Assert.AreEqual(typeName, location.locations[0].locationTypeName);
                    extent.SetStepStatusPass($"Verified the location grouped details are correct");
                }
            extent.SetStepStatusPass($"Verified the api response");
        }
        /// <summary>
        /// Verify Locations Grouped With Feature details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyLocationsGroupedWithFeatureDetails(string userName, string password, string typeName, string groupName, string locName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var locations = GetLocationGroupedWithFeatures(token, locName, groupId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locations)
                if (location.locationName == locName)
                {
                    Assert.AreEqual(groupId, location.groupId);
                    Assert.AreEqual(groupName, location.groupName);
                    Assert.AreEqual(locName, location.locationName);
                    Assert.AreEqual("Test Automation desc", location.locationDescription);
                    Assert.AreEqual(typeId, location.locationTypeId);
                    Assert.AreEqual(typeName, location.locationTypeName);
                    Assert.AreEqual("Automation code", location.locationTypeCode);
                    Assert.AreEqual("https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg", location.locationTypeIconUrl);
                    Assert.AreEqual("29B6F6", location.locationTypeColorHex);
                    Assert.AreEqual("Feature", location.featureData.type);
                    Assert.AreEqual("Point", location.featureData.geometry.type);
                    Assert.AreEqual(127.133804, location.featureData.geometry.coordinates[0]);
                    Assert.AreEqual(-23.624395, location.featureData.geometry.coordinates[1]);
                    Assert.AreEqual(100000, location.featureData.properties.locationRadius);
                    Assert.AreEqual(100000, location.locationRadiusMeters);
                    Assert.AreEqual(2, location.featureShape);
                    extent.SetStepStatusPass($"Verified the location details are correct");
                }
            extent.SetStepStatusPass($"Verified the api response");
        }
        /// <summary>
        /// Verify Location details by groupId
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyLocationsByGroupId(string userName, string password, string typeName, string groupName, string locName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var locations = getLocationDetailsByGroupId(groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locations)
                if (location.locationName == locName)
                {
                    Assert.AreEqual(groupId, location.groupId);
                    Assert.AreEqual(groupName, location.groupName);
                    Assert.AreEqual(locName, location.locationName);
                    Assert.AreEqual("Test Automation desc", location.locationDescription);
                    Assert.AreEqual(typeId, location.locationTypeId);
                    Assert.AreEqual(typeName, location.locationTypeName);
                    Assert.AreEqual("Automation code", location.locationTypeCode);
                    Assert.AreEqual("https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg", location.locationTypeIconUrl);
                    Assert.AreEqual("29B6F6", location.colorHex);
                    extent.SetStepStatusPass($"Verified the location details are correct");
                }
            extent.SetStepStatusPass($"Verified the api response");
        }
        /// <summary>
        /// Get locations with group and pagination
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyLocationsByGroupIdandPagination(string userName, string password, string typeName, string groupName, string locName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var locations = GetLocationDetailsByGroupAndPage(groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(groupId, locations.groupId);
            Assert.AreEqual(groupName, locations.groupName);
            Assert.AreEqual("Automation description", locations.description);
            Assert.AreEqual(1, locations.locationCount);
            Assert.AreEqual(groupId, locations.locationsList[0].groupId);
            Assert.AreEqual("Test Automation desc", locations.locationsList[0].locationDescription);
            Assert.AreEqual(groupName, locations.locationsList[0].groupName);
            Assert.AreEqual(locName, locations.locationsList[0].locationName);
            Assert.AreEqual(typeId, locations.locationsList[0].locationTypeId);
            Assert.AreEqual(typeName, locations.locationsList[0].locationTypeName);
            Assert.AreEqual("Automation code", locations.locationsList[0].locationTypeCode);
            Assert.AreEqual("https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg", locations.locationsList[0].locationTypeIconUrl);
            Assert.AreEqual("29B6F6", locations.locationsList[0].colorHex);
            extent.SetStepStatusPass($"Verified the location details are correct");
        }
        /// <summary>
        /// Add/ remove location from group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyAssignRemoveLocationstoGroup(string userName, string password, string groupName, string locName)
        {
            int locId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;
            var locations = getLocationDetailsByGroupId(groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locations)
                if (location.locationName == locName)
                    locId = location.locationId;

            AddLocationsToGroup(token, -1, locId);
            extent.SetStepStatusPass($"Verified that the location is removed.");
            AddLocationsToGroup(token, groupId, locId);
            extent.SetStepStatusPass($"Verified that the location is added back.");
        }
        /// <summary>
        /// Edit the location details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyEditLocations(string userName, string password, string typeName, string groupName, string locName)
        {
            int locId = 0;
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;
            var locations = getLocationDetailsByGroupId(groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locations)
                if (location.locationName == locName)
                    locId = location.locationId;

            var editLocation = EditLocationDetails(token, locName, groupId, typeId, locId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(true, editLocation.success);
        }
        /// <summary>
        /// Verify Location details by Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyLocationsById(string userName, string password, string typeName, string groupName, string locName)
        {
            int locId = 0;
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;
            var locationDetails = getLocationDetailsByGroupId(groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var locationDetail in locationDetails)
                if (locationDetail.locationName == locName)
                    locId = locationDetail.locationId;


            var locations = GetLocationByLocationId(token, locId);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(locId, locations.locationId);
            Assert.AreEqual(groupId, locations.groupId);
            Assert.AreEqual(groupName, locations.groupName);
            Assert.AreEqual(locName, locations.locationName);
            Assert.AreEqual("Test Automation desc edited", locations.locationDescription);
            Assert.AreEqual(typeId, locations.locationTypeId);
            Assert.AreEqual(typeName, locations.locationTypeName);
            Assert.AreEqual("29B6F6", locations.locationTypeColorHex);
            Assert.AreEqual("Feature", locations.featureData.type);
            Assert.AreEqual("Point", locations.featureData.geometry.type);
            Assert.AreEqual(127.133804, locations.featureData.geometry.coordinates[0]);
            Assert.AreEqual(-23.624395, locations.featureData.geometry.coordinates[1]);
            Assert.AreEqual(120000, locations.featureData.properties.locationRadius);
            Assert.AreEqual(120000, locations.locationRadiusMeters);
            Assert.AreEqual(2, locations.featureShape);
            extent.SetStepStatusPass($"Verified the location details are correct");
        }
        /// <summary>
        /// Delete Multiple Locations
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyMultipleDeleteLocation(string userName, string password, string typeName, string groupName)
        {
            int typeId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;

            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;

            var createLocation = CreateNewLocation(token, "AutoDelLoc1", groupId, typeId);
            int locId1 = createLocation.id;
            var createLocation2 = CreateNewLocation(token, "AutoDelLoc2", groupId, typeId);
            int locId2 = createLocation2.id;
            DeleteMultipleLocationsById(token, locId1, locId2);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }
        /// <summary>
        /// Delete Location By Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <param name="locName"></param>
        public void VerifyDeleteLocation(string userName, string password, string groupName, string locName)
        {
            int locId = 0;
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationGroups = GetLocationGroups(userName, password, token);
            foreach (var locationGroup in locationGroups)
                if (locationGroup.groupName == groupName)
                    groupId = locationGroup.groupId;
            var locations = getLocationDetailsByGroupId(groupId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var location in locations)
                if (location.locationName == locName)
                    locId = location.locationId;
            DeleteLocationsByID(token, locId);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }
        /// <summary>
        /// Dekete Location Type By Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="typeName"></param>
        public void VerifyDeleteLocationType(string userName, string password, string typeName)
        {
            int typeId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypes = GetLocationTypes(userName, password, token);
            foreach (var locationType in locationTypes)
                if (locationType.name == typeName)
                    typeId = locationType.id;
            DeleteLocationsTypeByID(token, typeId);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }

        #endregion

        #region Contacts API
        /// <summary>
        /// Verify the contact group creation
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyCreateContactGroup(string userName, string password, string groupName)
        {
            var contactGroups = CreateContactGroup(userName, password, groupName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(contactGroups.successful, true);
            extent.SetStepStatusPass($"Verified that the contact group is created correctly");
        }
        /// <summary>
        /// Verify the contact group contents
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyContactGroups(string userName, string password, string groupName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactGroups = CreateContactGroup(userName, password, groupName, token);
            Assert.AreEqual(contactGroups.successful, true);
            extent.SetStepStatusPass($"Verified that the contact group is created correctly");
            int groupId = contactGroups.contactGroupId;
            var contactGroupLists = GetContactGroups(userName, password, token);

            foreach (var contactGrouplist in contactGroupLists)
                if (contactGrouplist.contactGroupId == groupId)
                {
                    Assert.AreEqual(groupName, contactGrouplist.fullName);
                    Assert.AreEqual(groupName, contactGrouplist.shortName);
                    Assert.AreEqual("Test automation comments", contactGrouplist.comments);
                    Assert.AreEqual(0, contactGrouplist.contactDetailCount);
                }
            extent.SetStepStatusPass($"Verified that the contact group details are correct.");
        }
        /// <summary>
        /// Verify contact group usage details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyContactGroupUsage(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactGroupLists = GetContactGroups(userName, password, token);
            foreach (var contactGrouplist in contactGroupLists)
                if (contactGrouplist.fullName == groupName)
                    groupId = contactGrouplist.contactGroupId;
            var contactGroupUsage = getContactGroupUsageAsync(groupId.ToString(), token);
            extent.SetStepStatusPass($"Verified that the contact group usage details are correct.");
        }
        /// <summary>
        /// Delete contact group Usage
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void DeleteContactGroupUsage(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactGroupLists = GetContactGroups(userName, password, token);
            foreach (var contactGrouplist in contactGroupLists)
                if (contactGrouplist.fullName == groupName)
                    groupId = contactGrouplist.contactGroupId;
            var contactGroupUsage = deleteContactGroupUsageAsync(groupId.ToString(), token);
            extent.SetStepStatusPass($"Verified that the contact group usage details are deleted.");
        }
        /// <summary>
        /// Edit Contact group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyEditContactGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactGroupLists = GetContactGroups(userName, password, token);
            foreach (var contactGrouplist in contactGroupLists)
                if (contactGrouplist.fullName == groupName)
                    groupId = contactGrouplist.contactGroupId;
            var contactGroupInfo = EditContactGroupByID(userName, password, groupId, groupName + "Edited", token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(contactGroupInfo.successful, true);
            extent.SetStepStatusPass($"Verified that the edited contact group details are correct.");
        }

        /// <summary>
        /// Delete contact group By ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDeleteContactGroupById(string userName, string password, string groupName)
        {
            int groupId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactGroupLists = GetContactGroups(userName, password, token);
            foreach (var contactGrouplist in contactGroupLists)
                if (contactGrouplist.fullName == groupName)
                    groupId = contactGrouplist.contactGroupId;
            DeleteContactGroupDetailsByID(token, groupId.ToString());
            extent.SetStepStatusPass($"Verified that the response is success.");
        }

        #endregion

        #region Roles API
        /// <summary>
        /// Verify new role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        public void VerifyCreateNewRole(string userName, string password, string roleName)
        {
            var role = CreateNewRoleForUser(userName, password, roleName);
            extent.SetStepStatusPass($"Verified that the create role response is success.");
        }
        /// <summary>
        /// Verify roles details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        public void VerifyRoleDetails(string userName, string password, string roleName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            int[] access = new int[] { 12, 82, 29, 27, 52, 30, 28, 60, 61, 35, 71, 46, 47, 3, 64, 58, 57, 56, 38, 44, 70, 45, 5, 53, 89, 90 };
            int[] reportList = new int[] { 830, 415 };
            var roleLists = GetRoles(userName, password, token);
            extent.SetStepStatusPass($"Verified that the roles list is recieved correctly");

            foreach (var rolesList in roleLists)
                if (rolesList.roleName == roleName)
                {
                    Assert.AreEqual("Test automation description", rolesList.roleDescription);
                    Assert.AreEqual(true, rolesList.defaultRole);
                    Assert.IsTrue(rolesList.accessRights.SequenceEqual(access));
                    Assert.IsTrue(rolesList.reportList.SequenceEqual(reportList));
                }
            extent.SetStepStatusPass($"Verified that the roles details are correct.");
        }
        /// <summary>
        /// Edit Role details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        public void VerifyEditRolesByName(string userName, string password, string roleName)
        {
            string roleID = "";
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var roleLists = GetRoles(userName, password, token);
            foreach (var rolelist in roleLists)
                if (rolelist.roleName == roleName)
                    roleID = rolelist.roleId;
            EditRoleNameByID(userName, password, roleID, roleName + " Edited", token);
            extent.SetStepStatusPass($"Verified that the roles details are edited correctly.");
        }
        /// <summary>
        /// Edit roles by right
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        public void VerifyEditRolesByRights(string userName, string password, string roleName)
        {
            string roleID = "";
            int[] access = new int[] { 12, 82, 29, 27, 52, 30 };
            int[] reportList = new int[] { 830, 415, 303 };
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var roleLists = GetRoles(userName, password, token);
            foreach (var rolelist in roleLists)
                if (rolelist.roleName == roleName)
                    roleID = rolelist.roleId;
            EditRoleRightsByID(userName, password, roleID, token);
            extent.SetStepStatusPass($"Verified that the roles details are edited correctly.");
        }
        /// <summary>
        /// Verify Edited Role details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        public void verifyEditedRoleDetails(string userName, string password, string roleName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            int[] access = new int[] { 12, 82, 29, 27, 52, 30 };
            int[] reportList = new int[] { 830, 415, 303 };
            var editedRoleLists = GetRoles(userName, password, token);
            foreach (var editedRoleList in editedRoleLists)
                if (editedRoleList.roleName == roleName)
                {
                    Assert.AreEqual("Automation description edited", editedRoleList.roleDescription);
                    Assert.AreEqual(true, editedRoleList.defaultRole);
                    Assert.IsTrue(editedRoleList.accessRights.SequenceEqual(access));
                    Assert.IsTrue(editedRoleList.reportList.SequenceEqual(reportList));
                }
        }
        /// <summary>
        /// Delete roles By ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        public void VerifyDeleteRolesById(string userName, string password, string roleName)
        {
            string roleID = "";
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var roleLists = GetRoles(userName, password, token);
            foreach (var rolelist in roleLists)
                if (rolelist.roleName == roleName)
                    roleID = rolelist.roleId;
            DeleteRolesAsync(roleID, userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }
        /// <summary>
        /// Verify User access rights
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyUserAccessRights(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            getUserAccessRights(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }


        #endregion

        #region Zoom Preset API

        /// <summary>
        /// Create and verify zoom preset details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="presetName"></param>
        public void VerifyCreateZoomPreset(string userName, string password, string presetName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            CreateNewZoomPreset(userName, token, presetName);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }
        /// <summary>
        /// Verify zoom preset details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="presetName"></param>
        public void VerifyZoomPresetDetails(string userName, string password, string presetName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var presetList = getZoomPreset(userName, password, token);
            Assert.IsTrue(presetList.settings.Contains(presetName));
        }
        #endregion

        #region Map Settings API
        /// <summary>
        /// VerifyMapSettings Api
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        public void VerifyNewMapSettings(string userName, string password, string paramName, string value)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            CreateNewMapSetting(paramName, value, token);
            var mapSettings = getMapSettings(userName, password, token);
            switch (paramName)
            {
                case "W4_SHOW_VEHICLE_CLUSTERS":
                    Assert.AreEqual(value, mapSettings.W4_SHOW_VEHICLE_CLUSTERS);
                    break;
                case "W4_SHOW_LOCATIONS":
                    Assert.AreEqual(value, mapSettings.W4_SHOW_LOCATIONS);
                    break;
                case "W4_SHOW_LOCATION_LABELS":
                    Assert.AreEqual(value, mapSettings.W4_SHOW_LOCATION_LABELS);
                    break;
                case "W3_VEHICLE_LABEL_FIELD":
                    Assert.AreEqual(value, mapSettings.W3_VEHICLE_LABEL_FIELD);
                    break;
                case "W4_SHOW_VEHICLE_LABELS":
                    Assert.AreEqual(value, mapSettings.W4_SHOW_VEHICLE_LABELS);
                    break;
            }
            extent.SetStepStatusPass($"Verified that the response is success.");
        }


        #endregion

        #region Operational Hours API
        /// <summary>
        /// Creates and verifies the operational hour data
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="ohName"></param>
        public void VerifyNewOperationHours(string userName, string password, string ohName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var operationalHours = CreateNewOperationalHours(ohName, token);
            Assert.AreEqual(true, operationalHours.success);
            extent.SetStepStatusPass($"Verified that the response is success.");
            var operationalHoursList = getOperationalHoursAsync(token);
            foreach (var operationalHourList in operationalHoursList)
                if (operationalHourList.name.Trim() == ohName)
                {
                    Assert.AreEqual(true, operationalHourList.monday);
                    Assert.AreEqual(540, operationalHourList.mondayStart);
                    Assert.AreEqual(1080, operationalHourList.mondayStop);
                    Assert.AreEqual(false, operationalHourList.tuesday);
                    Assert.AreEqual(0, operationalHourList.tuesdayStart);
                    Assert.AreEqual(0, operationalHourList.tuesdayStop);
                    Assert.AreEqual(true, operationalHourList.wednesday);
                    Assert.AreEqual(540, operationalHourList.wednesdayStart);
                    Assert.AreEqual(1080, operationalHourList.wednesdayStop);
                    Assert.AreEqual(false, operationalHourList.thursday);
                    Assert.AreEqual(0, operationalHourList.thursdayStart);
                    Assert.AreEqual(0, operationalHourList.thursdayStop);
                    Assert.AreEqual(true, operationalHourList.friday);
                    Assert.AreEqual(540, operationalHourList.fridayStart);
                    Assert.AreEqual(1080, operationalHourList.fridayStop);
                    Assert.AreEqual(false, operationalHourList.saturday);
                    Assert.AreEqual(0, operationalHourList.saturdayStart);
                    Assert.AreEqual(0, operationalHourList.saturdayStop);
                    Assert.AreEqual(false, operationalHourList.sunday);
                    Assert.AreEqual(0, operationalHourList.sundayStart);
                    Assert.AreEqual(0, operationalHourList.sundayStop);
                    Assert.AreEqual("Test Automation description", operationalHourList.description);
                    Assert.AreEqual("(UTC+10:00) Eastern Australia Time (Sydney)", operationalHourList.timeZone);
                    extent.SetStepStatusPass($"Verified that the operational hour details are correct.");
                }
        }
        /// <summary>
        /// Edit operational Hours
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="ohName"></param>
        public void EditOperationalHoursByID(string userName, string password, string ohName)
        {
            int? id = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var operationalHoursList = getOperationalHoursAsync(token);
            foreach (var operationalHourList in operationalHoursList)
                if (operationalHourList.name.Trim() == ohName)
                    id = operationalHourList.opHoursId;
            var editOpHours = EditOperationalHours(ohName + " Edited", id.ToString(), token);
            Assert.AreEqual(true, editOpHours.success);
            extent.SetStepStatusPass($"Verified that the response is success.");
            var editoperationalHours = getOperationalHoursAsync(token);
            foreach (var editoperationalHour in editoperationalHours)
                if (editoperationalHour.name.Trim() == ohName + " Edited")
                {
                    Assert.AreEqual(false, editoperationalHour.monday);
                    Assert.AreEqual(0, editoperationalHour.mondayStart);
                    Assert.AreEqual(0, editoperationalHour.mondayStop);
                    Assert.AreEqual(true, editoperationalHour.tuesday);
                    Assert.AreEqual(540, editoperationalHour.tuesdayStart);
                    Assert.AreEqual(1080, editoperationalHour.tuesdayStop);
                    Assert.AreEqual(false, editoperationalHour.wednesday);
                    Assert.AreEqual(0, editoperationalHour.wednesdayStart);
                    Assert.AreEqual(0, editoperationalHour.wednesdayStop);
                    Assert.AreEqual(true, editoperationalHour.thursday);
                    Assert.AreEqual(540, editoperationalHour.thursdayStart);
                    Assert.AreEqual(1080, editoperationalHour.thursdayStop);
                    Assert.AreEqual(false, editoperationalHour.friday);
                    Assert.AreEqual(0, editoperationalHour.fridayStart);
                    Assert.AreEqual(0, editoperationalHour.fridayStop);
                    Assert.AreEqual(true, editoperationalHour.saturday);
                    Assert.AreEqual(540, editoperationalHour.saturdayStart);
                    Assert.AreEqual(1080, editoperationalHour.saturdayStop);
                    Assert.AreEqual(false, editoperationalHour.sunday);
                    Assert.AreEqual(0, editoperationalHour.sundayStart);
                    Assert.AreEqual(0, editoperationalHour.sundayStop);
                    Assert.AreEqual("Automation description Edited", editoperationalHour.description);
                    Assert.AreEqual("(UTC+09:30) Central Australia Time (Adelaide)", editoperationalHour.timeZone);
                    extent.SetStepStatusPass($"Verified that the edited operational hour details are correct.");
                }
        }
        /// <summary>
        /// Delete OperationalHours
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="ohName"></param>
        public void DeleteOperationalHours(string userName, string password, string ohName)
        {
            int? id = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var operationalHoursList = getOperationalHoursAsync(token);
            foreach (var operationalHourList in operationalHoursList)
                if (operationalHourList.name.Trim() == ohName)
                    id = operationalHourList.opHoursId;
            DeleteOperationalHoursByID(id.ToString(), token);
            extent.SetStepStatusPass($"Verified that the operational hours is deleted.");
        }



        #endregion

        #region Clients API
        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyCreateNewClient(string userName, string password, string clientName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails = CreateNewClient(token, clientName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(clientName, clientDetails.clientName);
            Assert.AreEqual(false, clientDetails.deleted);
            Assert.AreEqual(0, clientDetails.isAccountLocked);
            Assert.AreEqual("61132456", clientDetails.phone1);
            Assert.AreEqual("testclientAut" + DateTime.Now.ToString("dd") + "@gtail.com", clientDetails.email1);
            Assert.AreEqual("Test Auto notes", clientDetails.notes);
            Assert.AreEqual("Test", clientDetails.firstName);
            Assert.AreEqual("Automation", clientDetails.lastName);
            extent.SetStepStatusPass($"Verified that the client is created correctly");
        }
        /// <summary>
        /// VerifyCleint details by username
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyGetClientByUsername(string userName, string password, string clientName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail in clientDetails)
                if (clientDetail.clientName == clientName)

                {
                    Assert.AreEqual(clientName, clientDetail.clientName);
                    Assert.AreEqual(false, clientDetail.deleted);
                    Assert.AreEqual(0, clientDetail.isAccountLocked);
                    Assert.AreEqual("61132456", clientDetail.phone1);
                    Assert.AreEqual("testclientAut" + DateTime.Now.ToString("dd") + "@gtail.com", clientDetail.email1);
                    Assert.AreEqual("Test Auto notes", clientDetail.notes);
                    Assert.AreEqual("Test", clientDetail.firstName);
                    Assert.AreEqual("Automation", clientDetail.lastName);
                    Assert.AreEqual(242, clientDetail.clientRole);
                    Assert.AreEqual("Non-Admin", clientDetail.clientRoleName);
                    extent.SetStepStatusPass($"Verified that the Client details are correct");
                }
        }
        /// <summary>
        /// Verify client details grouped by id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyGetClientGroupedByClientId(string userName, string password, string clientName)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails1 = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail1 in clientDetails1)
                if (clientDetail1.clientName == clientName)
                    clientId = clientDetail1.clientId;

            var clientDetails = getClientVehicleDriverGrouped(clientId, token);
            Assert.AreEqual(clientId, clientDetails.clientId);
            Assert.AreEqual(clientName, clientDetails.clientName);
            Assert.AreEqual(false, clientDetails.deleted);
            Assert.AreEqual(0, clientDetails.isAccountLocked);
            Assert.AreEqual("61132456", clientDetails.phone1);
            Assert.AreEqual("testclientAut" + DateTime.Now.ToString("dd") + "@gtail.com", clientDetails.email1);
            Assert.AreEqual("Test Auto notes", clientDetails.notes);
            Assert.AreEqual("Test", clientDetails.firstName);
            Assert.AreEqual("Automation", clientDetails.lastName);
            Assert.AreEqual(242, clientDetails.clientRole);
            Assert.AreEqual("Non-Admin", clientDetails.clientRoleName);
            Assert.AreEqual("Test Automation", clientDetails.clientFullName);
            Assert.AreEqual(false, clientDetails.suppressAlarms);
            Assert.AreEqual(false, clientDetails.suppressAlarms);
            Assert.AreEqual(244, clientDetails.driversGrouped[0].groupId);
            Assert.AreEqual("AutoGroupDriver", clientDetails.driversGrouped[0].groupName);
            Assert.AreEqual(1, clientDetails.driversGrouped[0].driverCount);
            Assert.AreEqual(1, clientDetails.driversGrouped[0].driverTotalCount);
            Assert.AreEqual(77648, clientDetails.driversGrouped[0].drivers[0].driverId);
            Assert.AreEqual("Auto Driver", clientDetails.driversGrouped[0].drivers[0].shortName);
            Assert.AreEqual(388, clientDetails.vehiclesGrouped[0].groupId);
            Assert.AreEqual("AutomationGroup", clientDetails.vehiclesGrouped[0].groupName);
            Assert.AreEqual(1, clientDetails.vehiclesGrouped[0].unitCount);
            Assert.AreEqual(1, clientDetails.vehiclesGrouped[0].unitTotalCount);
            Assert.AreEqual(2727, clientDetails.vehiclesGrouped[0].units[0].unitId);
            Assert.AreEqual("AutoVehicle", clientDetails.vehiclesGrouped[0].units[0].unitName);
            extent.SetStepStatusPass($"Verified that the Client grouped details are correct");
        }
        /// <summary>
        /// VerifyEditClientDetails
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyEditClientDetails(string userName, string password, string clientName)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails1 = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail1 in clientDetails1)
                if (clientDetail1.clientName == clientName)
                    clientId = clientDetail1.clientId;
            var clientDetails = EditClient(token, clientId, clientName);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(clientName + "Edit", clientDetails.clientName);
            Assert.AreEqual(false, clientDetails.deleted);
            Assert.AreEqual(0, clientDetails.isAccountLocked);
            Assert.AreEqual("61222222", clientDetails.phone1);
            Assert.AreEqual("testclientAutEdit" + DateTime.Now.ToString("dd") + "@gtail.com", clientDetails.email1);
            Assert.AreEqual("Test Auto notes edited", clientDetails.notes);
            Assert.AreEqual("TestEdit", clientDetails.firstName);
            Assert.AreEqual("AutomationEdit", clientDetails.lastName);
            extent.SetStepStatusPass($"Verified that the client is updated correctly");
        }
        /// <summary>
        /// Update AlertsNotification
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyUpdateSignalRAlertsNotification(string userName, string password, string clientName)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails1 = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail1 in clientDetails1)
                if (clientDetail1.clientName == clientName)
                    clientId = clientDetail1.clientId;
            SuppressAlertsByClientId(token, clientId);
            extent.SetStepStatusPass($"Verified that the alerts notification is updated correctly");
        }
        /// <summary>
        /// Update alarms notification
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyUpdateSignalRAlarmsNotification(string userName, string password, string clientName)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails1 = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail1 in clientDetails1)
                if (clientDetail1.clientName == clientName)
                    clientId = clientDetail1.clientId;
            SuppressAlarmsByClientId(token, clientId);
            extent.SetStepStatusPass($"Verified that the alarms notification is updated correctly");
        }
        /// <summary>
        /// Update Account lock out
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyUpdateAccountLockout(string userName, string password, string clientName)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails1 = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail1 in clientDetails1)
                if (clientDetail1.clientName == clientName)
                    clientId = clientDetail1.clientId;
            UpdateAccountLockoutByClientId(token, clientId, 1);
            extent.SetStepStatusPass($"Verified that the account is locked out");
            UpdateAccountLockoutByClientId(token, clientId, 0);
            extent.SetStepStatusPass($"Verified that the account is activated again");
        }
        /// <summary>
        /// Verify Update Password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyUpdatePassword(string userName, string password, string newPassword)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            UpdatePasswordForLoggedinUser(token, newPassword);
            extent.SetStepStatusPass($"Verified that the password is updated");
            token = getBearerTokenAsync(userName, newPassword).Result.ToString().Replace("\"", "");
            UpdatePasswordForLoggedinUser(token, password);
            extent.SetStepStatusPass($"Verified that the password is updated back");

        }
        /// <summary>
        /// Verify Initial Script
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyInitialScript(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            InitialScriptRequest(token);
            extent.SetStepStatusPass($"Verified that the script is run");

        }
        /// <summary>
        /// Verify Client Details By ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyClientDetailsById(string userName, string password, string clientName)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails1 = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail1 in clientDetails1)
                if (clientDetail1.clientName == clientName)
                    clientId = clientDetail1.clientId;
            var clientDetails = GetClientDetailsByID(clientId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(clientId, clientDetails.clientId);
            Assert.AreEqual(clientName, clientDetails.clientName);
            Assert.AreEqual(false, clientDetails.deleted);
            Assert.AreEqual(0, clientDetails.isAccountLocked);
            Assert.AreEqual("61222222", clientDetails.phone1);
            Assert.AreEqual("testclientAutEdit" + DateTime.Now.ToString("dd") + "@gtail.com", clientDetails.email1);
            Assert.AreEqual("Test Auto notes edited", clientDetails.notes);
            Assert.AreEqual("TestEdit", clientDetails.firstName);
            Assert.AreEqual("AutomationEdit", clientDetails.lastName);
            extent.SetStepStatusPass($"Verified that the client details are correct");
        }
        /// <summary>
        /// Delete client by id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyDeleteClientById(string userName, string password, string clientName)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var clientDetails1 = getClientByUsername(userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var clientDetail1 in clientDetails1)
                if (clientDetail1.clientName == clientName)
                    clientId = clientDetail1.clientId;
            DeleteClientByID(token, clientId);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }

        #endregion

        #region UserSettings API
        /// <summary>
        /// Verify If user settings api response is correct
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyUserSettingsBySettingsName(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var userSettings = GetUserSettingsBySettingsName("W4_LAST_MAP_EXTENT", token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual("W4_LAST_MAP_EXTENT", userSettings.name);
            extent.SetStepStatusPass($"Verified that the api response is correct");
        }
        /// <summary>
        /// Verify Save user settings
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifySaveUserSettings(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            SaveUserSettings(token);
            extent.SetStepStatusPass($"Verified that the response is success.");
        }
        #endregion

        #region Trips API
        /// <summary>
        /// Verify Get Trips Details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyTripsForUser(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var tripDetails = GetTripList(userName, password, 3278, false, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.IsTrue(tripDetails.trips.Length != 0);
            extent.SetStepStatusPass($"Verified that the unassigned trips count is not 0.");
            var tripDetails2 = GetTripList(userName, password, 3278, true, token);
            Assert.IsTrue(tripDetails2.trips.Length != 0);
            extent.SetStepStatusPass($"Verified that the assigned trips count is not 0.");
        }
        /// <summary>
        /// Verify Trip Details By Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyTripsById(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var tripDetails = GetTripList(userName, password, 3278, false, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            int tripId = tripDetails.trips[0].tripId;
            var singleTripDetails = getSingleTripAsync(tripId, token, tripDetails.trips[0].startDate, tripDetails.trips[0].driverId);
            Assert.AreEqual(tripId, singleTripDetails.tripId);
            Assert.AreEqual(false, singleTripDetails.isBusiness);
            Assert.AreEqual(3278, singleTripDetails.unitId);
            Assert.AreEqual("3264AshleyUAT", singleTripDetails.unitName);
            var assignedTripDetails = GetTripList(userName, password, 3278, true, token);
            extent.SetStepStatusPass($"Verified that the trip details for unassigned trips are correct.");
            int tripId2 = assignedTripDetails.trips[0].tripId;
            var singleAssignedTripDetails = getSingleTripAsync(tripId2, token, assignedTripDetails.trips[0].startDate, assignedTripDetails.trips[0].driverId);
            Assert.AreEqual(tripId2, singleAssignedTripDetails.tripId);
            Assert.AreEqual(assignedTripDetails.trips[0].reason, singleAssignedTripDetails.reason);
            Assert.AreEqual(3278, singleAssignedTripDetails.unitId);
            Assert.AreEqual("3264AshleyUAT", singleAssignedTripDetails.unitName);
            extent.SetStepStatusPass($"Verified that the trip details for assigned trips are correct.");
        }
        /// <summary>
        /// Edit Single trip details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyEditSingleTripDetails(string userName, string password)
        {

            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var tripDetails = GetTripList(userName, password, 3278, false, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            int tripId = tripDetails.trips[0].tripId;
            var requestBody = new UpdateTripRequest();
            requestBody.tripId = tripId;
            requestBody.driverId = tripDetails.trips[0].driverId;
            requestBody.startDate = tripDetails.trips[0].startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ssZ");
            requestBody.endDate = tripDetails.trips[0].endDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ssZ");
            requestBody.isBusiness = true;
            requestBody.reason = "Customer visit";
            EditSingleTripDetails(token, requestBody);
            extent.SetStepStatusPass($"Verified that the trip details are edited.");
        }
        /// <summary>
        /// Update Multiple trip details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyEditMultipleTripDetails(string userName, string password, bool isAssigned)
        {

            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var tripDetails = GetTripList(userName, password, 3278, isAssigned, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            var requestBody1 = new UpdateTripRequest();
            var requestBody2 = new UpdateTripRequest();
            var requestBody = new UpdateTripRequest[2] { requestBody1, requestBody2 };
            requestBody1.tripId = tripDetails.trips[0].tripId; ;
            requestBody1.driverId = tripDetails.trips[0].driverId;
            requestBody1.startDate = tripDetails.trips[0].startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
            requestBody1.endDate = tripDetails.trips[0].endDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
            if (isAssigned == true)
            {
                requestBody1.isBusiness = false;
                requestBody1.reason = "Private";
            }
            else
            {
                requestBody1.isBusiness = true;
                requestBody1.reason = "Customer visit";
            }

            requestBody2.tripId = tripDetails.trips[1].tripId; ;
            requestBody2.driverId = tripDetails.trips[1].driverId;
            requestBody2.startDate = tripDetails.trips[1].startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
            requestBody2.endDate = tripDetails.trips[1].endDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
            if (isAssigned == true)
            {
                requestBody2.isBusiness = false;
                requestBody2.reason = "Private";
            }
            else
            {
                requestBody2.isBusiness = true;
                requestBody2.reason = "Customer visit";
            }
            EditMultipleTripDetails(token, requestBody);
            extent.SetStepStatusPass($"Verified that the trip details are edited.");
        }

        #endregion

        #region Services API
        /// <summary>
        /// Create new service
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clientName"></param>
        public void VerifyCreateNewService(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceDetails = CreateNewService(unitId, userName, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(unitId, serviceDetails.unitId);
            Assert.AreEqual(true, serviceDetails.success);
            extent.SetStepStatusPass($"Verified that the service is created correctly");
        }
        /// <summary>
        /// Get services by username and vehicle Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetServicesByUsername(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceDetails = GetServiceDetailsByUserName(userName, unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var serviceDetail in serviceDetails)
                if (serviceDetail.unitId == unitId)
                {
                    Assert.AreEqual(0, serviceDetail.serviceType);
                    Assert.AreEqual(1000.0, serviceDetail.cost);
                    Assert.AreEqual(4444, serviceDetail.odometer);
                    Assert.AreEqual("Test Automation notes", serviceDetail.notes);
                    Assert.AreEqual(12345, serviceDetail.engineHours);
                    Assert.AreEqual(1, serviceDetail.serviceCount);
                    extent.SetStepStatusPass($"Verified that the service details are correct");
                }
        }

        /// <summary>
        /// Verify LastService details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetLastServicesByVehicleId(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceDetails = GetLastServiceDetailsByID(unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var serviceDetail in serviceDetails)
                if (serviceDetail.unitId == unitId)
                {
                    Assert.AreEqual(0, serviceDetail.serviceType);
                    Assert.AreEqual(1000.0, serviceDetail.cost);
                    Assert.AreEqual(4444, serviceDetail.odometer);
                    Assert.AreEqual("Test Automation notes", serviceDetail.notes);
                    Assert.AreEqual(12345, serviceDetail.engineHours);
                    Assert.AreEqual(0, serviceDetail.serviceCount);
                    extent.SetStepStatusPass($"Verified that the service details are correct");
                }
        }
        /// <summary>
        /// VerifyEdit service details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyEditServiceDetails(string userName, string password, int unitId)
        {
            int serviceId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceDetails = GetServiceDetailsByUserName(userName, unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var serviceDetail in serviceDetails)
                if (serviceDetail.unitId == unitId)
                    serviceId = serviceDetail.serviceId;

            var editServiceDetails = EditServiceDetails(unitId, serviceId, userName, token);
            Assert.AreEqual(unitId, editServiceDetails.unitId);
            Assert.AreEqual(true, editServiceDetails.success);
            Assert.AreEqual(serviceId, editServiceDetails.serviceId);
            extent.SetStepStatusPass($"Verified that the service details are edited correctly");
        }
        /// <summary>
        /// Get service details by Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetServicesById(string userName, string password, int unitId)
        {
            int serviceId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceDetails = GetServiceDetailsByUserName(userName, unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var serviceDetail in serviceDetails)
                if (serviceDetail.unitId == unitId)
                    serviceId = serviceDetail.serviceId;

            var serviceById = GetServiceById(serviceId, userName, token);
            Assert.AreEqual(serviceId, serviceById.serviceId);
            Assert.AreEqual(unitId, serviceById.unitId);
            Assert.AreEqual(1, serviceById.serviceType);
            Assert.AreEqual(2000.0, serviceById.cost);
            Assert.AreEqual(5555, serviceById.odometer);
            Assert.AreEqual("Test Automation notes edited", serviceById.notes);
            Assert.AreEqual(54321, serviceById.engineHours);
            Assert.AreEqual(0, serviceById.serviceCount);
            extent.SetStepStatusPass($"Verified that the service details are correct");

        }
        /// <summary>
        /// Verify Service readings
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetServiceReading(string userName, string password, int unitId)
        {
            int serviceId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceDetails = GetServiceDetailsByUserName(userName, unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var serviceDetail in serviceDetails)
                if (serviceDetail.unitId == unitId)
                    serviceId = serviceDetail.serviceId;
            var serviceReading = GetServicereadingbyId(serviceId, token);
            Assert.AreEqual(serviceId, serviceReading.serviceId);
            Assert.AreEqual(5555, serviceReading.odometer);
            Assert.AreEqual(54321, serviceReading.engineHours);
            extent.SetStepStatusPass($"Verified that the service reading details are correct");

        }
        /// <summary>
        /// Verify delete services
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyDeleteServicesById(string userName, string password, int unitId)
        {
            int serviceId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceDetails = GetServiceDetailsByUserName(userName, unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            foreach (var serviceDetail in serviceDetails)
                if (serviceDetail.unitId == unitId)
                    serviceId = serviceDetail.serviceId;
            DeleteServicesByID(token, serviceId);
            extent.SetStepStatusPass($"Verified that the service is deleted.");

        }
        /// <summary>
        /// Verify Service types
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyGetServicesTypesByUsername(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceTypeDetails = GetServiceTypeByUserName(token);
            extent.SetStepStatusPass($"Verified that the response is success.");

            Assert.AreEqual(0, serviceTypeDetails[0].id);
            Assert.AreEqual("Major", serviceTypeDetails[0].serviceType);
            Assert.AreEqual(1, serviceTypeDetails[1].id);
            Assert.AreEqual("Normal", serviceTypeDetails[1].serviceType);
            Assert.AreEqual(2, serviceTypeDetails[2].id);
            Assert.AreEqual("Minor", serviceTypeDetails[2].serviceType);
            Assert.AreEqual(3, serviceTypeDetails[3].id);
            Assert.AreEqual("Unscheduled", serviceTypeDetails[3].serviceType);
            extent.SetStepStatusPass($"Verified that the service type details are correct");

        }

        #endregion

        #region ServiceSchedule

        /// <summary>
        /// Create new service schedule
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyUpdateServiceScheduleList(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var scheduleDetails = EditMultipleServiceScheduleDetails(token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(true, scheduleDetails[0].success);
            Assert.AreEqual(true, scheduleDetails[1].success);
            Assert.AreEqual(true, scheduleDetails[2].success);
            extent.SetStepStatusPass($"Verified that the schedule is created correctly");
        }
        /// <summary>
        /// Verify Service schedule details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        public void VerifyServiceScheduleDetails(string userName, string password, int unitId)
        {
            int clientId = 0;
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var serviceSchedule = GetServiceSchedulelist(unitId, token);
            extent.SetStepStatusPass($"Verified that the response is success.");
            Assert.AreEqual(474, serviceSchedule[0].contactId);
            Assert.AreEqual("Automation Group", serviceSchedule[0].contactName);
            Assert.AreEqual(true, serviceSchedule[0].enabled);
            Assert.AreEqual(20, serviceSchedule[0].interval);
            Assert.AreEqual(0, serviceSchedule[0].intervalEngineHours);
            Assert.AreEqual(1, serviceSchedule[0].intervalKm);
            Assert.AreEqual("Test Automation major", serviceSchedule[0].notes);
            Assert.AreEqual(2, serviceSchedule[0].reminder);
            Assert.AreEqual(0, serviceSchedule[0].reminderEngineHours);
            Assert.AreEqual(1, serviceSchedule[0].reminderKm);
            Assert.AreEqual(0, serviceSchedule[0].reminderSentEngineHours);
            Assert.AreEqual(506, serviceSchedule[0].scheduleId);
            Assert.AreEqual(1, serviceSchedule[0].serviceType);
            Assert.AreEqual(54321, serviceSchedule[0].startEngineHours);
            Assert.AreEqual(5555, serviceSchedule[0].startOdometer);
            Assert.AreEqual(10655, serviceSchedule[0].trackerId);

            Assert.AreEqual(474, serviceSchedule[1].contactId);
            Assert.AreEqual("Automation Group", serviceSchedule[1].contactName);
            Assert.AreEqual(true, serviceSchedule[1].enabled);
            Assert.AreEqual(30, serviceSchedule[1].interval);
            Assert.AreEqual(0, serviceSchedule[1].intervalEngineHours);
            Assert.AreEqual(2, serviceSchedule[1].intervalKm);
            Assert.AreEqual("Test Automation normal", serviceSchedule[1].notes);
            Assert.AreEqual(2, serviceSchedule[1].reminder);
            Assert.AreEqual(0, serviceSchedule[1].reminderEngineHours);
            Assert.AreEqual(1, serviceSchedule[1].reminderKm);
            Assert.AreEqual(0, serviceSchedule[1].reminderSentEngineHours);
            Assert.AreEqual(507, serviceSchedule[1].scheduleId);
            Assert.AreEqual(2, serviceSchedule[1].serviceType);
            Assert.AreEqual(54321, serviceSchedule[1].startEngineHours);
            Assert.AreEqual(5555, serviceSchedule[1].startOdometer);
            Assert.AreEqual(10655, serviceSchedule[1].trackerId);

            Assert.AreEqual(474, serviceSchedule[2].contactId);
            Assert.AreEqual("Automation Group", serviceSchedule[2].contactName);
            Assert.AreEqual(true, serviceSchedule[2].enabled);
            Assert.AreEqual(40, serviceSchedule[2].interval);
            Assert.AreEqual(0, serviceSchedule[2].intervalEngineHours);
            Assert.AreEqual(3, serviceSchedule[2].intervalKm);
            Assert.AreEqual("Test Automation minor", serviceSchedule[2].notes);
            Assert.AreEqual(2, serviceSchedule[2].reminder);
            Assert.AreEqual(0, serviceSchedule[2].reminderEngineHours);
            Assert.AreEqual(1, serviceSchedule[2].reminderKm);
            Assert.AreEqual(0, serviceSchedule[2].reminderSentEngineHours);
            Assert.AreEqual(508, serviceSchedule[2].scheduleId);
            Assert.AreEqual(3, serviceSchedule[2].serviceType);
            Assert.AreEqual(54321, serviceSchedule[2].startEngineHours);
            Assert.AreEqual(5555, serviceSchedule[2].startOdometer);
            Assert.AreEqual(10655, serviceSchedule[2].trackerId);


            extent.SetStepStatusPass($"Verified that the service schedule details are correct");
        }

        #endregion






        #endregion


    }
}
