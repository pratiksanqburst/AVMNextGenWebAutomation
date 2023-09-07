using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageRoles")]
    public class Test_ManageRoles: ManageRolesAndRights
    {
        #region Properties
        public Login login;
        #endregion

        [Test, Order(1)]
        public void Test_Add_Role()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageRoles();
            AddNewRoles();
        }
        [Test, Order(2)]
        public void Test_VerifyRoleDetails()
        {
            string roleName = "Automated Role " + DateTime.Now.ToString("ddMMyyyy");
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageRoles();
            SearchRolesByName(roleName);
        }
        [Test, Order(3)]
        public void Test_Edit_Roles()
        {
            string roleName = "Automated Role " + DateTime.Now.ToString("ddMMyyyy");
            string roleNameEdited = "Automated Role " + DateTime.Now.ToString("ddMMyyyy")+" Edited";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageRoles();
            SearchRolesByName(roleName);
            EditRoles(roleName);
            SearchRolesByName(roleNameEdited);
        }
        [Test, Order(4)]
        public void Test_Delete_Role()
        {
            string roleName = "Automated Role " + DateTime.Now.ToString("ddMMyyyy") + " Edited";
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageRoles();
            SearchRolesByName(roleName);
            DeleteRole(roleName);
            SearchRolesByName(roleName,0,false);
        }
    }
}
