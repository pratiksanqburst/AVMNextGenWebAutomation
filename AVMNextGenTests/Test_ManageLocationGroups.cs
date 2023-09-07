using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageLocationGroups")]
    public class Test_ManageLocationGroups:ManageLocations
    {
        #region Properties
        public Login login;
        #endregion

        [Test, Order(1)]
        public void Test_CreateGroup()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            string description = "Description text " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageLocationGroups();
            CreateLocationGroup(groupName, description);
        }
        [Test, Order(2)]
        public void Test_SearchGroup()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageLocationGroups();
            SearchLocationGroupByName(groupName, 0);
        }
        [Test, Order(3)]
        public void Test_CreateLocation()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            string locName = "AutoLocName" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            CreateNewLocation(locName, groupName,"Default");
        }
        [Test, Order(4)]
        public void Test_EditGroup()
        {
            string groupName = "AutoLocGroupName" + DateTime.Now.ToString("dd");
            string editedGroupName = "AutoLocNameEdit" + DateTime.Now.ToString("dd");
            string editedDescription = "Description text Edited " + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageLocationGroups();
            SearchLocationGroupByName(groupName, 0);
            EditLocationGroup(editedGroupName, editedDescription);
        }
        [Test, Order(5)]
        public void Test_DeketeGroup()
        {
            string groupName = "AutoLocNameEdit" + DateTime.Now.ToString("dd");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageLocationGroups();
            SearchLocationGroupByName(groupName, 0);
            DeleteLocationGroup(groupName);
        }
      

    }
}
