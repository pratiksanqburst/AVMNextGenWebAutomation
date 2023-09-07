using AVMNextGenWebAutomation.AVMNextGenAPI;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenPageObjects
{
    public class ManageContacts : AVMNextGenBase
    {

        IWebDriver manageContactsDriver;
        public ManageContacts() { }

        public ManageContacts(IWebDriver driver)
        {
            this.manageContactsDriver = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        string group = String.Empty;
        IWebElement ContactsLink => driver.FindElement(By.XPath("//li[contains(text(),'Contact')]"));
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement AddContactButton => driver.FindElement(By.Id("btn-add-contact"));
        IWebElement AddContactTitle => driver.FindElement(By.XPath("//h4[contains(@class,'modal-title')]"));
        IWebElement NameField => driver.FindElement(By.Id("Name"));
        IWebElement MobileField => driver.FindElement(By.Id("phone"));
        IWebElement EmailField => driver.FindElement(By.XPath("//input[@name='Email']"));
        IWebElement AllowSMSNotifications => driver.FindElement(By.XPath("//label[contains(text(),'Allow SMS Notifications')]/span"));
        IWebElement AllowEmailNotifications => driver.FindElement(By.XPath("//label[contains(text(),'Allow Email Notifications')]/span"));
        IWebElement ContactGroupLabel => driver.FindElement(By.XPath("//label[contains(text(),'Contact Group')]"));
        IWebElement EmailLabel => driver.FindElement(By.XPath("//label[contains(text(),'Email')]/span[contains(text(),'*')]"));
        IWebElement NameLabel => driver.FindElement(By.XPath("//label[contains(text(),'Name')]/span[contains(text(),'*')]"));
        IWebElement MobileLabel => driver.FindElement(By.XPath("//label[contains(text(),'Mobile Number')]/span[contains(text(),'*')]"));
        IWebElement ContactGroupDropDown => driver.FindElement(By.XPath("//ng-select[@formcontrolname='ContactGroupId']"));
        IWebElement ContactGroupOption => driver.FindElement(By.XPath($"//div[contains(@class,'ng-option ')]//span[contains(text(),'{group}')]"));
        IWebElement CloseButton => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement CancelButton => driver.FindElement(By.Id("add-groups-cancel-btn"));
        IWebElement SaveButton => driver.FindElement(By.Id("add-groups-create-btn"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement DeleteContactGroupButton => driver.FindElement(By.XPath("//img[@data-test-id='deletecontactgroup']"));
        IWebElement EditContactGroupButton => driver.FindElement(By.XPath("//img[@data-test-id='editcontactgroup']"));
        IWebElement AddContactGroupButton => driver.FindElement(By.Id("add-vehicle-grps-btn"));
        IWebElement ContactGroupNameLabel => driver.FindElement(By.XPath("//label[contains(text(),'Contact Group Name*')]"));
        IWebElement Description => driver.FindElement(By.Id("Description"));
        IWebElement SearchGroupName => driver.FindElement(By.Id("txtbox-contactgroup-search"));
        IWebElement SearchCount => driver.FindElement(By.Id("manage-vehicles-count"));
        IWebElement NoResult => driver.FindElement(By.XPath("//div[contains(text(),'No Contact groups')]"));
        IWebElement FirstGroupResult => driver.FindElement(By.XPath("//li[@data-test-id='contact-group-row']/span[1]"));
        IWebElement FirstGroupResultCount => driver.FindElement(By.XPath("//li[@data-test-id='contact-group-row']/span[2]"));
        IWebElement GroupNameMidPanel => driver.FindElement(By.XPath("//h2[@data-test-id='header-contactgroupname']"));
        IWebElement CountMidPanel => driver.FindElement(By.XPath("//p[@data-test-id='header-numberofcontacts']"));
        IWebElement NameHeading => driver.FindElement(By.XPath("//th[contains(text(),'Name')]"));
        IWebElement NameValue => driver.FindElement(By.XPath("//tr[@data-test-id='contact-row']/td[1]"));
        IWebElement MobileHeading => driver.FindElement(By.XPath("//th[contains(text(),'Mobile Number')]"));
        IWebElement MobileValue => driver.FindElement(By.XPath("//tr[@data-test-id='contact-row']/td[2]"));
        IWebElement SMSHeading => driver.FindElement(By.XPath("//th[contains(text(),'SMS Notification')]"));
        IWebElement SMSValue => driver.FindElement(By.XPath("//tr[@data-test-id='contact-row']/td[3]"));
        IWebElement EmailHeading => driver.FindElement(By.XPath("//th[text()='Email']"));
        IWebElement EmailValue => driver.FindElement(By.XPath("//tr[@data-test-id='contact-row']/td[4]"));
        IWebElement EmailNotificationHeading => driver.FindElement(By.XPath("//th[text()='Email Notification']"));
        IWebElement EmailNotificationValue => driver.FindElement(By.XPath("//tr[@data-test-id='contact-row']/td[5]"));
        IWebElement KebabMenu => driver.FindElement(By.XPath("//span[@class='kebab-menu']"));
        IWebElement EditContactButton => driver.FindElement(By.XPath("//li[@data-test-id='row-edit-contact']"));
        IWebElement DeleteContactButton => driver.FindElement(By.XPath("//li[@data-test-id='row-delete-contact']"));
        IWebElement DeleteGroupTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement DeleteBody => driver.FindElement(By.XPath("//div[@class='modal-body']/p"));
        IWebElement DeleteCancelButton => driver.FindElement(By.XPath("//button[contains(text(),'Cancel')]"));
        IWebElement DeleteConfirmButton => driver.FindElement(By.XPath("//button[contains(text(),'Delete')]"));
        IWebElement DeleteConfirm => driver.FindElement(By.XPath("//button[contains(text(),'Confirm')]"));
        IWebElement DeleteContactTitle => driver.FindElement(By.XPath("//h3[contains(text(),'Delete Contact')]"));
        IWebElement DeleteContactBody => driver.FindElement(By.XPath("//p[contains(text(),'delete')]"));
        #endregion

        #region Methods
        /// <summary>
        /// Navigate to Manage Contacts page
        /// </summary>
        public void NavigateToManageContacts()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            wait.Until(driver => ContactsLink.Displayed);
            ContactsLink.Click();
            wait.Until(driver => SearchGroupName.Displayed);
            driver.Navigate().Refresh();
            wait.Until(driver => SearchGroupName.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the contacts page is displayed.");
        }
        /// <summary>
        /// Adds a new contact group
        /// </summary>
        /// <param name="groupName"></param>
        public void AddContactGroup(string groupName)
        {
            wait.Until(driver => AddContactGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that add contact group button is displayed.");
            AddContactGroupButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => ContactGroupNameLabel.Displayed);
            Assert.AreEqual("Create New Contact Group", AddContactTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that add contact group modal is displayed.");
            NameField.SendKeys(groupName);
            Description.SendKeys("Automation Description");
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => CloseButton.Displayed);
            SaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Contact Group Added Successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that contact group is added.");
        }
        /// <summary>
        /// Searched for the contact group from left menu
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="count"></param>
        public void SearchContactGroup(string groupName, int count = 0)
        {
            wait.Until(driver => SearchGroupName.Displayed);
            extent.SetStepStatusPass("Verified that search field is displayed.");
            SearchGroupName.Clear();
            SearchGroupName.SendKeys(groupName);
            Thread.Sleep(2000);
            int resultCount = Convert.ToInt32(SearchCount.Text);
            if (resultCount > 0)
            {
                Assert.AreEqual(groupName, FirstGroupResult.Text.Trim());
                Assert.AreEqual(count.ToString(), FirstGroupResultCount.Text.Trim());
                extent.SetStepStatusPass("Verified that group name and count is displayed in left panel.");
                FirstGroupResult.Click();
                Thread.Sleep(2000);
                wait.Until(driver => GroupNameMidPanel.Displayed);
                Assert.AreEqual(groupName, GroupNameMidPanel.Text.Trim());
                Assert.AreEqual("Number of contacts: " + count.ToString(), CountMidPanel.Text.Trim());
                extent.SetStepStatusPass("Verified that group name and count is displayed in mid panel.");
            }
            else
            {
                Assert.AreEqual("No Contact groups", NoResult.Text.Trim());
            }
        }
        /// <summary>
        /// Edit the contact group details
        /// </summary>
        /// <param name="groupName"></param>
        public void EditContactGroup(string groupName)
        {
            SearchContactGroup(groupName);
            wait.Until(driver => EditContactGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that edit contact group button is displayed.");
            EditContactGroupButton.Click();
            wait.Until(driver => ContactGroupNameLabel.Displayed);
            Assert.AreEqual("Edit Contact Group", AddContactTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that edit contact group modal is displayed.");
            NameField.Clear();
            NameField.SendKeys(groupName + " edited");
            Description.Clear();
            Description.SendKeys("Edited Automation Description");
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => CloseButton.Displayed);
            SaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Contact group updated successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that contact group is edited.");
        }
        /// <summary>
        /// Deletes the contact group
        /// </summary>
        /// <param name="groupName"></param>
        public void DeleteContactGroup(string groupName)
        {
            SearchContactGroup(groupName);
            wait.Until(driver => DeleteContactGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that delete contact group button is displayed.");
            DeleteContactGroupButton.Click();
            wait.Until(driver => DeleteGroupTitle.Displayed);
            Assert.AreEqual("Confirmation", DeleteGroupTitle.Text.Trim());
            Assert.AreEqual("Are you sure you want to delete?", DeleteBody.Text.Trim());
            wait.Until(driver => CloseButton.Displayed);
            wait.Until(driver => DeleteCancelButton.Displayed);
            extent.SetStepStatusPass("Verified the delete modal contents.");
            DeleteConfirm.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Contact group deleted successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            SearchContactGroup(groupName);
            extent.SetStepStatusPass("Verified that delete contact group is working as expected.");
        }
        /// <summary>
        /// Added new contact under a group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="contactName"></param>
        public void AddContact(string groupName, string[] contactDetails)
        {
            SearchContactGroup(groupName);
            wait.Until(driver => AddContactButton.Displayed);
            AddContactButton.Click();
            wait.Until(driver => AddContactTitle.Displayed);
            extent.SetStepStatusPass("Verified that add contact button is displayed.");
            Assert.AreEqual("Add Contact", AddContactTitle.Text.Trim());
            wait.Until(driver => NameLabel.Displayed);
            wait.Until(driver => MobileLabel.Displayed);
            wait.Until(driver => ContactGroupLabel.Displayed);
            wait.Until(driver => EmailLabel.Displayed);
            extent.SetStepStatusPass("Verified that the mandatory fields are displayed.");
            NameField.Clear();
            NameField.SendKeys(contactDetails[0]);
            MobileField.Clear();
            MobileField.SendKeys(contactDetails[1]);
            AllowSMSNotifications.Click();
            EmailField.Clear();
            EmailField.SendKeys(contactDetails[2]);
            AllowEmailNotifications.Click();
            ContactGroupDropDown.Click();
            group = groupName;
            ContactGroupOption.Click();
            wait.Until(driver => CloseButton.Displayed);
            wait.Until(driver => CancelButton.Displayed);
            SaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Contact saved successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the contact is added correctly.");
        }
        /// <summary>
        /// Verify the contact details displayed in the table.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="contactDetails"></param>
        public void VerifyContactDetails(string groupName, string[] contactDetails)
        {
            SearchContactGroup(groupName,1);
            wait.Until(driver => NameHeading.Displayed);
            wait.Until(driver => MobileHeading.Displayed);
            wait.Until(driver => SMSHeading.Displayed);
            wait.Until(driver => EmailHeading.Displayed);
            wait.Until(driver => EmailNotificationHeading.Displayed);
            Assert.AreEqual(contactDetails[0], NameValue.Text.Trim());
            Assert.AreEqual(contactDetails[1], MobileValue.Text.Trim());
            Assert.AreEqual(contactDetails[2], SMSValue.Text.Trim());
            Assert.AreEqual(contactDetails[3], EmailValue.Text.Trim());
            Assert.AreEqual(contactDetails[4], EmailNotificationValue.Text.Trim());
            extent.SetStepStatusPass("Verified that the contact details are displayed properly in the table.");
        }

        /// <summary>
        /// Edit the contact details from kebab menu
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="contactName"></param>
        public void EditContacts(string groupName, string[] contactDetails)
        {
            SearchContactGroup(groupName,1);
            wait.Until(driver => KebabMenu.Displayed);
            KebabMenu.Click();
            Thread.Sleep(1000);
            wait.Until(driver => EditContactButton.Displayed);
            extent.SetStepStatusPass("Verified that edit contact button is displayed.");
            EditContactButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AddContactTitle.Displayed);
            Assert.AreEqual("Edit Contact", AddContactTitle.Text.Trim());
            wait.Until(driver => NameLabel.Displayed);
            wait.Until(driver => MobileLabel.Displayed);
            wait.Until(driver => ContactGroupLabel.Displayed);
            wait.Until(driver => EmailLabel.Displayed);
            extent.SetStepStatusPass("Verified that the mandatory fields are displayed.");
            NameField.Clear();
            NameField.SendKeys(contactDetails[0]);
            MobileField.Clear();
            MobileField.SendKeys(contactDetails[1]);
            AllowSMSNotifications.Click();
            EmailField.Clear();
            EmailField.SendKeys(contactDetails[2]);
            AllowEmailNotifications.Click();
            ContactGroupDropDown.Click();
            group = groupName;
            ContactGroupOption.Click();
            wait.Until(driver => CloseButton.Displayed);
            wait.Until(driver => CancelButton.Displayed);
            SaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Contact updated successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the contact is updated correctly.");
        }
        /// <summary>
        /// Delete Contact from the kebab menu
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="contactName"></param>
        public void DeleteContact(string groupName, string contactName)
        {
            SearchContactGroup(groupName,1);
            wait.Until(driver => KebabMenu.Displayed);
            KebabMenu.Click();
            wait.Until(driver => DeleteContactButton.Displayed);
            extent.SetStepStatusPass("Verified that delete contact button is displayed.");
            DeleteContactButton.Click();
            wait.Until(driver => DeleteContactTitle.Displayed);
            Assert.AreEqual("Delete Contact", DeleteContactTitle.Text.Trim());
            Assert.AreEqual("Are you sure to delete the contact : " + contactName, DeleteContactBody.Text.Trim());
            wait.Until(driver => DeleteCancelButton.Displayed);
            DeleteConfirmButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Contact deleted successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the contact is delete correctly.");
        }


        #endregion
    }
}
