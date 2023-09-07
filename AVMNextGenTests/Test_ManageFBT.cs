using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageFBT")]
    public class Test_ManageFBT : ManageFBT
    {

        #region Properties
        public Login login;
        #endregion
        [Test, Order(1)]
        public void Test_VerifyUnassignedTripDetails()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            VerifyTripDetails("155LIH", adminDev, adminDevPassword, 1544, false);
        }
        [Test, Order(2)]
        public void Test_VerifyAssignedTripDetails()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            VerifyTripDetails("155LIH", adminDev, adminDevPassword, 1544, true);
        }
        [Test, Order(3)]
        public void Test_VerifyUnassignedRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            VerifyRightPanel("155LIH", adminDev, adminDevPassword, 1544, false);
        }
        [Test, Order(4)]
        public void Test_VerifyAssignedRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            VerifyRightPanel("155LIH", adminDev, adminDevPassword, 1544, true);
        }
        [Test, Order(5)]
        public void Test_VerifyAssignTripsFromTop()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            AssignTrip("155LIH", adminDev, adminDevPassword, 1544, false);
        }
        [Test, Order(6)]
        public void Test_VerifyEditTripsFromTop()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            AssignTrip("155LIH", adminDev, adminDevPassword, 1544, true);
        }
        [Test, Order(7)]
        public void Test_VerifyAssignTripsFromRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            AssignFromRightPanel("155LIH", adminDev, adminDevPassword, 1544, false);
        }
        [Test, Order(8)]
        public void Test_VerifyEditTripsFromRightPanel()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminDev, adminDevPassword);
            NavigateToManageFBT();
            AssignFromRightPanel("155LIH", adminDev, adminDevPassword, 1544, true);
        }
    }
}
