using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageServices")]
    public class Test_ManageServices : ManageServices
    {
        #region Properties
        public Login login;
        public static string date = DateTime.Now.AddDays(-1).Day.ToString();
        public static string dateValue = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Replace("-","/")+ " 12:30 AM";
        public string[] serviceDetails = { "AutoVehicle", date, "12", "30", "Minor", "1000", "12345", "10000", "Automation notes" };
        public string[] serviceDetailsVerification = { "AutoVehicle", dateValue, "Minor", "1000", "12345", "10000", "Automation notes" };
        #endregion

        [Test, Order(1)]
        public void Test_AddService()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageServices();
            AddService(serviceDetails);
        }
        [Test, Order(2)]
        public void Test_VerifyServiceDetails()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageServices();
            VerifyServiceDetails(serviceDetailsVerification);
        }
        [Test, Order(3)]
        public void Test_DeleteService()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageServices();
            DeleteService("AutoVehicle");
        }
    }
}
