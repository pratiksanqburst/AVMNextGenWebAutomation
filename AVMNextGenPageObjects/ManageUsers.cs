using AVMNextGenWebAutomation.AVMNextGenAPI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenPageObjects
{
    public class ManageUsers : AVMNextGenBase
    {
        IWebDriver manageUsersDriver;
        public ManageUsers() { }

        public ManageUsers(IWebDriver driver)
        {
            this.manageUsersDriver = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        public TestDataUtils testDataUtils = new TestDataUtils();
        string rolevalue = string.Empty;
        string searchKey = string.Empty;
        int count = 1;
        int selectValue = 1;
        IWebElement SearchDriverField => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//input[@id='search-field']"));
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement Table => driver.FindElement(By.Id("driver-table"));
        IWebElement UserTab => driver.FindElement(By.XPath("//app-manage//li[contains(@class,'user')]"));
        IWebElement UserDetailsLink => driver.FindElement(By.LinkText("Details"));
        IWebElement SearchField => driver.FindElement(By.Id("txtsearchuser"));
        IWebElement AddButton => driver.FindElement(By.Id("btn-add-user"));
        IWebElement AddUserHeader => driver.FindElement(By.Id("divaddnewuserheader"));
        IWebElement EditUserHeader => driver.FindElement(By.Id("divedituserheader"));
        IWebElement UserNameField => driver.FindElement(By.Id("txtusername"));
        IWebElement FirstNameField => driver.FindElement(By.Id("txtfirstname"));
        IWebElement LastNameField => driver.FindElement(By.Id("txtlastname"));
        IWebElement SelectRole => driver.FindElement(By.Id("selectrole"));
        IWebElement SelectRoleValue => driver.FindElement(By.XPath($"//span[contains(text(),'{rolevalue}')]"));
        IWebElement EmailField => driver.FindElement(By.Id("txtemail"));
        IWebElement PhoneNumberField => driver.FindElement(By.Id("txtphone"));
        IWebElement NotesText => driver.FindElement(By.XPath("//textarea[@name='txtareanotes']"));
        IWebElement EditNotesText => driver.FindElement(By.XPath("//textarea[@id='textareanotes']"));
        IWebElement SelectVehicleButton => driver.FindElement(By.XPath("//div[contains(@class,'vehicle')]//button"));
        IWebElement VehicleSelectionHeader => driver.FindElement(By.Id("reports-vehicle-tree-header"));
        IWebElement SearchVehicle => driver.FindElement(By.XPath("//input[@placeholder='Search vehicle']"));
        IWebElement SearchDriver => driver.FindElement(By.XPath("//div[@id='fleet-list-wrapper']//avm-tree-view[2]//input[@placeholder='Search driver']"));
        IWebElement SearchResult => driver.FindElement(By.XPath($"//button[@data-test-id='entityname'][contains(text(),'{searchKey}')]"));
        IWebElement SelectAllButton => driver.FindElement(By.XPath($"//div[@id='fleet-list-wrapper']//avm-tree-view[{selectValue}]//button[@id='reports-select-all-btn']"));
        IWebElement UnSelectAllButton => driver.FindElement(By.XPath($"//div[@id='fleet-list-wrapper']//avm-tree-view[{selectValue}]//button[@id='reports-unselect-all-btn']"));
        IWebElement CancelButton => driver.FindElement(By.Id("reports-tree-cancel-btn"));
        IWebElement DoneButton => driver.FindElement(By.Id("reports-tree-done-btn"));
        IWebElement SelectDriverButton => driver.FindElement(By.XPath("//div[contains(@class,'driver')]//button"));
        IWebElement ChangeVehicleButton => driver.FindElement(By.XPath("//span[@data-test-id='btnchangevehicle']"));
        IWebElement ClearVehicleButton => driver.FindElement(By.XPath("//span[@data-test-id='btnclearvehicle']"));
        IWebElement ChangeDriverButton => driver.FindElement(By.XPath("//span[@data-test-id='btnchangedriver']"));
        IWebElement ClearDriverButton => driver.FindElement(By.XPath("//span[@data-test-id='btncleardriver']"));
        IWebElement AddUserCancelButton => driver.FindElement(By.Id("btnaddusercancel"));
        IWebElement AddUserSaveButton => driver.FindElement(By.Id("btnaddusersave"));
        IWebElement EditUserCancelButton => driver.FindElement(By.Id("btn-edit-user-cancel"));
        IWebElement EditUserSaveButton => driver.FindElement(By.Id("btn-edit-user-save"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement SuccessMessageClose => driver.FindElement(By.XPath("//div[@id='toast-container']//button[@type='button']"));
        IWebElement Headers => driver.FindElement(By.XPath($"//div[@id='div-users-table-header']/div[{count}]"));
        IWebElement TableValues => driver.FindElement(By.XPath($"//div[@id='div-users-table-rows']/div[{count}]"));
        IWebElement KebabMenu => driver.FindElement(By.XPath("//span[@data-test-id='user-kebab-menu']"));
        IWebElement EditFromKebabMenu => driver.FindElement(By.XPath("//li[@data-test-id='user-kebab-menu-edit']"));
        IWebElement DeleteFromKebabMenu => driver.FindElement(By.XPath("//li[@data-test-id='user-kebab-menu-delete']"));
        IWebElement DeleteHeading => driver.FindElement(By.XPath("//div[contains(@class,'delete-user')]/h3"));
        IWebElement DeleteBody => driver.FindElement(By.XPath("//div[contains(@class,'delete-user')]/p"));
        IWebElement Deletecancel => driver.FindElement(By.XPath("//button[@data-test-id='btn-cancel-user-confirm-popup']"));
        IWebElement DeleteButton => driver.FindElement(By.XPath("//button[@data-test-id='btn-delete-user-confirm-popup']"));
        IWebElement UserNameResult => driver.FindElement(By.XPath("//div[@id='div-users-table-rows']//div[@class='col-user']"));
        IWebElement UserFullName => driver.FindElement(By.XPath("//div[contains(@class,'right-panel')]//h2"));
        IWebElement UserNameRight => driver.FindElement(By.XPath("//div[contains(@class,'right-panel')]//p[contains(text(),'Username: ')]"));
        IWebElement ResetPasswordLink => driver.FindElement(By.XPath("//img[@data-test-id='img-show-reset-password-popup']"));
        IWebElement ResetPasswordText => driver.FindElement(By.XPath("//h3[contains(text(),'Reset password')]"));
        IWebElement ResetPasswordDescription => driver.FindElement(By.XPath("//h3[contains(text(),'Reset password')]/following-sibling::p"));
        IWebElement ResetPasswordButton => driver.FindElement(By.XPath("//button[@data-test-id='btn-user-reset-password']"));
        IWebElement UnlockUserRight => driver.FindElement(By.XPath("//img[@data-test-id='img-show-user-lock-unlock-popup']"));
        IWebElement LockButtonText => driver.FindElement(By.XPath("//label[@data-test-id='btn-user-lock']/parent::span"));
        IWebElement LockButton => driver.FindElement(By.XPath("//label[@data-test-id='btn-user-lock']"));
        IWebElement UnlockButtonText => driver.FindElement(By.XPath("//label[@data-test-id='btn-user-unlock']/parent::span"));
        IWebElement UnlockButton => driver.FindElement(By.XPath("//label[@data-test-id='btn-user-unlock']"));

        IWebElement DeleteButtonRight => driver.FindElement(By.XPath("//img[@data-test-id='img-user-delete-show-popup']"));
        IWebElement EditButtonRight => driver.FindElement(By.XPath("//img[@data-test-id='img-user-goto-edit-page']"));
        IWebElement SuppressAlertText => driver.FindElement(By.XPath("//span[contains(text(),' Suppress alerts notifications ')]"));
        IWebElement SuppressAlarmText => driver.FindElement(By.XPath("//span[contains(text(),' Suppress alarms notifications ')]"));
        IWebElement RoleRight => driver.FindElement(By.XPath("//label[contains(text(),'Role')]/following-sibling::p[1]"));
        IWebElement EmailRight => driver.FindElement(By.XPath("//label[contains(text(),'Email')]/following-sibling::p[1]"));
        IWebElement PhoneRight => driver.FindElement(By.XPath(" //label[contains(text(),'Phone')]/following-sibling::p[1]"));
        IWebElement VehicleGroupRight => driver.FindElement(By.XPath("//label[contains(text(),'Vehicle(s)/Vehicle groups user can see')]/following-sibling::div[1]//div[@class='vh-group list']"));
        IWebElement DriverGroupRight => driver.FindElement(By.XPath("//label[contains(text(),'Driver(s)/Driver groups user can see')]/following-sibling::div[1]//div[@class='vh-group list']"));
        IWebElement NotesRight => driver.FindElement(By.XPath(" //label[contains(text(),'Notes')]/following-sibling::p[1]"));
        IWebElement Checkbox => driver.FindElement(By.XPath($"//button[contains(text(),'{searchKey}')]"));
        IWebElement SupressAlertCheckbox => driver.FindElement(By.XPath($"//input[@id='chkbox-suppress-alerts']/following-sibling::span"));
        IWebElement SupressAlarmsCheckbox => driver.FindElement(By.XPath($"//input[@id='chkbox-suppress-alarms']/following-sibling::span"));
        
        

        #endregion

        #region Methods
        /// <summary>
        /// Verify Supress notifications
        /// </summary>
        /// <param name="userDetails"></param>
        public void VerifyUsersRightPanelSuppressNotifications(string[] userDetails)
        {
            SearchByUsername(userDetails[0]);
            extent.SetStepStatusPass("Searched for the user.");
            Thread.Sleep(2000);
            UserNameResult.Click();
            wait.Until(driver => UserFullName.Displayed);
            extent.SetStepStatusPass("Verified that Right Panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(UserFullName.Text.Trim().Contains(userDetails[1] + " " + userDetails[2]));
            wait.Until(driver => SupressAlertCheckbox.Displayed);
            Actions build = new Actions(driver);
            build.MoveToElement(SupressAlertCheckbox).Click().Build().Perform();
            Thread.Sleep(2000);
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Alert notification updated"));
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            build.MoveToElement(SupressAlarmsCheckbox).Click().Build().Perform();
            Thread.Sleep(2000);
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Alarm notification updated"));
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            build.MoveToElement(SupressAlertCheckbox).Click().Build().Perform();
            Thread.Sleep(2000);
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Alert notification updated"));
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            build.MoveToElement(SupressAlarmsCheckbox).Click().Build().Perform();
            Thread.Sleep(2000);
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Alarm notification updated"));
            SuccessMessageClose.Click();
            extent.SetStepStatusPass("Verified that the supress notification is working.");
        }
        /// <summary>
        /// Edit user rection from right panel
        /// </summary>
        /// <param name="userDetails"></param>
        public void VerifyUsersRightPanelEditRedirection(string[] userDetails)
        {
            SearchByUsername(userDetails[0]);
            extent.SetStepStatusPass("Searched for the user.");
            Thread.Sleep(2000);
            UserNameResult.Click();
            wait.Until(driver => UserFullName.Displayed);
            extent.SetStepStatusPass("Verified that Right Panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(UserFullName.Text.Trim().Contains(userDetails[1] + " " + userDetails[2]));
            wait.Until(driver => EditButtonRight.Displayed);
            EditButtonRight.Click();
            Thread.Sleep(2000);
            wait.Until(driver => EditUserHeader.Displayed);
            extent.SetStepStatusPass("Verified that the edit user redirection is working.");
        }
        /// <summary>
        /// Delete user redirection from right panel
        /// </summary>
        /// <param name="userDetails"></param>
        public void VerifyUsersRightPanelDeleteRedirection(string[] userDetails)
        {
            SearchByUsername(userDetails[0]);
            extent.SetStepStatusPass("Searched for the user.");
            Thread.Sleep(2000);
            UserNameResult.Click();
            wait.Until(driver => UserFullName.Displayed);
            extent.SetStepStatusPass("Verified that Right Panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(UserFullName.Text.Trim().Contains(userDetails[1] + " " + userDetails[2]));
            wait.Until(driver => DeleteButtonRight.Displayed);
            DeleteButtonRight.Click();
            Thread.Sleep(2000);
            wait.Until(driver => DeleteHeading.Displayed);
            extent.SetStepStatusPass("Verified that the delete user redirection is working.");
        }

        /// <summary>
        /// Verify the rightPanelDetails.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userDetails"></param>
        public void VerifyManageUsersRightPanel(string[] userDetails)
        {
            SearchByUsername(userDetails[0]);
            extent.SetStepStatusPass("Searched for the user.");
            Thread.Sleep(2000);
            UserNameResult.Click();
            wait.Until(driver => UserFullName.Displayed);
            extent.SetStepStatusPass("Verified that Right Panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(UserFullName.Text.Trim().Contains(userDetails[1]));
            Assert.IsTrue(UserNameRight.Text.Trim().Contains(userDetails[0]));
            wait.Until(driver => ResetPasswordLink.Displayed);
            wait.Until(driver => UnlockUserRight.Displayed);
            wait.Until(driver => EditButtonRight.Displayed);
            wait.Until(driver => SuppressAlertText.Displayed);
            wait.Until(driver => SuppressAlarmText.Displayed);
            Assert.IsTrue(RoleRight.Text.Trim().Contains(userDetails[2]));
            Assert.IsTrue(EmailRight.Text.Trim().Contains(userDetails[3]));
            Assert.IsTrue(PhoneRight.Text.Trim().Contains(userDetails[4]));
            Assert.IsTrue(VehicleGroupRight.Text.Trim().Contains(userDetails[5]));
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(adminUser, adminPassword);
            string driverNAme = driverTree.FirstOrDefault().groupName;
            Assert.IsTrue(DriverGroupRight.Text.Trim().Contains(driverNAme));
            Assert.IsTrue(NotesRight.Text.Trim().Contains(userDetails[6]));
            extent.SetStepStatusPass("Verified that details displayed on right panel.");
            driver.Navigate().Refresh();
            wait.Until(driver => ManageTab.Displayed);
        }
        /// <summary>
        /// Verify Reset Password
        /// </summary>
        /// <param name="userDetails"></param>
        public void VerifyUsersResetPassword(string[] userDetails)
        {
            SearchByUsername(userDetails[0]);
            extent.SetStepStatusPass("Searched for the user.");
            Thread.Sleep(2000);
            UserNameResult.Click();
            wait.Until(driver => UserFullName.Displayed);
            extent.SetStepStatusPass("Verified that Right Panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(UserFullName.Text.Trim().Contains(userDetails[1] + " " + userDetails[2]));
            wait.Until(driver => ResetPasswordLink.Displayed);
            ResetPasswordLink.Click();
            Thread.Sleep(2000);
            wait.Until(driver => ResetPasswordText.Displayed);
            Assert.IsTrue(ResetPasswordDescription.Text.Trim().Contains("Reset password link will be sent to this email " + userDetails[5]));
            ResetPasswordButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Reset password link sent to your email"));
            extent.SetStepStatusPass("Verified that the reset password is working.");
        }
        /// <summary>
        /// Verify Account lock
        /// </summary>
        /// <param name="userDetails"></param>
        public void VerifyUsersLockAccount(string[] userDetails)
        {
            SearchByUsername(userDetails[0]);
            extent.SetStepStatusPass("Searched for the user.");
            Thread.Sleep(2000);
            UserNameResult.Click();
            wait.Until(driver => UserFullName.Displayed);
            extent.SetStepStatusPass("Verified that Right Panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(UserFullName.Text.Trim().Contains(userDetails[1] + " " + userDetails[2]));
            wait.Until(driver => UnlockUserRight.Displayed);
            UnlockUserRight.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(LockButtonText.Text.Trim().Contains("Account is active"));
            LockButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Account locked successfully"));
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            UnlockUserRight.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(UnlockButtonText.Text.Trim().Contains("Account is locked"));
            UnlockButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Account unlocked successfully"));
            SuccessMessageClose.Click();
            extent.SetStepStatusPass("Verified that the account lock is working.");
        }

        /// <summary>
        /// Navigate to Manage Users page
        /// </summary>
        public void NavigateToManageUsers()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            testDataUtils.WaitForLoading();
            wait.Until(driver => SearchDriverField.Displayed);
            Thread.Sleep(1000);
            Actions action = new Actions(driver);
            action.MoveToElement(UserTab).Perform();
            wait.Until(driver => UserDetailsLink.Displayed);
            UserDetailsLink.Click();
            Thread.Sleep(3000);
            wait.Until(driver => TableValues.Displayed);
            extent.SetStepStatusPass("Verified that the manage user page is displayed.");
        }
        /// <summary>
        /// Search the manage users table by username
        /// </summary>
        /// <param name="userName"></param>
        public void SearchByUsername(string userName, bool isEmpty = false)
        {
            wait.Until(driver => SearchField.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the search field is displayed.");
            SearchField.Clear();
            SearchField.SendKeys(userName);
            Thread.Sleep(2000);
            count = 1;
            if (isEmpty == false)
            {
                wait.Until(driver => TableValues.Displayed);
            }
            else
            {
                try
                {
                    wait.Until(driver => TableValues.Displayed);
                    throw new Exception("User details are displayed.");
                }
                catch (Exception)
                {
                    extent.SetStepStatusPass("User details are no longer displayed.");
                }

            }
            extent.SetStepStatusPass("Entered the values in search field.");
        }
        /// <summary>
        /// Add New User
        /// </summary>
        public void AddUser(string role)
        {
            wait.Until(driver => AddButton.Displayed);
            extent.SetStepStatusPass("Verified that Add Button is displayed.");
            AddButton.Click();
            wait.Until(driver => AddUserHeader.Displayed);
            Thread.Sleep(3000);
            extent.SetStepStatusPass("Verified that the user is redirected to add user page.");
            Assert.IsTrue(AddUserHeader.Text.Contains("Add New User"));
            UserNameField.SendKeys("AutomationUser" + DateTime.Now.ToString("ddMMyyyy"));
            FirstNameField.SendKeys("Automation");
            LastNameField.SendKeys("User");
            EmailField.SendKeys("NetStarFleetLiteAutomation@gmail.com");
            SelectRole.Click();
            rolevalue = role;
            wait.Until(driver => SelectRoleValue.Displayed);
            SelectRoleValue.Click();
            PhoneNumberField.SendKeys("1234567890");
            NotesText.SendKeys("Test Automation Notes");
            SelectVehicleButton.Click();
            wait.Until(driver => VehicleSelectionHeader.Displayed);
            Assert.IsTrue(VehicleSelectionHeader.Text.Trim().Contains("Choose one or more vehicle"));
            extent.SetStepStatusPass("Verified that select vehicle right panel is displayed.");
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(adminUser, adminPassword);
            string vehicleName = vehicleTree.FirstOrDefault().unitName;
            Thread.Sleep(3000);
            SearchVehicle.SendKeys(vehicleName);
            Thread.Sleep(4000);
            searchKey = vehicleName;
            wait.Until(driver => SearchResult.Displayed);
            Thread.Sleep(4000);
            Thread.Sleep(1000);
            Actions build = new Actions(driver);
            build.MoveToElement(Checkbox).Click().Build().Perform();
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.checkbox-wrapper.tree-node.entity-deselect-color label");
            Assert.IsTrue(SelectAllButton.Displayed);
            Assert.IsTrue(UnSelectAllButton.Displayed);
            Assert.IsTrue(CancelButton.Displayed);
            Assert.IsTrue(DoneButton.Displayed);
            extent.SetStepStatusPass("Verified the display of different buttons on the right panel.");
            DoneButton.Click();
            wait.Until(driver => ChangeVehicleButton.Displayed);
            Assert.IsTrue(ClearVehicleButton.Displayed);
            Thread.Sleep(3000);
            SelectDriverButton.Click();
            wait.Until(driver => VehicleSelectionHeader.Displayed);
            Assert.IsTrue(VehicleSelectionHeader.Text.Trim().Contains("Choose one or more driver"));
            extent.SetStepStatusPass("Verified that select driver right panel is displayed.");
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(adminUser, adminPassword);
            string driverNAme = driverTree.FirstOrDefault().driverShortName;
            selectValue = 2;
            Thread.Sleep(3000);
            SearchDriver.SendKeys(driverNAme);
            Thread.Sleep(4000);
            searchKey = driverNAme;
            wait.Until(driver => SearchResult.Displayed);
            Actions build1 = new Actions(driver);
            build1.MoveToElement(Checkbox).Click().Build().Perform();
            // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.checkbox-wrapper.tree-node.entity-deselect-color label");
            Assert.IsTrue(SelectAllButton.Displayed);
            Assert.IsTrue(UnSelectAllButton.Displayed);
            Assert.IsTrue(CancelButton.Displayed);
            Assert.IsTrue(DoneButton.Displayed);
            extent.SetStepStatusPass("Verified the display of different buttons on the right panel.");
            DoneButton.Click();
            wait.Until(driver => ChangeDriverButton.Displayed);
            wait.Until(driver => ClearDriverButton.Displayed);
            wait.Until(driver => AddUserCancelButton.Enabled);
            Assert.IsTrue(AddUserCancelButton.Displayed);
            AddUserSaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Client added"));
            extent.SetStepStatusPass("Verified that the success message is displayed");
        }
        /// <summary>
        /// Verify the headers in the user table.
        /// </summary>
        public void VerifyHeaderTextsOnTable()
        {
            string[] headersText = { "Username", "First Name", "Last Name", "Role", "Phone", "Email" };
            for (int i = 1; i < 7; i++)
            {
                count = i;
                if (Headers.Text.Trim().Contains(headersText[i - 1]))
                    extent.SetStepStatusPass($"Header Value verified for {headersText[i - 1]}.");
                else
                    extent.SetTestStatusFail($"Header Value displayed is not correct for {headersText[i - 1]}.");

            }
        }
        /// <summary>
        /// Verifies the user details displayed on the first row.
        /// </summary>
        public void VerifyUserDetailsTable(string[] userDetails)
        {

            for (int i = 1; i <= userDetails.Length; i++)
            {
                count = i;
                if (TableValues.Text.Trim().Contains(userDetails[i - 1]))
                    extent.SetStepStatusPass($"User details Value verified for {userDetails[i - 1]}.");
                else
                    extent.SetTestStatusFail($"User details Value displayed is not correct for {userDetails[i - 1]}.");

            }
        }
        /// <summary>
        /// Search by username and verify the user details.
        /// </summary>
        public void VerifyUserDetailsOnTable(string[] userDetails)
        {
            SearchByUsername("AutomationUser" + DateTime.Now.ToString("ddMMyyyy"));
            extent.SetStepStatusPass("Entered the username in the search field.");
            VerifyHeaderTextsOnTable();
            VerifyUserDetailsTable(userDetails);
            extent.SetStepStatusPass("Verified all the user details");
        }
        /// <summary>
        /// Add drriver group to user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="driverNAme"></param>
        public void AddDriverGroupsToUser(string userName, string driverNAme)
        {
            SearchByUsername(userName);
            Thread.Sleep(2000);
            wait.Until(driver => KebabMenu.Displayed);
            extent.SetStepStatusPass("Verified that the kebab menu button is displayed.");
            KebabMenu.Click();
            wait.Until(driver => EditFromKebabMenu.Displayed);
            EditFromKebabMenu.Click();
            wait.Until(driver => EditUserHeader.Displayed);
            Thread.Sleep(3000);
            extent.SetStepStatusPass("Verified that the user is redirected to edit user page.");
            try
            {
                ChangeDriverButton.Click();
            }
            catch (NoSuchElementException)
            {
                SelectDriverButton.Click();
            }
            wait.Until(driver => VehicleSelectionHeader.Displayed);
            Assert.IsTrue(VehicleSelectionHeader.Text.Trim().Contains("Choose one or more driver"));
            extent.SetStepStatusPass("Verified that select driver right panel is displayed.");
            selectValue = 2;
            SearchDriver.SendKeys(driverNAme);
            searchKey = driverNAme;
            wait.Until(driver => SearchResult.Displayed);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.checkbox-wrapper.tree-node.entity-deselect-color label");
            Assert.IsTrue(SelectAllButton.Displayed);
            Assert.IsTrue(UnSelectAllButton.Displayed);
            Assert.IsTrue(CancelButton.Displayed);
            Assert.IsTrue(DoneButton.Displayed);
            extent.SetStepStatusPass("Verified the display of different buttons on the right panel.");
            DoneButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => EditUserCancelButton.Enabled);
            Assert.IsTrue(EditUserCancelButton.Displayed);
            EditUserSaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Client updated"));
            extent.SetStepStatusPass("Verified that the success message is displayed");
        }
        /// <summary>
        /// Edit User
        /// </summary>
        public void EditUser(string userName, string role)
        {
            SearchByUsername(userName);
            Thread.Sleep(2000);
            wait.Until(driver => KebabMenu.Displayed);
            extent.SetStepStatusPass("Verified that the kebab menu button is displayed.");
            KebabMenu.Click();
            wait.Until(driver => EditFromKebabMenu.Displayed);
            EditFromKebabMenu.Click();
            wait.Until(driver => EditUserHeader.Displayed);
            Thread.Sleep(6000);
            extent.SetStepStatusPass("Verified that the user is redirected to edit user page.");
            Assert.IsTrue(EditUserHeader.Text.Contains("Edit User"));
            wait.Until(driver => UserNameField.Enabled);
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            js2.ExecuteScript("arguments[0].value = '';", UserNameField);
            UserNameField.Click();
            UserNameField.Clear();
            UserNameField.SendKeys("AutomationUser" + DateTime.Now.ToString("ddMMyyyy") + "Edited");
            FirstNameField.Clear();
            FirstNameField.SendKeys("EditAutomation");
            LastNameField.Clear();
            LastNameField.SendKeys("EditUser");
            EmailField.Clear();
            EmailField.SendKeys("NetStarFleetLiteAutomationedit@gmail.com");
            SelectRole.Click();
            rolevalue = role;
            wait.Until(driver => SelectRoleValue.Displayed);
            SelectRoleValue.Click();
            PhoneNumberField.Clear();
            PhoneNumberField.SendKeys("987654321");
            EditNotesText.Clear();
            EditNotesText.SendKeys("Test Automation Notes Edited");
            ClearVehicleButton.Click();
            wait.Until(driver => SelectVehicleButton.Displayed);
            SelectVehicleButton.Click();
            wait.Until(driver => VehicleSelectionHeader.Displayed);
            Assert.IsTrue(VehicleSelectionHeader.Text.Trim().Contains("Choose one or more vehicle"));
            extent.SetStepStatusPass("Verified that select vehicle right panel is displayed.");
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(adminUser, adminPassword);
            string vehicleName = vehicleTree[1].unitName;
            selectValue = 1;
            SearchVehicle.SendKeys(vehicleName);
            searchKey = vehicleName;
            Thread.Sleep(4000);
            wait.Until(driver => SearchResult.Displayed);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.checkbox-wrapper.tree-node.entity-deselect-color label");
            Assert.IsTrue(SelectAllButton.Displayed);
            Assert.IsTrue(UnSelectAllButton.Displayed);
            Assert.IsTrue(CancelButton.Displayed);
            Assert.IsTrue(DoneButton.Displayed);
            extent.SetStepStatusPass("Verified the display of different buttons on the right panel.");
            DoneButton.Click();
            wait.Until(driver => ChangeVehicleButton.Displayed);
            Assert.IsTrue(ClearVehicleButton.Displayed);
            ClearDriverButton.Click();
            wait.Until(driver => SelectDriverButton.Displayed);
            SelectDriverButton.Click();
            wait.Until(driver => VehicleSelectionHeader.Displayed);
            Assert.IsTrue(VehicleSelectionHeader.Text.Trim().Contains("Choose one or more driver"));
            extent.SetStepStatusPass("Verified that select driver right panel is displayed.");
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(adminUser, adminPassword, true);
            string driverNAme = driverTree[1].driverShortName;
            SearchDriver.SendKeys(driverNAme);
            Thread.Sleep(4000);
            searchKey = driverNAme;
            selectValue = 2;
            wait.Until(driver => SearchResult.Displayed);
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.checkbox-wrapper.tree-node.entity-deselect-color label");
            Assert.IsTrue(SelectAllButton.Displayed);
            Assert.IsTrue(UnSelectAllButton.Displayed);
            Assert.IsTrue(CancelButton.Displayed);
            Assert.IsTrue(DoneButton.Displayed);
            extent.SetStepStatusPass("Verified the display of different buttons on the right panel.");
            DoneButton.Click();
            wait.Until(driver => SelectDriverButton.Displayed);
            //wait.Until(driver => ClearDriverButton.Displayed);
            wait.Until(driver => EditUserCancelButton.Enabled);
            Assert.IsTrue(EditUserCancelButton.Displayed);
            EditUserSaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("Client updated"));
            extent.SetStepStatusPass("Verified that the success message is displayed");
        }
        /// <summary>
        /// Delete User and verify its not displayed anymore
        /// </summary>
        /// <param name="userName"></param>
        public void DeleteUser(string userName)
        {
            SearchByUsername(userName);
            Thread.Sleep(3000);
            wait.Until(driver => KebabMenu.Displayed);
            extent.SetStepStatusPass("Verified that the kebab menu button is displayed.");
            KebabMenu.Click();
            wait.Until(driver => DeleteFromKebabMenu.Displayed);
            DeleteFromKebabMenu.Click();
            wait.Until(driver => DeleteHeading.Displayed);
            Assert.IsTrue(DeleteHeading.Text.Contains("Delete User"));
            Assert.IsTrue(DeleteBody.Text.Contains($"Are you sure to delete the user : EditAutomation EditUser"));
            wait.Until(driver => Deletecancel.Displayed);
            DeleteButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Contains("User deleted"));
            driver.Navigate().Refresh();
            SearchByUsername(userName, true);
        }
        #endregion
    }
}
