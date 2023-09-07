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
    public class ManageFBT : AVMNextGenBase
    {
        IWebDriver manageFBT;
        public ManageFBT() { }

        public ManageFBT(IWebDriver driver)
        {
            this.manageFBT = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        string buisinessReason = string.Empty;
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement ManageFBTTab => driver.FindElement(By.XPath("//li[contains(text(),'FBT')]"));
        IWebElement SearchVehicles => driver.FindElement(By.XPath("//input[@placeholder='Search Fleet']"));
        IWebElement SearchResult => driver.FindElement(By.XPath("//button[@data-test-id='entityname']"));
        IWebElement VehicleNameTitle => driver.FindElement(By.XPath("//div[@class='title']/h2"));
        IWebElement HeaderText => driver.FindElement(By.XPath("//div[@class='title']/p"));
        IWebElement UnassignedTabActive => driver.FindElement(By.XPath("//li[contains(text(),'Unassigned Trips')][@class='active']"));
        IWebElement AssignedTabActive => driver.FindElement(By.XPath("//li[contains(text(),'Assigned Trips')][@class='active']"));
        IWebElement UnassignedTab => driver.FindElement(By.XPath("//li[contains(text(),'Unassigned Trips')]"));
        IWebElement AssignedTab => driver.FindElement(By.XPath("//li[contains(text(),'Assigned Trips')]"));
        IWebElement StartDateColumn => driver.FindElement(By.XPath("//div[contains(text(),'Start Date/Time')]"));
        IWebElement StopDateColumn => driver.FindElement(By.XPath("//div[contains(text(),'Stop Date/Time')]"));
        IWebElement DistanceColumn => driver.FindElement(By.XPath("//div[contains(text(),'Distance')]"));
        IWebElement StartAddressColumn => driver.FindElement(By.XPath("//div[contains(text(),'Start Address')]"));
        IWebElement StopAddressColumn => driver.FindElement(By.XPath("//div[contains(text(),'Stop Address')]"));
        IWebElement DriverColumn => driver.FindElement(By.XPath("//div[contains(text(),'Driver')]"));
        IWebElement FirstElementCheckbox => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[1]//span"));
        IWebElement StartDateColumnValue => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[2]"));
        IWebElement StopDateColumnValue => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[3]"));
        IWebElement DistanceColumnValue => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[4]"));
        IWebElement StartAddressColumnValue => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[5]"));
        IWebElement StopAddressColumnValue => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[6]"));
        IWebElement DriverColumnValue => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[7]"));
        IWebElement TypeColumnValue => driver.FindElement(By.XPath("//div[@class='flex-table-wrapper fbt-table']/div[2]/div[1]/div[8]"));
        IWebElement RightPanelHeader => driver.FindElement(By.XPath("//div[@id='right-panel-tree-header']/div[1]/div"));
        IWebElement RighrCloseButton => driver.FindElement(By.Id("panel-close-btn"));
        IWebElement VehicleIDText => driver.FindElement(By.XPath("//p[@class='fbt-vehicle-id-wrap']"));
        IWebElement StartTimeRight => driver.FindElement(By.XPath("//label[contains(text(),'Start Date/Time')]/following-sibling::p"));
        IWebElement StopTimeRight => driver.FindElement(By.XPath("//label[contains(text(),'Stop Date/Time')]/following-sibling::p"));
        IWebElement StartAddressRight => driver.FindElement(By.XPath("//label[contains(text(),'Start Address')]/following-sibling::p"));
        IWebElement StopAddressRight => driver.FindElement(By.XPath("//label[contains(text(),'Stop Address')]/following-sibling::p"));
        IWebElement DistanceValueRight => driver.FindElement(By.XPath("//label[contains(text(),'Distance')]/following-sibling::p"));
        IWebElement TypeValueRight => driver.FindElement(By.XPath("//label[contains(text(),'Type')]/following-sibling::p"));
        IWebElement BusinessRadio => driver.FindElement(By.XPath("//input[@id='business']/following-sibling::label"));
        IWebElement PrivateRadio => driver.FindElement(By.XPath("//input[@id='personal']/following-sibling::label"));
        IWebElement ReasonDropdown => driver.FindElement(By.XPath("//label[contains(text(),'Select Reason')]/following-sibling::ng-select"));
        IWebElement ReasonDropdownSelect => driver.FindElement(By.XPath($"//span[contains(text(),'{buisinessReason}')]"));
        IWebElement RightPanelCancel => driver.FindElement(By.Id("right-panel-cancel-btn"));
        IWebElement RightPanelDone => driver.FindElement(By.Id("right-panel-done-btn"));
        IWebElement AssignTripButton => driver.FindElement(By.Id("assign-trip-btn"));
        IWebElement AssignModalTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement CloseButtonModal => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement CancelButtonModal => driver.FindElement(By.Id("assign-trip-cancel"));
        IWebElement DoneButtonModal => driver.FindElement(By.Id("assign-trip-done"));
        IWebElement bussinessModalButton => driver.FindElement(By.XPath("//input[@id='business']/following-sibling::label"));
        IWebElement PrivateModalButton => driver.FindElement(By.XPath("//input[@id='personal']/following-sibling::label"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));

        #endregion
        #region Methods
        /// <summary>
        /// Navigates to the manage FBT page
        /// </summary>
        public void NavigateToManageFBT()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            wait.Until(driver => ManageFBTTab.Displayed);
            Thread.Sleep(3000);
            extent.SetStepStatusPass("Verified that Manage Vehicle Tab is displayed.");
            ManageFBTTab.Click();
            wait.Until(driver => SearchVehicles.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the search field is displayed.");
        }

        /// <summary>
        /// Search vy the vehicle name
        /// </summary>
        /// <param name="vehicleName"></param>
        public void SearchByVehicleName(string vehicleName)
        {
            wait.Until(driver => SearchVehicles.Displayed);
            SearchVehicles.Clear();
            Thread.Sleep(1000);
            SearchVehicles.SendKeys(vehicleName);
            Thread.Sleep(2000);
            wait.Until(driver => SearchResult.Displayed);
            SearchResult.Click();
            Thread.Sleep(2000);
            wait.Until(driver => VehicleNameTitle.Displayed);
            Assert.AreEqual(vehicleName, VehicleNameTitle.Text.Trim());
            wait.Until(driver => HeaderText.Displayed);
            Assert.AreEqual("Vehicle FBT - Please assign your trips", HeaderText.Text.Trim());
            extent.SetStepStatusPass("Verified that the vehcile is selected");
        }
        /// <summary>
        /// Switches to assigned or unassigned tab based on boolean value
        /// </summary>
        /// <param name="isAssigned"></param>
        public void SwitchAssignedTab(bool isAssigned)
        {
            if (isAssigned)
            {
                try
                {
                    wait.Until(driver => UnassignedTabActive.Displayed);
                    AssignedTab.Click();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                try
                {
                    wait.Until(driver => AssignedTabActive.Displayed);
                    UnassignedTab.Click();
                }
                catch (Exception ex)
                {

                }
            }
            extent.SetStepStatusPass("Switched to the required tab.");
        }
        /// <summary>
        /// Verify the trip details displayed on table
        /// </summary>
        /// <param name="vehicleName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="isAssigned"></param>
        public void VerifyTripDetails(string vehicleName, string userName, string password, int unitId, bool isAssigned)
        {
            getAPIResponse = new GetAPIResponse();
            SearchByVehicleName(vehicleName);
            SwitchAssignedTab(isAssigned);
            Thread.Sleep(8000);
            var tripList = getAPIResponse.GetTripList(userName, password, unitId, isAssigned);
            extent.SetStepStatusPass("Fetched trip details.");
            wait.Until(driver => StartDateColumn.Displayed);
            wait.Until(driver => StopDateColumn.Displayed);
            wait.Until(driver => DistanceColumn.Displayed);
            wait.Until(driver => StartAddressColumn.Displayed);
            wait.Until(driver => StopAddressColumn.Displayed);
            wait.Until(driver => DriverColumn.Displayed);
            wait.Until(driver => StartDateColumnValue.Displayed);
            extent.SetStepStatusPass("Verified the column headers.");
            Assert.AreEqual(tripList.trips[0].startDate.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), StartDateColumnValue.Text.Trim());
            Assert.AreEqual(tripList.trips[0].endDate.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), StopDateColumnValue.Text.Trim());
            Assert.AreEqual(tripList.trips[0].km.ToString() + " km", DistanceColumnValue.Text.Trim());
            Assert.AreEqual(tripList.trips[0].startLocation.Trim(), StartAddressColumnValue.Text.Trim());
            Assert.AreEqual(tripList.trips[0].stopLocation.Trim(), StopAddressColumnValue.Text.Trim());
            if (tripList.trips[0].driverName == null)

                Assert.AreEqual("", DriverColumnValue.Text.Trim());
            else
                Assert.AreEqual(tripList.trips[0].driverName.ToString().Trim(), DriverColumnValue.Text.Trim());
            if (isAssigned)
            {
                if (tripList.trips[0].isBusiness)
                    Assert.AreEqual("Business", TypeColumnValue.Text.Trim());
                else
                    Assert.AreEqual("Private", TypeColumnValue.Text.Trim());
            }
            extent.SetStepStatusPass("Verified the values displayed for the first trip");
        }
        /// <summary>
        /// Verify the trips right panel
        /// </summary>
        /// <param name="vehicleName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="isAssigned"></param>
        public void VerifyRightPanel(string vehicleName, string userName, string password, int unitId, bool isAssigned)
        {
            getAPIResponse = new GetAPIResponse();
            SearchByVehicleName(vehicleName);
            SwitchAssignedTab(isAssigned);
            Thread.Sleep(3000);
            var tripList = getAPIResponse.GetTripList(userName, password, unitId, isAssigned);
            extent.SetStepStatusPass("Fetched trip details.");
            wait.Until(driver => StartDateColumnValue.Displayed);
            StartDateColumnValue.Click();
            wait.Until(driver => RightPanelHeader.Displayed);
            extent.SetStepStatusPass("Opened the righr panel");
            Thread.Sleep(10000);
            Assert.AreEqual(vehicleName, RightPanelHeader.Text.Trim());
            wait.Until(driver => RighrCloseButton.Displayed);
            //Assert.IsTrue(VehicleIDText.Text.Replace("/r/n", "").Contains($"Vehicle ID: {tripList.trips[0].unitId}"));
            Assert.AreEqual(tripList.trips[0].startDate.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), StartTimeRight.Text.Trim());
            Assert.AreEqual(tripList.trips[0].endDate.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), StopTimeRight.Text.Trim());
            Assert.AreEqual(tripList.trips[0].km.ToString() + " km", DistanceValueRight.Text.Trim());
            Assert.AreEqual(tripList.trips[0].startLocation.Trim(), StartAddressRight.Text.Trim());
            Assert.AreEqual(tripList.trips[0].stopLocation.Trim(), StopAddressRight.Text.Trim());
            if (isAssigned)
            {
                if (tripList.trips[0].isBusiness)
                    Assert.AreEqual("Business", TypeValueRight.Text.Trim());
                else
                    Assert.AreEqual("Private", TypeValueRight.Text.Trim());
            }
            else
            {
                Assert.AreEqual("Unassigned", TypeValueRight.Text.Trim());
            }
            extent.SetStepStatusPass("Verified the contents present in the right panel.");
            driver.Navigate().Refresh();
            wait.Until(driver => SearchVehicles.Displayed);
        }

        /// <summary>
        /// Assign or edit trips from table
        /// </summary>
        /// <param name="vehicleName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="isAssigned"></param>
        public void AssignTrip(string vehicleName, string userName, string password, int unitId, bool isAssigned)
        {
            SearchByVehicleName(vehicleName);
            SwitchAssignedTab(isAssigned);
            Thread.Sleep(3000);
            wait.Until(driver => FirstElementCheckbox.Displayed);
            Thread.Sleep(3000);
            FirstElementCheckbox.Click();
            extent.SetStepStatusPass("Selected te first trip");
            wait.Until(driver => AssignTripButton.Displayed);
            AssignTripButton.Click();
            extent.SetStepStatusPass("opened the assign/ edit pop up");
            wait.Until(driver => AssignModalTitle.Displayed);
            Thread.Sleep(2000);
            if (!isAssigned)
                Assert.AreEqual("Assign Trip(s)", AssignModalTitle.Text.Trim());
            else
                Assert.AreEqual("Edit Trip(s)", AssignModalTitle.Text.Trim());
            wait.Until(driver => CloseButtonModal.Displayed);

            if (isAssigned)
            {
                getAPIResponse = new GetAPIResponse();
                var tripList = getAPIResponse.GetTripList(userName, password, unitId, isAssigned);
                extent.SetStepStatusPass("Fetched trip details.");
                if (tripList.trips[0].isBusiness)
                    PrivateModalButton.Click();
                else
                {
                    bussinessModalButton.Click();
                    ReasonDropdown.Click();
                    buisinessReason = "Sales call";
                    ReasonDropdownSelect.Click();
                }

            }
            else
            {
                bussinessModalButton.Click();
                ReasonDropdown.Click();
                buisinessReason = "Site visit";
                ReasonDropdownSelect.Click();
            }
            wait.Until(driver => CancelButtonModal.Displayed);
            DoneButtonModal.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Trip updated successfully", SuccessMessage.Text.Trim());
            extent.SetStepStatusPass("Successfully updated the trip");

        }
        /// <summary>
        /// Assign/ edit trips from right panel
        /// </summary>
        /// <param name="vehicleName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="isAssigned"></param>
        public void AssignFromRightPanel(string vehicleName, string userName, string password, int unitId, bool isAssigned)
        {
            SearchByVehicleName(vehicleName);
            SwitchAssignedTab(isAssigned);
            Thread.Sleep(3000);
            wait.Until(driver => StartDateColumnValue.Displayed);
            StartDateColumnValue.Click();
            wait.Until(driver => RightPanelHeader.Displayed);
            extent.SetStepStatusPass("Opened the right panel.");
            Thread.Sleep(6000);
            if (isAssigned)
            {
                getAPIResponse = new GetAPIResponse();
                var tripList = getAPIResponse.GetTripList(userName, password, unitId, isAssigned);
                extent.SetStepStatusPass("Fetched trip details.");
                if (tripList.trips[0].isBusiness)
                    PrivateRadio.Click();
                else
                {
                    BusinessRadio.Click();
                    ReasonDropdown.Click();
                    buisinessReason = "Sales call";
                    ReasonDropdownSelect.Click();
                }

            }
            else
            {
                BusinessRadio.Click();
                ReasonDropdown.Click();
                buisinessReason = "Site visit";
                ReasonDropdownSelect.Click();
            }
            wait.Until(driver => RightPanelCancel.Displayed);
            RightPanelDone.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Trip updated successfully", SuccessMessage.Text.Trim());
            extent.SetStepStatusPass("Successfully updated the trip.");
        }
        #endregion
    }
}
