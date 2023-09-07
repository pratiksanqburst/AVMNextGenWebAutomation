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
    public class ManageServices : AVMNextGenBase
    {
        IWebDriver manageServicesDriver;
        public ManageServices() { }

        public ManageServices(IWebDriver driver)
        {
            this.manageServicesDriver = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        public string date = string.Empty;
        public string hour = string.Empty;
        public string minute = string.Empty;
        public string serviceType = string.Empty;
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement ServicesLink => driver.FindElement(By.XPath("//span[contains(text(),'Service')]"));
        IWebElement SearchField => driver.FindElement(By.XPath("//input[@data-test-id='service-search-fleet']"));
        IWebElement FirstEntry => driver.FindElement(By.XPath("//button[@data-test-id='entityname']"));
        IWebElement EmptyContentHeading => driver.FindElement(By.XPath("//div[contains(@class,'empty-content')]/h4"));
        IWebElement EmptyContentBody => driver.FindElement(By.XPath("//div[contains(@class,'empty-content')]/p"));
        IWebElement AddServiceButton => driver.FindElement(By.XPath("//button[contains(@class,'plus button')]"));
        IWebElement AddServiceTitle => driver.FindElement(By.XPath("//h4[contains(@class,'modal-title')]"));
        IWebElement DateLabel => driver.FindElement(By.XPath("//label[contains(text(),'Date*')]"));
        IWebElement TimeLabel => driver.FindElement(By.XPath("//label[contains(text(),'Time*')]"));
        IWebElement ServiceTypeLabel => driver.FindElement(By.XPath("//label[contains(text(),'Service Type*')]"));
        IWebElement TotalCostLabel => driver.FindElement(By.XPath("//label[contains(text(),'Total Cost*')]"));
        IWebElement EngineHoursLabel => driver.FindElement(By.XPath("//label[contains(text(),'Engine Hours')]"));
        IWebElement OdometerLabel => driver.FindElement(By.XPath("//label[contains(text(),'Odometer')]"));
        IWebElement NotesLabel => driver.FindElement(By.XPath("//label[contains(text(),'Notes')]"));
        IWebElement DatePickerSelect => driver.FindElement(By.XPath("//button[contains(@aria-label,'Open calendar')]"));
        IWebElement DateSelect => driver.FindElement(By.XPath($"//div[contains(@class,'mat-calendar-body-cell')][text()=' {date} ']"));
        IWebElement TimePickerSelect => driver.FindElement(By.XPath("//time-picker[contains(@formcontrolname,'serviceTime')]"));
        IWebElement HourSelect => driver.FindElement(By.XPath($"//span[@id='hour-{hour}']"));
        IWebElement MinuteSelect => driver.FindElement(By.XPath($"//span[@id='minute-{minute}']"));
        IWebElement AMSelect => driver.FindElement(By.XPath($"//span[contains(text(),'AM')]"));
        IWebElement PMSelect => driver.FindElement(By.XPath($"//span[contains(text(),'PM')]"));
        IWebElement TimePickerOk => driver.FindElement(By.XPath("//button[contains(text(),'OK')]"));
        IWebElement ServiceTypeDropdown => driver.FindElement(By.XPath("//ng-select[@data-test-id='service-add-form-service-type']"));
        IWebElement ServiceTypeOption => driver.FindElement(By.XPath($"//div[contains(@class,'ng-option')]/span[contains(text(),'{serviceType}')]"));
        IWebElement Cost => driver.FindElement(By.XPath($"//input[contains(@formcontrolname,'cost')]"));
        IWebElement Currency => driver.FindElement(By.XPath("//span[contains(text(),'AUD')]"));
        IWebElement EngineHours => driver.FindElement(By.XPath($"//input[contains(@formcontrolname,'engineHours')]"));
        IWebElement EngineHoursUnit => driver.FindElement(By.XPath("//span[contains(text(),'hours')]"));
        IWebElement Odometer => driver.FindElement(By.XPath($"//input[contains(@formcontrolname,'odometer')]"));
        IWebElement OdometerUnit => driver.FindElement(By.XPath("//span[contains(text(),'kms')]"));
        IWebElement Notes => driver.FindElement(By.XPath($"//textarea[contains(@formcontrolname,'notes')]"));
        IWebElement CancelButton => driver.FindElement(By.Id("schedules-cancel-btn"));
        IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement VehicleName => driver.FindElement(By.XPath("//h2[@data-test-id='service-title-vehicle-name']"));
        IWebElement ServiceHistoryDetails => driver.FindElement(By.XPath("//div[@data-test-id='service-title']/p"));
        IWebElement DateTimeField => driver.FindElement(By.XPath("//div[@data-test-id='service-col-date-time']"));
        IWebElement ServiceTypeField => driver.FindElement(By.XPath("//div[@data-test-id='service-col-service-type']"));
        IWebElement CostField => driver.FindElement(By.XPath("//div[@data-test-id='service-col-cost']"));
        IWebElement EngineHoursField => driver.FindElement(By.XPath("//div[@data-test-id='service-col-engine-hours']"));
        IWebElement OdometerField => driver.FindElement(By.XPath("//div[@data-test-id='service-col-odometer']"));
        IWebElement NotesField => driver.FindElement(By.XPath("//div[@data-test-id='service-col-notes']"));
        IWebElement DateTimeValue => driver.FindElement(By.XPath("//div[@data-test-id='service-row-date-time']"));
        IWebElement ServiceTypeValue => driver.FindElement(By.XPath("//div[@data-test-id='service-row-service-type']"));
        IWebElement CostValue => driver.FindElement(By.XPath("//div[@data-test-id='service-row-cost']"));
        IWebElement EngineHoursValue => driver.FindElement(By.XPath("//div[@data-test-id='service-row-engine-hours']"));
        IWebElement OdometerValue => driver.FindElement(By.XPath("//div[@data-test-id='service-row-odometer']"));
        IWebElement NotesValue => driver.FindElement(By.XPath("//div[@data-test-id='service-row-notes']"));
        IWebElement KebabMenu => driver.FindElement(By.XPath("//div[@data-test-id='service-kebab-menu']/span"));
        IWebElement KebabMenuDelete => driver.FindElement(By.XPath("//li[@data-test-id='kebab-menu-delete']"));
        IWebElement KebabMenuEdit => driver.FindElement(By.XPath("//li[@data-test-id='kebab-menu-edit']"));
        IWebElement DeleteModalTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement DeleteClose => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement DeleteModalBody => driver.FindElement(By.XPath("//div[@class='modal-body']/p"));
        IWebElement DeleteCancel => driver.FindElement(By.XPath("//button[contains(text(),'Cancel')]"));
        IWebElement DeleteConfirm => driver.FindElement(By.XPath("//button[contains(text(),'Delete')]"));




        #endregion

        #region Methods
        /// <summary>
        /// Navigate to Manage Services
        /// </summary>
        public void NavigateToManageServices()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            wait.Until(driver => ServicesLink.Displayed);
            ServicesLink.Click();
            wait.Until(driver => SearchField.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the sertvices page is displayed.");
        }
        /// <summary>
        /// Search for a vehcile name from left tree
        /// </summary>
        /// <param name="vehicleName"></param>
        public void SearchVehicle(string vehicleName, bool isPresent = false)
        {
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that Search Field is displayed.");
            SearchField.Clear();
            SearchField.SendKeys(vehicleName);
            Thread.Sleep(2000);
            wait.Until(driver => FirstEntry.Displayed);
            FirstEntry.Click();
            if (isPresent == true)
            {
                wait.Until(driver => VehicleName.Displayed);
                Assert.AreEqual(vehicleName, VehicleName.Text.Trim());
                extent.SetStepStatusPass("Verified that the services are displayed.");
            }
            else
            {
                wait.Until(driver => EmptyContentHeading.Displayed);
                Assert.AreEqual($"You've not added any service history yet for {vehicleName}.", EmptyContentHeading.Text.Trim());
                Assert.AreEqual($"Get started by adding a service history detail", EmptyContentBody.Text.Trim());
                wait.Until(driver => AddServiceButton.Displayed);
                extent.SetStepStatusPass("Verified that the empty contact details are displayed.");
            }
            extent.SetStepStatusPass("Verified that the services page is displayed.");
        }
        /// <summary>
        /// Adds a new service to the given vehicle
        /// </summary>
        public void AddService(string[] serviceDetails, bool isPresent = false)
        {
            SearchVehicle(serviceDetails[0], isPresent);
            AddServiceButton.Click();
            wait.Until(driver => AddServiceTitle.Displayed);
            Assert.AreEqual("Add Service Detail", AddServiceTitle.Text.Trim());
            wait.Until(driver => DateLabel.Displayed);
            wait.Until(driver => TimeLabel.Displayed);
            wait.Until(driver => ServiceTypeLabel.Displayed);
            wait.Until(driver => TotalCostLabel.Displayed);
            wait.Until(driver => EngineHoursLabel.Displayed);
            wait.Until(driver => OdometerLabel.Displayed);
            wait.Until(driver => NotesLabel.Displayed);
            extent.SetStepStatusPass("Verified that the mandatory field labels are displayed in the add service pop up.");
            DatePickerSelect.Click();
            date = serviceDetails[1];
            wait.Until(driver => DateSelect.Displayed);
            DateSelect.Click();
            extent.SetStepStatusPass("Verified that date is selected.");
            TimePickerSelect.Click();
            wait.Until(driver => TimePickerOk.Displayed);
            hour = serviceDetails[2];
            HourSelect.Click();
            Thread.Sleep(2000);
            minute = serviceDetails[3];
            MinuteSelect.Click();
            AMSelect.Click();
            TimePickerOk.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that time is selected.");
            ServiceTypeDropdown.Click();
            serviceType = serviceDetails[4];
            wait.Until(driver => ServiceTypeOption.Displayed);
            ServiceTypeOption.Click();
            extent.SetStepStatusPass("Verified that service type is selected.");
            Cost.Clear();
            Cost.SendKeys(serviceDetails[5]);
            wait.Until(driver => Currency.Displayed);
            extent.SetStepStatusPass("Verified that cost is entered.");
            EngineHours.Clear();
            EngineHours.SendKeys(serviceDetails[6]);
            wait.Until(driver => EngineHoursUnit.Displayed);
            extent.SetStepStatusPass("Verified that engine hours is entered.");
            Odometer.Clear();
            Odometer.SendKeys(serviceDetails[7]);
            wait.Until(driver => OdometerUnit.Displayed);
            extent.SetStepStatusPass("Verified that odometer is entered.");
            Notes.Clear();
            Notes.SendKeys(serviceDetails[8]);
            extent.SetStepStatusPass("Verified that notes is entered.");
            wait.Until(driver => CancelButton.Displayed);
            AddButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Service created successfully", SuccessMessage.Text.Trim());
            extent.SetStepStatusPass("Verified that the service is added.");
        }
        /// <summary>
        /// Edit Service
        /// </summary>
        /// <param name="serviceDetails"></param>
        /// <param name="isPresent"></param>
        public void EditService(string[] serviceDetails, bool isPresent = true)
        {
            SearchVehicle(serviceDetails[0], isPresent);
            Thread.Sleep(5000);
            KebabMenu.Click();
            Thread.Sleep(2000);
            wait.Until(driver => KebabMenuEdit.Displayed);
            KebabMenuEdit.Click();
            wait.Until(driver => AddServiceTitle.Displayed);
            Assert.AreEqual("Edit Service Detail", AddServiceTitle.Text.Trim());
            wait.Until(driver => DateLabel.Displayed);
            wait.Until(driver => TimeLabel.Displayed);
            wait.Until(driver => ServiceTypeLabel.Displayed);
            wait.Until(driver => TotalCostLabel.Displayed);
            wait.Until(driver => EngineHoursLabel.Displayed);
            wait.Until(driver => OdometerLabel.Displayed);
            wait.Until(driver => NotesLabel.Displayed);
            extent.SetStepStatusPass("Verified that the mandatory field labels are displayed in the edit service pop up.");
            DatePickerSelect.Click();
            date = serviceDetails[1];
            wait.Until(driver => DateSelect.Displayed);
            DateSelect.Click();
            extent.SetStepStatusPass("Verified that date is edited.");
            TimePickerSelect.Click();
            wait.Until(driver => TimePickerOk.Displayed);
            hour = serviceDetails[2];
            HourSelect.Click();
            Thread.Sleep(2000);
            minute = serviceDetails[3];
            MinuteSelect.Click();
            AMSelect.Click();
            TimePickerOk.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that time is edited.");
            ServiceTypeDropdown.Click();
            serviceType = serviceDetails[4];
            wait.Until(driver => ServiceTypeOption.Displayed);
            ServiceTypeOption.Click();
            extent.SetStepStatusPass("Verified that service type is edited.");
            Cost.Clear();
            Cost.SendKeys(serviceDetails[5]);
            wait.Until(driver => Currency.Displayed);
            extent.SetStepStatusPass("Verified that cost is edited.");
            EngineHours.Clear();
            EngineHours.SendKeys(serviceDetails[6]);
            wait.Until(driver => EngineHoursUnit.Displayed);
            extent.SetStepStatusPass("Verified that engine hours is edited.");
            Odometer.Clear();
            Odometer.SendKeys(serviceDetails[7]);
            wait.Until(driver => OdometerUnit.Displayed);
            extent.SetStepStatusPass("Verified that odometer is edited.");
            Notes.Clear();
            Notes.SendKeys(serviceDetails[8]);
            extent.SetStepStatusPass("Verified that notes is edited.");
            wait.Until(driver => CancelButton.Displayed);
            AddButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Service updated successfully", SuccessMessage.Text.Trim());
            extent.SetStepStatusPass("Verified that the service is edited.");
        }

        /// <summary>
        /// Verify the service values displayed in the table.
        /// </summary>
        /// <param name="serviceDetails"></param>
        /// <param name="isPresent"></param>
        public void VerifyServiceDetails(string[] serviceDetails, bool isPresent = true)
        {
            SearchVehicle(serviceDetails[0], isPresent);
            wait.Until(driver => ServiceHistoryDetails.Displayed);
            extent.SetStepStatusPass("Verified that the service history details label is displayed.");
            Assert.AreEqual("Date/Time", DateTimeField.Text.Trim());
            Assert.AreEqual("Service Type", ServiceTypeField.Text.Trim());
            Assert.AreEqual("Total Cost", CostField.Text.Trim());
            Assert.AreEqual("Engine Hours", EngineHoursField.Text.Trim());
            Assert.AreEqual("Odometer", OdometerField.Text.Trim());
            Assert.AreEqual("Notes", NotesField.Text.Trim());
            extent.SetStepStatusPass("Verified that the table column names are displayed properly.");
            wait.Until(driver => DateTimeValue.Displayed);
            Assert.AreEqual(serviceDetails[1], DateTimeValue.Text.Trim());
            Assert.AreEqual(serviceDetails[2], ServiceTypeValue.Text.Trim());
            Assert.AreEqual(serviceDetails[3], CostValue.Text.Trim());
            Assert.AreEqual(serviceDetails[4], EngineHoursValue.Text.Trim());
            Assert.AreEqual(serviceDetails[5], OdometerValue.Text.Trim());
            Assert.AreEqual(serviceDetails[6], NotesValue.Text.Trim());
            extent.SetStepStatusPass("Verified that the service details are displayed properly.");
        }
        /// <summary>
        /// Delete Services
        /// </summary>
        /// <param name="vehicleName"></param>
        public void DeleteService(string vehicleName)
        {
            SearchVehicle(vehicleName,true);
            Thread.Sleep(5000);
            KebabMenu.Click();
            Thread.Sleep(2000);
            wait.Until(driver => KebabMenuDelete.Displayed);
            KebabMenuDelete.Click();
            wait.Until(driver => DeleteModalTitle.Displayed);
            extent.SetStepStatusPass("Verified that the delete service popup is displayed properly.");
            Assert.AreEqual("Confirmation", DeleteModalTitle.Text.Trim());
            Assert.AreEqual("Are you sure you want to delete the service entry?", DeleteModalBody.Text.Trim());
            wait.Until(driver => DeleteClose.Displayed);
            wait.Until(driver => DeleteCancel.Displayed);
            extent.SetStepStatusPass("Verified the contents of the delete pop up.");
            DeleteConfirm.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Service deleted successfully", SuccessMessage.Text.Trim());
            SearchVehicle(vehicleName);
            extent.SetStepStatusPass("Verified that the service is deleted.");
        }

        #endregion
    }
}
