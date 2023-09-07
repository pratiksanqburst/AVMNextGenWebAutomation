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
    public class ManageDrivers : AVMNextGenBase
    {
        IWebDriver manageDriver;
        public ManageDrivers() { }

        public ManageDrivers(IWebDriver driver)
        {
            this.manageDriver = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        public string date = string.Empty;
        public string optionValue = string.Empty;
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        //IWebElement ManageTab => driver.FindElement(By.Id("row-drivername"));

        IWebElement Title => driver.FindElement(By.XPath("//h2[contains(text(),'Driver')]"));
        IWebElement ManageDriverTab => driver.FindElement(By.XPath("//div[@id='manage-page']//li[contains(text(),'Driver')]"));
        IWebElement SearchDriverField => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//input[@id='search-field']"));
        IWebElement DriverGroupsSearchHeading => driver.FindElement(By.Id("driver-grps-heading"));
        IWebElement AddDriverGroupButton => driver.FindElement(By.Id("add-driver-grps-btn"));
        IWebElement AddDriverGroupPopupHeading => driver.FindElement(By.Id("modal-title"));
        IWebElement NameLabel => driver.FindElement(By.Id("name-label"));
        IWebElement AddColorLabel => driver.FindElement(By.Id("color-label"));
        IWebElement AddDescriptionLabel => driver.FindElement(By.Id("desc-label"));
        IWebElement ColorLabel => driver.FindElement(By.Id("label-color"));
        IWebElement DescriptionLabel => driver.FindElement(By.Id("label-desc"));
        IWebElement NameInputField => driver.FindElement(By.Id("Name"));
        IWebElement DescriptionInputField => driver.FindElement(By.Id("Description"));
        IWebElement BlueColorSelection => driver.FindElement(By.XPath("//div[contains(@class,'color-circles')]//div[1]"));
        IWebElement RedColorSelection => driver.FindElement(By.XPath("//div[contains(@class,'color-circles')]//div[5]"));
        IWebElement CloseButton => driver.FindElement(By.XPath("//img[@data-test-id='close-delete-user-confirm-popup']"));
        IWebElement CancelButton => driver.FindElement(By.Id("add-groups-cancel-btn"));
        IWebElement AddCloseButton => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement ConfirmButton => driver.FindElement(By.Id("add-groups-create-btn"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement SearchResultText => driver.FindElement(By.Id("search-results-heading"));
        IWebElement SearchResultCount => driver.FindElement(By.Id("manage-drivers-count"));
        IWebElement SearchGroupName => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//span[@id='group-name']"));
        IWebElement SearchGroupCount => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//span[@id='list-count']"));
        IWebElement GroupNameHeading => driver.FindElement(By.XPath("//p[@id='group-name']"));
        IWebElement DriverNumber => driver.FindElement(By.XPath("//p[@id='num-drivers-text']"));
        IWebElement NoDriverText => driver.FindElement(By.Id("no-driver-text"));
        IWebElement GetStartedText => driver.FindElement(By.Id("get-started-text"));
        IWebElement AddDriverButton => driver.FindElement(By.XPath("//div[contains(@class,'empty-content')]//button[@id='add-driver-btn']"));
        IWebElement AddDriverHeading => driver.FindElement(By.Id("add-new-driver-heading"));
        IWebElement EditDriverHeading => driver.FindElement(By.XPath("//h2[contains(text(),'Edit Driver')]"));
        IWebElement DeleteDriverHeading => driver.FindElement(By.XPath("//h4[@class='modal-title']"));
        IWebElement Deletebody => driver.FindElement(By.XPath("//p[@id='modal-body-text']"));
        IWebElement DeleteCancel => driver.FindElement(By.XPath("//button[@data-test-id='btn-cancel-user-confirm-popup']"));
        IWebElement DeleteSave => driver.FindElement(By.XPath("//button[@data-test-id='btn-delete-user-confirm-popup']"));



        IWebElement FirstNameLabel => driver.FindElement(By.Id("first-name-label"));
        IWebElement FirstNameField => driver.FindElement(By.Id("first-name-field"));
        IWebElement LastNameLabel => driver.FindElement(By.Id("last-name-label"));
        IWebElement LastNameField => driver.FindElement(By.Id("last-name-field"));
        IWebElement EmailLabel => driver.FindElement(By.Id("email-label"));
        IWebElement EmailField => driver.FindElement(By.Id("email-field"));
        IWebElement PhoneLabel => driver.FindElement(By.Id("phone-label"));
        IWebElement PhoneField => driver.FindElement(By.Id("phone-field"));
        IWebElement AddressLabel => driver.FindElement(By.Id("address-label"));
        IWebElement AddressField => driver.FindElement(By.Id("address-field"));
        IWebElement UniqueIdLabel => driver.FindElement(By.Id("unique-id-label"));
        IWebElement UniqueIdField => driver.FindElement(By.Id("unique-id-field"));
        IWebElement DriverIdLabel => driver.FindElement(By.Id("driverid-label"));
        IWebElement DriverIdField => driver.FindElement(By.Id("driverid-field"));
        IWebElement LicenseNumberLabel => driver.FindElement(By.Id("license-number-label"));
        IWebElement LicenseNumberField => driver.FindElement(By.Id("license-number-field"));
        IWebElement LicenseExpiryLabel => driver.FindElement(By.Id("license-exp-label"));
        IWebElement LicenseExpiryField => driver.FindElement(By.Id("license-exp-field"));
        IWebElement LicenseStateLabel => driver.FindElement(By.Id("license-state-label"));
        IWebElement LicenseStateField => driver.FindElement(By.Id("license-state-field"));
        IWebElement DateJoinedLabel => driver.FindElement(By.Id("date-joined-label"));
        IWebElement DateJoinedField => driver.FindElement(By.Id("date-joined-field"));

        IWebElement ChooseYear => driver.FindElement(By.XPath($"//button[@aria-label='Choose month and year']"));
        IWebElement ChoosePreviuosYear => driver.FindElement(By.XPath($"//button[@aria-label='Previous 24 years']"));
        IWebElement DateSelect => driver.FindElement(By.XPath($"//div[contains(@class,'mat-calendar-body-cell')][text()=' {date} ']"));
        IWebElement DobLabel => driver.FindElement(By.Id("dob-label"));
        IWebElement DobField => driver.FindElement(By.Id("dob-field"));
        IWebElement NationalityLabel => driver.FindElement(By.Id("nationality-label"));
        IWebElement NationalityField => driver.FindElement(By.Id("nationality-field"));
        IWebElement FieldOption => driver.FindElement(By.XPath($"//span[contains(@class,'ng-option')][contains(text(),'{optionValue}')]"));
        IWebElement GenderLabel => driver.FindElement(By.Id("gender-label"));
        IWebElement GenderField => driver.FindElement(By.Id("gender-field"));
        IWebElement GenderFieldOption => driver.FindElement(By.XPath("//div[@id='gender-field-panel']/mat-option[1]"));
        IWebElement BloodTypeLabel => driver.FindElement(By.Id("bloodtype-label"));
        IWebElement BloodTypeField => driver.FindElement(By.Id("bloodtype-field"));
        IWebElement BloodTypeFieldOption => driver.FindElement(By.XPath("//div[@id='bloodtype-field-panel']/mat-option[1]"));
        IWebElement ContactNameLabel => driver.FindElement(By.Id("emergency-contactname-label"));
        IWebElement ContactNameField => driver.FindElement(By.Id("emergency-contactname-field"));
        IWebElement ContactRelationLabel => driver.FindElement(By.Id("emergency-contactrltnshp-label"));
        IWebElement ContactRelationField => driver.FindElement(By.Id("emergency-contactrltnshp-field"));
        IWebElement ContactPhoneLabel => driver.FindElement(By.Id("emergency-contactphn-label"));
        IWebElement ContactPhoneField => driver.FindElement(By.Id("emergency-contactphn-field"));
        IWebElement VehicleText => driver.FindElement(By.Id("vehicle-text"));
        IWebElement UnassignedText => driver.FindElement(By.Id("unassigned-text"));
        IWebElement UnassignedEditText => driver.FindElement(By.Id("vehicle-name"));
        IWebElement VehicleImage => driver.FindElement(By.Id("vehicle-img"));
        IWebElement AssignVehicle => driver.FindElement(By.XPath("//button[@id='assign'][contains(text(),'Vehicle')]"));
        IWebElement SearchVehicles => driver.FindElement(By.XPath("//avm-tree-view//input[@id='search-field']"));
        IWebElement SearchResultSelect => driver.FindElement(By.XPath("//button[@data-test-id='entityname']/parent::label"));
        IWebElement RightCancel => driver.FindElement(By.XPath("//avm-tree-view//button[@id='right-panel-cancel-btn']"));
        IWebElement RightDone => driver.FindElement(By.XPath("//avm-tree-view//button[@id='right-panel-done-btn']"));
        IWebElement RightDriverCancel => driver.FindElement(By.Id("right-panel-cancel-btn"));
        IWebElement RightDriverDone => driver.FindElement(By.Id("right-panel-done-btn"));
        IWebElement AssignGroup => driver.FindElement(By.XPath("//button[@id='assign'][contains(text(),'Group')]"));
        IWebElement SearchGroup => driver.FindElement(By.Id("search-field"));
        IWebElement SelectGroup => driver.FindElement(By.XPath("//div[contains(@class,'right-panel')]//span[@id='group-name']"));
        IWebElement CancelButtonAssign => driver.FindElement(By.Id("cancel-btn"));
        IWebElement SaveButtonAssign => driver.FindElement(By.Id("save-btn"));
        IWebElement DriverNameHeading => driver.FindElement(By.Id("col-drivername"));
        IWebElement PhoneNumberHeading => driver.FindElement(By.Id("col-phno"));
        IWebElement GroupHeading => driver.FindElement(By.Id("col-group"));
        IWebElement VehicleHeading => driver.FindElement(By.Id("col-vehicle"));
        IWebElement DriverNameValue => driver.FindElement(By.Id("row-drivername"));
        IWebElement PhoneValue => driver.FindElement(By.Id("row-phno"));
        IWebElement GroupValue => driver.FindElement(By.Id("row-group"));
        IWebElement VehicleValue => driver.FindElement(By.Id("row-vehicle"));
        IWebElement EditOption => driver.FindElement(By.Id("edit-option"));
        IWebElement DeleteOption => driver.FindElement(By.Id("delete-option"));
        IWebElement AssignGroupButton => driver.FindElement(By.Id("assign-group-option"));
        IWebElement AssignVehicleButton => driver.FindElement(By.Id("assign-vehicle-option"));
        IWebElement KebabMenu => driver.FindElement(By.Id("kebab-menu"));
        IWebElement RightPanelHeader => driver.FindElement(By.XPath("//div[@id='right-panel-tree-header']/p"));
        IWebElement EditIconRightPanel => driver.FindElement(By.Id("details-edit-icon"));
        IWebElement DeleteIconRightPanel => driver.FindElement(By.Id("details-delete-icon"));
        IWebElement VehcileDetailsLabel => driver.FindElement(By.Id("details-label"));
        IWebElement VehicleNameRight => driver.FindElement(By.Id("driver-vehicle-name"));
        IWebElement AssignVehicleRight => driver.FindElement(By.Id("assign-vehicle-btn"));
        IWebElement DriverGroupLabel => driver.FindElement(By.Id("driver-group"));
        IWebElement DriverGroupName => driver.FindElement(By.Id("driver-group-name"));
        IWebElement AssignGroupButtonRight => driver.FindElement(By.Id("assign-group-btn"));
        IWebElement RightEmailLabel => driver.FindElement(By.Id("email-label"));
        IWebElement RightEmailValue => driver.FindElement(By.Id("email-field"));
        IWebElement RightPhoneLabel => driver.FindElement(By.Id("phone-label"));
        IWebElement RightPhoneValue => driver.FindElement(By.Id("phone-field"));
        IWebElement RightAddressLabel => driver.FindElement(By.Id("address-label"));
        IWebElement RightAddressValue => driver.FindElement(By.Id("address-field"));
        IWebElement RightUniqueIdLabel => driver.FindElement(By.Id("unique-id-label"));
        IWebElement RightUniqueIdValue => driver.FindElement(By.Id("unique-id-field"));
        IWebElement RightDriverIdLabel => driver.FindElement(By.Id("driver-id-label"));
        IWebElement RightDriverIdValue => driver.FindElement(By.Id("driver-id-field"));
        IWebElement RightLicenseLabel => driver.FindElement(By.Id("license-num-label"));
        IWebElement RightLicenseValue => driver.FindElement(By.Id("license-num-field"));
        IWebElement RightLicenseExpiryLabel => driver.FindElement(By.Id("license-expiry-label"));
        IWebElement RightLicenseExpiryValue => driver.FindElement(By.Id("license-expiry-field"));
        IWebElement RightLicenseStateLabel => driver.FindElement(By.Id("license-state-label"));
        IWebElement RightLicenseStateValue => driver.FindElement(By.Id("license-state-field"));
        IWebElement RightDateJoinedLabel => driver.FindElement(By.Id("date-joined-label"));
        IWebElement RightDateJoinedValue => driver.FindElement(By.Id("date-joined-field"));
        IWebElement ModalHeading => driver.FindElement(By.Id("modal-title"));
        IWebElement ModalBodyText => driver.FindElement(By.Id("modal-body-text"));
        IWebElement ModalCancelButton => driver.FindElement(By.XPath("//button[@data-test-id='btn-cancel-user-confirm-popup']"));
        IWebElement ModalConfirmButton => driver.FindElement(By.XPath("//button[@data-test-id='btn-delete-user-confirm-popup']"));
        IWebElement EditGroupButton => driver.FindElement(By.Id("group-edit-icon"));
        IWebElement DeleteGroupButton => driver.FindElement(By.Id("group-delete-icon"));

        #endregion

        #region Methods
        /// <summary>
        /// Verify the contents on the driver right panel
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="driverDetails"></param>
        public void VerifyDriverRightPanel(string groupName, string[] driverDetails)
        {
            SearchDriverGroup(groupName, 1);
            wait.Until(driver => DriverNameHeading.Displayed);
            wait.Until(driver => DriverNameValue.Displayed);
            DriverNameValue.Click();
            Thread.Sleep(3000);
            wait.Until(driver => RightPanelHeader.Displayed);
            Assert.AreEqual(driverDetails[0], RightPanelHeader.Text.Trim());
            wait.Until(driver => EditIconRightPanel.Displayed);
            wait.Until(driver => DeleteIconRightPanel.Displayed);
            Assert.AreEqual("Vehicle", VehcileDetailsLabel.Text.Trim());
            Assert.AreEqual(driverDetails[1], VehicleNameRight.Text.Trim());
            Assert.AreEqual("Driver Group", DriverGroupLabel.Text.Trim());
            Assert.AreEqual(driverDetails[2], DriverGroupName.Text.Trim());
            Assert.AreEqual("Email Address", RightEmailLabel.Text.Trim());
            Assert.AreEqual(driverDetails[3], RightEmailValue.Text.Trim());
            Assert.AreEqual("Phone Number", RightPhoneLabel.Text.Trim());
            Assert.AreEqual(driverDetails[4], RightPhoneValue.Text.Trim());
            Assert.AreEqual("Address", RightAddressLabel.Text.Trim());
            Assert.AreEqual(driverDetails[5], RightAddressValue.Text.Trim());
            Assert.AreEqual("Unique ID", RightUniqueIdLabel.Text.Trim());
            Assert.AreEqual(driverDetails[6], RightUniqueIdValue.Text.Trim());
            Assert.AreEqual("Driver ID Tag", RightDriverIdLabel.Text.Trim());
            Assert.AreEqual(driverDetails[7], RightDriverIdValue.Text.Trim());
            Assert.AreEqual("License Number", RightLicenseLabel.Text.Trim());
            Assert.AreEqual(driverDetails[8], RightLicenseValue.Text.Trim());
            Assert.AreEqual("License Expiry", RightLicenseExpiryLabel.Text.Trim());
            Assert.AreEqual(driverDetails[9], RightLicenseExpiryValue.Text.Trim());
            Assert.AreEqual("License State", RightLicenseStateLabel.Text.Trim());
            Assert.AreEqual(driverDetails[10], RightLicenseStateValue.Text.Trim());
            Assert.AreEqual("Date Joined", RightDateJoinedLabel.Text.Trim());
            Assert.AreEqual(driverDetails[11], RightDateJoinedValue.Text.Trim());
            extent.SetStepStatusPass("Verified the details displayed on the right panel.");
            driver.Navigate().Refresh();
            wait.Until(driver => SearchDriverField.Displayed);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Navigate to manage driver tab
        /// </summary>
        public void NavigateToManageDriver()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            Thread.Sleep(3000);
            wait.Until(driver => SearchDriverField.Displayed);
            extent.SetStepStatusPass("Verified that the search field is displayed.");
        }
        /// <summary>
        /// Add driver group
        /// </summary>
        /// <param name="groupName"></param>
        public void AddDriverGroup(string groupName)
        {
            wait.Until(driver => AddDriverGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that add driver group button is displayed.");
            AddDriverGroupButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AddDriverGroupPopupHeading.Displayed);
            Assert.AreEqual("Add Driver Group", AddDriverGroupPopupHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that add driver group modal is displayed.");
            Assert.AreEqual("Name*", NameLabel.Text.Trim());
            Assert.AreEqual("Description", AddDescriptionLabel.Text.Trim());
            Assert.AreEqual("Color", AddColorLabel.Text.Trim());
            NameInputField.SendKeys(groupName);
            DescriptionInputField.SendKeys("Automation Description");
            BlueColorSelection.Click();
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => AddCloseButton.Displayed);
            ConfirmButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Driver Group Added Successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that driver group is added.");
        }
        /// <summary>
        /// Searches for the group in left menu.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="count"></param>
        public void SearchDriverGroup(string groupName, int count = 0)
        {
            wait.Until(driver => SearchDriverField.Displayed);
            extent.SetStepStatusPass("Verified that search field is displayed.");
            SearchDriverField.Clear();
            SearchDriverField.SendKeys(groupName);
            Thread.Sleep(2000);
            wait.Until(driver => SearchResultText.Displayed);
            int resultCount = Convert.ToInt32(SearchResultCount.Text);
            if (resultCount > 0)
            {
                Assert.AreEqual(groupName, SearchGroupName.Text.Trim());
                Assert.AreEqual(count.ToString(), SearchGroupCount.Text.Trim());
                extent.SetStepStatusPass("Verified that group name and count is displayed in left panel.");
                SearchGroupName.Click();
                Thread.Sleep(2000);
                wait.Until(driver => GroupNameHeading.Displayed);
                Assert.AreEqual(groupName, GroupNameHeading.Text.Trim());
                Assert.AreEqual("Number of drivers:  " + count.ToString(), DriverNumber.Text.Trim());
                if (count == 0)
                {
                    wait.Until(driver => NoDriverText.Displayed);
                    Assert.AreEqual("No driver in this group", NoDriverText.Text.Trim());
                    Assert.AreEqual("Get started by adding a driver to this group", GetStartedText.Text.Trim());
                }
                extent.SetStepStatusPass("Verified that group name and count is displayed in mid panel.");
            }
            else
            {
                extent.SetStepStatusPass("Verified that search result is empty.");
            }
        }
        /// <summary>
        /// Edit the driver group details
        /// </summary>
        /// <param name="groupName"></param>
        public void EditDriverGroup(string groupName)
        {
            wait.Until(driver => EditGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that edit driver group button is displayed.");
            EditGroupButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AddDriverGroupPopupHeading.Displayed);
            Assert.AreEqual("Edit Driver Group", AddDriverGroupPopupHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that edit driver group modal is displayed.");
            Assert.AreEqual("Name*", NameLabel.Text.Trim());
            Assert.AreEqual("Description", DescriptionLabel.Text.Trim());
            Assert.AreEqual("Color", ColorLabel.Text.Trim());
            NameInputField.Clear();
            NameInputField.SendKeys(groupName);
            DescriptionInputField.Clear();
            DescriptionInputField.SendKeys("Automation Description edited");
            RedColorSelection.Click();
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => AddCloseButton.Displayed);
            ConfirmButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Driver Group Edited Successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that driver group is edited.");
        }
        /// <summary>
        /// Delete Driver Group
        /// </summary>
        /// <param name="groupName"></param>
        public void DeleteDriverGroup(string groupName)
        {
            SearchDriverGroup(groupName);
            wait.Until(driver => DeleteGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that delete driver group button is displayed.");
            DeleteGroupButton.Click();
            wait.Until(driver => ModalHeading.Displayed);
            Assert.AreEqual("Delete Driver Group", ModalHeading.Text.Trim());
            Assert.AreEqual("Deleting a driver group does not delete the drivers in it. The drivers will be relocated to the 'Ungrouped' category. Do you want to delete this group?", ModalBodyText.Text.Trim());
            wait.Until(driver => CloseButton.Displayed);
            wait.Until(driver => ModalCancelButton.Displayed);
            extent.SetStepStatusPass("Verified the delete modal contents.");
            ModalConfirmButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Driver group deleted", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            SearchDriverGroup(groupName);
            extent.SetStepStatusPass("Verified that delete contact group is working as expected.");
        }
        /// <summary>
        /// Adds a new driver to the group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="driverDetails"></param>
        public void AddDriver(string groupName, string[] driverDetails)
        {
            SearchDriverGroup(groupName);
            wait.Until(driver => AddDriverButton.Displayed);
            AddDriverButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AddDriverHeading.Displayed);
            extent.SetStepStatusPass("Verified that add contact button is displayed.");
            Assert.AreEqual("Add New Driver", AddDriverHeading.Text.Trim());
            Assert.AreEqual("First Name*", FirstNameLabel.Text.Trim());
            Assert.AreEqual("Last Name*", LastNameLabel.Text.Trim());
            Assert.AreEqual("Email*", EmailLabel.Text.Trim());
            Assert.AreEqual("Phone*", PhoneLabel.Text.Trim());
            Assert.AreEqual("Address", AddressLabel.Text.Trim());
            Assert.AreEqual("Unique ID", UniqueIdLabel.Text.Trim());
            Assert.AreEqual("Driver ID Tag", DriverIdLabel.Text.Trim());
            Assert.AreEqual("License Number", LicenseNumberLabel.Text.Trim());
            Assert.AreEqual("License Expiry", LicenseExpiryLabel.Text.Trim());
            Assert.AreEqual("License State", LicenseStateLabel.Text.Trim());
            Assert.AreEqual("Date Joined", DateJoinedLabel.Text.Trim());
            //Assert.AreEqual("Date of Birth", DobLabel.Text.Trim());
            //Assert.AreEqual("Nationality", NationalityLabel.Text.Trim());
            //Assert.AreEqual("Gender", GenderLabel.Text.Trim());
            //Assert.AreEqual("Blood Type", BloodTypeLabel.Text.Trim());
            //Assert.AreEqual("Emergency Contact Name", ContactNameLabel.Text.Trim());
            //Assert.AreEqual("Emergency Contact Relationship", ContactRelationLabel.Text.Trim());
            //Assert.AreEqual("Emergency Contact Phone No.", ContactPhoneLabel.Text.Trim());
            Assert.AreEqual("Vehicle", VehicleText.Text.Trim());
            Assert.AreEqual("Unassigned", UnassignedText.Text.Trim());
            wait.Until(driver => VehicleImage.Displayed);
            wait.Until(driver => AssignVehicle.Displayed);
            wait.Until(driver => AssignGroup.Displayed);
            extent.SetStepStatusPass("Verified that the mandatory fields are displayed.");
            Thread.Sleep(2000);
            FirstNameField.SendKeys(driverDetails[0]);
            LastNameField.SendKeys(driverDetails[1]);
            EmailField.SendKeys(driverDetails[2]);
            PhoneField.SendKeys(driverDetails[3]);
            AddressField.SendKeys(driverDetails[4]);
            UniqueIdField.SendKeys(driverDetails[5]);
            LicenseNumberField.SendKeys(driverDetails[6]);
            LicenseStateField.SendKeys(driverDetails[7]);
            //NationalityField.Click();
            //optionValue = driverDetails[8];
            //FieldOption.Click();
            //optionValue = driverDetails[9];
            //GenderField.Click();
            //FieldOption.Click();
            //optionValue = driverDetails[10];
            //BloodTypeField.Click();
            //FieldOption.Click();
            //ContactNameField.SendKeys(driverDetails[11]);
            //ContactRelationField.SendKeys(driverDetails[12]);
            //ContactPhoneField.SendKeys(driverDetails[13]);
            LicenseExpiryField.Click();
            SelectDateFromCalender(driverDetails[14]);
            DateJoinedField.Click();
            SelectDateFromCalender(driverDetails[15]);
            //DobField.Click();
            //SelectDateFromCalender(driverDetails[16]);
            AssignVehicle.Click();
            Thread.Sleep(2000);
            wait.Until(driver => SearchVehicles.Displayed);
            SearchVehicles.Clear();
            SearchVehicles.SendKeys(driverDetails[17]);
            Thread.Sleep(1000);
            //Actions build = new Actions(driver);
            //build.MoveToElement(SearchResultSelect).Click().Build().Perform(); ;
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.checkbox-wrapper.tree-node.entity-deselect-color label");
            SearchResultSelect.Click();
            wait.Until(driver => RightCancel.Displayed);
            RightDone.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(driverDetails[17], UnassignedText.Text.Trim());
            AssignGroup.Click();
            Thread.Sleep(2000);
            wait.Until(driver => SearchGroup.Displayed);
            SearchGroup.Clear();
            SearchGroup.SendKeys(groupName);
            Thread.Sleep(1000);
            SelectGroup.Click();
            wait.Until(driver => RightDriverDone.Displayed);
            Thread.Sleep(2000);
            RightDriverCancel.Click();
            Thread.Sleep(2000);
            wait.Until(driver => CancelButtonAssign.Displayed);
            SaveButtonAssign.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Driver added successfully", SuccessMessage.Text.Trim());
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the driver is added correctly.");
        }
        /// <summary>
        /// Verifies the driver details displayed on the middle panel
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="driverDetails"></param>
        public void VerifyDriverDetails(string groupName, string[] driverDetails)
        {
            SearchDriverGroup(groupName, 1);
            wait.Until(driver => DriverNameHeading.Displayed);
            Assert.AreEqual("Driver Name", DriverNameHeading.Text.Trim());
            Assert.AreEqual("Phone Number", PhoneNumberHeading.Text.Trim());
            Assert.AreEqual("Group", GroupHeading.Text.Trim());
            Assert.AreEqual("Vehicle", VehicleHeading.Text.Trim());
            Assert.AreEqual(driverDetails[0], DriverNameValue.Text.Trim());
            Assert.AreEqual(driverDetails[1], PhoneValue.Text.Trim());
            Assert.AreEqual(driverDetails[2], GroupValue.Text.Trim());
            Assert.AreEqual(driverDetails[3], VehicleValue.Text.Trim());
            extent.SetStepStatusPass("Verified that the driver details are displayed properly.");
        }

        /// <summary>
        /// Edit driver to the group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="driverDetails"></param>
        public void EditDriver(string groupName, string[] driverDetails)
        {
            SearchDriverGroup(groupName, 1);
            wait.Until(driver => KebabMenu.Displayed);
            KebabMenu.Click();
            wait.Until(driver => EditOption.Displayed);
            EditOption.Click();
            Thread.Sleep(2000);
            wait.Until(driver => EditDriverHeading.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that add contact button is displayed.");
            Assert.AreEqual("Edit Driver", EditDriverHeading.Text.Trim());
            Assert.AreEqual("First Name*", FirstNameLabel.Text.Trim());
            Assert.AreEqual("Last Name*", LastNameLabel.Text.Trim());
            Assert.AreEqual("Email*", EmailLabel.Text.Trim());
            Assert.AreEqual("Phone*", PhoneLabel.Text.Trim());
            Assert.AreEqual("Address", AddressLabel.Text.Trim());
            Assert.AreEqual("Unique ID", UniqueIdLabel.Text.Trim());
            Assert.AreEqual("Driver ID Tag", DriverIdLabel.Text.Trim());
            Assert.AreEqual("License Number", LicenseNumberLabel.Text.Trim());
            Assert.AreEqual("License Expiry", LicenseExpiryLabel.Text.Trim());
            Assert.AreEqual("License State", LicenseStateLabel.Text.Trim());
            //Assert.AreEqual("Date Joined", DateJoinedLabel.Text.Trim());
            //Assert.AreEqual("Date of Birth", DobLabel.Text.Trim());
            //Assert.AreEqual("Nationality", NationalityLabel.Text.Trim());
            //Assert.AreEqual("Gender", GenderLabel.Text.Trim());
            //Assert.AreEqual("Blood Type", BloodTypeLabel.Text.Trim());
            //Assert.AreEqual("Emergency Contact Name", ContactNameLabel.Text.Trim());
            //Assert.AreEqual("Emergency Contact Relationship", ContactRelationLabel.Text.Trim());
            //Assert.AreEqual("Emergency Contact Phone No.", ContactPhoneLabel.Text.Trim());
            Assert.AreEqual("Vehicle", VehicleText.Text.Trim());
            wait.Until(driver => AssignVehicle.Displayed);
            wait.Until(driver => AssignGroup.Displayed);
            extent.SetStepStatusPass("Verified that the mandatory fields are displayed.");
            FirstNameField.Clear();
            FirstNameField.SendKeys(driverDetails[0]);
            Thread.Sleep(500);
            LastNameField.Clear();
            LastNameField.SendKeys(driverDetails[1]);
            Thread.Sleep(500);
            EmailField.Clear();
            EmailField.SendKeys(driverDetails[2]);
            Thread.Sleep(500);
            PhoneField.Clear();
            PhoneField.SendKeys(driverDetails[3]);
            Thread.Sleep(500);
            AddressField.Clear();
            AddressField.SendKeys(driverDetails[4]);
            Thread.Sleep(500);
            UniqueIdField.Clear();
            UniqueIdField.SendKeys(driverDetails[5]);
            Thread.Sleep(500);
            LicenseNumberField.Clear();
            LicenseNumberField.SendKeys(driverDetails[6]);
            Thread.Sleep(500);
            LicenseStateField.Clear();
            LicenseStateField.SendKeys(driverDetails[7]);
            Thread.Sleep(500);
            //NationalityField.Click();
            //Thread.Sleep(500);
            //optionValue = driverDetails[8];
            //FieldOption.Click();
            //Thread.Sleep(500);
            //optionValue = driverDetails[9];
            //GenderField.Click();
            //Thread.Sleep(500);
            //FieldOption.Click();
            //Thread.Sleep(500);
            //optionValue = driverDetails[10];
            //BloodTypeField.Click();
            //Thread.Sleep(500);
            //FieldOption.Click();
            //Thread.Sleep(500);
            //ContactNameField.Clear();
            //ContactNameField.SendKeys(driverDetails[11]);
            //Thread.Sleep(500);
            //ContactRelationField.Clear();
            //ContactRelationField.SendKeys(driverDetails[12]);
            //Thread.Sleep(500);
            //ContactPhoneField.Clear();
            //ContactPhoneField.SendKeys(driverDetails[13]);
            Thread.Sleep(500);
            LicenseExpiryField.Click();
            SelectDateFromCalender(driverDetails[14]);
            DateJoinedField.Click();
            Thread.Sleep(500);
            SelectDateFromCalender(driverDetails[15]);
            //DobField.Click();
            //Thread.Sleep(500);
            //SelectDateFromCalender(driverDetails[16]);
            AssignVehicle.Click();
            Thread.Sleep(2000);
            AssignVehicle.Click();
            Thread.Sleep(3000);
            wait.Until(driver => AssignVehicle.Displayed);
            SearchVehicles.Clear();
            SearchVehicles.SendKeys(driverDetails[17]);
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.checkbox-wrapper.tree-node.entity-deselect-color label");
            wait.Until(driver => RightCancel.Displayed);
            RightDone.Click();
            Thread.Sleep(1000);
            Assert.AreEqual(driverDetails[17], UnassignedEditText.Text.Trim());
            AssignGroup.Click();
            Thread.Sleep(3000);
            wait.Until(driver => SearchGroup.Displayed);
            SearchGroup.Clear();
            SearchGroup.SendKeys(groupName);
            Thread.Sleep(1000);
            SelectGroup.Click();
            wait.Until(driver => RightDriverCancel.Displayed);
            RightDriverCancel.Click();
            Thread.Sleep(1000);
            wait.Until(driver => CancelButtonAssign.Displayed);
            SaveButtonAssign.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Driver edited successfully", SuccessMessage.Text.Trim());
            Thread.Sleep(4000);
            extent.SetStepStatusPass("Verified that the driver is edited correctly.");
        }
        /// <summary>
        /// Delete the driver present within the group
        /// </summary>
        /// <param name="groupName"></param>
        public void DeleteDriver(string groupName, int count = 0)
        {
            SearchDriverGroup(groupName, count);
            wait.Until(driver => KebabMenu.Displayed);
            KebabMenu.Click();
            wait.Until(driver => DeleteOption.Displayed);
            DeleteOption.Click();
            wait.Until(driver => DeleteDriverHeading.Displayed);
            Assert.AreEqual("Delete Driver", DeleteDriverHeading.Text.Trim());
            Assert.AreEqual("Deleting a driver will remove the driver from the application including all" +
                " details, any vehicles that the driver was assigned to will have unassigned driver.", Deletebody.Text.Trim());
            wait.Until(driver => DeleteCancel.Displayed);
            DeleteSave.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Driver deleted", SuccessMessage.Text.Trim());
            Thread.Sleep(4000);
            extent.SetStepStatusPass("Verified that the driver is edited correctly.");
        }




        /// <summary>
        /// Selects the date from calender
        /// </summary>
        /// <param name="dateValue"></param>
        public void SelectDateFromCalender(string dateValue)
        {
            DateTime dateTime = Convert.ToDateTime(dateValue);
            string day = dateTime.Day.ToString();
            string month = dateTime.ToString("MMM").ToUpper();
            string year = dateTime.ToString("yyyy");
            if (dateTime.Year != DateTime.Now.Year || dateTime.Month != DateTime.Now.Month)
            {
                ChooseYear.Click();
                Thread.Sleep(1000);
                if (dateTime.Year < 2016)
                    ChoosePreviuosYear.Click();
                Thread.Sleep(1000);
                date = year;
                DateSelect.Click();
                Thread.Sleep(1000);
                date = month;
                DateSelect.Click();
            }
            Thread.Sleep(1000);
            date = day;
            DateSelect.Click();
            Thread.Sleep(1000);
        }

        #endregion
    }
}
