using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageContacts")]
    public class Test_ManageContacts : ManageContacts
    {
        #region Properties
        public Login login;
        public string contactGroup = "AutomationGroup" + DateTime.Now.ToString("dd");
        public static string contactName = "AutomationContact" + DateTime.Now.ToString("dd");
        public static string editContactName = "AutomationContact" + DateTime.Now.ToString("dd") + " edited";
        public static string editedContactGroup = "AutomationGroup" + DateTime.Now.ToString("dd") + " edited";
        public string[] contactDetails = { contactName, "1234567890", "FleetLiteAutomationContact@gmail.com" };
        public string[] contactDetailsVerification = { contactName, "1234567890", "ENABLED", "FleetLiteAutomationContact@gmail.com", "ENABLED" };
        public string[] editContactDetails = { editContactName, "987654321", "FleetLiteAutomationContactEdited@gmail.com" };
        public string[] editContactDetailsVerification = { editContactName, "987654321", "DISABLED", "FleetLiteAutomationContactEdited@gmail.com", "DISABLED" };
        #endregion

        [Test, Order(1)]
        public void Test_Add_ContactGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageContacts();
            AddContactGroup(contactGroup);
            SearchContactGroup(contactGroup);
        }
        [Test, Order(2)]
        public void Test_Edit_ContactGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageContacts();
            EditContactGroup(contactGroup);
            SearchContactGroup(editedContactGroup);
        }
        [Test, Order(3)]
        public void Test_Add_Contact()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageContacts();
            AddContact(editedContactGroup, contactDetails);
            VerifyContactDetails(editedContactGroup, contactDetailsVerification);
        }
        [Test, Order(4)]
        public void Test_Edit_Contact()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageContacts();
            EditContacts(editedContactGroup, editContactDetails);
            VerifyContactDetails(editedContactGroup, editContactDetailsVerification);
        }
        [Test, Order(5)]
        public void Test_Delete_Contact()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageContacts();
            DeleteContact(editedContactGroup, editContactName);
        }
        [Test, Order(6)]
        public void Test_Delete_ContactGroup()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            NavigateToManageContacts();
            DeleteContactGroup(editedContactGroup);
            SearchContactGroup(editedContactGroup);
        }

    }
}
