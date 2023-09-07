using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageVehicles")]
    public class Test_ManageVehicles : ManageVehicles
    {
        #region Properties
        public Login login;
        #endregion

        [Test,Order(1)]
        public void Test_CreateGroup()
        {
            string groupName = "AutomationGroupName" + DateTime.Now.ToString("dd");
            string description = "Description text " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(userName, password);
            NavigateToManageVehicles();
            CreateVehicleGroup(groupName, description);
        }
        [Test, Order(2)]
        public void Test_SearchGroup()
        {
            string groupName = "AutomationGroupName" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(userName, password);
            NavigateToManageVehicles();
            SearchVehicleGroup(groupName, 0);
        }
        [Test, Order(3)]
        public void Test_EditGroup()
        {
            string groupName = "AutomationGroupName" + DateTime.Now.ToString("dd");
            string editedGroupName = "AutomationGroupNameEdit" + DateTime.Now.ToString("dd");
            string editedDescription = "Description text Edited " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(userName, password);
            NavigateToManageVehicles();
            SearchVehicleGroup(groupName, 0);
            EditVehicleGroup(editedGroupName, editedDescription);
        }
        [Test, Order(4)]
        public void Test_DeleteGroup()
        {
            string groupName = "AutomationGroupNameEdit" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(userName, password);
            NavigateToManageVehicles();
            SearchVehicleGroup(groupName, 0);
            DeleteVehicleGroup(groupName);
        }
    }
}
