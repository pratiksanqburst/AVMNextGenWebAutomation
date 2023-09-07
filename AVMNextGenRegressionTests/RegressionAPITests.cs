using AVMNextGenWebAutomation.AVMNextGenAPI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenRegressionTests
{
    [Category("API Regression")]
    public class RegressionAPITests : APIBaseTest
    {
        [Test, Order(1)]
        public void Test_001_GetAlarmsByUserName()
        {
            VerifyAlarmsByUserNameAPI(adminDev, adminDevPassword);
        }

        [Test, Order(2)]
        public void Test_002_ClearAlarms()
        {
            ClearAlarm(adminDev, adminDevPassword);
        }

        [Test, Order(3)]
        public void Test_003_GetAlertsByUserName()
        {
            VerifyAlertsByUserNameAPI(adminUser, adminPassword);
        }
        [Test, Order(4)]
        public void Test_004_GetAlertsByID()
        {
            VerifyAlertsByAlertID(adminUser, adminPassword);
        }
        [Test, Order(5)]
        public void Test_005_GetVehicleTreeByUserName()
        {
            VerifyVehiclesByUserNameAPI(adminUser, adminPassword);
        }
        [Test, Order(6)]
        public void Test_006_GetVehicleTreeBySearchKey()
        {
            VerifyVehiclesBySearchKeyword(adminUser, adminPassword, "AutoVehicle");
        }
        [Test, Order(7)]
        public void Test_007_GetVehicleTreeGroupedBySearchKey()
        {
            VerifyVehiclesGroupedBySearchKeyword(adminUser, adminPassword, "AutoVehicle");
        }
        [Test, Order(8)]
        public void Test_008_GetVehicleStatusByUserName()
        {
            VerifyVehicleStatusByUserName(adminUser, adminPassword, 2727, 0);
        }

        [Test, Order(9)]
        public void Test_009_CreateNewContactGroup()
        {
            VerifyContactGroups(adminUser, adminPassword, "AutoContact" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(10)]
        public void Test_010_VerifyContactGroupUsageDetails()
        {
            VerifyContactGroupUsage(adminUser, adminPassword, "AutoContact" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(11)]
        public void Test_011_DeleteContactGroupUsageDetails()
        {
            DeleteContactGroupUsage(adminUser, adminPassword, "AutoContact" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(12)]
        public void Test_012_EditContactGroup()
        {
            VerifyEditContactGroupById(adminUser, adminPassword, "AutoContact" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(13)]
        public void Test_013_DeleteContactGroup()
        {
            VerifyDeleteContactGroupById(adminUser, adminPassword, "AutoContact" + DateTime.Now.ToString("dd") + "Edited");
        }
        [Test, Order(14)]
        public void Test_014_CreateNewRole()
        {
            VerifyCreateNewRole(adminUser, adminPassword, "AutoRole" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(15)]
        public void Test_015_VerifyNewRoleDetails()
        {
            VerifyRoleDetails(adminUser, adminPassword, "AutoRole" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(16)]
        public void Test_016_VerifyEditRolesByName()
        {
            VerifyEditRolesByName(adminUser, adminPassword, "AutoRole" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(17)]
        public void Test_017_VerifyEditRolesByRights()
        {
            VerifyEditRolesByRights(adminUser, adminPassword, "AutoRole" + DateTime.Now.ToString("dd") + " Edited");
        }
        [Test, Order(18)]
        public void Test_018_VerifyEditRolesDetails()
        {
            verifyEditedRoleDetails(adminUser, adminPassword, "AutoRole" + DateTime.Now.ToString("dd") + " Edited");
        }
        [Test, Order(19)]
        public void Test_019_VerifyDeleteRoles()
        {
            VerifyDeleteRolesById(adminUser, adminPassword, "AutoRole" + DateTime.Now.ToString("dd") + " Edited");
        }
        [Test, Order(20)]
        public void Test_020_VerifyAccessRights()
        {
            VerifyUserAccessRights(adminUser, adminPassword);
        }
        [Test, Order(21)]
        public void Test_021_VerifyCreateZoomPreset()
        {
            VerifyCreateZoomPreset(adminUser, adminPassword, "AutoPreset" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(22)]
        public void Test_022_VerifyZoomPresetDetails()
        {
            VerifyZoomPresetDetails(adminUser, adminPassword, "AutoPreset" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(23)]
        public void Test_023_VerifyMapSettingsAPIShowVehicle()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W4_SHOW_VEHICLE_LABELS", "True");
        }
        [Test, Order(24)]
        public void Test_024_VerifyMapSettingsAPILabelFieldFleet()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W3_VEHICLE_LABEL_FIELD", "fleetid,name");
        }
        [Test, Order(25)]
        public void Test_025_VerifyMapSettingsAPILabelFieldRegistration()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W3_VEHICLE_LABEL_FIELD", "registration,name");
        }
        [Test, Order(26)]
        public void Test_026_VerifyMapSettingsAPILabelFieldDriver()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W3_VEHICLE_LABEL_FIELD", "drivername,name");
        }
        [Test, Order(27)]
        public void Test_027_VerifyMapSettingsAPILabelFieldVehicle()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W3_VEHICLE_LABEL_FIELD", "vehicleid,name");
        }
        [Test, Order(28)]
        public void Test_028_VerifyMapSettingsAPIShowLocations()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W4_SHOW_LOCATIONS", "True");
        }
        [Test, Order(29)]
        public void Test_029_VerifyMapSettingsAPIShowLocationsLabels()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W4_SHOW_LOCATION_LABELS", "True");
        }
        [Test, Order(30)]
        public void Test_030_VerifyMapSettingsAPIShowVehicleClusters()
        {
            VerifyNewMapSettings(adminUser, adminPassword, "W4_SHOW_VEHICLE_CLUSTERS", "False");
        }
        [Test, Order(31)]
        public void Test_031_VerifyNewOperationalHourDetails()
        {
            VerifyNewOperationHours(adminUser, adminPassword, "AutoOH" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(32)]
        public void Test_032_VerifyEditOperationalHourDetails()
        {
            EditOperationalHoursByID(adminUser, adminPassword, "AutoOH" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(33)]
        public void Test_033_VerifyDeleteOperationalHourDetails()
        {
            DeleteOperationalHours(adminUser, adminPassword, "AutoOH" + DateTime.Now.ToString("dd") + " Edited");
        }
        [Test, Order(34)]
        public void Test_034_CreateNewVehicleGroup()
        {
            VerifyCreateVehicleGroup(adminUser, adminPassword, "AutoVehGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(35)]
        public void Test_035_EditVehicleGroup()
        {
            VerifyEditVehicleGroupById(adminUser, adminPassword, "AutoVehGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(36)]
        public void Test_036_VerifyVehicleGroupById()
        {
            VerifyVehicleGroupById(adminUser, adminPassword, "AutoVehGrp" + DateTime.Now.ToString("dd") + "Edited");
        }
        [Test, Order(37)]
        public void Test_037_DeleteVehicleGroup()
        {
            VerifyDeleteVehicleGroupById(adminUser, adminPassword, "AutoVehGrp" + DateTime.Now.ToString("dd") + "Edited");
        }
        [Test, Order(38)]
        public void Test_038_CreateDriverGroup()
        {
            VerifyCreateDriverGroup(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(39)]
        public void Test_039_GetDriverGroupDetailsByUsername()
        {
            VerifyDriverGroupByUser(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(40)]
        public void Test_040_VerifyCreateNewDriver()
        {
            VerifyCreateDriver(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(41)]
        public void Test_041_VerifyDriverDetailsBySearchKey()
        {
            VerifyDriverInfobySearchKey(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "Test AutoDriver");
        }
        [Test, Order(42)]
        public void Test_042_VerifyDriverGroupedDetailsBySearchKey()
        {
            VerifyDriverGroupedInfobySearchKey(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "Test AutoDriver");
        }
        [Test, Order(43)]
        public void Test_043_VerifyDriverDetailsByGroupId()
        {
            VerifyDriverInfobyGroupId(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "Test AutoDriver");
        }
        [Test, Order(44)]
        public void Test_044_VerifyAssignUnassignVehicle()
        {
            VerifyAssignUnassignvehicle(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "Test AutoDriver");
        }
        [Test, Order(45)]
        public void Test_045_VerifyEditDriver()
        {
            VerifyEditDriver(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "Test AutoDriver");
        }
        [Test, Order(46)]
        public void Test_046_VerifyDriverById()
        {
            VerifyDriverInfoId(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "TestEdit AutoDriverEdit");
        }
        [Test, Order(47)]
        public void Test_047_VerifyAssignDriverToGrp()
        {
            VerifyAssignDriverToGroup(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "TestEdit AutoDriverEdit");
        }
        [Test, Order(48)]
        public void Test_048_VerifyDeleteDriver()
        {
            VerifyDeleteDriverById(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"), "TestEdit AutoDriverEdit");
        }
        [Test, Order(49)]
        public void Test_049_VerifyEditDriverGroup()
        {
            VerifyEditDriverGroup(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(50)]
        public void Test_050_VerifyDriverGroupbyId()
        {
            VerifyDriverGroupById(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd") + "Edited");
        }
        [Test, Order(51)]
        public void Test_051_VerifyDeleteDriverGroupbyId()
        {
            VerifyDeleteDriverGroupById(adminUser, adminPassword, "AutoDriveGrp" + DateTime.Now.ToString("dd") + "Edited");
        }
        [Test, Order(52)]
        public void Test_052_VerifyCreateNewClient()
        {
            VerifyCreateNewClient(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(53)]
        public void Test_053_VerifyClientDetailsByUserName()
        {
            VerifyGetClientByUsername(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(54)]
        public void Test_054_VerifyClientDetailsGroupedById()
        {
            VerifyGetClientGroupedByClientId(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(55)]
        public void Test_055_VerifyEditClientDetails()
        {
            VerifyEditClientDetails(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(56)]
        public void Test_056_VerifyUpdateAlertsNotification()
        {
            VerifyUpdateSignalRAlertsNotification(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd") + "Edit");
        }
        [Test, Order(57)]
        public void Test_057_VerifyUpdateAlarmsNotification()
        {
            VerifyUpdateSignalRAlarmsNotification(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd") + "Edit");
        }
        [Test, Order(58)]
        public void Test_058_VerifyAccountLockoutDetails()
        {
            VerifyUpdateAccountLockout(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd") + "Edit");
        }
        [Test, Order(59)]
        public void Test_059_VerifyUpdatePasswordDetails()
        {
            VerifyUpdatePassword("Testautomationuser", "Test@v1", "Test@v2");
        }
        [Test, Order(60)]
        public void Test_060_VerifyUpdateInitialScripts()
        {
            VerifyInitialScript("Testautomationuser", "Test@v1");
        }
        [Test, Order(61)]
        public void Test_061_VerifyClientDetailsById()
        {
            VerifyClientDetailsById(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd") + "Edit");
        }
        [Test, Order(62)]
        public void Test_062_VerifyDeleteClientById()
        {
            VerifyDeleteClientById(adminUser, adminPassword, "AutoClient" + DateTime.Now.ToString("dd") + "Edit");
        }
        [Test, Order(63)]
        public void Test_063_VerifyUserSettingsByUserName()
        {
            VerifyUserSettingsBySettingsName(adminUser, adminPassword);
        }
        [Test, Order(64)]
        public void Test_064_VerifySaveUserSettings()
        {
            VerifySaveUserSettings(adminUser, adminPassword);
        }
        [Test, Order(65)]
        public void Test_065_VerifyGetTripDetailsByVehicleId()
        {
            VerifyTripsForUser(adminDev, adminDevPassword);
        }
        [Test, Order(66)]
        public void Test_066_VerifyGetTripDetailsByTripId()
        {
            VerifyTripsById(adminDev, adminDevPassword);
        }
        [Test, Order(67)]
        public void Test_067_VerifyEditTripDetailsByTripId()
        {
            VerifyEditSingleTripDetails(adminDev, adminDevPassword);
        }
        [Test, Order(68)]
        public void Test_068_VerifyEditMultipleAssignedTripDetailsByTripId()
        {
            VerifyEditMultipleTripDetails(adminDev, adminDevPassword, true);
        }
        [Test, Order(69)]
        public void Test_069_VerifyEditMultipleUnAssignedTripDetailsByTripId()
        {
            VerifyEditMultipleTripDetails(adminDev, adminDevPassword, false);
        }
        [Test, Order(70)]
        public void Test_070_VerifyCreateNewService()
        {
            VerifyCreateNewService(adminUser, adminPassword, 2727);
        }
        [Test, Order(71)]
        public void Test_071_VerifyServiceDetailsByUserName()
        {
            VerifyGetServicesByUsername(adminUser, adminPassword, 2727);
        }
        [Test, Order(72)]
        public void Test_072_VerifyLastServiceDetailsByVehicleId()
        {
            VerifyGetLastServicesByVehicleId(adminUser, adminPassword, 2727);
        }
        [Test, Order(73)]
        public void Test_073_VerifyEditServiceDetails()
        {
            VerifyEditServiceDetails(adminUser, adminPassword, 2727);
        }
        [Test, Order(74)]
        public void Test_074_VerifyServiceDetailsById()
        {
            VerifyGetServicesById(adminUser, adminPassword, 2727);
        }
        [Test, Order(75)]
        public void Test_075_VerifyServiceReadingDetailsById()
        {
            VerifyGetServiceReading(adminUser, adminPassword, 2727);
        }

        [Test, Order(76)]
        public void Test_076_VerifyDeleteServiceDetailsById()
        {
            VerifyDeleteServicesById(adminUser, adminPassword, 2727);
        }
        [Test, Order(77)]
        public void Test_077_VerifyServiceTypeDetailsById()
        {
            VerifyGetServicesTypesByUsername(adminUser, adminPassword);
        }
        [Test, Order(78)]
        public void Test_078_VerifyUpdateServiceSchedule()
        {
            VerifyUpdateServiceScheduleList(adminDev, adminDevPassword);
        }
        [Test, Order(79)]
        public void Test_079_VerifyServiceScheduleDetails()
        {
            VerifyServiceScheduleDetails(adminDev, adminDevPassword, 3014);
        }






        [Test, Order(80)]
        public void Test_080_CreateLocationType()
        {
            VerifyCreateLocationType(adminUser, adminPassword, "AutoLocType" + DateTime.Now.ToString("dd"));
        }

        [Test, Order(81)]
        public void Test_081_GetLocationTypes()
        {
            VerifyLocationsTypesByUser(adminUser, adminPassword, "AutoLocType" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(82)]
        public void Test_082_GetLocationTypesByPage()
        {
            VerifyLocationsTypesByPage(adminUser, adminPassword, "AutoLocType" + DateTime.Now.ToString("dd"));
        }

        [Test, Order(83)]
        public void Test_083_GetLocationTypesIcons()
        {
            VerifyLocationsTypeIcons(adminUser, adminPassword);
        }

        [Test, Order(84)]
        public void Test_084_CreateLocationGroups()
        {
            VerifyCreateLocationGroup(adminUser, adminPassword, "AutoLocGrp" + DateTime.Now.ToString("dd"));
        }

        [Test, Order(85)]
        public void Test_085_GetLocationGroups()
        {
            VerifyLocationsGroupByUser(adminUser, adminPassword, "AutoLocGrp" + DateTime.Now.ToString("dd"));
        }

        [Test, Order(86)]
        public void Test_086_CreateNewLocation()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyCreateNewLocation(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }
        [Test, Order(87)]
        public void Test_087_VerifyLocationDetails()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyLocationsByUser(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }
        [Test, Order(88)]
        public void Test_088_VerifyLocationDetailsBySearchKey()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyLocationsBySearchKey(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }

        [Test, Order(89)]
        public void Test_089_VerifyLocationGroupedDetailsBySearchKey()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyLocationsGroupedBySearchKey(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }
        [Test, Order(90)]
        public void Test_090_VerifyLocationGroupedWithFeatures()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyLocationsGroupedWithFeatureDetails(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }
        [Test, Order(91)]
        public void Test_091_VerifyLocationDetailsByGroupId()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyLocationsByGroupId(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }
        [Test, Order(92)]
        public void Test_092_VerifyLocationDetailsByGroupAndPagination()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyLocationsByGroupIdandPagination(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }

        [Test, Order(93)]
        public void Test_093_VerifyAddOrRemoveLocationFromGroup()
        {
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd"); ;

            VerifyAssignRemoveLocationstoGroup(adminUser, adminPassword, locGroupName, locName);
        }

        [Test, Order(94)]
        public void Test_094_VerifyEditLocations()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd");

            VerifyEditLocations(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }
        [Test, Order(95)]
        public void Test_095_VerifyLocationsDetailsById()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd") + "Edit";

            VerifyLocationsById(adminUser, adminPassword, locTypeName, locGroupName, locName);
        }
        [Test, Order(96)]
        public void Test_096_VerifyMultipleLocationDelete()
        {
            string locTypeName = "AutoLocType" + DateTime.Now.ToString("dd");
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");

            VerifyMultipleDeleteLocation(adminUser, adminPassword, locTypeName, locGroupName);
        }

        [Test, Order(97)]
        public void Test_097_VerifyLocationDelete()
        {
            string locGroupName = "AutoLocGrp" + DateTime.Now.ToString("dd");
            string locName = "AutoLoc" + DateTime.Now.ToString("dd") + "Edit";
            VerifyDeleteLocation(adminUser, adminPassword, locGroupName, locName);
        }

        [Test, Order(98)]
        public void Test_098_GetLocationGroupsByGroupId()
        {
            VerifyLocationsGroupById(adminUser, adminPassword, "AutoLocGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(99)]
        public void Test_099_EditLocationGroupsByGroupId()
        {
            VerifyEditLocationsGroupById(adminUser, adminPassword, "AutoLocGrp" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(100)]
        public void Test_100_DeleteLocationGroupsByGroupId()
        {
            VerifyDeleteLocationsGroupById(adminUser, adminPassword, "AutoLocGrp" + DateTime.Now.ToString("dd") + "Edited");
        }

        [Test, Order(101)]
        public void Test_101_EditLocationTypesByTypeId()
        {
            VerifyEditLocationsTypeById(adminUser, adminPassword, "AutoLocType" + DateTime.Now.ToString("dd"));
        }
        [Test, Order(102)]
        public void Test_102_GetLocationTypesByTypeId()
        {
            VerifyLocationsTypesById(adminUser, adminPassword, "AutoLocType" + DateTime.Now.ToString("dd") + "Edited");
        }
        [Test, Order(103)]
        public void Test_103_DeleteLocationTypesByTypeId()
        {
            VerifyDeleteLocationType(adminUser, adminPassword, "AutoLocType" + DateTime.Now.ToString("dd") + "Edited");
        }
        [Test, Order(104)]
        public void Test_104_VerifyEditVehicle()
        {
            VerifyEditVehicleDetails(adminUser, adminPassword, 2727);
        }

        [Test, Order(105)]
        public void Test_105_VerifyVehicleDetailsByUnitId()
        {
            VerifyGetVehiclesByUnitId(adminUser, adminPassword, 2727);
        }
        [Test, Order(106)]
        public void Test_106_VerifyVehicleDetailsByUnitId()
        {
            VerifyGetOperatingHours(adminUser, adminPassword);
        }
        [Test, Order(107)]
        public void Test_107_VerifyOdoAndEnginehours()
        {
            VerifyGetOdoAndEngineHours(adminUser, adminPassword, 2444);
        }
        [Test, Order(108)]
        public void Test_108_VerifyAddorRemoveVehicle()
        {
            VerifyAssignRemoveVehicletoGroup(adminUser, adminPassword, 388, 2727);
        }
        [Test, Order(109)]
        public void Test_109_VerifyVehicleContacts()
        {
            VerifyGetVehicleContactDetails(adminUser, adminPassword);
        }
        [Test, Order(110)]
        public void Test_110_VerifyVehicleContactsByUnitId()
        {
            VerifyGetVehicleContactDetailsByUnitId(adminUser, adminPassword, 2727);
        }
        [Test, Order(111)]
        public void Test_111_VerifyEditVehicleContactsByUnitId()
        {
            VerifyEditVehicleContactDetailsByUnitId(adminUser, adminPassword, 2727,470,"AutomationGroup");
        }
        [Test, Order(112)]
        public void Test_112_VerifyVehiclesFindNowByUnitId()
        {
            VerifyVehicleFindNowByUnitId(adminUser, adminPassword, 2727);
        }
        [Test, Order(113)]
        public void Test_113_VerifyVehiclesVehicleHistoryDetails()
        {
            VerifyVehiclesHistory(adminUser, adminPassword, 2620);
        }

        [Test, Order(114)]
        public void Test_114_VerifyVehiclesVehicleAlertsDetails()
        {
            VerifyVehiclesAlerts(adminUser, adminPassword, 2727);
        }
        [Test, Order(115)]
        public void Test_115_VerifyDeleteAlertDetails()
        {
            DeleteAlertDetails(adminUser, adminPassword);
        }


    }
}
