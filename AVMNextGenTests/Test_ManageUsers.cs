using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageUsers")]
    public class Test_ManageUsers : ManageUsers
    {
        #region Properties
        public Login login;
        #endregion

        [Test, Order(1)]
        public void Test_Add_User()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageUsers();
            AddUser("Non-Admin");
        }

        [Test, Order(2)]
        public void Test_Verify_User_Details()
        {
            string[] userDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "Automation", "User", "Non-Admin", "(+61)1234567890", "NetStarFleetLiteAutomation@gmail.com" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageUsers();
            VerifyUserDetailsOnTable(userDetails);
        }
        [Test, Order(3)]
        public void Test_Verify_User_Details_RightPanel()
        {
            string[] userDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "Automation User", "Non-Admin",  "NetStarFleetLiteAutomation@gmail.com", "(+61)1234567890", "AutomationGroup", "Test Automation Notes"};
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageUsers();
            VerifyManageUsersRightPanel(userDetails);
        }


        [Test, Order(4)]
        public void Test_Verify_Edit_User_Details()
        {
            string[] userDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy") + "Edited", "EditAutomation", "EditUser", "New role", "0987654321", "NetStarFleetLiteAutomationedit@gmail.com" };
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageUsers();
            EditUser("AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "New role");
            VerifyUserDetailsOnTable(userDetails);
        }
        [Test, Order(5)]
        public void Test_Delete_User()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageUsers();
            DeleteUser("AutomationUser" + DateTime.Now.ToString("ddMMyyyy") + "Edited");
        }
    }
}
