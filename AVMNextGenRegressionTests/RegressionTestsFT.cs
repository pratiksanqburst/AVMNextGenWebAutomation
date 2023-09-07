using AVMNextGenWebAutomation.AVMNextGenAPI;
using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenRegressionTests
{
    [Category("RegressionFT")]
    public class RegressionTestsFT : AVMNextGenBase
    {
        #region Properties
        public Login login = new Login();
        public HomePage homePage = new HomePage();
        public ManageVehicles manageVehicles = new ManageVehicles();
        public ManageLocations manageLocations = new ManageLocations();
        public ManageServices manageServices = new ManageServices();
        public ManageContacts manageContacts = new ManageContacts();
        public ManageUsers manageUsers = new ManageUsers();
        public ManageDrivers manageDrivers = new ManageDrivers();
        public ManageRolesAndRights manageRolesAndRights = new ManageRolesAndRights();
        public ManageGlobalSettings manageGlobalSettings = new ManageGlobalSettings();
        public ManageFBT manageFBT = new ManageFBT();
        public FMReports fMReports = new FMReports();
        public static string date = DateTime.Now.AddDays(-1).Day.ToString();
        public static string dateValue = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Replace("-", "/") + " 12:30 AM";
        public string[] serviceDetails = { "AutoVehicle", date, "12", "30", "Minor", "1000", "12345", "10000", "Automation notes" };
        public string[] serviceDetailsVerification = { "AutoVehicle", dateValue, "Minor", "1000", "12345", "10000", "Automation notes" };
        public string contactGroup = "AutomationGroup" + DateTime.Now.ToString("dd");
        public static string contactName = "AutomationContact" + DateTime.Now.ToString("dd");
        public static string editContactName = "AutomationContact" + DateTime.Now.ToString("dd") + " edited";
        public static string editedContactGroup = "AutomationGroup" + DateTime.Now.ToString("dd") + " edited";
        public string[] contactDetails = { contactName, "1234567890", "FleetLiteAutomationContact@gmail.com" };
        public string[] contactDetailsVerification = { contactName, "+611234567890", "ENABLED", "FleetLiteAutomationContact@gmail.com", "ENABLED" };
        public string[] editContactDetails = { editContactName, "987654321", "FleetLiteAutomationContactEdited@gmail.com" };
        public string[] editContactDetailsVerification = { editContactName, "+61987654321", "DISABLED", "FleetLiteAutomationContactEdited@gmail.com", "DISABLED" };
        static string slotTimeName = "AutoTimeSlot" + DateTime.Now.ToString("dd");
        static string editedSlotTimeName = "TimeSlotEdit" + DateTime.Now.ToString("dd");
        string[] slotDetails = { slotTimeName, "(UTC+10:00) Papua New Guinea Time (Port Moresby)", "Test Description" };
        string[] dayDetails = { "Monday", "Sunday" };
        string[] timeDetails = { "09:30 - 22:30", "10:30 - 23:30" };
        string[] editedSlotDetails = { editedSlotTimeName, "(UTC) Coordinated Universal Time", "Test Description Edited" };
        string[] editedDayDetails = { "Tuesday", "Saturday" };

        #endregion

        #region Methods
        [Category("RegressionFTTest")]
        [Test, Order(1)]
        public void Test_001_Add_User()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.AddUser("Non-Admin");
        }
        [Category("RegressionFTTest")]
        [Test, Order(2)]
        public void Test_002_Verify_User_Details()
        {
            string[] userDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "Automation", "User", "Non-Admin", "1234567890", "NetStarFleetLiteAutomation@gmail.com" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyUserDetailsOnTable(userDetails);
        }
        [Test, Order(3)]
        public void Test_003_Verify_User_Details_RightPanel()
        {
            string[] userDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "Automation User", "Non-Admin", "NetStarFleetLiteAutomation@gmail.com", "(+61)1234567890", "AutoVehicle", "Test Automation Notes" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyManageUsersRightPanel(userDetails);
        }
        [Test, Order(4)]
        public void Test_004_Verify_Edit_User_Details()
        {
            string[] userDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy") + "Edited", "EditAutomation", "EditUser", "New role", "987654321", "NetStarFleetLiteAutomationedit@gmail.com" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.EditUser("AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "New role");
            manageUsers.VerifyUserDetailsOnTable(userDetails);
        }
        [Test, Order(4)]
        public void Test_004_Delete_User()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.DeleteUser("AutomationUser" + DateTime.Now.ToString("ddMMyyyy") + "Edited");
        }
        [Test, Order(5)]
        public void Test_005_Add_UserRole()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.AddNewRoles();
        }
        [Test, Order(6)]
        public void Test_006_VerifyRoleDetails()
        {
            string roleName = "AutoRole " + DateTime.Now.ToString("ddMMyyyy");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.SearchRolesByName(roleName);
        }
        [Test, Order(7)]
        public void Test_007_Edit_Roles()
        {
            string roleName = "AutoRole " + DateTime.Now.ToString("ddMMyyyy");
            string roleNameEdited = "AutoRole " + DateTime.Now.ToString("ddMMyyyy") + " Edited";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.SearchRolesByName(roleName);
            manageRolesAndRights.EditRoles(roleName);
            manageRolesAndRights.SearchRolesByName(roleNameEdited);
        }
        [Test, Order(8)]
        public void Test_008_Delete_Role()
        {
            string roleName = "AutoRole " + DateTime.Now.ToString("ddMMyyyy") + " Edited";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.SearchRolesByName(roleName);
            manageRolesAndRights.DeleteRole(roleName);
            manageRolesAndRights.SearchRolesByName(roleName, 0, false);
        }

        [Test, Order(9)]
        public void Test_009_Login_Validation()
        {
            login.LoginToAVMLite(userName, password);

        }
        [Category("RegressionFTTest")]
        [Test, Order(10)]
        public void Test_010_LeftMenu_HomePage()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.LeftMenuVerification();
        }
        [Test, Order(11)]
        public void Test_011_VehicleTree()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyVehicleTree(adminUser, adminPassword);
        }
        [Test, Order(12)]
        public void Test_012_VehicleRightPanel()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            //homePage.VerifyVehicleRightPanel("AutoVehicle", adminUser, adminPassword);
        }

        [Test, Order(13)]
        public void Test_013_CreateDriverGroup()
        {
            string groupName = "AutDriverGroup" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageDrivers.NavigateToManageDriver();
            manageDrivers.AddDriverGroup(groupName);
            manageDrivers.SearchDriverGroup(groupName);
        }

        [Test, Order(14)]
        public void Test_014_CreateNewDriver()
        {
            string groupName = "AutDriverGroup" + DateTime.Now.ToString("dd");
            string[] driverDetails = { "Automation", "Driver", "FleetLiteAutomationDriver@gmail.com","1234567890","Test Address","UID1234","Licence123" ,
            "LicenseStateTest", "Afghanistan","Male","O+","TestContact","TestRelation","876543212",DateTime.Now.AddDays(-3).ToString(),
            DateTime.Now.AddDays(-2).ToString(),DateTime.Now.AddDays(-10).ToString(),"AutoVehicle",groupName};
            string[] driverDetailsVerification = { "Automation Driver", "(+61)1234567890", groupName, "AutoVehicle" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageDrivers.NavigateToManageDriver();
            manageDrivers.SearchDriverGroup(groupName);
            manageDrivers.AddDriver(groupName, driverDetails);
            manageDrivers.VerifyDriverDetails(groupName, driverDetailsVerification);
        }
        [Test, Order(15)]
        public void Test_015_VerifyAddDriverGroupToUser()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.AddDriverGroupsToUser(adminUser, "Automation Driver");
        }

        [Test, Order(16)]
        public void Test_016_VerifyDriverNameForVehicle()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyVehicleRightPanel("AutoVehicle", adminUser, adminPassword);
        }

        [Test, Order(17)]
        public void Test_017_DriverTree()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyDriverTree(adminUser, adminPassword);
        }

        [Test, Order(18)]
        public void Test_018_DriverRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyDriverRightPanel("Automation Driver", adminUser, adminPassword);
        }

        [Test, Order(19)]
        public void Test_019_VerifyEditVehicle()
        {
            string[] vehicleDetails = { "AutoVehicleEdit", "2727", "TestManufaced", "2021", "RG1234", "TestTypeed",
                "ReqTestLicenseed", "VIN123ed", "EN123ed", "TestCated" };
            string[] vehicleDetailsVerification = { "AutoVehicleEdit", "2727", "AutomationGroup", "Automation Driver", "TestManufaced", "2021",
                "RG1234" };
            string[] vehicleDetailsReset = { "AutoVehicle", "2727", "TestManufac", "2022", "RG7357", "TestType",
                "ReqTestLicense", "VIN123", "EN123", "TestCat" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.SearchVehicleGroup("AutomationGroup", 1);
            manageVehicles.EditVehicleDetails("AutomationGroup", vehicleDetails);
            manageVehicles.VerifyVehicleDetails("AutomationGroup", vehicleDetailsVerification);
            homePage.NavigateToHomePage();
            homePage.VerifyVehicleTree(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.SearchVehicleGroup("AutomationGroup", 1);
            manageVehicles.EditVehicleDetails("AutomationGroup", vehicleDetailsReset);
        }
        [Test, Order(20)]
        public void Test_020_ManageVehicleRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.SearchVehicleGroup("AutomationGroup", 1);
            manageVehicles.VerifyManageVehicleRightPanel("AutomationGroup", 2727);
        }

        [Test, Order(21)]
        public void Test_021_CreateVehicleGroup()
        {
            string groupName = "AtmGrpName" + DateTime.Now.ToString("dd");
            string description = "Description text " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.CreateVehicleGroup(groupName, description);
        }
        [Test, Order(22)]
        public void Test_022_EditVehicleGroup()
        {
            string groupName = "AtmGrpName" + DateTime.Now.ToString("dd");
            string editedGroupName = "AtmGrpNameEdit" + DateTime.Now.ToString("dd");
            string editedDescription = "Description text Edited " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.SearchVehicleGroup(groupName, 0);
            manageVehicles.EditVehicleGroup(editedGroupName, editedDescription);
        }
        [Test, Order(23)]
        public void Test_023_ChangeVehicleGroup()
        {
            string editedGroupName = "AtmGrpNameEdit" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.VerifyChangeGroup("AutomationGroup", editedGroupName);
        }
        [Test, Order(24)]
        public void Test_024_VerifyRemoveVehicleGroup()
        {
            string editedGroupName = "AtmGrpNameEdit" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.VerifyRemoveGroup(editedGroupName);
        }
        [Test, Order(25)]
        public void Test_025_VerifyAssignVehicleGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.AssignVehicleToGroup("Ungrouped", "AutomationGroup", "AutoVehicle");
        }

        [Test, Order(26)]
        public void Test_026_DeleteVehicleGroup()
        {
            string groupName = "AtmGrpNameEdit" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.SearchVehicleGroup(groupName, 0);
            manageVehicles.DeleteVehicleGroup(groupName);
        }
        [Test, Order(27)]
        public void Test_027_Edit_Driver()
        {
            string groupName = "AutDriverGroup" + DateTime.Now.ToString("dd");
            string[] editDriverDetails = { "Auto", "DriverEdited", "FleetLiteAutomationDriveredited@gmail.com","987654331","Test Address edited","TestUId","321Licence" ,
            "Edited state", "Andorra","Female","B+","TestContactEdited","TestRelationEdited","1111111",DateTime.Now.AddDays(-5).ToString(),
             DateTime.Now.AddDays(-6).ToString(),DateTime.Now.AddDays(-15).ToString(),"AutoVehicle",groupName };
            string[] editDriverDetailsVerification = { "Auto DriverEdited", "(+61)987654331", groupName, "AutoVehicle" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageDrivers.NavigateToManageDriver();
            manageDrivers.EditDriver(groupName, editDriverDetails);
            manageDrivers.VerifyDriverDetails(groupName, editDriverDetailsVerification);
        }
        [Test, Order(28)]
        public void Test_028_Edit_DriverGroup()
        {
            string groupName = "AutDriverGroup" + DateTime.Now.ToString("dd");
            string editedDriverGroup = "AtmnGrp" + DateTime.Now.ToString("dd") + "edit";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageDrivers.NavigateToManageDriver();
            manageDrivers.SearchDriverGroup(groupName, 1);
            manageDrivers.EditDriverGroup(editedDriverGroup);
            manageDrivers.SearchDriverGroup(editedDriverGroup, 1);
            homePage.NavigateToHomePage();
            homePage.VerifyDriverTree(adminUser, adminPassword);
            //homePage.VerifyDriverRightPanel("Auto DriverEdited", adminUser, adminPassword);
        }
        [Test, Order(29)]
        public void Test_029_Delete_Driver()
        {
            string editedDriverGroup = "AtmnGrp" + DateTime.Now.ToString("dd") + "edit";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageDrivers.NavigateToManageDriver();
            manageDrivers.DeleteDriver(editedDriverGroup, 1);
        }
        [Test, Order(30)]
        public void Test_030_Delete_DriverGroup()
        {
            string editedDriverGroup = "AtmnGrp" + DateTime.Now.ToString("dd") + "edit";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageDrivers.NavigateToManageDriver();
            manageDrivers.DeleteDriverGroup(editedDriverGroup);
            manageDrivers.SearchDriverGroup(editedDriverGroup);
        }
        [Test, Order(31)]
        public void Test_031_CreateLocationGroup()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            string description = "Description text " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageLocations.NavigateToManageLocationGroups();
            manageLocations.CreateLocationGroup(groupName, description);
        }
        [Test, Order(32)]
        public void Test_032_SearchLocationGroup()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageLocations.NavigateToManageLocationGroups();
            manageLocations.SearchLocationGroupByName(groupName, 0);
        }
        [Test, Order(33)]
        public void Test_033_CreateLocation()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            string locName = "AutoLocName" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageLocations.CreateNewLocation(locName, groupName, "Default");
        }
        [Test, Order(34)]
        public void Test_034_EditLocationGroup()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            string editedGroupName = "AutoLocEdit" + DateTime.Now.ToString("dd");
            string editedDescription = "Description text Edited " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageLocations.NavigateToManageLocationGroups();
            manageLocations.SearchLocationGroupByName(groupName, 1);
            manageLocations.EditLocationGroup(editedGroupName, editedDescription);
        }
        [Test, Order(35)]
        public void Test_035_DeleteLocationGroup()
        {
            string groupName = "AutoLocEdit" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageLocations.NavigateToManageLocationGroups();
            manageLocations.DeleteLocationGroup(groupName);
        }
        [Test, Order(36)]
        public void Test_036_AddService()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
            manageServices.AddService(serviceDetails);
        }
        [Test, Order(37)]
        public void Test_037_VerifyServiceDetails()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
            manageServices.VerifyServiceDetails(serviceDetailsVerification);
        }
        [Test, Order(38)]
        public void Test_038_DeleteService()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
            manageServices.DeleteService("AutoVehicle");
        }
        [Test, Order(39)]
        public void Test_039_Add_ContactGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageContacts.NavigateToManageContacts();
            manageContacts.AddContactGroup(contactGroup);
            manageContacts.SearchContactGroup(contactGroup);
        }
        [Test, Order(40)]
        public void Test_040_Edit_ContactGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageContacts.NavigateToManageContacts();
            manageContacts.EditContactGroup(contactGroup);
            manageContacts.SearchContactGroup(editedContactGroup);
        }
        [Test, Order(41)]
        public void Test_041_Add_Contact()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageContacts.NavigateToManageContacts();
            manageContacts.AddContact(editedContactGroup, contactDetails);
            manageContacts.VerifyContactDetails(editedContactGroup, contactDetailsVerification);
        }
        [Test, Order(42)]
        public void Test_042_Edit_Contact()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageContacts.NavigateToManageContacts();
            manageContacts.EditContacts(editedContactGroup, editContactDetails);
            manageContacts.VerifyContactDetails(editedContactGroup, editContactDetailsVerification);
        }
        [Test, Order(43)]
        public void Test_043_Delete_Contact()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageContacts.NavigateToManageContacts();
            manageContacts.DeleteContact(editedContactGroup, editContactName);
        }
        [Test, Order(44)]
        public void Test_044_Delete_ContactGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageContacts.NavigateToManageContacts();
            manageContacts.DeleteContactGroup(editedContactGroup);
            manageContacts.SearchContactGroup(editedContactGroup);
        }

        [Test, Order(45)]
        public void Test_045_Add_TimeSlot()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageGlobalSettings.AddTimeSlot(slotTimeName);
            manageGlobalSettings.VerifyTimeSlot(slotDetails, dayDetails, timeDetails);
        }
        [Test, Order(46)]
        public void Test_046_Edit_TimeSlot()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageGlobalSettings.EditTimeSlot(slotTimeName, editedSlotTimeName);
            manageGlobalSettings.VerifyTimeSlot(editedSlotDetails, editedDayDetails, timeDetails);
        }

        [Test, Order(47)]
        public void Test_047_Delete_TimeSlot()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            manageGlobalSettings.DeleteTimeSlot(editedSlotTimeName);
        }
        [Test, Order(48)]
        public void Test_048_VehicleHistory()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyVehicleHistory("FleetNavTestSim10605");
        }
        [Test, Order(49)]
        public void Test_049_FindNowVehiclesDrivers()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyFindNowVehicles("AutoVehicle");
            homePage.VerifyFindNowDrivers("Test AutoDriver");
        }
        [Test, Order(50)]
        public void Test_050_FindNowAlertsAndAlarms()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.EditOperationalHours("AutoGrp2", "TestSan");
            homePage.NavigateToHomePage();
            homePage.VerifyFindNowAlerts("MdtSimLite");
            homePage.VerifyFindNowAlarms("MdtSimLite");
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.EditOperationalHours("AutoGrp2", "Select Any");
        }
        [Test, Order(51)]
        public void Test_051_VerifyMapDownload()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifySaveScreenShot("CaptureMap");
        }
        [Test, Order(52)]
        public void Test_052_VerifyMapSettinsSecondaryLabel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyMapSettingsLabel(adminUser, adminPassword);
        }
        [Test, Order(53)]
        public void Test_053_VerifyUnassignedTripDetails()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.VerifyTripDetails("Brad Test", adminDev, adminDevPassword, 3282, false);
        }
        [Test, Order(54)]
        public void Test_054_VerifyAssignedTripDetails()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.VerifyTripDetails("Brad Test", adminDev, adminDevPassword, 3282, true);
        }
        [Test, Order(55)]
        public void Test_055_VerifyUnassignedRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.VerifyRightPanel("Brad Test", adminDev, adminDevPassword, 3282, false);
        }
        [Test, Order(56)]
        public void Test_056_VerifyAssignedRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.VerifyRightPanel("Brad Test", adminDev, adminDevPassword, 3282, true);
        }
        [Test, Order(57)]
        public void Test_057_VerifyAssignTripsFromTop()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.AssignTrip("Brad Test", adminDev, adminDevPassword, 3282, false);
        }
        [Test, Order(58)]
        public void Test_058_VerifyEditTripsFromTop()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.AssignTrip("Brad Test", adminDev, adminDevPassword, 3282, true);
        }
        [Test, Order(59)]
        public void Test_059_VerifyAssignTripsFromRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.AssignFromRightPanel("Brad Test", adminDev, adminDevPassword, 3282, false);
        }
        [Test, Order(60)]
        public void Test_060_VerifyEditTripsFromRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageFBT.NavigateToManageFBT();
            manageFBT.AssignFromRightPanel("Brad Test", adminDev, adminDevPassword, 3282, true);
        }

        [Test, Order(61)]
        public void Test_061_VerifyReportsLandingPage()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            fMReports.VerifyReportsLandingPage();
        }
        [Test, Order(62)]
        public void Test_062_VerifyDriverBehaviourGenerate()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
        }
        [Test, Order(63)]
        public void Test_063_VerifyDriverBehaviourGenerateDriver()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "Testdriver 1", startDate, endDate, "Eastern Australia",false);
        }

        [Test, Order(64)]
        public void Test_064_VerifyDriverBehaviourReportContent()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            DriverBehaviourRequestBody requestBody = new DriverBehaviourRequestBody();
            requestBody.reportType = 22;
            requestBody.reportName = "Driver Behaviour";
            requestBody.startTime = DateTime.Today.AddDays(-10).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 0;
            requestBody.sortColumn = "";
            requestBody.searchText = "";
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.VerifyDriverBehaviourReportDetails(requestBody, adminUser, adminPassword);
        }
        [Test, Order(65)]
        public void Test_065_VerifyDriverBehaviourReportSort()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            DriverBehaviourRequestBody requestBody = new DriverBehaviourRequestBody();
            requestBody.reportType = 22;
            requestBody.reportName = "Driver Behaviour";
            requestBody.startTime = DateTime.Today.AddDays(-10).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = "";
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.DriverBehaviourSort();
            fMReports.VerifyDriverBehaviourReportDetails(requestBody, adminUser, adminPassword);
        }
        [Test, Order(66)]
        public void Test_066_VerifyDriverBehaviourReportSearch()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            DriverBehaviourRequestBody requestBody = new DriverBehaviourRequestBody();
            requestBody.reportType = 22;
            requestBody.reportName = "Driver Behaviour";
            requestBody.startTime = DateTime.Today.AddDays(-10).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 0;
            requestBody.sortColumn = "";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.ReportSearch(keyword);
            fMReports.VerifyDriverBehaviourReportDetails(requestBody, adminUser, adminPassword);
        }
        [Test, Order(67)]
        public void Test_067_VerifyDriverBehaviourReportSearchandSort()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            DriverBehaviourRequestBody requestBody = new DriverBehaviourRequestBody();
            requestBody.reportType = 22;
            requestBody.reportName = "Driver Behaviour";
            requestBody.startTime = DateTime.Today.AddDays(-10).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.ReportSearch(keyword);
            fMReports.DriverBehaviourSort();
            fMReports.VerifyDriverBehaviourReportDetails(requestBody, adminUser, adminPassword);
        }

        [Test, Order(68)]
        public void Test_068_VerifyDriverBehaviourReportDownload()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            fMReports.ReportSearch(keyword);
            fMReports.DriverBehaviourSort();
            Thread.Sleep(3000);
            fMReports.DownloadReport("export_Driver Behaviour Report");
        }

        [Test, Order(69)]
        public void Test_069_VerifyDriverBehaviourReportSchedule()
        {
            string keyword = "MDT Tester";
            string[] scheduleValues = new[] { "AutoSchDB", "Driver Behaviour", "Daily", "PDF", "", DateTime.Now.AddDays(1).ToString("dd'/'MM'/'yyyy") + " 06:30 AM", adminUser, "Sandeep Contact Group" };
            string[] scheduleValuesRightPanel = new[] { "AutoSchDB", "Daily", "Active", "PDF", "06:30 AM", "Previous Day", "Sandeep Contact Group", "Test automation notes" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Driver Behaviour", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            fMReports.ReportSearch(keyword);
            fMReports.DriverBehaviourSort();
            Thread.Sleep(3000);
            fMReports.CreateSchedule("AutoSchDB","Previous day","Pdf");
            fMReports.VerifyScheduleDetails(scheduleValues);
            fMReports.ScheduleRightPanel(scheduleValuesRightPanel, false);
            fMReports.DBReportPanel("Driver Behaviour", "MDT Tester 18_SS");
        }

        [Test, Order(70)]
        public void Test_070_VerifyDriverBehaviourReportRunNowFromKebabMenu()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DriverBehaviourRequestBody requestBody = new DriverBehaviourRequestBody();
            requestBody.reportType = 22;
            requestBody.reportName = "Driver Behaviour";
            requestBody.startTime = DateTime.Today.AddDays(-1).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddDays(-1).AddHours(23).AddMinutes(59).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            int count= fMReports.ReportResultCountDB(requestBody, adminUser, adminPassword);
            fMReports.NavigateToViewSchedules();
            fMReports.VerifyRunSchedule("AutoSchDB", count);
            fMReports.EditScheduleReport("AutoSchDB","Daily","Excel",true);
            fMReports.VerifyRunSchedule("AutoSchDB", count);
            fMReports.EditScheduleReport("AutoSchDB", "Daily", "CSV", true);
            fMReports.VerifyRunSchedule("AutoSchDB", count);

        }
        [Test, Order(71)]
        public void Test_071_VerifyDriverBehaviourReportRunNowFromRightPanel()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DriverBehaviourRequestBody requestBody = new DriverBehaviourRequestBody();
            requestBody.reportType = 22;
            requestBody.reportName = "Driver Behaviour";
            requestBody.startTime = DateTime.Today.AddDays(-1).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddDays(-1).AddHours(23).AddMinutes(59).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            int count = fMReports.ReportResultCountDB(requestBody, adminUser, adminPassword);
            fMReports.NavigateToViewSchedules();
            fMReports.EditScheduleReport("AutoSchDB", "Daily", "PDF", true);
            fMReports.VerifyRunSchedule("AutoSchDB", count, false);
            fMReports.EditScheduleReport("AutoSchDB", "Daily", "Excel", true);
            fMReports.VerifyRunSchedule("AutoSchDB", count, false);
            fMReports.EditScheduleReport("AutoSchDB", "Daily", "CSV", true);
            fMReports.VerifyRunSchedule("AutoSchDB", count, false);
        }
        [Test, Order(72)]
        public void Test_072_VerifyDriverBehaviourReportEditSchedule()
        {
            string[] scheduleValues = new[] { "AutoSchDBEdit", "Driver Behaviour", "Daily", "PDF", "", DateTime.Now.AddDays(1).ToString("dd'/'MM'/'yyyy") + " 10:30 AM", adminUser, "AutoContactGrp" };
            string[] scheduleValuesRightPanel = new[] { "AutoSchDBEdit", "Daily", "Active", "PDF", "10:30 AM", "Current Day", "AutoContactGrp", "Test automation notes Edited" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            fMReports.NavigateToViewSchedules();
            fMReports.EditScheduleReport("AutoSchDB", "Current Day", "PDF");
            fMReports.VerifyScheduleDetails(scheduleValues, false);
            fMReports.ScheduleRightPanel(scheduleValuesRightPanel, false);
        }
        [Test, Order(73)]
        public void Test_073_VerifyDriverBehaviourPauseRestartSchedule()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            fMReports.NavigateToViewSchedules();
            fMReports.VerifyPauseSchedule("AutoSchDBEdit");
            fMReports.VerifyRestartSchedule("AutoSchDBEdit");
            fMReports.VerifyPauseSchedule("AutoSchDBEdit", false);
            fMReports.VerifyRestartSchedule("AutoSchDBEdit", false);
        }

        [Test, Order(74)]
        public void Test_074_VerifyDriverBehaviourReportDelete()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            fMReports.NavigateToViewSchedules();
            fMReports.DeleteScheduleReport("AutoSchDBEdit");
        }


        [Test, Order(75)]
        public void Test_075_VerifySALGenerate()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
        }
        [Test, Order(76)]
        public void Test_076_VerifySALGenerateDriver()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "Testdriver 1", startDate, endDate, "Eastern Australia", false);
        }

        [Test, Order(77)]
        public void Test_077_VerifySALReportContent()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            SALRequestBody requestBody = new SALRequestBody();
            requestBody.reportType = 4;
            requestBody.reportName = "Stopped at Location";
            requestBody.startTime = DateTime.Today.AddDays(-30).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 0;
            requestBody.sortColumn = "";
            requestBody.searchText = "";
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.VerifySALReportDetails(requestBody, adminUser, adminPassword);
        }
        [Test, Order(78)]
        public void Test_078_VerifySALReportSort()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            SALRequestBody requestBody = new SALRequestBody();
            requestBody.reportType = 4;
            requestBody.reportName = "Stopped at Location";
            requestBody.startTime = DateTime.Today.AddDays(-30).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = "";
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.DriverBehaviourSort();
            fMReports.VerifySALReportDetails(requestBody, adminUser, adminPassword);
        }
        [Test, Order(79)]
        public void Test_079_VerifySALReportSearch()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            SALRequestBody requestBody = new SALRequestBody();
            requestBody.reportType = 4;
            requestBody.reportName = "Stopped at Location";
            requestBody.startTime = DateTime.Today.AddDays(-30).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 0;
            requestBody.sortColumn = "";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.ReportSearch(keyword);
            fMReports.VerifySALReportDetails(requestBody, adminUser, adminPassword);
        }
        [Test, Order(80)]
        public void Test_080_VerifySALReportSearchandSort()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            SALRequestBody requestBody = new SALRequestBody();
            requestBody.reportType = 4;
            requestBody.reportName = "Stopped at Location";
            requestBody.startTime = DateTime.Today.AddDays(-30).AddHours(6).AddMinutes(30).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddHours(22).AddMinutes(30).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            fMReports.ReportSearch(keyword);
            fMReports.DriverBehaviourSort();
            fMReports.VerifySALReportDetails(requestBody, adminUser, adminPassword);
        }

        [Test, Order(81)]
        public void Test_081_VerifySALReportDownload()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            fMReports.ReportSearch(keyword);
            fMReports.DriverBehaviourSort();
            Thread.Sleep(3000);
            fMReports.DownloadReport("StoppedAtLocationReport");
        }

        [Test, Order(82)]
        public void Test_082_VerifySALReportSchedule()
        {
            string keyword = "MDT Tester";
            string[] scheduleValues = new[] { "AutoSchSAL", "Stopped at Location", "Daily", "PDF", "", DateTime.Now.AddDays(1).ToString("dd'/'MM'/'yyyy") + " 06:30 AM", adminUser, "Sandeep Contact Group" };
            string[] scheduleValuesRightPanel = new[] { "AutoSchSAL", "Daily", "Active", "PDF", "06:30 AM", "Previous Day", "Sandeep Contact Group", "Test automation notes" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Stopped at Location", "MDT Tester 18_SS", startDate, endDate, "Eastern Australia");
            fMReports.ReportSearch(keyword);
            fMReports.DriverBehaviourSort();
            Thread.Sleep(3000);
            fMReports.CreateSchedule("AutoSchSAL", "Previous day", "Pdf");
            fMReports.VerifyScheduleDetails(scheduleValues);
            fMReports.ScheduleRightPanel(scheduleValuesRightPanel, false);
            
        }

        [Test, Order(83)]
        public void Test_083_VerifySALReportRunNowFromKebabMenu()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            SALRequestBody requestBody = new SALRequestBody();
            requestBody.reportType = 4;
            requestBody.reportName = "Stopped at Location";
            requestBody.startTime = DateTime.Today.AddDays(-1).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddDays(-1).AddHours(23).AddMinutes(59).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            int count = fMReports.ReportResultCountDB(requestBody, adminUser, adminPassword);
            fMReports.NavigateToViewSchedules();
            fMReports.VerifyRunSchedule("AutoSchSAL", count);
            fMReports.EditScheduleReport("AutoSchSAL", "Daily", "Excel", true);
            fMReports.VerifyRunSchedule("AutoSchSAL", count);
            fMReports.EditScheduleReport("AutoSchSAL", "Daily", "CSV", true);
            fMReports.VerifyRunSchedule("AutoSchSAL", count);

        }
        [Test, Order(84)]
        public void Test_084_VerifySALRunNowFromRightPanel()
        {
            string keyword = "MDT Tester 18";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            SALRequestBody requestBody = new SALRequestBody();
            requestBody.reportType = 4;
            requestBody.reportName = "Stopped at Location";
            requestBody.startTime = DateTime.Today.AddDays(-1).ToUniversalTime();
            requestBody.stopTime = DateTime.Today.AddDays(-1).AddHours(23).AddMinutes(59).ToUniversalTime();
            requestBody.selectedTimeZone = "Australia/Melbourne";
            requestBody.reportBy = 0;
            requestBody.pageSize = 25;
            requestBody.pageNumber = 1;
            requestBody.sortOrder = 1;
            requestBody.sortColumn = "Date";
            requestBody.searchText = keyword;
            requestBody.browserOffset = -5.5;
            requestBody.selectedIds = new int[] { 34 };
            requestBody.pageState = "";
            requestBody.reportSubType = 0;
            int count = fMReports.ReportResultCountDB(requestBody, adminUser, adminPassword);
            fMReports.NavigateToViewSchedules();
            fMReports.EditScheduleReport("AutoSchSAL", "Daily", "PDF", true);
            fMReports.VerifyRunSchedule("AutoSchSAL", count, false);
            fMReports.EditScheduleReport("AutoSchSAL", "Daily", "Excel", true);
            fMReports.VerifyRunSchedule("AutoSchSAL", count, false);
            fMReports.EditScheduleReport("AutoSchSAL", "Daily", "CSV", true);
            fMReports.VerifyRunSchedule("AutoSchSAL", count, false);
        }
        [Test, Order(85)]
        public void Test_085_VerifySALReportEditSchedule()
        {
            string[] scheduleValues = new[] { "AutoSchSALEdit", "Stopped at Location", "Daily", "PDF", "", DateTime.Now.AddDays(1).ToString("dd'/'MM'/'yyyy") + " 10:30 AM", adminUser, "AutoContactGrp" };
            string[] scheduleValuesRightPanel = new[] { "AutoSchSALEdit", "Daily", "Active", "PDF", "10:30 AM", "Current Day", "AutoContactGrp", "Test automation notes Edited" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            fMReports.NavigateToViewSchedules();
            fMReports.EditScheduleReport("AutoSchSAL", "Current Day", "PDF");
            fMReports.VerifyScheduleDetails(scheduleValues, false);
            fMReports.ScheduleRightPanel(scheduleValuesRightPanel, false);
        }
        [Test, Order(86)]
        public void Test_086_VerifySALPauseRestartSchedule()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            fMReports.NavigateToViewSchedules();
            fMReports.VerifyPauseSchedule("AutoSchSALEdit");
            fMReports.VerifyRestartSchedule("AutoSchSALEdit");
            fMReports.VerifyPauseSchedule("AutoSchSALEdit", false);
            fMReports.VerifyRestartSchedule("AutoSchSALEdit", false);
        }

        [Test, Order(87)]
        public void Test_087_VerifySALReportDelete()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            fMReports.NavigateToViewSchedules();
            fMReports.DeleteScheduleReport("AutoSchSALEdit");
        }





























        [Test, Order(90)]
        public void Test_090_VerifySpeedingReportGenerate()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            fMReports.NavigateToReportsPage();
            DateTime startDate = DateTime.Now.AddDays(-90);
            DateTime endDate = DateTime.Now;
            fMReports.GenerateReport("Speeding", "Tracker 2", startDate, endDate, "Eastern Australia");
        }
        #endregion
    }
}
