using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVMNextGenWebAutomation.AVMNextGenAPI;
using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using AVMNextGenWebAutomation.RegressionTestData;
using NUnit.Framework;

namespace AVMNextGenWebAutomation.AVMNextGenRegressionTests
{
    [Category("FTRegression")]
    public class FTRegression : AVMNextGenBase
    {
        #region Properties
        public Login login = new Login(driver);
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
        public RegTestData regTestData = new RegTestData();

        #endregion

        [Test, Order(1)]
        public void Test_001_Add_User()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.AddUser(regTestData.userDetails[3]);
        }

        [Test, Order(2)]
        public void Test_002_Verify_User_Details()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyUserDetailsOnTable(regTestData.userDetails);
        }

        [Test, Order(3)]
        public void Test_003_Verify_User_Details_RightPanel()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyManageUsersRightPanel(regTestData.userDetailsRightPanel);
        }

        [Test, Order(4)]
        public void Test_004_Verify_Edit_User_Details()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.EditUser(regTestData.userDetails[0], regTestData.editUserDetails[3]);
            manageUsers.VerifyUserDetailsOnTable(regTestData.editUserDetails);
        }
        [Test, Order(5)]
        public void Test_005_Verify_Reset_Password()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyUsersResetPassword(regTestData.editUserDetails);
        }
        [Test, Order(6)]
        public void Test_006_Verify_User_AccountLock()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyUsersLockAccount(regTestData.editUserDetails);
        }
        [Test, Order(7)]
        public void Test_007_Verify_Edit_User_Redirection()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyUsersRightPanelEditRedirection(regTestData.editUserDetails);
        }
        [Test, Order(8)]
        public void Test_008_Verify_Delete_User_Redirection()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyUsersRightPanelDeleteRedirection(regTestData.editUserDetails);
        }
        [Test, Order(9)]
        public void Test_009_Verify_User_Supress_Notification()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.VerifyUsersRightPanelSuppressNotifications(regTestData.editUserDetails);
        }
        [Test, Order(10)]
        public void Test_010_Verify_Delete_User()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageUsers.NavigateToManageUsers();
            manageUsers.DeleteUser(regTestData.editUserDetails[0]);
        }
        [Test, Order(11)]
        public void Test_011_Verify_Add_User_Role()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.AddNewRoles();
        }
        [Test, Order(12)]
        public void Test_012_VerifyRoleDetails()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.SearchRolesByName(regTestData.roleName);
        }
        [Test, Order(13)]
        public void Test_013_Edit_Roles()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.SearchRolesByName(regTestData.roleName);
            manageRolesAndRights.EditRoles(regTestData.roleName);
            manageRolesAndRights.SearchRolesByName(regTestData.roleNameEdited);
        }

        [Test, Order(14)]
        public void Test_014_Delete_Role()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageRolesAndRights.NavigateToManageRoles();
            manageRolesAndRights.SearchRolesByName(regTestData.roleNameEdited);
            manageRolesAndRights.DeleteRole(regTestData.roleNameEdited);
        }
        [Test, Order(15)]
        public void Test_015_Login_Validation()
        {
            login.LoginToAVMLite(userName, password);
        }
        [Test, Order(16)]
        public void Test_016_ForgotPassword_Validation()
        {
            login.VerifyForgotPassword(regTestData.forgotUserName);
        }
        [Test, Order(17)]
        public void Test_017_ChangePassword()
        {
            login.LoginToAVMLite(regTestData.forgotUserName, regTestData.UserNameChangePassword);
            login.VerifyChangePassword(regTestData.UserNameChangePassword2);
            login.LoginToAVMLite(regTestData.forgotUserName, regTestData.UserNameChangePassword2);
            login.VerifyChangePassword(regTestData.UserNameChangePassword);
        }
        [Test, Order(18)]
        public void Test_018_LeftMenu_HomePage()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.LeftMenuVerification();
        }
        [Test, Order(19)]
        public void Test_019_VehicleTree()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyVehicleTree(adminUser, adminPassword);
        }
        [Test, Order(20)]
        public void Test_020_VehicleRightPanel()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyVehicleRightPanel(regTestData.VehicleName, adminUser, adminPassword);
        }
        [Test, Order(21)]
        public void Test_021_VehicleTelemetry()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyVehicleTelemetry(adminUser, adminPassword, regTestData.VehicleName);
        }
        [Test, Order(22)]
        public void Test_022_VehicleRightPanelRedirection()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyVehicleRightPanelRedirection(regTestData.VehicleName, adminUser, adminPassword);
        }
        [Test, Order(23)]
        public void Test_023_DriverTree()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyDriverTree(adminUser, adminPassword);
        }
        [Test, Order(24)]
        public void Test_024_DriverRightPanel()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyDriverRightPanel(regTestData.DriverName, adminUser, adminPassword);
        }
        [Test, Order(25)]
        public void Test_025_DriverTelemetry()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyDriverTelemetry(adminUser, adminPassword, regTestData.DriverName);
        }
        [Test, Order(26)]
        public void Test_026_DriverRightPanelRedirection()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyDriverRightPanelRedirection(regTestData.DriverName, adminUser, adminPassword);
        }
        [Test, Order(27)]
        public void Test_027_LocationTree()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyLocationTree(adminUser, adminPassword);
        }
        [Test, Order(28)]
        public void Test_028_LocationRightPanel()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyLocationRightPanel(adminUser, adminPassword);
        }
        [Test, Order(29)]
        public void Test_029_LocationRightPanelRedirection()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyLocationRightPanelRedirection(adminUser, adminPassword);
        }
        [Test, Order(30)]
        public void Test_030_AlarmTree()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlarmTree(adminUser, adminPassword);
        }
        [Test, Order(31)]
        public void Test_031_AlarmRightPanel()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlarmRightPanel(adminUser, adminPassword, regTestData.VehicleName);
        }
        [Test, Order(32)]
        public void Test_032_AlarmTelemetry()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlarmTelemetry(adminUser, adminPassword, regTestData.VehicleName);
        }
        [Test, Order(33)]
        public void Test_033_AlarmRightPanelRedirection()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlarmRightPanelRedirection(adminUser, adminPassword, regTestData.VehicleName);
        }
        [Test, Order(34)]
        public void Test_034_AlertTree()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlertTree(adminUser, adminPassword);
        }
        [Test, Order(35)]
        public void Test_035_AlertRightPanel()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlertRightPanel(adminUser, adminPassword, regTestData.VehicleName);
        }
        [Test, Order(36)]
        public void Test_036_AlertTelemetry()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlertTelemetry(adminUser, adminPassword, regTestData.VehicleName);
        }
        [Test, Order(37)]
        public void Test_037_AlertRightPanelRedirection()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            homePage.VerifyAlertRightPanelRedirection(adminUser, adminPassword, regTestData.VehicleName);
        }
        [Test, Order(38)]
        public void Test_038_AddService()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
            manageServices.AddService(regTestData.serviceDetails);
        }
        [Test, Order(39)]
        public void Test_039_VerifyServiceDetails()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
            manageServices.VerifyServiceDetails(regTestData.serviceDetailsVerification);
        }
        [Test, Order(40)]
        public void Test_040_VerifyEditService()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
            manageServices.EditService(regTestData.editServiceDetails);
            manageServices.VerifyServiceDetails(regTestData.editServiceDetailsVerification);
        }
        [Test, Order(41)]
        public void Test_041_VerifyDeleteService()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
            manageServices.DeleteService(regTestData.VehicleName);
        }
        [Test, Order(42)]
        public void Test_042_VerifyServiceScheduleMajor()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
        [Test, Order(43)]
        public void Test_043_VerifyServiceScheduleMajorReminder()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
        [Test, Order(44)]
        public void Test_044_VerifyServiceScheduleNormal()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
        [Test, Order(45)]
        public void Test_045_VerifyServiceScheduleNormalReminder()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
        [Test, Order(46)]
        public void Test_046_VerifyServiceScheduleMinor()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
        [Test, Order(47)]
        public void Test_047_VerifyServiceScheduleMinorReminder()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
        [Test, Order(48)]
        public void Test_048_VerifyServiceToggleOFF()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
        [Test, Order(49)]
        public void Test_049_VerifyServiceScheduleReminderAbsent()
        {
            login.LoginToAVMLite(adminUser, adminPassword);
            manageServices.NavigateToManageServices();
        }
    }
}
