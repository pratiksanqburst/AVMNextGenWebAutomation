using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("HomePage")]
    public class Test_HomePage : HomePage
    {

        #region Properties
        public Login login;
        public ManageVehicles manageVehicles = new ManageVehicles();
        #endregion

        [Test, Order(1)]
        public void Test_LeftMenu_HomePage()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            LeftMenuVerification();
        }
        [Test, Order(2)]
        public void Test_VehicleTree()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyVehicleTree(adminUser, adminPassword);
        }
        [Test, Order(3)]
        public void Test_DriverTree()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyDriverTree(adminUser, adminPassword);
        }
        [Test, Order(4)]
        public void Test_AlarmTree()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyAlarmTree(adminUser, adminPassword);
        }
        [Test, Order(5)]
        public void Test_AlertTree()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyAlertTree(adminUser, adminPassword);
        }
        [Test, Order(6)]
        public void Test_LocationTree()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyLocationTree(adminUser, adminPassword);
        }
        [Test, Order(7)]
        public void Test_VehicleRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyVehicleRightPanel("AutoVehicle", adminUser, adminPassword);
        }
        [Test, Order(8)]
        public void Test_DriverRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyDriverRightPanel("Test USer", adminUser, adminPassword);
        }
        [Test, Order(9)]
        public void Test_LocationRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyLocationRightPanel(adminUser, adminPassword);
        }
        [Test, Order(10)]
        public void Test_AlarmRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyAlarmRightPanel(adminUser, adminPassword,"");
        }
        [Test, Order(11)]
        public void Test_AlertRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyAlertRightPanel(adminUser, adminPassword,"");
        }
        [Test, Order(12)]
        public void Test_VehicleHistory()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyVehicleHistory("FleetNavTestSim10605");
        }
        [Test, Order(12)]
        public void Test_FindNowVehiclesDrivers()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyFindNowVehicles("AutoVehicle");
            VerifyFindNowDrivers("Auto Driver");
        }
        [Test, Order(13)]
        public void Test_FindNowAlertsAndAlarms()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.EditOperationalHours("AutoGrp2", "TestSan");
            NavigateToHomePage();
            VerifyFindNowAlerts("MdtSimLite");
            VerifyFindNowAlarms("MdtSimLite");
            manageVehicles.NavigateToManageVehicles();
            manageVehicles.EditOperationalHours("AutoGrp2", "Select Any");
        }
        [Test, Order(14)]
        public void Test_VerifyMapDownload()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifySaveScreenShot("CaptureMap");
        }
        [Test, Order(15)]
        public void Test_VerifyMapSettinsSecondaryLabel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            VerifyMapSettingsLabel(adminUser, adminPassword);
        }
    }
}
