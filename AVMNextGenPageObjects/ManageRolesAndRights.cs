using AVMNextGenWebAutomation.AVMNextGenAPI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenPageObjects
{
    public class ManageRolesAndRights : AVMNextGenBase
    {
        IWebDriver manageRolesDriver;
        public ManageRolesAndRights() { }

        public ManageRolesAndRights(IWebDriver driver)
        {
            this.manageRolesDriver = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        public TestDataUtils testDataUtils = new TestDataUtils();
        IWebElement Table => driver.FindElement(By.Id("driver-table"));
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement Title => driver.FindElement(By.XPath("//h2[contains(text(),'Users')]"));
        IWebElement UserLink => driver.FindElement(By.XPath("//app-manage//li[contains(@class,'user')]"));
        IWebElement RolesLink => driver.FindElement(By.LinkText("Roles & Rights"));
        IWebElement SearchRoles => driver.FindElement(By.Id("search-roles"));
        IWebElement AddRolesButton => driver.FindElement(By.Id("add-role-btn"));
        IWebElement AddRolesHeader => driver.FindElement(By.XPath("//span[@id='add-role-popup-close']/following-sibling::h3"));
        IWebElement NameLabel => driver.FindElement(By.Id("add-role-popup-name-label"));
        IWebElement NameField => driver.FindElement(By.Id("add-role-popup-name-fld"));
        IWebElement DescLabel => driver.FindElement(By.Id("add-role-popup-desc-label"));
        IWebElement DescField => driver.FindElement(By.Id("add-role-popup-desc-fld"));
        IWebElement AddRolesCancel => driver.FindElement(By.Id("add-role-popup-cancel"));
        IWebElement AddRolesSave => driver.FindElement(By.Id("add-role-popup-save"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement SearchResult => driver.FindElement(By.Id("role-name"));
        IWebElement SelectedRoleName => driver.FindElement(By.Id("selected-role-name"));
        IWebElement SelectedRoleCount => driver.FindElement(By.Id("selected-role-count"));
        IWebElement UsersTab => driver.FindElement(By.Id("selected-role-title"));
        IWebElement UsersMessage => driver.FindElement(By.Id("users-length"));
        IWebElement EditButton => driver.FindElement(By.Id("role-edit-icon"));
        IWebElement DeleteButton => driver.FindElement(By.Id("role-delete-icon"));
        IWebElement EditTitle => driver.FindElement(By.XPath("//span[@id='popup-close']/following-sibling::h3"));
        IWebElement EditNameLabel => driver.FindElement(By.Id("label-name"));
        IWebElement EditNameField => driver.FindElement(By.Id("field-name"));
        IWebElement EditDescLabel => driver.FindElement(By.Id("label-description"));
        IWebElement EditDescField => driver.FindElement(By.Id("field-description"));
        IWebElement EditRolesCancel => driver.FindElement(By.Id("popup-cancel-btn"));
        IWebElement EditRolesSave => driver.FindElement(By.Id("popup-save-btn"));
        IWebElement DeleteTitle => driver.FindElement(By.XPath("//span[@id='delete-popup-close']/following-sibling::h3"));
        IWebElement DeleteModalContent => driver.FindElement(By.XPath("//span[@id='delete-popup-close']/following-sibling::span"));
        IWebElement DeleteCancel => driver.FindElement(By.Id("delete-popup-cancel"));
        IWebElement DeleteButtonSave => driver.FindElement(By.Id("delete-popup-delete"));
        IWebElement SearchResultCount => driver.FindElement(By.Id("roles-search-count"));
        IWebElement SearchRolesClose => driver.FindElement(By.Id("search-roles-close"));

        #endregion

        #region Methods
        /// <summary>
        /// Navigate to Manage Roles page
        /// </summary>
        public void NavigateToManageRoles()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            testDataUtils.WaitForLoading();
            wait.Until(driver => Table.Displayed);
            Thread.Sleep(1000);
            Actions action = new Actions(driver);
            action.MoveToElement(UserLink).Perform();
            wait.Until(driver => RolesLink.Displayed);
            RolesLink.Click();
            wait.Until(driver => SearchRoles.Displayed);
            extent.SetStepStatusPass("Verified that the roles page is displayed.");
        }

        /// <summary>
        /// Adds new role
        /// </summary>
        public void AddNewRoles()
        {
            wait.Until(driver => AddRolesButton.Displayed);
            extent.SetStepStatusPass("Verified that the add roles button is displayed.");
            AddRolesButton.Click();
            wait.Until(driver => AddRolesHeader.Displayed);
            Assert.IsTrue(AddRolesHeader.Text.Trim().Contains("Add Role"));
            Assert.IsTrue(NameLabel.Text.Trim().Contains("Name"));
            Assert.IsTrue(DescLabel.Text.Trim().Contains("Description"));
            extent.SetStepStatusPass("Verified that the field names are displayed properly.");
            NameField.Clear();
            NameField.SendKeys("AutoRole " + DateTime.Now.ToString("ddMMyyyy"));
            DescField.Clear();
            DescField.SendKeys("Automated Description message");
            extent.SetStepStatusPass("Entered the role name and description.");
            wait.Until(driver => AddRolesCancel.Displayed);
            extent.SetStepStatusPass("Verified that the cancel button is displayed.");
            Thread.Sleep(2000);
            AddRolesSave.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Trim().Contains("Role added"));
        }
        /// <summary>
        /// Search by roles name
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="isPresent">true or false, if expecting results</param>
        public void SearchRolesByName(string roleName,int userCount=0, bool isPresent = true)
        {
            wait.Until(driver => SearchRoles.Displayed);
            extent.SetStepStatusPass("Verified that the search field is displayed.");
            Thread.Sleep(2000);
            SearchRoles.Clear();
            SearchRoles.SendKeys(roleName);
            Thread.Sleep(1000);
            wait.Until(driver => SearchResultCount.Displayed);
            extent.SetStepStatusPass("Verified that the search result count is displayed.");
            if (isPresent)
            {
                Assert.IsTrue(SearchResultCount.Text.Trim().Contains("Search Results (1)"));
                SearchResult.Click();
                wait.Until(driver => SelectedRoleName.Displayed);
                Assert.IsTrue(SelectedRoleName.Text.Trim().Contains(roleName));
                Assert.IsTrue(SelectedRoleCount.Text.Trim().Contains($"Number of users: {userCount}"));
                extent.SetStepStatusPass("Verified that the search result is selected.");
            }
            else
            {
                Assert.IsTrue(SearchResultCount.Text.Trim().Contains("Search Results (0)"));
                SearchRolesClose.Click();
                extent.SetStepStatusPass("Verified that the search result is not displayed.");
            }
        }
        /// <summary>
        /// Edit Roles
        /// </summary>
        /// <param name="roleName"></param>
        public void EditRoles(string roleName)
        {
            SearchRolesByName(roleName);
            wait.Until(driver => EditButton.Displayed);
            extent.SetStepStatusPass("Verified that the edit button is displayed.");
            EditButton.Click();
            wait.Until(driver => EditTitle.Displayed);
            Assert.IsTrue(EditTitle.Text.Trim().Contains("Edit Role"));
            Assert.IsTrue(EditNameLabel.Text.Trim().Contains("Name"));
            Assert.IsTrue(EditDescLabel.Text.Trim().Contains("Description"));
            extent.SetStepStatusPass("Verified that the field names are displayed properly.");
            EditNameField.Clear();
            EditNameField.SendKeys("AutoRole " + DateTime.Now.ToString("ddMMyyyy")+" Edited");
            EditDescField.Clear();
            EditDescField.SendKeys("Automated Description message edited");
            extent.SetStepStatusPass("Entered the role name and description.");
            wait.Until(driver => EditRolesCancel.Displayed);
            extent.SetStepStatusPass("Verified that the cancel button is displayed.");
            EditRolesSave.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Trim().Contains("Role updated"));
        }
        /// <summary>
        /// Deletes Role
        /// </summary>
        /// <param name="roleName"></param>
        public void DeleteRole(string roleName)
        {
            SearchRolesByName(roleName);
            wait.Until(driver => DeleteButton.Displayed);
            extent.SetStepStatusPass("Verified that the delete button is displayed.");
            DeleteButton.Click();
            wait.Until(driver => DeleteTitle.Displayed);
            Assert.IsTrue(DeleteTitle.Text.Trim().Contains("Delete Role"));
            Assert.IsTrue(DeleteModalContent.Text.Trim().Contains($"Are you sure to delete the role : {roleName}"));
            extent.SetStepStatusPass("Verified that the delete body contents are displayed properly.");
            wait.Until(driver => DeleteCancel.Displayed);
            extent.SetStepStatusPass("Verified that the cancel button is displayed.");
            DeleteButtonSave.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Trim().Contains("Role deleted"));
        }



        #endregion
    }
}
