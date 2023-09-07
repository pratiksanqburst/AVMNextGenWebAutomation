using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenRegressionTests
{
    [Category("RegressionFM")]
    public class RegressionTestsFM : AVMNextGenBase
    {
        #region Properties
        public Login login = new Login();
        public FMHomePage fmHomePage= new FMHomePage();
        #endregion
        [Test, Order(1)]
        public void Test_001_Login_Validation()
        {
            login.LoginToAVMLite(userNameFM, passwordFM,true);

        }
        [Test, Order(2)]
        public void Test_002_LeftMenu_HomePage()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.LeftMenuVerification();
        }
        [Test, Order(3)]
        public void Test_003_VehicleTree()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyVehicleTree(adminUser, adminPassword);
        }
        [Test, Order(4)]
        public void Test_004_VehicleTelemetryPopup()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyVehicleTelemetry(userNameFM, userNameFM,"MDT Tester 17_SS");
        }
        [Test, Order(5)]
        public void Test_005_VehicleRightPanel()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyVehicleRightPanel(userNameFM, userNameFM, "MDT Tester 17_SS");
        }

        [Test, Order(6)]
        public void Test_006_DriverTree()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyDriverTree(userNameFM, passwordFM, "Sandeep Tester");
        }
        [Test, Order(7)]
        public void Test_007_DriverTelemetryPopup()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyDriverTelemetry(userNameFM, passwordFM, "MDT Tester 17_SS");
        }
        [Test, Order(8)]
        public void Test_008_DriverRightPanel()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyDriverRightPanel(userNameFM, passwordFM, "MDT Tester 17_SS");
        }
        [Test, Order(9)]
        public void Test_009_DriverListView()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyDriverListView(userNameFM, passwordFM, "MDT Tester 17_SS");
        }
        [Test, Order(10)]
        public void Test_010_DriverRightPanelListView()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyDriverRightPanelListView(userNameFM, passwordFM, "MDT Tester 17_SS");
        }
        [Test, Order(11)]
        public void Test_011_AlertTree()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlertTree(userNameFM, passwordFM);
        }
        [Test, Order(12)]
        public void Test_012_AlertTelemetryPopup()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlertTelemetry(userNameFM, passwordFM);
        }
        [Test, Order(13)]
        public void Test_013_AlertRightPanel()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlertRightPanel(userNameFM, passwordFM);
        }
        [Test, Order(14)]
        public void Test_014_AlertListView()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlertListView(userNameFM, passwordFM);
        }
        [Test, Order(15)]
        public void Test_015_AlertRightPanelListView()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlertRightPanelListView(userNameFM, passwordFM);
        }

        [Test, Order(16)]
        public void Test_016_AlarmTree()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlarmTree(userNameFM, passwordFM);
        }
        [Test, Order(17)]
        public void Test_017_AlarmTelemetryPopup()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlarmTelemetry(userNameFM, passwordFM);
        }
        [Test, Order(18)]
        public void Test_018_AlarmRightPanel()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlarmRightPanel(userNameFM, passwordFM);
        }
        [Test, Order(19)]
        public void Test_019_AlarmListView()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlarmListView(userNameFM, passwordFM);
        }
        [Test, Order(20)]
        public void Test_020_AlarmRightPanelListView()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyAlarmRightPanelListView(userNameFM, passwordFM);
        }
        [Test, Order(21)]
        public void Test_021_LocationTree()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyLocationTree(userNameFM, passwordFM);
        }
        [Test, Order(22)]
        public void Test_022_LocationTelemetryPopup()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyLocationTelemetry(userNameFM, passwordFM);
        }
        [Test, Order(23)]
        public void Test_023_LocationRightPanel()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyLocationRightPanel(userNameFM, passwordFM);
        }

        [Test, Order(24)]
        public void Test_024_LocationListView()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyLocationListView(userNameFM, passwordFM);
        }

        [Test, Order(25)]
        public void Test_025_LocationListViewRightPanel()
        {
            login.LoginToAVMLite(userNameFM, passwordFM, true);
            fmHomePage.VerifyLocationRightPanelListView(userNameFM, passwordFM);
        }






        




    }


}
