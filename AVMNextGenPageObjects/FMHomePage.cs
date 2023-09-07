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
    public class FMHomePage : AVMNextGenBase
    {
        IWebDriver fMHomePageDriver;
        public FMHomePage() { }

        public FMHomePage(IWebDriver driver)
        {
            this.fMHomePageDriver = driver;
        }
        public GetAPIResponse getAPIResponse;
        #region Properties
        public int rowNumber = 1;
        public int colNumber = 1;
        public int buttonNumber = 1;
        #region TopMenuNavigation
        IWebElement Home => driver.FindElement(By.LinkText("Home"));
        #endregion

        #region LeftMenuNavigation
        IWebElement Vehicles => driver.FindElement(By.Id("vehicles-icon"));
        IWebElement Drivers => driver.FindElement(By.Id("drivers-icon"));
        IWebElement Locations => driver.FindElement(By.Id("locations-icon"));
        IWebElement Alerts => driver.FindElement(By.Id("alerts-icon"));
        IWebElement Alarms => driver.FindElement(By.Id("alarms-icon"));
        IWebElement FloatingPanelTitle => driver.FindElement(By.Id("fleet-list-accordion"));
        IWebElement ListView => driver.FindElement(By.Id("listview-icon"));


        #endregion
        #region ListView
        IWebElement ColumnName => driver.FindElement(By.XPath($"//div[contains(@class,'record-list')]/div/div[{rowNumber}]/div[{colNumber}]"));
        IWebElement RowValues => driver.FindElement(By.XPath($"//div[contains(@class,'record-list')]/div/div[2]/div[{rowNumber}]/div[{colNumber}]"));
        IWebElement ListViewHeader => driver.FindElement(By.XPath($"//span[@class='fleet-list-text']"));
        IWebElement SearchFieldListDrivers => driver.FindElement(By.XPath("//app-list-view//input[@placeholder='Search Drivers']"));
        IWebElement SearchFieldListAlerts => driver.FindElement(By.XPath("//app-list-view//input[@placeholder='Search Alerts']"));
        IWebElement SearchFieldListAlarms => driver.FindElement(By.XPath("//app-list-view//input[@placeholder='Search Alarms']"));
        IWebElement SearchFieldListLoc => driver.FindElement(By.XPath("//app-list-view//input[@placeholder='Search Locations']"));
        #endregion

        #region AlertsLeftMenu
        IWebElement SearchFieldAlerts => driver.FindElement(By.XPath("//fm-avm-tree-view//input[@placeholder='Search Alerts']"));
        IWebElement AlertsDate => driver.FindElement(By.XPath("//div[contains(@class,'alerts-list')]/div[1]//div[@class='alerts-date-wrapper']/p"));
        IWebElement AlertsName => driver.FindElement(By.XPath("//div[contains(@class,'alerts-list')]/div[1]/div[2]//div[@class='alerts-details']/p"));
        IWebElement AlertsVehicleName => driver.FindElement(By.XPath("//div[contains(@class,'alerts-list')]/div[1]/div[2]//p[@class='alerts-vehiclename']"));
        IWebElement AlertsTime => driver.FindElement(By.XPath("//div[contains(@class,'alerts-list')]/div[1]/div[2]//p[@class='alerts-datetime']"));
        #endregion

        #region AlarmLeftMenu
        IWebElement SearchFieldAlarms => driver.FindElement(By.XPath("//fm-avm-tree-view//input[@placeholder='Search Alarms']"));
        #endregion


        #region LocationsLeftMenu


        #endregion
        #region VehiclesLeftMenu
        IWebElement VehiclesText => driver.FindElement(By.XPath("//h2[@class='accordion-header']"));
        IWebElement VehiclesCount => driver.FindElement(By.XPath("//span[@class='fleet-number']"));
        IWebElement VehiclesClose => driver.FindElement(By.XPath("//div[@id='fleet-list-wrapper']//span[@class='close']"));
        IWebElement SearchField => driver.FindElement(By.Id("search-field"));
        IWebElement FirstSearchResult => driver.FindElement(By.XPath("//div[@class='vehicle-list']//li[1]"));
        IWebElement FirstSearchResultText => driver.FindElement(By.XPath("//div[@id='department-accordion']/div[1]//div[@class='vehicle-list']//li[1]//button"));
        IWebElement FirstGroup => driver.FindElement(By.XPath("//div[@id='department-accordion']/div[1]//h2[contains(@id,'dept-header')]//div"));
        IWebElement FirstGroupSearch => driver.FindElement(By.XPath("//div[@id='department-accordion']/div[1]//h2[contains(@id,'dept-header')]//div"));
        #endregion
        #region TreeActions
        IWebElement FilterIcon => driver.FindElement(By.XPath("//div[contains(@class,'filter-icon')]"));
        IWebElement ExpandAll => driver.FindElement(By.Id("expandall-label"));
        IWebElement CollapseAll => driver.FindElement(By.Id("collapseall-label"));
        IWebElement ShowAll => driver.FindElement(By.Id("selectAll-label"));
        IWebElement HideAll => driver.FindElement(By.Id("unselectAll-label"));

        #endregion
        #region Telemetry Popup
        IWebElement TelemetryPopUp => driver.FindElement(By.XPath("//div[@class='vehicle-info-popup']"));
        IWebElement LocTelemetryPopUp => driver.FindElement(By.XPath("//div[@class='location-info-popup']"));

        IWebElement TelemetryName => driver.FindElement(By.XPath("//div[@class='vh-info']/h3[1]"));
        IWebElement TelemetrySecondLine => driver.FindElement(By.XPath("//div[@class='vh-info']/p"));

        IWebElement LocationGroupName => driver.FindElement(By.XPath("//li[@class='location-dept-name']/span"));
        IWebElement TelemetrySpeed => driver.FindElement(By.XPath("//li[@class='map-loc']"));
        IWebElement TelemetryLocation => driver.FindElement(By.XPath("//li[@class='map-info']"));
        IWebElement TelemetryTimeSet => driver.FindElement(By.XPath("//li[@class='time-set']/span"));

        IWebElement TelemetryHistory => driver.FindElement(By.XPath("//div[@class='tele-tools']/img[1]"));
        IWebElement TelemetryLocate => driver.FindElement(By.XPath("//div[@class='tele-tools']/img[2]"));
        IWebElement TelemetryReports => driver.FindElement(By.XPath("//div[@class='tele-tools']/img[3]"));
        IWebElement TelemetryDashcam => driver.FindElement(By.XPath("//div[@class='tele-tools']/img[4]"));
        IWebElement TelemetryButtons => driver.FindElement(By.XPath($"//div[@class='tele-tools']/img[{buttonNumber}]"));
        IWebElement TelemetryAlertTime => driver.FindElement(By.XPath("//li[@class='alert-time']/span"));
        IWebElement TelemetryAlertLocation => driver.FindElement(By.XPath("//li[@class='alert-location']"));
        IWebElement TelemetryAlertDriver => driver.FindElement(By.XPath("//li[@class='alert-driver']"));
        IWebElement TelemetryAlertContact => driver.FindElement(By.XPath("//li[@class='alert-contact']"));

        IWebElement TelemetryAlarmTime => driver.FindElement(By.XPath("//li[@class='time-set']"));
        IWebElement TelemetryAlarmDriver => driver.FindElement(By.XPath("//li[@class='map-driver']"));
        IWebElement TelemetryAlarmContact => driver.FindElement(By.XPath("//li[@class='map-contact']"));
        IWebElement TelemetryAlarmAddress => driver.FindElement(By.XPath("//li[@class='map-info']"));

        IWebElement TelemetryViewDetails => driver.FindElement(By.LinkText("View Details"));
        IWebElement TelemetryClose => driver.FindElement(By.XPath("//a[contains(@class,'close')]"));


        #endregion

        #region Right Panel 
        IWebElement RightPanelImage => driver.FindElement(By.XPath("//div[@class='driver-info-img']/img"));

        IWebElement RightVehicleName => driver.FindElement(By.XPath("//div[@class='driver-contact-details']/span[1]"));
        IWebElement RightDriverName => driver.FindElement(By.XPath("//div[@class='driver-contact-details']/span[2]"));
        IWebElement RightDriverPanelVehcile => driver.FindElement(By.XPath("//div[@class='driver-contact-details']/p/span[1]"));
        IWebElement RightPhoneDetails => driver.FindElement(By.XPath("//span[@id='phone-details']"));
        IWebElement RightSpeedDetails => driver.FindElement(By.XPath("//span[@id='speed-details']"));
        IWebElement RightDirection => driver.FindElement(By.XPath("//span[@class='direction']"));
        IWebElement RightLocationDetails => driver.FindElement(By.XPath("//span[@id='location-details']"));
        IWebElement RightTimeDetails => driver.FindElement(By.XPath("//span[@id='time-details']"));

        IWebElement RightHistoryButton => driver.FindElement(By.Id("history-button"));
        IWebElement RightFindNowButton => driver.FindElement(By.Id("track-vehicle-button"));
        IWebElement RightLocateButton => driver.FindElement(By.Id("locate-vehicle-button"));
        IWebElement ShowOnMapButton => driver.FindElement(By.Id("show-on-map-button"));
        IWebElement RightReportsButton => driver.FindElement(By.Id("reports-button"));
        IWebElement RightDashcamButton => driver.FindElement(By.Id("dashcam-button"));
        IWebElement RightInfoTabButton => driver.FindElement(By.Id("info-tab-switch"));
        IWebElement RightStatusTabButton => driver.FindElement(By.Id("status-tab-switch"));
        IWebElement RightServiceTabButton => driver.FindElement(By.Id("service-tab-switch"));
        IWebElement RightAssetCardButton => driver.FindElement(By.Id("view-card-btn"));

        IWebElement RightTimeAtLocation => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='time-at-location']"));
        IWebElement RightTimeAtLocationValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='time-at-location-text']"));

        IWebElement RightDriver => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='driver']"));
        IWebElement RightDriverValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='driver-name']"));


        IWebElement RightDriverStatus => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='driver-status']"));
        IWebElement RightDriverStatusValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='driver-status-text']"));
        IWebElement RightVehId => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='vehicle-id']"));
        IWebElement RightVehIdValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='vehicle-id-text']"));
        IWebElement RightRegistration => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='registration']"));
        IWebElement RightRegistrationValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='registration-text']"));
        IWebElement RightOdometer => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='odometer']"));
        IWebElement RightOdometerValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[@id='odometer-text']"));
        IWebElement RightEngHours => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[contains(text(),'Engine hours')]"));
        IWebElement RightEngHoursValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[contains(text(),'Engine hours')]/following-sibling::span"));
        IWebElement RightStatus => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[contains(text(),'Status')]"));
        IWebElement RightStatusValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[contains(text(),'Status')]/following-sibling::span"));
        IWebElement RightGpsState => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[contains(text(),'GPS State')]"));
        IWebElement RightGpsStateValue => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tab')]//span[contains(text(),'GPS State')]/following-sibling::span"));

        IWebElement RightLastIgnitionOff => driver.FindElement(By.XPath(" //div[@id='Status']//div[contains(@class,'last-stopped-main-text')]/span"));

        IWebElement RightDurationState => driver.FindElement(By.XPath("//div[@id='Status']//p[contains(text(),'Duration')]"));
        IWebElement RightDurationStateValue => driver.FindElement(By.XPath("//div[@id='Status']//p[contains(text(),'Duration')]/following-sibling::p"));
        IWebElement RightDateTime => driver.FindElement(By.XPath("//div[@id='Status']//p[contains(text(),'Date & Time')]"));
        IWebElement RightDateTimeValue => driver.FindElement(By.XPath("//div[@id='Status']//p[contains(text(),'Date & Time')]/following-sibling::p"));

        IWebElement RightLocation => driver.FindElement(By.XPath("//div[@id='Status']//p[contains(text(),'Location')]"));
        IWebElement RightLocationValue => driver.FindElement(By.XPath("//div[@id='Status']//p[contains(text(),'Location')]/following-sibling::p"));
        IWebElement RightIgnition => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Ignition']"));
        IWebElement RightIgnitionValue => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Ignition']/following-sibling::span"));
        IWebElement RightPower => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Power']"));
        IWebElement RightPowerValue => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Power']/following-sibling::span"));
        IWebElement RightBackUpPower => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Backup Power']"));
        IWebElement RightBackUpPowerValue => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Backup Power']/following-sibling::span"));
        IWebElement RightTipPurpose => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Trip Purpose']"));
        IWebElement RightTripPurposeValue => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Trip Purpose']/following-sibling::span"));
        IWebElement RightEmergency => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Emergency']"));
        IWebElement RightEmergencyValue => driver.FindElement(By.XPath("//div[@id='Status']//span[text()='Emergency']/following-sibling::span"));

        IWebElement RightAlertsHeading => driver.FindElement(By.XPath("//div[@id='alerts-right-panel']//h3"));
        IWebElement RightAlertsVehicle => driver.FindElement(By.XPath("//div[@id='alerts-right-panel']//p"));
        IWebElement RightAlertsSubTitle => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']"));
        IWebElement RightAlertsMessage => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']/following-sibling::div[1]//label[contains(text(),'Message')]/following-sibling::span"));
        IWebElement RightAlertsVehicleName => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']/following-sibling::div[1]//label[contains(text(),'Vehicle')]/following-sibling::span"));
        IWebElement RightAlertsSpeed => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']/following-sibling::div[1]//label[contains(text(),'Speed')]/following-sibling::span"));
        IWebElement RightAlertsDriver => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']/following-sibling::div[1]//label[contains(text(),'Driver')]/following-sibling::span"));
        IWebElement RightAlertsPhone => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']/following-sibling::div[1]//label[contains(text(),'Phone')]/following-sibling::span"));
        IWebElement RightAlertsTime => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']/following-sibling::div[1]//label[contains(text(),'Time')]/following-sibling::span"));
        IWebElement RightAlertsAddress => driver.FindElement(By.XPath("//div[@class='sub-title desktop-only']/following-sibling::div[1]//label[contains(text(),'Address')]/following-sibling::span"));
        IWebElement RightPanelCloseAlert => driver.FindElement(By.XPath("//div[@id='app-right-info-view']//img[contains(@src,'close')]"));
        IWebElement RightPanelCloseListAlert => driver.FindElement(By.XPath("//app-list-view//div[@class='head-title']/following-sibling::span/img[contains(@src,'close')]"));


        IWebElement RightAlarmHeading => driver.FindElement(By.XPath("//span[@class='name-text']"));
        IWebElement RightAlarmsVehicle => driver.FindElement(By.XPath("//span[@class='name-text']/following-sibling::p/span"));
        IWebElement RightAlarmsSubTitle => driver.FindElement(By.XPath("//span[@class='alarms-details-heading']"));
        IWebElement RightAlarmsClearButton => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']//button[@id='alarms-clear-button']"));
        IWebElement RightAlarmsName => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Alarm')]/following-sibling::span"));
        IWebElement RightAlarmsVehicleName => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Vehicle')]/following-sibling::span"));
        IWebElement RightAlarmsFleedId => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Fleet ID')]/following-sibling::span"));
        IWebElement RightAlarmsTime => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Time')]/following-sibling::span"));
        IWebElement RightAlarmsDriver => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Driver')]/following-sibling::span"));
        IWebElement RightAlarmsPhone => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Phone')]/following-sibling::span"));
        IWebElement RightAlarmsSpeed => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Speed')]/following-sibling::span"));
        IWebElement RightAlarmsDirection => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Direction')]/following-sibling::span"));
        IWebElement RightAlarmsAddress => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[2]//span[contains(text(),'Address')]/following-sibling::span"));
        IWebElement RightAlarmsClose => driver.FindElement(By.XPath("//div[@class='location-rightinfo-header']/following-sibling::img"));





        IWebElement RightLocHeading => driver.FindElement(By.XPath("//span[@class='name-text']"));
        IWebElement RightLocType => driver.FindElement(By.XPath("//span[@class='direction-text']"));
        IWebElement RightLocEditDetails => driver.FindElement(By.Id("edit-detail-button"));
        IWebElement RightLocEdit => driver.FindElement(By.Id("edit-location-button"));
        IWebElement RightLocDelete => driver.FindElement(By.Id("delete-location-button"));
        IWebElement RightLocDetailsHeading => driver.FindElement(By.XPath("//p[contains(@class,'location-details-heading')]"));
        IWebElement RightLocNameDetails => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[1]//span[contains(text(),'Name')]/following-sibling::span"));
        IWebElement RightLocDeptDetails => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[1]//span[contains(text(),'Dept')]/following-sibling::span"));
        IWebElement RightLocGroupDetails => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[1]//span[contains(text(),'Group')]/following-sibling::span"));
        IWebElement RightLocTypeDetails => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[1]//span[contains(text(),'Location Type')]/following-sibling::span"));
        IWebElement RightLocDescriptionDetails => driver.FindElement(By.XPath("//div[@class='alerts-panel-details desktop-only']/div[1]//span[contains(text(),'Description')]/following-sibling::span"));
        IWebElement RightLocClose => driver.FindElement(By.XPath("//div[@class='location-rightinfo-header']/img"));































        #endregion






        #endregion

        #region Methods

        /// <summary>
        /// Navigates to home page
        /// </summary>
        public void NavigateToHomePage()
        {

            wait.Until(driver => Home.Displayed);
            extent.SetStepStatusPass("Verified that home link is displayed.");
            Home.Click();
            wait.Until(driver => Vehicles.Displayed);
            extent.SetStepStatusPass("Verified that the home page is displayed.");
        }

        /// <summary>
        /// Verifies the display of left menu ans floating panel
        /// </summary>
        public void LeftMenuVerification()
        {
            wait.Until(driver => Vehicles.Displayed);
            Assert.IsTrue(Vehicles.Displayed);
            extent.SetStepStatusPass("Verified that Vehicles link is displayed.");
            Vehicles.Click();
            Assert.IsTrue(FloatingPanelTitle.Text.Contains("Fleet List"));
            extent.SetStepStatusPass("Verified that Vehicles floating panel is displayed.");
            Thread.Sleep(1000);
            Assert.IsTrue(Drivers.Displayed);
            extent.SetStepStatusPass("Verified that drivers link is displayed.");
            Drivers.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Driver List"));
            extent.SetStepStatusPass("Verified that drivers floating panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(Locations.Displayed);
            extent.SetStepStatusPass("Verified that locations link is displayed.");
            Locations.Click();
            Assert.IsTrue(FloatingPanelTitle.Text.Contains("Locations"));
            extent.SetStepStatusPass("Verified that Locations floating panel is displayed.");
            Assert.IsTrue(Alerts.Displayed);
            extent.SetStepStatusPass("Verified that alerts link is displayed.");
            Alerts.Click();
            Assert.IsTrue(FloatingPanelTitle.Text.Contains("Alerts"));
            extent.SetStepStatusPass("Verified that Alerts floating panel is displayed.");
            Assert.IsTrue(Alarms.Displayed);
            extent.SetStepStatusPass("Verified that alarms link is displayed.");
            Alarms.Click();
            Assert.IsTrue(FloatingPanelTitle.Text.Contains("Alarms"));
            extent.SetStepStatusPass("Verified that Alarms floating panel is displayed.");
        }

        /// <summary>
        /// Verify the vehicle tree floating panel with API response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyVehicleTree(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(userName, password);
            extent.SetStepStatusPass("Fetched vehicle details.");
            string vehicleName = vehicleTree.FirstOrDefault().unitName.Trim();
            string vehicleId = vehicleTree.FirstOrDefault().vehicleId.Trim();
            string groupName = vehicleTree.FirstOrDefault().groupName.Trim();
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Assert.AreEqual(groupName, FirstGroup.Text.Split('(')[0].Replace("\r\n", "").Trim());
            extent.SetStepStatusPass("Verified that group matches the search result displayed.");
            if (vehicleId != "")
                Assert.AreEqual(vehicleName + $" ({vehicleId})", FirstSearchResultText.Text.Trim());
            else
                Assert.AreEqual(vehicleName + $" (Not Set)", FirstSearchResultText.Text.Trim());
            extent.SetStepStatusPass("Verified that vehicle matches the search result displayed.");
        }
        /// <summary>
        /// Verify alarm tree
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlarmTree(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            string alarmName = alarmTree.alarms.FirstOrDefault().alarmText.Trim();
            string alarmUnitName = alarmTree.alarms.FirstOrDefault().unitName.Trim();
            string alarmTime = alarmTree.alarms.FirstOrDefault().utcTime.ToLocalTime().ToString("h:mm tt");
            string alarmDate = alarmTree.alarms.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy");
            Alarms.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => SearchFieldAlarms.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchFieldAlarms.SendKeys(alarmName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlertsDate.Displayed);
            Assert.AreEqual(alarmDate, AlertsDate.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm date name matches the search result displayed.");
            wait.Until(driver => AlertsName.Displayed);
            Assert.AreEqual(alarmName, AlertsName.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm title the search result displayed.");
            Assert.AreEqual(alarmUnitName, AlertsVehicleName.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm unit name matches the search result displayed.");
            Assert.AreEqual(alarmTime, AlertsTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm time name matches the search result displayed.");
        }
        /// <summary>
        /// Verify alarm telemetry
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlarmTelemetry(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            string alarmName = alarmTree.alarms.FirstOrDefault().alarmText.Trim();
            string alarmUnitName = alarmTree.alarms.FirstOrDefault().unitName.Trim();
            string alarmDate = alarmTree.alarms.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' h:mm tt");
            string driverName = alarmTree.alarms.FirstOrDefault().driverName.Trim();
            string address = alarmTree.alarms.FirstOrDefault().address.Trim();
            string number = alarmTree.alarms.FirstOrDefault().contactPhone.Trim();
            Alarms.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => SearchFieldAlarms.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchFieldAlarms.SendKeys(alarmName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlertsName.Displayed);
            AlertsName.Click();
            Thread.Sleep(2000);
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            Assert.AreEqual(alarmName, TelemetryName.Text.Trim());
            Assert.AreEqual(alarmUnitName, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual(alarmDate, TelemetryAlarmTime.Text.Trim());
            Assert.AreEqual(address, TelemetryAlarmAddress.Text.Trim());
            Assert.AreEqual(driverName, TelemetryAlarmDriver.Text);
            Assert.AreEqual(number, TelemetryAlarmContact.Text);
            extent.SetStepStatusPass("Verified the alarm details.");
            Assert.IsTrue(TelemetryHistory.GetAttribute("src").Contains("tele-history"));
            buttonNumber = 2;
            Assert.IsTrue(TelemetryButtons.GetAttribute("src").Contains("tele-location"));
            buttonNumber = 3;
            Assert.IsTrue(TelemetryButtons.GetAttribute("src").Contains("tele-locate"));
            wait.Until(driver => TelemetryViewDetails.Displayed);
            wait.Until(driver => TelemetryClose.Displayed);
            TelemetryClose.Click();
            extent.SetStepStatusPass("Verified the view details and buttons.");
        }
        /// <summary>
        /// Verify alarm right panels
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlarmRightPanel(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            string alarmName = alarmTree.alarms.FirstOrDefault().alarmText.Trim();
            string fleetId = alarmTree.alarms.FirstOrDefault().fleetId.ToString().Trim();
            string alarmUnitName = alarmTree.alarms.FirstOrDefault().unitName.Trim();
            string alarmDate = alarmTree.alarms.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' h:mm tt");
            string driverName = alarmTree.alarms.FirstOrDefault().driverName.Trim();
            string address = alarmTree.alarms.FirstOrDefault().address.Trim();
            string number = alarmTree.alarms.FirstOrDefault().contactPhone.Trim();
            string speed = Math.Floor(alarmTree.alarms.FirstOrDefault().speed).ToString().Trim() + " km/h";
            string direction = alarmTree.alarms.FirstOrDefault().headStr.Trim();
            string directionValue = getDirectionValue(direction);
            Alarms.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => SearchFieldAlarms.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchFieldAlarms.SendKeys(alarmName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlertsName.Displayed);
            AlertsName.Click();
            Thread.Sleep(2000);
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            TelemetryViewDetails.Click();
            Thread.Sleep(2000);
            wait.Until(driver => RightAlarmHeading.Displayed);
            Assert.AreEqual(alarmName, RightAlarmHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm heading is displayed.");
            wait.Until(driver => RightHistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => RightFindNowButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => RightLocateButton.Displayed);
            extent.SetStepStatusPass("Verified that locate button is displayed.");
            Assert.AreEqual(alarmUnitName, RightAlarmsVehicle.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm vehicle name is displayed.");
            Assert.AreEqual("Alarm details", RightAlarmsSubTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm details is displayed.");
            wait.Until(driver => RightAlarmsClearButton.Displayed);
            extent.SetStepStatusPass("Verified that alarm clear is displayed.");
            Assert.AreEqual(alarmName, RightAlarmsName.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm message is displayed.");
            Assert.AreEqual(alarmUnitName, RightAlarmsVehicleName.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm vehicle name is displayed.");
            Assert.AreEqual(fleetId, RightAlarmsFleedId.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm fleet id is displayed.");
            Assert.AreEqual(alarmDate, RightAlarmsTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm time is displayed.");
            Assert.AreEqual(driverName, RightAlarmsDriver.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm driver is displayed.");
            Assert.AreEqual(number, RightAlarmsPhone.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm phone is displayed.");
            Assert.AreEqual(speed, RightAlarmsSpeed.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm speed is displayed.");
            Assert.AreEqual(directionValue, RightAlarmsDirection.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm direction is displayed.");
            Assert.AreEqual(address, RightAlarmsAddress.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm address is displayed.");
            wait.Until(driver => RightAlarmsClose.Displayed);
            RightAlarmsClose.Click();
            extent.SetStepStatusPass("Verified that alarm close button is displayed.");
            extent.SetStepStatusPass("Verified the alarm right panel details.");
        }

        /// <summary>
        /// Verify alarm List View
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlarmListView(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            wait.Until(driver => Alarms.Displayed);
            Alarms.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Alarms"));
            wait.Until(driver => SearchFieldAlarms.Displayed);
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            Assert.AreEqual("Alarms", ListViewHeader.Text.Trim());
            string[] columnNameValues = { "Alarm", "Date/Time", "Vehicle", "Assigned Driver", "Address" };
            for (int i = 1; i < 6; i++)
            {
                colNumber = i;
                Assert.AreEqual(columnNameValues[colNumber - 1], ColumnName.Text.Trim());
            }
            int rowCountValue = 5;

            if (alarmTree.alarms.Count() <= 5)
                rowCountValue = alarmTree.alarms.Count();

            for (int j = 0; j < rowCountValue; j++)
            {
                colNumber = 1;
                rowNumber = j + 1;
                Assert.AreEqual(alarmTree.alarms[j].alarmText.Trim(), RowValues.Text.Trim());
                colNumber = 2;
                Assert.AreEqual(alarmTree.alarms[j].utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' h:mm tt"), RowValues.Text.Trim());
                colNumber = 3;
                Assert.IsTrue(RowValues.Text.Trim().Contains(alarmTree.alarms[j].unitName));
                colNumber = 4;
                if (alarmTree.alarms[j].driverName?.ToString() == null)
                {
                    Assert.AreEqual("-", RowValues.Text.Trim());
                }
                else
                    Assert.AreEqual(alarmTree.alarms[j].driverName?.ToString(), RowValues.Text.Trim());
                colNumber = 5;
                Assert.AreEqual(alarmTree.alarms[j].address.ToString().Trim(), RowValues.Text.Trim());
                extent.SetStepStatusPass("Verified alarm details.");

            }

            extent.SetStepStatusPass("Verified that alarm matches the search result displayed.");
        }
        /// <summary>
        /// Verify Alarm right panel in list view
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlarmRightPanelListView(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            string alarmName = alarmTree.alarms.FirstOrDefault().alarmText.Trim();
            string fleetId = alarmTree.alarms.FirstOrDefault().fleetId.ToString().Trim();
            string alarmUnitName = alarmTree.alarms.FirstOrDefault().unitName.Trim();
            string alarmDate = alarmTree.alarms.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' h:mm tt");
            string driverName = alarmTree.alarms.FirstOrDefault().driverName.Trim();
            string address = alarmTree.alarms.FirstOrDefault().address.Trim();
            string number = alarmTree.alarms.FirstOrDefault().contactPhone.Trim();
            string speed = Math.Floor(alarmTree.alarms.FirstOrDefault().speed).ToString().Trim() + " km/h";
            string direction = alarmTree.alarms.FirstOrDefault().headStr.Trim();
            string directionValue = getDirectionValue(direction);

            Alarms.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => SearchFieldAlarms.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            wait.Until(driver => SearchFieldListAlarms.Displayed);
            SearchFieldListAlarms.SendKeys(alarmName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            colNumber = 1;
            rowNumber = 1;
            RowValues.Click();
            Thread.Sleep(2000);
            wait.Until(driver => RightAlarmHeading.Displayed);
            Assert.AreEqual(alarmName, RightAlarmHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm heading is displayed.");
            wait.Until(driver => RightHistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => RightFindNowButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => RightLocateButton.Displayed);
            extent.SetStepStatusPass("Verified that locate button is displayed.");
            wait.Until(driver => ShowOnMapButton.Displayed);
            extent.SetStepStatusPass("Verified that show on map button is displayed.");
            Assert.AreEqual(alarmUnitName, RightAlarmsVehicle.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm vehicle name is displayed.");
            Assert.AreEqual("Alarm details", RightAlarmsSubTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm details is displayed.");
            wait.Until(driver => RightAlarmsClearButton.Displayed);
            extent.SetStepStatusPass("Verified that alarm clear is displayed.");
            Assert.AreEqual(alarmName, RightAlarmsName.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm message is displayed.");
            Assert.AreEqual(alarmUnitName, RightAlarmsVehicleName.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm vehicle name is displayed.");
            Assert.AreEqual(fleetId, RightAlarmsFleedId.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm fleet id is displayed.");
            Assert.AreEqual(alarmDate, RightAlarmsTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm time is displayed.");
            Assert.AreEqual(driverName, RightAlarmsDriver.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm driver is displayed.");
            Assert.AreEqual(number, RightAlarmsPhone.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm phone is displayed.");
            Assert.AreEqual(speed, RightAlarmsSpeed.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm speed is displayed.");
            Assert.AreEqual(directionValue, RightAlarmsDirection.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm direction is displayed.");
            Assert.AreEqual(address, RightAlarmsAddress.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm address is displayed.");
            wait.Until(driver => RightAlarmsClose.Displayed);
            RightAlarmsClose.Click();
            extent.SetStepStatusPass("Verified that alarm close button is displayed.");
            extent.SetStepStatusPass("Verified the alarm right panel details.");
        }
        /// <summary>
        /// Verify alert tree
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlertTree(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alertTree = getAPIResponse.GetAlertTree(userName, password);
            extent.SetStepStatusPass("Fetched alert details.");
            string alertName = alertTree.FirstOrDefault().alertText.Trim();
            string alertUnitName = alertTree.FirstOrDefault().unitName.Trim();
            string alertTime = alertTree.FirstOrDefault().utcTime.ToLocalTime().ToString("h:mm tt");
            string alertDate = alertTree.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy");
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => SearchFieldAlerts.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchFieldAlerts.SendKeys(alertName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlertsDate.Displayed);
            Assert.AreEqual(alertDate, AlertsDate.Text.Trim());
            extent.SetStepStatusPass("Verified that alert date name matches the search result displayed.");
            wait.Until(driver => AlertsName.Displayed);
            Assert.AreEqual(alertName, AlertsName.Text.Trim());
            extent.SetStepStatusPass("Verified that alert title the search result displayed.");
            Assert.AreEqual(alertUnitName, AlertsVehicleName.Text.Trim());
            extent.SetStepStatusPass("Verified that alert unit name matches the search result displayed.");
            Assert.AreEqual(alertTime, AlertsTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alert time name matches the search result displayed.");
        }
        /// <summary>
        /// Verify Alert Telemetry
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyAlertTelemetry(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alertTree = getAPIResponse.GetAlertTree(userName, password);
            extent.SetStepStatusPass("Fetched alert details.");
            string alertName = alertTree.FirstOrDefault().alertText.Trim();
            string alertUnitName = alertTree.FirstOrDefault().unitName.Trim();
            string alertDate = alertTree.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' hh:mm tt");
            string driverName = alertTree.FirstOrDefault().driverName.Trim();
            string address = alertTree.FirstOrDefault().address.Trim();
            string number = alertTree.FirstOrDefault().contactPhone.Trim();
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => SearchFieldAlerts.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchFieldAlerts.SendKeys(alertName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlertsName.Displayed);
            AlertsName.Click();
            Thread.Sleep(2000);
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            Assert.AreEqual(alertName, TelemetryName.Text.Trim());
            Assert.AreEqual(alertUnitName, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual(alertDate, TelemetryAlertTime.Text.Trim());
            Assert.AreEqual(address, TelemetryAlertLocation.Text.Trim());
            Assert.AreEqual(driverName, TelemetryAlertDriver.Text);
            Assert.AreEqual(number, TelemetryAlertContact.Text);
            extent.SetStepStatusPass("Verified the alert details.");
            Assert.IsTrue(TelemetryHistory.GetAttribute("src").Contains("tele-history"));
            buttonNumber = 2;
            Assert.IsTrue(TelemetryButtons.GetAttribute("src").Contains("tele-location"));
            buttonNumber = 3;
            Assert.IsTrue(TelemetryButtons.GetAttribute("src").Contains("tele-locate"));
            wait.Until(driver => TelemetryViewDetails.Displayed);
            wait.Until(driver => TelemetryClose.Displayed);
            extent.SetStepStatusPass("Verified the view details and buttons.");
        }
        /// <summary>
        /// Verify alerts right panel
        /// </summary>
        public void VerifyAlertRightPanel(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alertTree = getAPIResponse.GetAlertTree(userName, password);
            extent.SetStepStatusPass("Fetched alert details.");
            string alertName = alertTree.FirstOrDefault().alertText.Trim();
            string alertUnitName = alertTree.FirstOrDefault().unitName.Trim();
            string alertDate = alertTree.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' h:mm tt");
            string driverName = alertTree.FirstOrDefault().driverName.Trim();
            string address = alertTree.FirstOrDefault().address.Trim();
            string number = alertTree.FirstOrDefault().contactPhone.Trim();
            string speed = Math.Floor(alertTree.FirstOrDefault().speed).ToString().Trim() + " km/h";
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => SearchFieldAlerts.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchFieldAlerts.SendKeys(alertName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlertsName.Displayed);
            AlertsName.Click();
            Thread.Sleep(2000);
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            TelemetryViewDetails.Click();
            Thread.Sleep(2000);
            wait.Until(driver => RightAlertsHeading.Displayed);
            Assert.AreEqual(alertName, RightAlertsHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that alert heading is displayed.");
            wait.Until(driver => RightHistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => RightFindNowButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => RightLocateButton.Displayed);
            extent.SetStepStatusPass("Verified that locate button is displayed.");

            Assert.AreEqual(alertName, RightAlertsHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that alert heading is displayed.");
            Assert.AreEqual(alertUnitName, RightAlertsVehicle.Text.Trim());
            extent.SetStepStatusPass("Verified that alert vehicle name is displayed.");
            Assert.AreEqual("Alert Details", RightAlertsSubTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that alert details is displayed.");
            Assert.AreEqual(alertName, RightAlertsMessage.Text.Trim());
            extent.SetStepStatusPass("Verified that alert message is displayed.");
            Assert.AreEqual(alertUnitName, RightAlertsVehicleName.Text.Trim());
            extent.SetStepStatusPass("Verified that alert vehicle name is displayed.");
            Assert.AreEqual(speed, RightAlertsSpeed.Text.Trim());
            extent.SetStepStatusPass("Verified that alert speed is displayed.");
            Assert.AreEqual(driverName, RightAlertsDriver.Text.Trim());
            extent.SetStepStatusPass("Verified that alert driver is displayed.");
            Assert.AreEqual(number, RightAlertsPhone.Text.Trim());
            extent.SetStepStatusPass("Verified that alert phone is displayed.");
            Assert.AreEqual(alertDate, RightAlertsTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alert time is displayed.");
            Assert.AreEqual(address, RightAlertsAddress.Text.Trim());
            extent.SetStepStatusPass("Verified that alert address is displayed.");
            wait.Until(driver => RightPanelCloseAlert.Displayed);
            extent.SetStepStatusPass("Verified that alert close button is displayed.");
            extent.SetStepStatusPass("Verified the alert right panel details.");
        }
        /// <summary>
        /// Verify Alert List View
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlertListView(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alertTree = getAPIResponse.GetAlertTree(userName, password);
            wait.Until(driver => Alerts.Displayed);
            Alerts.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Alerts"));
            wait.Until(driver => SearchFieldAlerts.Displayed);
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            Assert.AreEqual("Alerts", ListViewHeader.Text.Trim());
            string[] columnNameValues = { "Alert", "Date/Time", "Vehicle", "Assigned Driver", "Address" };
            for (int i = 1; i < 6; i++)
            {
                colNumber = i;
                Assert.AreEqual(columnNameValues[colNumber - 1], ColumnName.Text.Trim());
            }
            int rowCountValue = 5;

            if (alertTree.Count() <= 5)
                rowCountValue = alertTree.Count();

            for (int j = 0; j < rowCountValue; j++)
            {
                colNumber = 1;
                rowNumber = j + 1;
                Assert.AreEqual(alertTree[j].alertText.Trim(), RowValues.Text.Trim());
                colNumber = 2;
                Assert.AreEqual(alertTree[j].utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' h:mm tt"), RowValues.Text.Trim());
                colNumber = 3;
                Assert.IsTrue(RowValues.Text.Trim().Contains(alertTree[j].unitName));
                colNumber = 4;
                Assert.AreEqual(alertTree[j].driverName.ToString(), RowValues.Text.Trim());
                colNumber = 5;
                Assert.AreEqual(alertTree[j].address.ToString().Trim(), RowValues.Text.Trim());
                extent.SetStepStatusPass("Verified alert details.");

            }

            extent.SetStepStatusPass("Verified that alert matches the search result displayed.");
        }
        /// <summary>
        /// Right panel list view
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlertRightPanelListView(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alertTree = getAPIResponse.GetAlertTree(userName, password);
            extent.SetStepStatusPass("Fetched alert details.");
            string alertName = alertTree.FirstOrDefault().alertText.Trim();
            string alertUnitName = alertTree.FirstOrDefault().unitName.Trim();
            string alertDate = alertTree.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy',' h:mm tt");
            string driverName = alertTree.FirstOrDefault().driverName.Trim();
            string address = alertTree.FirstOrDefault().address.Trim();
            string number = alertTree.FirstOrDefault().contactPhone.Trim();
            string speed = Math.Floor(alertTree.FirstOrDefault().speed).ToString().Trim() + " km/h";
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => SearchFieldAlerts.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            wait.Until(driver => SearchFieldListAlerts.Displayed);
            SearchFieldListAlerts.SendKeys(alertName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alert name in search field.");
            colNumber = 1;
            rowNumber = 1;
            RowValues.Click();
            Thread.Sleep(2000);
            wait.Until(driver => RightAlertsHeading.Displayed);
            wait.Until(driver => RightHistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => RightFindNowButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => RightLocateButton.Displayed);
            extent.SetStepStatusPass("Verified that locate button is displayed.");
            wait.Until(driver => ShowOnMapButton.Displayed);
            extent.SetStepStatusPass("Verified that show on map button is displayed.");
            Assert.AreEqual(alertName, RightAlertsHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that alert heading is displayed.");
            Assert.AreEqual(alertName, RightAlertsHeading.Text.Trim());
            extent.SetStepStatusPass("Verified that alert heading is displayed.");
            Assert.AreEqual(alertUnitName, RightAlertsVehicle.Text.Trim());
            extent.SetStepStatusPass("Verified that alert vehicle name is displayed.");
            Assert.AreEqual("Alert Details", RightAlertsSubTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that alert details is displayed.");
            Assert.AreEqual(alertName, RightAlertsMessage.Text.Trim());
            extent.SetStepStatusPass("Verified that alert message is displayed.");
            Assert.AreEqual(alertUnitName, RightAlertsVehicleName.Text.Trim());
            extent.SetStepStatusPass("Verified that alert vehicle name is displayed.");
            Assert.AreEqual(speed, RightAlertsSpeed.Text.Trim());
            extent.SetStepStatusPass("Verified that alert speed is displayed.");
            Assert.AreEqual(driverName, RightAlertsDriver.Text.Trim());
            extent.SetStepStatusPass("Verified that alert driver is displayed.");
            Assert.AreEqual(number, RightAlertsPhone.Text.Trim());
            extent.SetStepStatusPass("Verified that alert phone is displayed.");
            Assert.AreEqual(alertDate, RightAlertsTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alert time is displayed.");
            Assert.AreEqual(address, RightAlertsAddress.Text.Trim());
            extent.SetStepStatusPass("Verified that alert address is displayed.");
            wait.Until(driver => RightPanelCloseListAlert.Displayed);
            RightPanelCloseListAlert.Click();
            extent.SetStepStatusPass("Verified that alert close button is displayed.");
            extent.SetStepStatusPass("Verified the alert right panel details.");
        }
        /// <summary>
        /// Get direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public string getDirectionValue(string direction)
        {
            string directionValue = string.Empty;
            switch (direction)
            {
                case "N":
                    directionValue = "North";
                    break;
                case "S":
                    directionValue = "South";
                    break;
                case "E":
                    directionValue = "East";
                    break;
                case "W":
                    directionValue = "West";
                    break;
                case "NE":
                    directionValue = "North East";
                    break;
                case "NW":
                    directionValue = "North West";
                    break;
                case "SE":
                    directionValue = "South East";
                    break;
                case "SW":
                    directionValue = "South West";
                    break;

            }
            return directionValue;
        }

        /// <summary>
        /// Verify Telemetry pop up details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyVehicleTelemetry(string userName, string password, string vehName)
        {
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleInfoBySearchKeyword(userName, password, vehName);
            extent.SetStepStatusPass("Fetched vehicle details.");
            string vehicleName = vehicleTree.FirstOrDefault().unitName.Trim();
            string driverName = vehicleTree.FirstOrDefault().driverName.Trim();
            string speed = Math.Round(vehicleTree.FirstOrDefault().speed).ToString().Trim();
            string direction = vehicleTree.FirstOrDefault().headStr.Trim();
            string location = vehicleTree.FirstOrDefault().address.Trim();
            string directionValue = getDirectionValue(direction);
            DateTime locationTime = vehicleTree.FirstOrDefault().utcTime;
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            wait.Until(driver => FirstSearchResultText.Displayed);
            FirstSearchResultText.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            Assert.AreEqual(vehicleName, TelemetryName.Text.Trim());
            Assert.AreEqual(driverName, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual(speed + " km/h - " + directionValue, TelemetrySpeed.Text.Trim());
            Assert.AreEqual(location, TelemetryLocation.Text.Trim());
            Assert.AreEqual(locationTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), TelemetryTimeSet.Text);
            extent.SetStepStatusPass("Verified the vehicle details.");
            Assert.IsTrue(TelemetryHistory.GetAttribute("src").Contains("tele-history"));
            Assert.IsTrue(TelemetryLocate.GetAttribute("src").Contains("tele-locate"));
            Assert.IsTrue(TelemetryReports.GetAttribute("src").Contains("tele-report"));
            Assert.IsTrue(TelemetryDashcam.GetAttribute("src").Contains("tele-cam"));
            wait.Until(driver => TelemetryViewDetails.Displayed);
            extent.SetStepStatusPass("Verified the view details and buttons.");
        }
        /// <summary>
        /// Verify Vehicle Right panel
        /// </summary>
        /// <param name="vehicleName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyVehicleRightPanel(string vehicleName, string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(userName, password);
            extent.SetStepStatusPass("Fetched vehicle details.");
            int vehicleId = 1;
            foreach (var n in vehicleTree)
            {
                if (n.unitName.Equals(vehicleName))
                {
                    vehicleId = n.unitId;
                }
            }
            getAPIResponse = new GetAPIResponse();
            var driverRightpanelStatus = getAPIResponse.GetDriverRightPanel(userName, password, vehicleId, false);
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            wait.Until(driver => FirstSearchResultText.Displayed);
            FirstSearchResultText.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            TelemetryViewDetails.Click();


            Thread.Sleep(2000);
            wait.Until(driver => RightPanelImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            Assert.AreEqual(driverRightpanelStatus.unitName, RightVehicleName.Text);
            extent.SetStepStatusPass("Verified that vehicle name is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverName, RightDriverName.Text);
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            var speedValue = Math.Round(driverRightpanelStatus.speed) + " km/h";
            Assert.AreEqual(speedValue, RightSpeedDetails.Text);
            extent.SetStepStatusPass("Verified that speed is displayed.");
            string directionValue = getDirectionValue(driverRightpanelStatus.headStr);
            Assert.AreEqual(directionValue, RightDirection.Text);
            extent.SetStepStatusPass("Verified that direction is displayed.");
            Assert.AreEqual(driverRightpanelStatus.address, RightLocationDetails.Text);
            extent.SetStepStatusPass("Verified that location details is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RightTimeDetails.Text);
            extent.SetStepStatusPass("Verified that time details is displayed.");
            wait.Until(driver => RightHistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => RightFindNowButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => RightReportsButton.Displayed);
            extent.SetStepStatusPass("Verified that report button is displayed.");
            wait.Until(driver => RightDashcamButton.Displayed);
            extent.SetStepStatusPass("Verified that dashcam button is displayed.");
            wait.Until(driver => RightInfoTabButton.Displayed);
            extent.SetStepStatusPass("Verified that info tab button is displayed.");
            wait.Until(driver => RightStatusTabButton.Displayed);
            extent.SetStepStatusPass("Verified that status tab button is displayed.");
            wait.Until(driver => RightServiceTabButton.Displayed);
            extent.SetStepStatusPass("Verified that service tab button is displayed.");
            Assert.AreEqual("Time at Location", RightTimeAtLocation.Text);
            extent.SetStepStatusPass("Verified that time at location label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RightTimeAtLocationValue.Text);
            extent.SetStepStatusPass("Verified that time at location text is displayed.");
            Assert.AreEqual("Driver", RightDriver.Text);
            extent.SetStepStatusPass("Verified that driver label is displayed.");
            if (driverRightpanelStatus.driverName == null)
                Assert.AreEqual("Driver not assigned", RightDriverValue.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.driverName, RightDriverValue.Text.Trim());
                extent.SetStepStatusPass($"Verified that driver name - {RightDriverValue.Text.Trim()} is displayed.");
            }
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Assert.AreEqual("Driver status", RightDriverStatus.Text);
            extent.SetStepStatusPass("Verified that driver status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverStatus, RightDriverStatusValue.Text);
            extent.SetStepStatusPass("Verified that driver status text is displayed.");
            Assert.AreEqual("Vehicle ID", RightVehId.Text);
            extent.SetStepStatusPass("Verified that vehicle id label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.vehId, RightVehIdValue.Text);
            extent.SetStepStatusPass("Verified that vehicle id text is displayed.");
            Assert.AreEqual("Registration", RightRegistration.Text);
            extent.SetStepStatusPass("Verified that registration label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.rego, RightRegistrationValue.Text);
            extent.SetStepStatusPass("Verified that registration text is displayed.");
            Assert.AreEqual("Odometer", RightOdometer.Text);
            extent.SetStepStatusPass("Verified that odometer label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.odoKm).ToString(), RightOdometerValue.Text);
            extent.SetStepStatusPass("Verified that odometer text is displayed.");
            Assert.AreEqual("Engine hours", RightEngHours.Text);
            extent.SetStepStatusPass("Verified that eng hours label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.engineHours) + " hrs", RightEngHoursValue.Text);
            extent.SetStepStatusPass("Verified that engine hours text is displayed.");

            Assert.AreEqual("Status", RightStatus.Text);
            extent.SetStepStatusPass("Verified that status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.status, RightStatusValue.Text);
            extent.SetStepStatusPass("Verified that status value text is displayed.");
            Assert.AreEqual("GPS State", RightGpsState.Text);
            extent.SetStepStatusPass("Verified that gps state label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.gpsState, RightGpsStateValue.Text);
            extent.SetStepStatusPass("Verified that gps state value text is displayed.");

            RightStatusTabButton.Click();
            wait.Until(driver => RightLocation.Displayed);
            extent.SetStepStatusPass("Verified that status tab is loaded.");
            Assert.AreEqual("Last Ignition OFF", RightLastIgnitionOff.Text);
            extent.SetStepStatusPass("Verified that last ign label is displayed.");
            Assert.AreEqual("Duration", RightDurationState.Text);
            extent.SetStepStatusPass("Verified that duration label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.lastStopDuration.ToString(), RightDurationStateValue.Text);
            extent.SetStepStatusPass("Verified that duration label is displayed.");
            Assert.AreEqual("Location", RightLocation.Text);
            extent.SetStepStatusPass("Verified that location label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.address, RightLocationValue.Text);
            extent.SetStepStatusPass("Verified that location value is displayed.");
            Assert.AreEqual(driverRightpanelStatus.lastStopTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RightDateTimeValue.Text);
            extent.SetStepStatusPass("Verified that date and time value is displayed.");
            Assert.AreEqual("Ignition", RightIgnition.Text);
            extent.SetStepStatusPass("Verified that ignition label is displayed.");
            if (driverRightpanelStatus.ign)
                Assert.AreEqual("ON", RightIgnitionValue.Text);
            else
                Assert.AreEqual("OFF", RightIgnitionValue.Text);
            extent.SetStepStatusPass("Verified that Ignition state value is displayed.");

            Assert.AreEqual("Power", RightPower.Text);
            extent.SetStepStatusPass("Verified that power label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.power, RightPowerValue.Text);
            extent.SetStepStatusPass("Verified that power value is displayed.");

            Assert.AreEqual("Backup Power", RightBackUpPower.Text);
            extent.SetStepStatusPass("Verified that back up power label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.backupPower, RightBackUpPowerValue.Text);
            extent.SetStepStatusPass("Verified that backup power value is displayed.");

            Assert.AreEqual("Trip Purpose", RightTipPurpose.Text);
            extent.SetStepStatusPass("Verified that trip purpose label is displayed.");

            if (driverRightpanelStatus.isPrivate)
                Assert.AreEqual("Private", RightTripPurposeValue.Text);
            else
                Assert.AreEqual("Business", RightTripPurposeValue.Text);
            extent.SetStepStatusPass("Verified that trip purpose value is displayed.");

        }
        /// <summary>
        /// Verify Driver tree
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyDriverTree(string userName, string password, string driver)
        {
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(userName, password);
            string driverName = driverTree.FirstOrDefault().driverShortName.Trim();
            string vehicleId = driverTree.FirstOrDefault().unitId.ToString().Trim();
            string groupName = driverTree.FirstOrDefault().groupName.Trim();
            extent.SetStepStatusPass("Fetched driver details.");
            for (int i = 0; i < driverTree.Count; i++)
            {
                if (driverTree[i].driverShortName == driver)
                {
                    driverName = driverTree[i].driverShortName.Trim();
                    vehicleId = driverTree[i].unitId.ToString().Trim();
                    groupName = driverTree[i].groupName.Trim();
                }
            }

            Drivers.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Drivers"));
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(2000);
            SearchField.SendKeys(driverName);
            Thread.Sleep(2000);
            FilterIcon.Click();
            ExpandAll.Click();
            FilterIcon.Click();
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Assert.AreEqual(groupName, FirstGroupSearch.Text.Split('(')[0].Replace("\r\n", "").Trim());
            extent.SetStepStatusPass("Verified that group matches the search result displayed.");
            Assert.AreEqual(driverName, FirstSearchResultText.Text.Trim());
            extent.SetStepStatusPass("Verified that driver matches the search result displayed.");
        }
        /// <summary>
        /// Verify Driver List View
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="driver"></param>
        public void VerifyDriverListView(string userName, string password, string driver)
        {
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(userName, password);
            wait.Until(driver => Drivers.Displayed);
            Drivers.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Drivers"));
            wait.Until(driver => SearchField.Displayed);
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            Assert.AreEqual("Drivers", ListViewHeader.Text.Trim());
            string[] columnNameValues = { "Driver", "Assigned Vehicle", "Department", "Group", "Last Contact", "Last Known Address" };
            for (int i = 1; i < 6; i++)
            {
                colNumber = i;
                Assert.AreEqual(columnNameValues[colNumber - 1], ColumnName.Text.Trim());
            }
            int rowCountValue = 5;

            if (driverTree.Count() <= 5)
                rowCountValue = driverTree.Count();

            for (int j = 0; j < driverTree.Count(); j++)
            {
                colNumber = 1;
                if (driverTree[j].vehicleName != null)
                {
                    colNumber = 1;
                    Assert.AreEqual(driverTree[j].driverShortName, RowValues.Text.Trim());
                    colNumber = 2;
                    Assert.AreEqual(driverTree[j].vehicleName, RowValues.Text.Trim());
                    colNumber = 3;
                    Assert.AreEqual("-", RowValues.Text.Trim());
                    colNumber = 4;
                    Assert.AreEqual(driverTree[j].groupName.ToString(), RowValues.Text.Trim());
                    colNumber = 5;
                    Assert.AreEqual(driverTree[j].utcTime?.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RowValues.Text.Trim());
                    colNumber = 6;
                    Assert.AreEqual(driverTree[j].address.ToString().Trim(), RowValues.Text.Trim());
                    extent.SetStepStatusPass("Verified vehicle details.");
                    rowNumber = rowNumber + 1;
                }
            }

            extent.SetStepStatusPass("Verified that driver matches the search result displayed.");
        }
        /// <summary>
        /// Verify Driver Telemetry pop up.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyDriverTelemetry(string userName, string password, string vehName)
        {
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleInfoBySearchKeyword(userName, password, vehName);
            extent.SetStepStatusPass("Fetched vehicle details.");
            string vehicleName = vehicleTree.FirstOrDefault().unitName.Trim();
            string driverName = vehicleTree.FirstOrDefault().driverName.Trim();
            string speed = Math.Round(vehicleTree.FirstOrDefault().speed).ToString().Trim();
            string direction = vehicleTree.FirstOrDefault().headStr.Trim();
            string location = vehicleTree.FirstOrDefault().address.Trim();
            string directionValue = getDirectionValue(direction);
            DateTime locationTime = vehicleTree.FirstOrDefault().utcTime;
            Drivers.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Drivers"));
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(2000);
            SearchField.SendKeys(driverName);
            Thread.Sleep(2000);
            FilterIcon.Click();
            ExpandAll.Click();
            FilterIcon.Click();
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered driver name in search field.");
            wait.Until(driver => FirstSearchResultText.Displayed);
            FirstSearchResultText.Click();
            Thread.Sleep(2000);
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            Assert.AreEqual(vehicleName, TelemetryName.Text.Trim());
            Assert.AreEqual(driverName, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual(speed + " km/h - " + directionValue, TelemetrySpeed.Text.Trim());
            Assert.AreEqual(location, TelemetryLocation.Text.Trim());
            Assert.AreEqual(locationTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, hh:mm tt"), TelemetryTimeSet.Text);
            extent.SetStepStatusPass("Verified the vehicle details.");
            Assert.IsTrue(TelemetryHistory.GetAttribute("src").Contains("tele-history"));
            Assert.IsTrue(TelemetryLocate.GetAttribute("src").Contains("tele-locate"));
            Assert.IsTrue(TelemetryReports.GetAttribute("src").Contains("tele-report"));
            Assert.IsTrue(TelemetryDashcam.GetAttribute("src").Contains("telecam-crown"));
            wait.Until(driver => TelemetryViewDetails.Displayed);
            extent.SetStepStatusPass("Verified the view details and buttons.");
        }


        /// <summary>
        /// Driver right panel in map view
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleName"></param>
        public void VerifyDriverRightPanel(string userName, string password, string vehicleName)
        {
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(userName, password);
            extent.SetStepStatusPass("Fetched vehicle details.");
            int vehicleId = 1;
            foreach (var n in vehicleTree)
            {
                if (n.unitName.Equals(vehicleName))
                {
                    vehicleId = n.unitId;
                }
            }
            var driverRightpanelStatus = getAPIResponse.GetDriverRightPanel(userName, password, vehicleId, false);
            string driverName = driverRightpanelStatus.driverName.Trim();
            Drivers.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Drivers"));
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(2000);
            SearchField.SendKeys(driverName);
            Thread.Sleep(2000);
            FilterIcon.Click();
            ExpandAll.Click();
            FilterIcon.Click();
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered driver name in search field.");
            wait.Until(driver => FirstSearchResultText.Displayed);
            FirstSearchResultText.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            TelemetryViewDetails.Click();
            Thread.Sleep(2000);
            wait.Until(driver => RightPanelImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverName, RightVehicleName.Text);
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Assert.AreEqual(driverRightpanelStatus.unitName, RightDriverPanelVehcile.Text);
            extent.SetStepStatusPass("Verified that vehicle name is displayed.");
            Assert.AreEqual(driverRightpanelStatus.contactPhone, RightPhoneDetails.Text);
            extent.SetStepStatusPass("Verified that speed is displayed.");
            var speedValue = Math.Round(driverRightpanelStatus.speed) + " km/h";
            Assert.AreEqual(speedValue, RightSpeedDetails.Text);
            extent.SetStepStatusPass("Verified that speed is displayed.");
            string directionValue = getDirectionValue(driverRightpanelStatus.headStr);
            Assert.AreEqual(directionValue, RightDirection.Text);
            extent.SetStepStatusPass("Verified that direction is displayed.");
            Assert.AreEqual(driverRightpanelStatus.address, RightLocationDetails.Text);
            extent.SetStepStatusPass("Verified that location details is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RightTimeDetails.Text);
            extent.SetStepStatusPass("Verified that time details is displayed.");
            wait.Until(driver => RightHistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => RightLocateButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => RightReportsButton.Displayed);
            extent.SetStepStatusPass("Verified that report button is displayed.");
            wait.Until(driver => RightDashcamButton.Displayed);
            extent.SetStepStatusPass("Verified that dashcam button is displayed.");
            wait.Until(driver => RightInfoTabButton.Displayed);
            extent.SetStepStatusPass("Verified that info tab button is displayed.");
            wait.Until(driver => RightStatusTabButton.Displayed);
            extent.SetStepStatusPass("Verified that status tab button is displayed.");
            Assert.AreEqual("Time at Location", RightTimeAtLocation.Text);
            extent.SetStepStatusPass("Verified that time at location label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RightTimeAtLocationValue.Text);
            extent.SetStepStatusPass("Verified that time at location text is displayed.");
            Assert.AreEqual("Driver", RightDriver.Text);
            extent.SetStepStatusPass("Verified that driver label is displayed.");
            if (driverRightpanelStatus.driverName == null)
                Assert.AreEqual("Driver not assigned", RightDriverValue.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.driverName, RightDriverValue.Text.Trim());
                extent.SetStepStatusPass($"Verified that driver name - {RightDriverValue.Text.Trim()} is displayed.");
            }
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Assert.AreEqual("Driver status", RightDriverStatus.Text);
            extent.SetStepStatusPass("Verified that driver status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverStatus, RightDriverStatusValue.Text);
            extent.SetStepStatusPass("Verified that driver status text is displayed.");
            Assert.AreEqual("Vehicle ID", RightVehId.Text);
            extent.SetStepStatusPass("Verified that vehicle id label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.vehId, RightVehIdValue.Text);
            extent.SetStepStatusPass("Verified that vehicle id text is displayed.");
            Assert.AreEqual("Registration", RightRegistration.Text);
            extent.SetStepStatusPass("Verified that registration label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.rego, RightRegistrationValue.Text);
            extent.SetStepStatusPass("Verified that registration text is displayed.");
            Assert.AreEqual("Odometer", RightOdometer.Text);
            extent.SetStepStatusPass("Verified that odometer label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.odoKm).ToString(), RightOdometerValue.Text);
            extent.SetStepStatusPass("Verified that odometer text is displayed.");
            Assert.AreEqual("Engine hours", RightEngHours.Text);
            extent.SetStepStatusPass("Verified that eng hours label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.engineHours) + " hrs", RightEngHoursValue.Text);
            extent.SetStepStatusPass("Verified that engine hours text is displayed.");
            Assert.AreEqual("Status", RightStatus.Text);
            extent.SetStepStatusPass("Verified that status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.status, RightStatusValue.Text);
            extent.SetStepStatusPass("Verified that status value text is displayed.");
            Assert.AreEqual("GPS State", RightGpsState.Text);
            extent.SetStepStatusPass("Verified that gps state label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.gpsState, RightGpsStateValue.Text);
            extent.SetStepStatusPass("Verified that gps state value text is displayed.");
            RightStatusTabButton.Click();
            wait.Until(driver => RightIgnition.Displayed);
            Assert.AreEqual("Ignition", RightIgnition.Text);
            extent.SetStepStatusPass("Verified that ignition label is displayed.");
            if (driverRightpanelStatus.ign)
                Assert.AreEqual("ON", RightIgnitionValue.Text);
            else
                Assert.AreEqual("OFF", RightIgnitionValue.Text);
            extent.SetStepStatusPass("Verified that Ignition state value is displayed.");

            Assert.AreEqual("Power", RightPower.Text);
            extent.SetStepStatusPass("Verified that power label is displayed.");

            if (driverRightpanelStatus.power == null)
                Assert.AreEqual("", RightPowerValue.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.power, RightPowerValue.Text);
                extent.SetStepStatusPass("Verified that power value is displayed.");
            }


            Assert.AreEqual("Backup Power", RightBackUpPower.Text);
            extent.SetStepStatusPass("Verified that back up power label is displayed.");
            if (driverRightpanelStatus.backupPower == null)
                Assert.AreEqual("", RightBackUpPowerValue.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.backupPower, RightBackUpPowerValue.Text);
                extent.SetStepStatusPass("Verified that backup power value is displayed.");
            }

            Assert.AreEqual("Trip Purpose", RightTipPurpose.Text);
            extent.SetStepStatusPass("Verified that trip purpose label is displayed.");

            if (driverRightpanelStatus.isPrivate)
                Assert.AreEqual("Private", RightTripPurposeValue.Text);
            else
                Assert.AreEqual("Business", RightTripPurposeValue.Text);

            Assert.AreEqual("Emergency", RightEmergency.Text);
            extent.SetStepStatusPass("Verified that emergency label is displayed.");
            Assert.AreEqual("ON", RightEmergencyValue.Text);
            extent.SetStepStatusPass("Verified that emergency value is displayed.");

            extent.SetStepStatusPass("Verified that trip purpose value is displayed.");
        }
        /// <summary>
        /// Driver right panel in list view
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleName"></param>
        public void VerifyDriverRightPanelListView(string userName, string password, string vehicleName)
        {
            wait.Until(driver => Drivers.Displayed);
            Drivers.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Drivers"));
            wait.Until(driver => SearchField.Displayed);
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(userName, password);
            extent.SetStepStatusPass("Fetched vehicle details.");
            int vehicleId = 1;
            foreach (var n in vehicleTree)
            {
                if (n.unitName.Equals(vehicleName))
                {
                    vehicleId = n.unitId;
                }
            }
            var driverRightpanelStatus = getAPIResponse.GetDriverRightPanel(userName, password, vehicleId, false);
            string driverName = driverRightpanelStatus.driverName.Trim();

            wait.Until(driver => SearchFieldListDrivers.Displayed);
            SearchFieldListDrivers.SendKeys(driverName);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Entered driver name in search field.");
            rowNumber = 1;
            colNumber = 1;
            RowValues.Click();
            Thread.Sleep(2000);
            wait.Until(driver => RightPanelImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverName, RightVehicleName.Text);
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Assert.AreEqual(driverRightpanelStatus.unitName, RightDriverPanelVehcile.Text);
            extent.SetStepStatusPass("Verified that vehicle name is displayed.");
            Assert.AreEqual(driverRightpanelStatus.contactPhone, RightPhoneDetails.Text);
            extent.SetStepStatusPass("Verified that speed is displayed.");
            var speedValue = Math.Round(driverRightpanelStatus.speed) + " km/h";
            Assert.AreEqual(speedValue, RightSpeedDetails.Text);
            extent.SetStepStatusPass("Verified that speed is displayed.");
            string directionValue = getDirectionValue(driverRightpanelStatus.headStr);
            Assert.AreEqual(directionValue, RightDirection.Text);
            extent.SetStepStatusPass("Verified that direction is displayed.");
            Assert.AreEqual(driverRightpanelStatus.address, RightLocationDetails.Text);
            extent.SetStepStatusPass("Verified that location details is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RightTimeDetails.Text);
            extent.SetStepStatusPass("Verified that time details is displayed.");
            wait.Until(driver => RightHistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => RightLocateButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => RightReportsButton.Displayed);
            extent.SetStepStatusPass("Verified that report button is displayed.");
            wait.Until(driver => RightDashcamButton.Displayed);
            extent.SetStepStatusPass("Verified that dashcam button is displayed.");
            wait.Until(driver => RightInfoTabButton.Displayed);
            extent.SetStepStatusPass("Verified that info tab button is displayed.");
            wait.Until(driver => RightStatusTabButton.Displayed);
            extent.SetStepStatusPass("Verified that status tab button is displayed.");
            Assert.AreEqual("Time at Location", RightTimeAtLocation.Text);
            extent.SetStepStatusPass("Verified that time at location label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), RightTimeAtLocationValue.Text);
            extent.SetStepStatusPass("Verified that time at location text is displayed.");
            Assert.AreEqual("Driver", RightDriver.Text);
            extent.SetStepStatusPass("Verified that driver label is displayed.");
            if (driverRightpanelStatus.driverName == null)
                Assert.AreEqual("Driver not assigned", RightDriverValue.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.driverName, RightDriverValue.Text.Trim());
                extent.SetStepStatusPass($"Verified that driver name - {RightDriverValue.Text.Trim()} is displayed.");
            }
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Assert.AreEqual("Driver status", RightDriverStatus.Text);
            extent.SetStepStatusPass("Verified that driver status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverStatus, RightDriverStatusValue.Text);
            extent.SetStepStatusPass("Verified that driver status text is displayed.");
            Assert.AreEqual("Vehicle ID", RightVehId.Text);
            extent.SetStepStatusPass("Verified that vehicle id label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.vehId, RightVehIdValue.Text);
            extent.SetStepStatusPass("Verified that vehicle id text is displayed.");
            Assert.AreEqual("Registration", RightRegistration.Text);
            extent.SetStepStatusPass("Verified that registration label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.rego, RightRegistrationValue.Text);
            extent.SetStepStatusPass("Verified that registration text is displayed.");
            Assert.AreEqual("Odometer", RightOdometer.Text);
            extent.SetStepStatusPass("Verified that odometer label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.odoKm).ToString(), RightOdometerValue.Text);
            extent.SetStepStatusPass("Verified that odometer text is displayed.");
            Assert.AreEqual("Engine hours", RightEngHours.Text);
            extent.SetStepStatusPass("Verified that eng hours label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.engineHours) + " hrs", RightEngHoursValue.Text);
            extent.SetStepStatusPass("Verified that engine hours text is displayed.");
            Assert.AreEqual("Status", RightStatus.Text);
            extent.SetStepStatusPass("Verified that status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.status, RightStatusValue.Text);
            extent.SetStepStatusPass("Verified that status value text is displayed.");
            Assert.AreEqual("GPS State", RightGpsState.Text);
            extent.SetStepStatusPass("Verified that gps state label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.gpsState, RightGpsStateValue.Text);
            extent.SetStepStatusPass("Verified that gps state value text is displayed.");
            RightStatusTabButton.Click();
            wait.Until(driver => RightIgnition.Displayed);
            Assert.AreEqual("Ignition", RightIgnition.Text);
            extent.SetStepStatusPass("Verified that ignition label is displayed.");
            if (driverRightpanelStatus.ign)
                Assert.AreEqual("ON", RightIgnitionValue.Text);
            else
                Assert.AreEqual("OFF", RightIgnitionValue.Text);
            extent.SetStepStatusPass("Verified that Ignition state value is displayed.");

            Assert.AreEqual("Power", RightPower.Text);
            extent.SetStepStatusPass("Verified that power label is displayed.");

            if (driverRightpanelStatus.power == null)
                Assert.AreEqual("", RightPowerValue.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.power, RightPowerValue.Text);
                extent.SetStepStatusPass("Verified that power value is displayed.");
            }


            Assert.AreEqual("Backup Power", RightBackUpPower.Text);
            extent.SetStepStatusPass("Verified that back up power label is displayed.");
            if (driverRightpanelStatus.backupPower == null)
                Assert.AreEqual("", RightBackUpPowerValue.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.backupPower, RightBackUpPowerValue.Text);
                extent.SetStepStatusPass("Verified that backup power value is displayed.");
            }

            Assert.AreEqual("Trip Purpose", RightTipPurpose.Text);
            extent.SetStepStatusPass("Verified that trip purpose label is displayed.");

            if (driverRightpanelStatus.isPrivate)
                Assert.AreEqual("Private", RightTripPurposeValue.Text);
            else
                Assert.AreEqual("Business", RightTripPurposeValue.Text);

            Assert.AreEqual("Emergency", RightEmergency.Text);
            extent.SetStepStatusPass("Verified that emergency label is displayed.");
            Assert.AreEqual("ON", RightEmergencyValue.Text);
            extent.SetStepStatusPass("Verified that emergency value is displayed.");

            extent.SetStepStatusPass("Verified that trip purpose value is displayed.");
        }
        /// <summary>
        /// Verify location tree
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationTree(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var locationTree = getAPIResponse.GetLocationTree(userName, password);
            extent.SetStepStatusPass("Fetched location details.");
            string locationName = locationTree.FirstOrDefault().locationName.Trim();
            string groupName = locationTree.FirstOrDefault().groupName.Trim();
            Locations.Click();
            wait.Until(driver => VehiclesText.Text.Contains("Locations"));
            Thread.Sleep(2000);
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchField.SendKeys(locationName);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Entered location name in search field.");
            Assert.AreEqual(groupName, FirstGroup.Text.Split('(')[0].Replace("\r\n", "").Trim());
            extent.SetStepStatusPass("Verified that group matches the search result displayed.");
            Assert.AreEqual(locationName, FirstSearchResultText.Text.Trim());
            extent.SetStepStatusPass("Verified that location matches the search result displayed.");
        }
        /// <summary>
        /// Verify location telemetry pop up
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationTelemetry(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var locationTree = getAPIResponse.GetLocationTree(userName, password);
            extent.SetStepStatusPass("Fetched location details.");
            string locationName = locationTree.FirstOrDefault().locationName.Trim();
            string locationType = locationTree.FirstOrDefault().locationTypeName.Trim();
            string groupName = locationTree.FirstOrDefault().groupName.Trim();
            Locations.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Locations"));
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchField.SendKeys(locationName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered Locations name in search field.");
            wait.Until(driver => FirstGroup.Displayed);
            FirstSearchResultText.Click();
            Thread.Sleep(2000);
            wait.Until(driver => LocTelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            Assert.AreEqual(locationName, TelemetryName.Text.Trim());
            Assert.AreEqual(locationType, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual(groupName, LocationGroupName.Text.Trim());
            extent.SetStepStatusPass("Verified the location details.");
            Assert.IsTrue(TelemetryHistory.GetAttribute("src").Contains("tele-edit"));
            buttonNumber = 2;
            Assert.IsTrue(TelemetryButtons.GetAttribute("src").Contains("tele-location"));
            buttonNumber = 3;
            Assert.IsTrue(TelemetryButtons.GetAttribute("src").Contains("tele-delete"));
            wait.Until(driver => TelemetryViewDetails.Displayed);
            wait.Until(driver => TelemetryClose.Displayed);
            TelemetryClose.Click();
            extent.SetStepStatusPass("Verified the view details and buttons.");
        }

        /// <summary>
        /// Verify location right panel
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationRightPanel(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var locationTree = getAPIResponse.GetLocationTree(userName, password);
            extent.SetStepStatusPass("Fetched location details.");
            string locationName = locationTree.FirstOrDefault().locationName.Trim();
            string locationType = locationTree.FirstOrDefault().locationTypeName.Trim();
            string groupName = locationTree.FirstOrDefault().groupName.Trim();
            string description = locationTree.FirstOrDefault().locationDescription.Trim();
            Locations.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Locations"));
            wait.Until(driver => SearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            SearchField.SendKeys(locationName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered Locations name in search field.");
            wait.Until(driver => FirstGroup.Displayed);
            FirstSearchResultText.Click();
            Thread.Sleep(2000);
            wait.Until(driver => LocTelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            TelemetryViewDetails.Click();
            wait.Until(driver => RightLocHeading.Displayed);
            Assert.AreEqual(locationName, RightLocHeading.Text.Trim());
            Assert.AreEqual(locationType, RightLocType.Text.Trim());
            wait.Until(driver => RightLocEditDetails.Displayed);
            extent.SetStepStatusPass("Verified that edit deail button is displayed.");
            wait.Until(driver => RightLocEdit.Displayed);
            extent.SetStepStatusPass("Verified that right location button is displayed.");
            wait.Until(driver => RightLocDelete.Displayed);
            extent.SetStepStatusPass("Verified that delete button is displayed.");
            Assert.AreEqual("Location Details", RightLocDetailsHeading.Text.Trim());
            Assert.AreEqual(locationName, RightLocNameDetails.Text.Trim());
            Assert.AreEqual("-", RightLocDeptDetails.Text.Trim());
            Assert.AreEqual(groupName, RightLocGroupDetails.Text.Trim());
            Assert.AreEqual(locationType, RightLocTypeDetails.Text.Trim());
            Assert.AreEqual(description, RightLocDescriptionDetails.Text.Trim());
            extent.SetStepStatusPass("Verified that location details are displayed properly.");
            RightLocClose.Click();
        }
        /// <summary>
        /// Verify location list view
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationListView(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var locationTree = getAPIResponse.GetLocationTree(userName, password);
            wait.Until(driver => Locations.Displayed);
            Locations.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Locations"));
            wait.Until(driver => SearchField.Displayed);
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            Assert.AreEqual("Locations", ListViewHeader.Text.Trim());
            string[] columnNameValues = { "Location", "Department", "Group", "Location Type", "Description" };
            for (int i = 1; i < 6; i++)
            {
                colNumber = i;
                Assert.AreEqual(columnNameValues[colNumber - 1], ColumnName.Text.Trim());
            }
            int rowCountValue = 5;

            if (locationTree.Count() <= 5)
                rowCountValue = locationTree.Count();

            for (int j = 0; j < rowCountValue; j++)
            {
                colNumber = 1;
                rowNumber = j + 1;
                Assert.AreEqual(locationTree[j].locationName.Trim(), RowValues.Text.Trim());
                colNumber = 2;
                Assert.AreEqual("-", RowValues.Text.Trim());
                colNumber = 3;
                Assert.AreEqual(locationTree[j].groupName.Trim(), RowValues.Text.Trim());
                colNumber = 4;
                Assert.AreEqual(locationTree[j].locationTypeName.Trim(), RowValues.Text.Trim());
                colNumber = 5;
                if (locationTree[j].locationDescription.ToString().Trim() == "")
                    Assert.AreEqual("-", RowValues.Text.Trim());
                else
                    Assert.AreEqual(locationTree[j].locationDescription.ToString().Trim(), RowValues.Text.Trim());
                extent.SetStepStatusPass("Verified location details.");

            }
            extent.SetStepStatusPass("Verified that location details are displayed properly.");
        }
        /// <summary>
        /// VErify location right panel in list view
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationRightPanelListView(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var locationTree = getAPIResponse.GetLocationTree(userName, password);
            extent.SetStepStatusPass("Fetched location details.");
            string locationName = locationTree.FirstOrDefault().locationName.Trim();
            string locationType = locationTree.FirstOrDefault().locationTypeName.Trim();
            string groupName = locationTree.FirstOrDefault().groupName.Trim();
            string description = locationTree.FirstOrDefault().locationDescription.Trim();
            Locations.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Locations"));
            wait.Until(driver => SearchField.Displayed);
            ListView.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ListViewHeader.Displayed);
            wait.Until(driver => SearchFieldListLoc.Displayed);
            SearchFieldListLoc.SendKeys(locationName);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            colNumber = 1;
            rowNumber = 1;
            RowValues.Click();
            Thread.Sleep(2000);
            wait.Until(driver => RightLocHeading.Displayed);
            Assert.AreEqual(locationName, RightLocHeading.Text.Trim());
            Assert.AreEqual(locationType, RightLocType.Text.Trim());
            wait.Until(driver => RightLocEditDetails.Displayed);
            extent.SetStepStatusPass("Verified that edit deail button is displayed.");
            wait.Until(driver => RightLocEdit.Displayed);
            extent.SetStepStatusPass("Verified that right location button is displayed.");
            wait.Until(driver => RightLocDelete.Displayed);
            extent.SetStepStatusPass("Verified that delete button is displayed.");
            Assert.AreEqual("Location Details", RightLocDetailsHeading.Text.Trim());
            Assert.AreEqual(locationName, RightLocNameDetails.Text.Trim());
            Assert.AreEqual("-", RightLocDeptDetails.Text.Trim());
            Assert.AreEqual(groupName, RightLocGroupDetails.Text.Trim());
            Assert.AreEqual(locationType, RightLocTypeDetails.Text.Trim());
            Assert.AreEqual(description, RightLocDescriptionDetails.Text.Trim());
            extent.SetStepStatusPass("Verified that location details are displayed properly for list view right panel.");
        }






        #endregion



    }
}
