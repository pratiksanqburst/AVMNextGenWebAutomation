using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageDrivers")]
    public class Test_ManageDrivers: ManageDrivers
    {
        #region Properties
        public Login login;
        public string driverGroup = "AtmnDriverGroup" + DateTime.Now.ToString("dd");
        public static string editContactName = "AutomationDriver" + DateTime.Now.ToString("dd") + " edited";
        public static string editedDriverGroup = "AtmDriverGrp" + DateTime.Now.ToString("dd") + "edit";
        public string[] driverDetails = { "Automation", "Driver", "FleetLiteAutomationDriver@gmail.com","1234567890","Test Address","UID1234","Licence123" ,
            "LicenseStateTest", "Afghanistan","Male","O+","TestContact","TestRelation","876543212",DateTime.Now.AddDays(3).ToString(),
            DateTime.Now.AddDays(-2).ToString(),DateTime.Now.AddDays(-10).ToString(),"AutoVehicle",editedDriverGroup};
        public string[] driverDetailsVerification = { "Automation Driver", "1234567890", editedDriverGroup, "AutoVehicle"};
        public string[] editDriverDetails = { "Auto", "DriverEdited", "FleetLiteAutomationDriveredited@gmail.com","0987654331","Test Address edited","TestUId","321Licence" ,
            "Edited state", "Andorra","Female","B+","TestContactEdited","TestRelationEdited","1111111",DateTime.Now.AddDays(5).ToString(),
            DateTime.Now.AddDays(-6).ToString(),DateTime.Now.AddDays(-15).ToString(),"AutoVehicle",editedDriverGroup };
        public string[] editDriverDetailsVerification = { "Auto DriverEdited", "987654331", editedDriverGroup, "AutoVehicle" };
        public string[] driverRightPanelVerification = { "Automation Driver","AutoVehicle",editedDriverGroup, "FleetLiteAutomationDriver@gmail.com","1234567890","Test Address","UID1234","0","Licence123" ,
           DateTime.Now.AddDays(3).ToString("dd'/'MM'/'yyyy"), "LicenseStateTest",DateTime.Now.AddDays(-2).ToString("dd'/'MM'/'yyyy")};

        #endregion

        [Test, Order(1)]
        public void Test_Add_DriverGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageDriver();
            AddDriverGroup(driverGroup);
            SearchDriverGroup(driverGroup);
        }
        [Test, Order(2)]
        public void Test_Edit_DriverGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageDriver();
            SearchDriverGroup(driverGroup);
            EditDriverGroup(editedDriverGroup);
            SearchDriverGroup(editedDriverGroup);
        }
        [Test, Order(3)]
        public void Test_Add_Driver()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageDriver();
            AddDriver(editedDriverGroup, driverDetails);
            VerifyDriverDetails(editedDriverGroup, driverDetailsVerification);
        }
        [Test, Order(4)]
        public void Test_Verify_DriverRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageDriver();
            VerifyDriverRightPanel(editedDriverGroup, driverRightPanelVerification);
        }


        [Test, Order(5)]
        public void Test_Edit_Driver()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageDriver();
            EditDriver(editedDriverGroup, editDriverDetails);
            VerifyDriverDetails(editedDriverGroup, editDriverDetailsVerification);
        }
        [Test, Order(6)]
        public void Test_Delete_Driver()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageDriver();
            DeleteDriver(editedDriverGroup);
        }
        [Test, Order(7)]
        public void Test_Delete_DriverGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageDriver();
            DeleteDriverGroup(editedDriverGroup);
            SearchDriverGroup(editedDriverGroup);
        }


    }
}
