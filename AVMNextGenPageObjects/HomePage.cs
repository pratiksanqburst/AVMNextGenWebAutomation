using AVMNextGenWebAutomation.AVMNextGenAPI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AVMNextGenWebAutomation.AVMNextGenPageObjects
{
    public class HomePage : AVMNextGenBase
    {
        IWebDriver homePageDriver;
        public HomePage() { }

        public HomePage(IWebDriver driver)
        {
            this.homePageDriver = driver;
        }
        public GetAPIResponse getAPIResponse;
        #region Properties
        string statusLegendValue = String.Empty;
        string timeValue = String.Empty;
        string[] statusLegendtexts = { "Moving", "Stopped", "Ignition OFF", "Power Fail", "Power Low", "Backup Battery Low", "Harsh Acceleration", "Harsh Braking", "Harsh Cornering", "Impact Detected", "Vehicle Rollover", "Speeding", "Stopped Speeding", "Tamper", "Sensor" };
        IWebElement Vehicles => driver.FindElement(By.Id("vehicles-icon"));
        IWebElement Drivers => driver.FindElement(By.Id("drivers-icon"));
        IWebElement Locations => driver.FindElement(By.Id("locations-icon"));
        IWebElement Alerts => driver.FindElement(By.Id("alerts-icon"));
        IWebElement Alarms => driver.FindElement(By.Id("alarms-icon"));
        IWebElement Home => driver.FindElement(By.LinkText("Home"));
        IWebElement FloatingPanelTitle => driver.FindElement(By.Id("fleet-accordion"));
        IWebElement VehicleSearchField => driver.FindElement(By.XPath("//input[@placeholder='Search Fleet']"));
        IWebElement DriverSearchField => driver.FindElement(By.XPath("//input[@placeholder='Search Drivers']"));
        IWebElement AlarmSearchField => driver.FindElement(By.XPath("//input[@placeholder='Search Alarms']"));
        IWebElement AlertSearchField => driver.FindElement(By.XPath("//input[@placeholder='Search Alerts']"));
        IWebElement LocationsSearchField => driver.FindElement(By.XPath("//input[@placeholder='Search Locations']"));
        IWebElement FirstGroup => driver.FindElement(By.XPath("//h2[contains(@id,'dept-header')]//button"));
        IWebElement FirstEntry => driver.FindElement(By.XPath("//div[@class='vehicle-list']/ul//button"));
        IWebElement AlarmTitle => driver.FindElement(By.XPath("//p[@class='alerts-text']"));
        IWebElement AlarmUnit => driver.FindElement(By.XPath("//p[@class='alerts-vehiclename']"));
        IWebElement AlarmTime => driver.FindElement(By.XPath("//p[@class='alerts-datetime']"));
        IWebElement SuccessMessageClose => driver.FindElement(By.XPath("//div[@id='toast-container']//button[@type='button']"));

        #region RightPanel
        IWebElement RightPanelExpand => driver.FindElement(By.Id("right-panel-collapse-arrow"));
        IWebElement VehicleImage => driver.FindElement(By.Id("vehicle-image"));
        IWebElement VehicleName => driver.FindElement(By.Id("vehicle-name-driver"));
        IWebElement VehicleNameValue => driver.FindElement(By.Id("vehicle-name"));
        IWebElement DriverName => driver.FindElement(By.Id("driver-name"));
        IWebElement IgnitionIcon => driver.FindElement(By.Id("ignition-icon"));
        IWebElement IgnitionText => driver.FindElement(By.Id("ignition-text"));
        IWebElement Speed => driver.FindElement(By.Id("distance"));
        IWebElement Direction => driver.FindElement(By.XPath("//span[@class='direction']"));
        IWebElement Locationicon => driver.FindElement(By.Id("location-image"));
        IWebElement LocationDetails => driver.FindElement(By.Id("location-details"));
        IWebElement TimeLogIcon => driver.FindElement(By.Id("time-log"));
        IWebElement TimeDetails => driver.FindElement(By.Id("time-details"));
        IWebElement HistoryButton => driver.FindElement(By.Id("history-button"));
        IWebElement HistoryTitle => driver.FindElement(By.XPath("//div[@class='title']/h2"));
        IWebElement StatusLegends => driver.FindElement(By.XPath("//label[contains(text(),'Status Legends')]"));
        IWebElement StatusLegendText => driver.FindElement(By.XPath($"//li[contains(text(),'{statusLegendValue}')]"));
        IWebElement HistoryContainer => driver.FindElement(By.XPath($"//div[@class='vehicle-info-container']"));
        IWebElement DriverStatusTextBox => driver.FindElement(By.XPath($"//div[contains(@class,'driver-status')]"));
        IWebElement TimeSelectionDropdown => driver.FindElement(By.XPath($"//ng-select"));
        IWebElement TimeSelectionValue => driver.FindElement(By.XPath($"//span[contains(text(),'{timeValue}')]"));
        IWebElement HistoryBackButton => driver.FindElement(By.XPath($"//div[@class='icons']/img[1]"));
        IWebElement LocateVehicleButton => driver.FindElement(By.Id("locate-vehicle-button"));
        IWebElement ReportsButton => driver.FindElement(By.Id("reports-button"));
        IWebElement DashcamButton => driver.FindElement(By.Id("dashcam-button"));
        IWebElement TrackVehicleButton => driver.FindElement(By.Id("track-vehicle-button"));
        IWebElement ShowOnMapButton => driver.FindElement(By.Id("show-on-map-button"));
        IWebElement InfoTab => driver.FindElement(By.Id("info-tab-switch"));
        IWebElement StatusTab => driver.FindElement(By.Id("status-tab-switch"));
        IWebElement ServiceTab => driver.FindElement(By.Id("service-tab-switch"));
        IWebElement TimeAtLocation => driver.FindElement(By.Id("time-at-location"));
        IWebElement TimeAtLocationText => driver.FindElement(By.Id("time-at-location-text"));
        IWebElement Driver => driver.FindElement(By.Id("driver"));
        IWebElement DriverStatus => driver.FindElement(By.Id("driver-status"));
        IWebElement DriverStatusText => driver.FindElement(By.Id("driver-status-text"));
        IWebElement VehicleId => driver.FindElement(By.Id("vehicle-id"));
        IWebElement VehicleIdText => driver.FindElement(By.Id("vehicle-id-text"));
        IWebElement Registration => driver.FindElement(By.Id("registration"));
        IWebElement RegistrationText => driver.FindElement(By.Id("registration-text"));
        IWebElement Odometer => driver.FindElement(By.Id("odometer"));
        IWebElement EngineHoursValue => driver.FindElement(By.XPath("//span[contains(text(),'Engine hours')]/following-sibling::span"));
        IWebElement TerminalStateValue => driver.FindElement(By.XPath("//span[contains(text(),'Terminal State')]/following-sibling::span"));
        IWebElement IgnitionValue => driver.FindElement(By.XPath("//span[contains(text(),'Ignition')]/following-sibling::span"));
        IWebElement BackupValue => driver.FindElement(By.XPath("//span[contains(text(),'Backup')]/following-sibling::span"));
        IWebElement LocationStatusValue => driver.FindElement(By.XPath("//p[contains(text(),'Location')]/following-sibling::p"));
        IWebElement DateAndTime => driver.FindElement(By.XPath("//p[contains(text(),'Date')]/following-sibling::p"));
        IWebElement OdometerText => driver.FindElement(By.Id("odometer-text"));
        IWebElement Location => driver.FindElement(By.Id("location-name"));
        IWebElement LocationTypeRightPanel => driver.FindElement(By.Id("location-vehicle-direction"));
        IWebElement LocationIconRight => driver.FindElement(By.Id("location-right-icon"));
        IWebElement EditDetail => driver.FindElement(By.Id("edit-detail-button"));
        IWebElement EditLocation => driver.FindElement(By.Id("edit-location-button"));
        IWebElement DeleteLocation => driver.FindElement(By.Id("delete-location-button"));
        IWebElement LocationDetailsText => driver.FindElement(By.XPath("//p[contains(text(),'Location details')]"));
        IWebElement LocationNameRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Name')]"));
        IWebElement LocationNameRightText => driver.FindElement(By.XPath("//span[contains(text(),'Name')]/following-sibling::span"));
        IWebElement GroupRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Group')]"));
        IWebElement GroupRightText => driver.FindElement(By.XPath("//span[contains(text(),'Group')]/following-sibling::span"));
        IWebElement LocationTypeRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Location Type')]"));
        IWebElement LocationTypeRightText => driver.FindElement(By.XPath("//span[contains(text(),'Location Type')]/following-sibling::span"));
        IWebElement DescriptionRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Description')]"));
        IWebElement DescriptionRightText => driver.FindElement(By.XPath("//span[contains(text(),'Description')]/following-sibling::span"));
        IWebElement AlertsIcon => driver.FindElement(By.Id("alerts-vehicle-img"));
        IWebElement AlertsName => driver.FindElement(By.Id("alerts-vehicle-name"));
        IWebElement AlertsVehicleName => driver.FindElement(By.Id("alerts-vehicle-name-text"));
        IWebElement AlertIgnitionIcon => driver.FindElement(By.Id("ignition-icon"));
        IWebElement AlertIgnitionText => driver.FindElement(By.Id("ignition-text"));
        IWebElement AlertDistance => driver.FindElement(By.Id("alerts-distance"));
        IWebElement AlertDirection => driver.FindElement(By.Id("alerts-direction"));
        IWebElement AlertDetailsText => driver.FindElement(By.XPath("//p[contains(text(),'Alert details')]"));
        IWebElement MessageRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Message')]"));
        IWebElement MessageRightText => driver.FindElement(By.XPath("//span[contains(text(),'Message')]/following-sibling::span"));
        IWebElement VehicleRightPlaceholder => driver.FindElement(By.XPath("//span[text()='Vehicle']"));
        IWebElement VehicleRightText => driver.FindElement(By.XPath("//span[contains(text(),'Vehicle')]/following-sibling::span"));
        IWebElement SpeedRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Speed')]"));
        IWebElement SpeedRightText => driver.FindElement(By.XPath("//span[contains(text(),'Speed')]/following-sibling::span"));
        IWebElement DriverRightPlaceholder => driver.FindElement(By.XPath("//p[@class='tabcontent-details']//span[text()='Driver']"));
        IWebElement DriverRightText => driver.FindElement(By.XPath("//span[contains(text(),'Driver')]/following-sibling::span"));
        IWebElement PhoneRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Phone')]"));
        IWebElement PhoneRightText => driver.FindElement(By.XPath("//span[contains(text(),'Phone')]/following-sibling::span"));
        IWebElement TimeRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Time')]"));
        IWebElement TimeRightText => driver.FindElement(By.XPath("//span[contains(text(),'Time')]/following-sibling::span"));
        IWebElement AddressRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Address')]"));
        IWebElement AddressRightText => driver.FindElement(By.XPath("//span[contains(text(),'Address')]/following-sibling::span"));
        IWebElement SuccessAlertDialogue => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement AlarmsIcon => driver.FindElement(By.Id("alarms-vehicle-img"));
        IWebElement AlarmsName => driver.FindElement(By.Id("alarms-vehicle-name"));
        IWebElement AlarmsVehicleName => driver.FindElement(By.Id("alarms-vehicle-name-text"));
        IWebElement AlarmIgnitionIcon => driver.FindElement(By.Id("ignition-icon"));
        IWebElement AlarmIgnitionText => driver.FindElement(By.Id("ignition-text"));
        IWebElement AlarmDistance => driver.FindElement(By.Id("alarms-distance"));
        IWebElement AlarmDirection => driver.FindElement(By.Id("alarms-direction"));
        IWebElement AlarmClear => driver.FindElement(By.Id("alarms-clear-button"));
        IWebElement AlarmDetailsText => driver.FindElement(By.XPath("//span[contains(text(),'Alarm details')]"));
        IWebElement AlarmRightPlaceholder => driver.FindElement(By.XPath("//span[@class='content-heading'][contains(text(),'Alarm')]"));
        IWebElement AlarmRightText => driver.FindElement(By.XPath("//span[contains(text(),'Alarm')]/following-sibling::span"));
        IWebElement FleetIDRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Fleet ID')]"));
        IWebElement FleetIDRightText => driver.FindElement(By.XPath("//span[contains(text(),'Fleet ID')]/following-sibling::span"));
        IWebElement DirectionRightPlaceholder => driver.FindElement(By.XPath("//span[contains(text(),'Direction')]"));
        IWebElement DirectionRightText => driver.FindElement(By.XPath("//span[contains(text(),'Direction')]/following-sibling::span"));
        IWebElement HomeTab => driver.FindElement(By.Id("menu-home"));
        IWebElement SaveScreenshot => driver.FindElement(By.XPath("//li[@ngbtooltip='Save As']"));
        IWebElement MapSettings => driver.FindElement(By.XPath("//li[@ngbtooltip='Settings']"));
        IWebElement PrimaryVehicleLabel => driver.FindElement(By.XPath("//div[contains(text(),'Primary Vehicle Label')]"));
        IWebElement VehicleIdLabel => driver.FindElement(By.XPath("//input[@id='map-settings-vehicle-id']/following-sibling::label[1]"));
        IWebElement TrackerIDLabel => driver.FindElement(By.XPath("//input[@id='map-settings-tracker-id']/following-sibling::label[1]"));
        IWebElement RegistrationLabel => driver.FindElement(By.XPath("//input[@id='map-settings-rego']/following-sibling::label[1]"));
        IWebElement DriverLabel => driver.FindElement(By.XPath(" //input[@id='map-settings-driver']/following-sibling::label[1]"));
        IWebElement EditLocationDetailsHeading => driver.FindElement(By.XPath("//h2[contains(text(),'Edit Details')]"));
        IWebElement EditLocationDetailsCancel => driver.FindElement(By.XPath("//app-edit-location//button[contains(text(),'Cancel')]"));
        IWebElement DeleteLocationDetailsTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement DeleteLocationDetailsCancel => driver.FindElement(By.XPath("//div[@class='modal-footer']//button[contains(text(),'Cancel')]"));
        IWebElement EditLocationZone => driver.FindElement(By.XPath("//p[@class='zone']"));
       
        #endregion

        #region Telemetry
        IWebElement TelemetryPopUp => driver.FindElement(By.XPath("//div[@class='vehicle-info-popup']"));
        IWebElement TelemetryName => driver.FindElement(By.XPath("//div[@class='vh-info']/h3[1]"));
        IWebElement TelemetrySecondLine => driver.FindElement(By.XPath("//div[@class='vh-info']/p"));
        IWebElement TimeText => driver.FindElement(By.XPath("//div[@class='time']/span"));
        IWebElement DateTelemetry => driver.FindElement(By.XPath("//div[@class='time']/p[1]"));
        IWebElement TimeTelemetry => driver.FindElement(By.XPath("//div[@class='time']/p[2]"));
        IWebElement LocationText => driver.FindElement(By.XPath("//div[@class='lcation']/span"));
        IWebElement LocationValue => driver.FindElement(By.XPath("//div[@class='lcation']/p[1]"));
        IWebElement SpeedText => driver.FindElement(By.XPath("//div[@class='speed']/span"));
        IWebElement SpeedTelemetry => driver.FindElement(By.XPath("//div[@class='speed']/p[1]"));
        IWebElement DirectionTelemetry => driver.FindElement(By.XPath("//div[@class='speed']/p[2]"));
        IWebElement reportsTelemetry => driver.FindElement(By.XPath("//a[@class='reports']"));
        IWebElement StatusTelemetry => driver.FindElement(By.XPath("//div[@class='vh-position']/div"));
        IWebElement ReportsHeading => driver.FindElement(By.XPath("//h3[text()='Reports']"));
        IWebElement HistoryDuration => driver.FindElement(By.XPath("//label[contains(text(),'History Duration')]"));
        IWebElement HistoryBack => driver.FindElement(By.XPath("//div[@class='cols flex-wrap']//img[contains(@src,'arrow-left')]"));

        IWebElement AlarmTimeTelemetry => driver.FindElement(By.XPath("//app-alarm-info-popup//span[contains(text(),'Time')]/following-sibling::p"));
        IWebElement AlarmFleet => driver.FindElement(By.XPath("//app-alarm-info-popup//span[contains(text(),'Fleet Id')]/following-sibling::p"));
        IWebElement AlarmSpeed => driver.FindElement(By.XPath("//app-alarm-info-popup//span[contains(text(),'Speed')]/following-sibling::p"));
        IWebElement AlarmDriver => driver.FindElement(By.XPath("//app-alarm-info-popup//span[contains(text(),'Driver')]/following-sibling::p"));
        IWebElement AlarmPhone => driver.FindElement(By.XPath("//app-alarm-info-popup//span[contains(text(),'Phone')]/following-sibling::p"));
        IWebElement AlarmAddress => driver.FindElement(By.XPath("//app-alarm-info-popup//span[contains(text(),'Address')]/following-sibling::p"));

        IWebElement AlertTelemetryDate => driver.FindElement(By.XPath("//app-alert-info-popup//span[contains(text(),'Time')]/following-sibling::p[1]"));
        IWebElement AlertTelemetryTime => driver.FindElement(By.XPath("//app-alert-info-popup//span[contains(text(),'Time')]/following-sibling::p[2]"));
        IWebElement AlertTelemetryLocation => driver.FindElement(By.XPath("//app-alert-info-popup//span[contains(text(),'Location')]/following-sibling::p"));
        IWebElement AlertTelemetrySpeed => driver.FindElement(By.XPath("//app-alert-info-popup//span[contains(text(),'Speed')]/following-sibling::p[1]"));
        IWebElement AlertTelemetryDirection => driver.FindElement(By.XPath("//app-alert-info-popup//span[contains(text(),'Speed')]/following-sibling::p[2]"));
        IWebElement AlertTelemetryDriver => driver.FindElement(By.XPath("//app-alert-info-popup//span[contains(text(),'Driver')]/following-sibling::p"));
        IWebElement AlertTelemetryPhone => driver.FindElement(By.XPath("//app-alert-info-popup//span[contains(text(),'Phone')]/following-sibling::p"));

        
        



        #endregion

        #region Dashcam
        IWebElement DashCamImage => driver.FindElement(By.XPath("//img[contains(@src,'dashcam-unavailable')]"));
        IWebElement DashCamUnavailableText => driver.FindElement(By.XPath("//p[@class='unavailable-text']"));
        IWebElement DashCamNotInstalledText => driver.FindElement(By.XPath("//p[@class='not-installed-text']"));
        IWebElement DashCamPhone => driver.FindElement(By.XPath("//p[@class='not-installed-text']/following-sibling::p[1]/span"));
        IWebElement DashCamEmail => driver.FindElement(By.XPath("//p[@class='not-installed-text']/following-sibling::p[2]/span"));
        IWebElement DashCamOk => driver.FindElement(By.Id("dashcam-ok-btn"));
        #endregion

        #endregion

        #region Methods
        /// <summary>
        /// Verify vehicle telemetry
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyVehicleTelemetry(string userName, string password, string vehName)
        {
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(userName, password);
            extent.SetStepStatusPass("Fetched vehicle details.");
            int vehicleId = 1;
            foreach (var n in vehicleTree)
            {
                if (n.unitName.Equals(vehName))
                {
                    vehicleId = n.unitId;
                }
            }
            getAPIResponse = new GetAPIResponse();
            var driverRightpanelStatus = getAPIResponse.GetDriverRightPanel(userName, password, vehicleId, false);
            extent.SetStepStatusPass("Fetched vehicle details.");
            string vehicleName = driverRightpanelStatus.unitName.Trim();
            string driverName = driverRightpanelStatus.driverName.Trim();
            string speed = Math.Round(driverRightpanelStatus.speed).ToString().Trim();
            int speedValue = Convert.ToInt32(Math.Round(driverRightpanelStatus.speed));
            string status = VehicleStatus(speedValue, driverRightpanelStatus.ign);
            string direction = driverRightpanelStatus.headStr.Trim();
            string location = driverRightpanelStatus.address.Trim();
            DateTime locationTime = driverRightpanelStatus.utcTime;
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            VehicleSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => VehicleImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            wait.Until(driver => ShowOnMapButton.Displayed);
            ShowOnMapButton.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");

            if (vehicleId.ToString() != "")
                Assert.AreEqual(vehicleName + $" ({vehicleId})", TelemetryName.Text.Trim());
            else
                Assert.AreEqual(vehicleName + $" (Not Set)", TelemetryName.Text.Trim());

            Assert.AreEqual(driverName, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual("Time", TimeText.Text.Trim());
            Assert.AreEqual(locationTime.ToLocalTime().ToString("dd'/'MM'/'yyyy"), DateTelemetry.Text.Trim());
            Assert.AreEqual(locationTime.ToLocalTime().ToString("hh:mm tt"), TimeTelemetry.Text.Trim());
            Assert.AreEqual("Location", LocationText.Text.Trim());
            Assert.AreEqual(location, LocationValue.Text.Trim());
            Assert.AreEqual("Speed", SpeedText.Text.Trim());
            Assert.AreEqual(speed + " km/h", SpeedTelemetry.Text.Trim());
            Assert.AreEqual(direction, DirectionTelemetry.Text.Trim());
            Assert.AreEqual(status, StatusTelemetry.Text.Trim());
            reportsTelemetry.Click();
            wait.Until(driver => ReportsHeading.Displayed);
            extent.SetStepStatusPass("Verified the Telemetry popup.");
        }

        /// <summary>
        /// Get vehicle status
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="ign"></param>
        /// <returns></returns>
        public string VehicleStatus(int speed, bool ign)
        {
            string status = "";
            if (ign)
            {
                if (speed < 5)
                    status = "Stopped";
                else
                    status = "Moving";
            }
            else
                status = "Ignition OFF";

            return status;
        }




        /// <summary>
        /// Verify the secondary labels displayed on the vehicle tree.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyMapSettingsLabel(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var vehicleTree = getAPIResponse.GetVehicleTree(userName, password);
            extent.SetStepStatusPass("Fetched vehicle details.");
            string vehicleName = vehicleTree[0].unitName.Trim();
            string vehicleId = vehicleTree[0].vehicleId.Trim();
            string trackerId = vehicleTree[0].fleetId.ToString().Trim();
            string registration = vehicleTree[0].vehicleRego.Trim();
            string driverLabel = vehicleTree[0].driverName.Trim();
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            VehicleSearchField.SendKeys(vehicleName);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            MapSettings.Click();
            wait.Until(driver => PrimaryVehicleLabel.Displayed);
            VehicleIdLabel.Click();
            Thread.Sleep(2000);
            if (vehicleId != "")
                Assert.AreEqual(vehicleName + $" ({vehicleId})", FirstEntry.Text.Trim());
            else
                Assert.AreEqual(vehicleName + $" (Not Set)", FirstEntry.Text.Trim());
            TrackerIDLabel.Click();
            Thread.Sleep(2000);
            if (trackerId != "")
                Assert.AreEqual(vehicleName + $" (TID: {trackerId})", FirstEntry.Text.Trim());
            else
                Assert.AreEqual(vehicleName + $" (Not Set)", FirstEntry.Text.Trim());
            RegistrationLabel.Click();
            Thread.Sleep(2000);
            if (registration != "")
                Assert.AreEqual(vehicleName + $" ({registration})", FirstEntry.Text.Trim());
            else
                Assert.AreEqual(vehicleName + $" (Not Set)", FirstEntry.Text.Trim());
            DriverLabel.Click();
            Thread.Sleep(2000);
            if (driverLabel != "")
                Assert.AreEqual(vehicleName + $" ({driverLabel})", FirstEntry.Text.Trim());
            else
                Assert.AreEqual(vehicleName + $" (Not Set)", FirstEntry.Text.Trim());
            VehicleIdLabel.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that secondary text changes when selecting options from map settings window.");
        }

        /// <summary>
        /// Verify map screeb shot download
        /// </summary>
        /// <param name="filename"></param>
        /// <exception cref="Exception"></exception>
        public void VerifySaveScreenShot(string filename)
        {
            wait.Until(driver => Vehicles.Displayed);
            Thread.Sleep(2000);
            wait.Until(driver => SaveScreenshot.Displayed);
            SaveScreenshot.Click();
            Thread.Sleep(3000);
            if (CheckFileDownloaded(filename))
                extent.SetStepStatusPass("Verified that the file is downloaded.");
            else
                throw new Exception("Download Failed");
        }
        /// <summary>
        /// Check the file that are downloaded in the last 3 minutes
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }
        /// <summary>
        /// Navigates to home page
        /// </summary>
        public void NavigateToHomePage()
        {

            wait.Until(driver => HomeTab.Displayed);
            extent.SetStepStatusPass("Verified that home link is displayed.");
            HomeTab.Click();
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
            Thread.Sleep(1000);
            Assert.IsTrue(FloatingPanelTitle.Text.Contains("Fleet List"));
            extent.SetStepStatusPass("Verified that Vehicles floating panel is displayed.");
            Thread.Sleep(1000);
            Assert.IsTrue(Drivers.Displayed);
            extent.SetStepStatusPass("Verified that drivers link is displayed.");
            Drivers.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Driver List"));
            extent.SetStepStatusPass("Verified that drivers floating panel is displayed.");
            Thread.Sleep(2000);
            Assert.IsTrue(Locations.Displayed);
            extent.SetStepStatusPass("Verified that locations link is displayed.");
            Locations.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(FloatingPanelTitle.Text.Contains("Locations"));
            extent.SetStepStatusPass("Verified that Locations floating panel is displayed.");
            Assert.IsTrue(Alerts.Displayed);
            extent.SetStepStatusPass("Verified that alerts link is displayed.");
            Alerts.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(FloatingPanelTitle.Text.Contains("Alerts"));
            extent.SetStepStatusPass("Verified that Alerts floating panel is displayed.");
            Assert.IsTrue(Alarms.Displayed);
            extent.SetStepStatusPass("Verified that alarms link is displayed.");
            Alarms.Click();
            Thread.Sleep(1000);
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
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            VehicleSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Assert.AreEqual(groupName, FirstGroup.Text.Split('(')[0].Replace("\r\n", "").Trim());
            extent.SetStepStatusPass("Verified that group matches the search result displayed.");
            if (vehicleId != "")
                Assert.AreEqual(vehicleName + $" ({vehicleId})", FirstEntry.Text.Trim());
            else
                Assert.AreEqual(vehicleName + $" (Not Set)", FirstEntry.Text.Trim());
            extent.SetStepStatusPass("Verified that vehicle matches the search result displayed.");
        }
        /// <summary>
        /// Verify the driver tree floatingpanel with API response.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyDriverTree(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(userName, password);
            extent.SetStepStatusPass("Fetched driver details.");
            string driverName = driverTree.FirstOrDefault().driverShortName.Trim();
            string groupName = driverTree.FirstOrDefault().groupName.Trim();
            Drivers.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Driver List"));
            wait.Until(driver => DriverSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            DriverSearchField.Clear();
            DriverSearchField.SendKeys(driverName);
            extent.SetStepStatusPass($"Entered driver name - {driverName} in search field.");
            wait.Until(driver => FirstGroup.Displayed);
            Assert.AreEqual(groupName, FirstGroup.Text.Split('(')[0].Replace("\r\n", "").Trim());
            extent.SetStepStatusPass("Verified that group matches the search result displayed.");
            Assert.AreEqual(driverName, FirstEntry.Text.Trim());
            extent.SetStepStatusPass($"Verified that driver name - {driverName} matches the search result displayed.");
        }
        /// <summary>
        /// Verify the alarm tree floatingpanel with API response.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyAlarmTree(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            string alarmName = alarmTree.alarms[0].alarmText.Trim();
            string alarmUnitName = alarmTree.alarms[0].unitName.Trim();
            string alarmTime = alarmTree.alarms[0].utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt");
            Alarms.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => AlarmSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            AlarmSearchField.SendKeys(alarmName);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Assert.AreEqual(alarmName, AlarmTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm title the search result displayed.");
            Assert.AreEqual(alarmUnitName, AlarmUnit.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm unit name matches the search result displayed.");
            Assert.AreEqual(alarmTime, AlarmTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm time matches the search result displayed.");
        }
        /// <summary>
        /// Alarm Right panel redirections
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyAlarmRightPanelRedirection(string userName, string password, string vehName)
        {
            wait.Until(driver => Alarms.Displayed);
            Thread.Sleep(2000);
            Alarms.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => AlarmSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(2000);
            AlarmSearchField.SendKeys(vehName);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Thread.Sleep(2000);
            AlarmTitle.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AlarmsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alarms image is displayed.");
            wait.Until(driver => AlarmsName.Displayed);
            Assert.AreEqual(vehName, AlarmsName.Text.Trim());
            
            extent.SetStepStatusPass("Verified that ping is sent from alarms.");
            ShowOnMapButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => TelemetryPopUp.Displayed);
            Thread.Sleep(2000);
            TrackVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            HistoryButton.Click();
            wait.Until(driver => HistoryDuration.Displayed);
            try
            {
                SuccessMessageClose.Click();
            }
            catch (Exception) { }
            HistoryBack.Click();
            wait.Until(driver => AlarmsIcon.Displayed);
            LocateVehicleButton.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified the redirections from alarms right panel.");

        }
        /// <summary>
        /// Verify Alarm Telemetry
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyAlarmTelemetry(string userName, string password, string vehName)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            int vehicleId = 1;
            string alarmName = "";
            string alarmTime = "";
            bool ignition = false;
            string driverName = "";
            double speed = 0;
            string directionValue = "";
            string fleetId = "";
            string phone = "";
            string address = "";
            foreach (var n in alarmTree.alarms)
            {
                if (n.unitName.Equals(vehName))
                {
                    vehicleId = n.unitId;
                    alarmName = n.alarmText.Trim();
                    alarmTime = n.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt");
                    ignition = n.ignition;
                    driverName = n.driverName;
                    speed = Math.Truncate(n.speed);
                    directionValue = n.headStr;
                    fleetId = n.fleetId.ToString();
                    phone = n.contactPhone;
                    address = n.address;
                    break;
                }
            }
            Alarms.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => AlarmSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(2000);
            AlarmSearchField.SendKeys(vehName);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Thread.Sleep(2000);
            AlarmTitle.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AlarmsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alarms image is displayed.");
            ShowOnMapButton.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            Assert.AreEqual(alarmName, TelemetryName.Text.Trim());
            Assert.AreEqual(vehName, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual(alarmTime, AlarmTimeTelemetry.Text.Trim());
            Assert.AreEqual(fleetId, AlarmFleet.Text.Trim());
            Assert.AreEqual(speed + " km/h", AlarmSpeed.Text.Trim());
            Assert.AreEqual(driverName, AlarmDriver.Text.Trim());
            Assert.AreEqual(phone, AlarmPhone.Text.Trim());
            Assert.AreEqual(address, AlarmAddress.Text.Trim());
            extent.SetStepStatusPass("Verified Telemetry details.");
        }


        /// <summary>
        /// Verify the alarm right panel
        /// </summary>
        public void VerifyAlarmRightPanel(string userName, string password,string vehName)
        {
            getAPIResponse = new GetAPIResponse();
            var alarmTree = getAPIResponse.GetAlarmTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            int vehicleId = 1;
            string alarmName = "";
            string alarmTime = "";
            bool ignition = false;
            string driverName = "";
            double speed = 0;
            string directionValue = "";
            string fleetId = "";
            string phone = "";
            string address = "";
            foreach (var n in alarmTree.alarms)
            {
                if (n.unitName.Equals(vehName))
                {
                    vehicleId = n.unitId;
                    alarmName = n.alarmText.Trim();
                    alarmTime = n.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt");
                    ignition=n.ignition;
                    driverName = n.driverName;
                    speed = Math.Truncate(n.speed);
                    directionValue = n.headStr;
                    fleetId = n.fleetId.ToString();
                    phone = n.contactPhone;
                    address = n.address;
                    break;
                }
            }
            Alarms.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => AlarmSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(2000);
            AlarmSearchField.SendKeys(alarmName);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Assert.AreEqual(alarmName, AlarmTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm title the search result displayed.");
            Assert.AreEqual(vehName, AlarmUnit.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm unit name matches the search result displayed.");
            Assert.AreEqual(alarmTime, AlarmTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alarm time name matches the search result displayed.");
            Thread.Sleep(2000);
            AlarmTitle.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AlarmsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alarms image is displayed.");
            wait.Until(driver => AlarmsName.Displayed);
            Assert.AreEqual(vehName, AlarmsName.Text.Trim());
            Assert.AreEqual(true, AlarmIgnitionIcon.Displayed);
            if (ignition)
                Assert.AreEqual("Ignition On", AlarmIgnitionText.Text.Trim());
            else
                Assert.AreEqual("Ignition Off", AlarmIgnitionText.Text.Trim());
            if (driverName == null)
                Assert.AreEqual("Driver not assigned", AlarmsVehicleName.Text.Trim());
            else
                Assert.AreEqual(driverName, AlarmsVehicleName.Text.Trim());
            Assert.AreEqual(speed + " km/h", AlarmDistance.Text.Trim());
            string direction = getDirectionValue(directionValue);
            Assert.AreEqual(direction, AlarmDirection.Text.Trim());
            Assert.AreEqual(true, HistoryButton.Displayed);
            Assert.AreEqual(true, LocateVehicleButton.Displayed);
            wait.Until(driver => AlarmClear.Displayed);
            extent.SetStepStatusPass("Verified that alarm right panel top section is displayed.");
            Assert.AreEqual("Alarm details", AlarmDetailsText.Text.Trim());
            Assert.AreEqual("Alarm", AlarmRightPlaceholder.Text.Trim());
            Assert.AreEqual(alarmName, AlarmRightText.Text.Trim());
            Assert.AreEqual("Vehicle", VehicleRightPlaceholder.Text.Trim());
            Assert.AreEqual(vehName, VehicleRightText.Text.Trim());
            Assert.AreEqual("Fleet ID", FleetIDRightPlaceholder.Text.Trim());
            Assert.AreEqual(fleetId, FleetIDRightText.Text.Trim());
            Assert.AreEqual("Time", TimeRightPlaceholder.Text.Trim());
            Assert.AreEqual(alarmTime, TimeRightText.Text.Trim());
            Assert.AreEqual("Driver", DriverRightPlaceholder.Text.Trim());
            if (driverName == null)
                Assert.AreEqual("Driver not assigned", DriverRightText.Text.Trim());
            else
                Assert.AreEqual(driverName, DriverRightText.Text.Trim());
            Assert.AreEqual("Phone", PhoneRightPlaceholder.Text.Trim());
            if (phone == null)
                Assert.AreEqual("", PhoneRightText.Text.Trim());
            else
                Assert.AreEqual(phone, PhoneRightText.Text.Trim());

            Assert.AreEqual("Speed", SpeedRightPlaceholder.Text.Trim());
            Assert.AreEqual(speed + " km/h", SpeedRightText.Text.Trim());
            Assert.AreEqual("Direction", DirectionRightPlaceholder.Text.Trim());
            Assert.AreEqual(direction, DirectionRightText.Text.Trim());
            Assert.AreEqual("Address", AddressRightPlaceholder.Text.Trim());
            Assert.AreEqual(address, AddressRightText.Text.Trim());
            extent.SetStepStatusPass("Verified that alarms right panel bottom section is displayed.");
        }
        /// <summary>
        /// Verify the alert tree floatingpanel with API response.
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
            string alertTime = alertTree.FirstOrDefault().utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt");
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => AlertSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            AlertSearchField.SendKeys(alertName);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Assert.AreEqual(alertName, AlarmTitle.Text.Trim());
            extent.SetStepStatusPass("Verified that alert title the search result displayed.");
            Assert.AreEqual(alertUnitName, AlarmUnit.Text.Trim());
            extent.SetStepStatusPass("Verified that alert unit name matches the search result displayed.");
            Assert.AreEqual(alertTime, AlarmTime.Text.Trim());
            extent.SetStepStatusPass("Verified that alert time name matches the search result displayed.");
        }
        /// <summary>
        /// Verify the alert right panel
        /// </summary>
        public void VerifyAlertRightPanel(string userName, string password,string vehName)
        {
            getAPIResponse = new GetAPIResponse();
            var alertTree = getAPIResponse.GetAlertTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            int vehicleId = 1;
            string alertName = "";
            string alertTime = "";
            bool ignition = false;
            string driverName = "";
            string speed = "";
            string directionValue = "";
            string fleetId = "";
            string phone = "";
            string address = "";
            foreach (var n in alertTree)
            {
                if (n.unitName.Equals(vehName))
                {
                    vehicleId = n.unitId;
                    alertName = n.alertText.Trim();
                    alertTime = n.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt");
                    ignition = n.ignition;
                    driverName = n.driverName;
                    speed = Math.Truncate(n.speed).ToString();
                    directionValue = n.headStr;
                    fleetId = n.fleetId.ToString();
                    phone = n.contactPhone;
                    address = n.address;
                    break;
                }
            }
            extent.SetStepStatusPass("Fetched alert details.");
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => AlertSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            AlertSearchField.SendKeys(alertName);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Thread.Sleep(2000);
            AlarmTitle.Click();
            wait.Until(driver => AlertsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alerts image is displayed.");
            wait.Until(driver => AlertsName.Displayed);
            Assert.AreEqual(vehName, AlertsName.Text.Trim());
            Assert.AreEqual(true, AlertIgnitionIcon.Displayed);
            if (ignition)
                Assert.AreEqual("Ignition On", AlertIgnitionText.Text.Trim());
            else
                Assert.AreEqual("Ignition Off", AlertIgnitionText.Text.Trim());
            if (driverName == null)
                Assert.AreEqual("Driver not assigned", AlertsVehicleName.Text.Trim());
            else
                Assert.AreEqual(driverName, AlertsVehicleName.Text.Trim());
            Assert.AreEqual(speed + " km/h", AlertDistance.Text.Trim());
            string direction = getDirectionValue(directionValue);
            Assert.AreEqual(direction, AlertDirection.Text.Trim());
            Assert.AreEqual(true, HistoryButton.Displayed);
            Assert.AreEqual(true, LocateVehicleButton.Displayed);
            Assert.AreEqual(true, ShowOnMapButton.Displayed);
            Assert.AreEqual(true, TrackVehicleButton.Displayed);
            extent.SetStepStatusPass("Verified that alert right panel top section is displayed.");
            Assert.AreEqual("Alert details", AlertDetailsText.Text.Trim());
            Assert.AreEqual("Message", MessageRightPlaceholder.Text.Trim());
            Assert.AreEqual(alertName, MessageRightText.Text.Trim());
            Assert.AreEqual("Vehicle", VehicleRightPlaceholder.Text.Trim());
            Assert.AreEqual(vehName, VehicleRightText.Text.Trim());
            Assert.AreEqual("Speed", SpeedRightPlaceholder.Text.Trim());
            Assert.AreEqual(speed + " km/h", SpeedRightText.Text.Trim());
            Assert.AreEqual("Driver", DriverRightPlaceholder.Text.Trim());
            if (driverName == null)
                Assert.AreEqual("Driver not assigned", DriverRightText.Text.Trim());
            else
                Assert.AreEqual(driverName, DriverRightText.Text.Trim());
            Assert.AreEqual("Phone", PhoneRightPlaceholder.Text.Trim());
            if (phone == null)
                Assert.AreEqual("", PhoneRightText.Text.Trim());
            else
                Assert.AreEqual(phone, PhoneRightText.Text.Trim());
            Assert.AreEqual("Time", TimeRightPlaceholder.Text.Trim());
            Assert.AreEqual(alertTime, TimeRightText.Text.Trim());
            Assert.AreEqual("Address", AddressRightPlaceholder.Text.Trim());
            Assert.AreEqual(address, AddressRightText.Text.Trim());
            extent.SetStepStatusPass("Verified that alert right panel bottom section is displayed.");
        }
        /// <summary>
        /// Verify Alert Telemetry Details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyAlertTelemetry(string userName, string password, string vehName)
        {
            getAPIResponse = new GetAPIResponse();
            var alertTree = getAPIResponse.GetAlertTree(userName, password);
            extent.SetStepStatusPass("Fetched alarm details.");
            int vehicleId = 1;
            string alertName = "";
            string alertDate = "";
            string alertTime = "";
            bool ignition = false;
            string driverName = "";
            string speed = "";
            string directionValue = "";
            string fleetId = "";
            string phone = "";
            string address = "";
            foreach (var n in alertTree)
            {
                if (n.unitName.Equals(vehName))
                {
                    vehicleId = n.unitId;
                    alertName = n.alertText.Trim();
                    alertDate = n.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy");
                    alertTime = n.utcTime.ToLocalTime().ToString("h:mm tt");
                    ignition = n.ignition;
                    driverName = n.driverName;
                    speed = Math.Truncate(n.speed).ToString();
                    directionValue = n.headStr;
                    fleetId = n.fleetId.ToString();
                    phone = n.contactPhone;
                    address = n.address;
                    break;
                }
            }
            extent.SetStepStatusPass("Fetched alert details.");
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => AlertSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            AlertSearchField.SendKeys(vehName);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Thread.Sleep(2000);
            AlarmTitle.Click();
            wait.Until(driver => AlertsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alerts image is displayed.");
            ShowOnMapButton.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            Assert.AreEqual(alertName, TelemetryName.Text.Trim());
            Assert.AreEqual(vehName, TelemetrySecondLine.Text.Trim());

            Assert.AreEqual(alertDate, AlertTelemetryDate.Text.Trim());
            Assert.AreEqual(alertTime, AlertTelemetryTime.Text.Trim());
            Assert.AreEqual(address, AlertTelemetryLocation.Text.Trim());
            Assert.AreEqual(speed + " km/h", AlertTelemetrySpeed.Text.Trim());
            Assert.AreEqual(directionValue, AlertTelemetryDirection.Text.Trim());
            Assert.AreEqual(driverName, AlertTelemetryDriver.Text.Trim());
            Assert.AreEqual(phone, AlertTelemetryPhone.Text.Trim());
            extent.SetStepStatusPass("Verified Telemetry details.");
        }
        /// <summary>
        /// Verify alert right panel redirections
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehName"></param>
        public void VerifyAlertRightPanelRedirection(string userName, string password, string vehName)
        {
            wait.Until(driver => Alerts.Displayed);
            Thread.Sleep(2000);
            Alerts.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => AlertSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            AlertSearchField.SendKeys(vehName);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Thread.Sleep(2000);
            AlarmTitle.Click();
            wait.Until(driver => AlertsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alerts image is displayed.");
            wait.Until(driver => AlertsName.Displayed);
            Assert.AreEqual(vehName, AlertsName.Text.Trim());
            extent.SetStepStatusPass("Verified that ping is sent from alerts.");
            ShowOnMapButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => TelemetryPopUp.Displayed);
            Thread.Sleep(2000);
            TrackVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            HistoryButton.Click();
            wait.Until(driver => HistoryDuration.Displayed);
            Thread.Sleep(2000);
            try
            {
                SuccessMessageClose.Click();
            }
            catch (Exception) { }
            HistoryBack.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AlertsIcon.Displayed);
            LocateVehicleButton.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified the redirections from alerts right panel.");

        }
        /// <summary>
        /// Verify location tree displayed on the left panel
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
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Locations"));
            wait.Until(driver => LocationsSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            LocationsSearchField.SendKeys(locationName);
            extent.SetStepStatusPass("Entered location name in search field.");
            wait.Until(driver => FirstGroup.Displayed);
            Assert.AreEqual(groupName, FirstGroup.Text.Split('(')[0].Replace("\r\n", "").Trim());
            extent.SetStepStatusPass("Verified that group matches the search result displayed.");
            Assert.AreEqual(locationName, FirstEntry.Text.Trim());
            extent.SetStepStatusPass("Verified that location name matches the search result displayed.");
        }
        /// <summary>
        /// Verifies location tab right panel
        /// </summary>
        public void VerifyLocationRightPanel(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var locationTree = getAPIResponse.GetLocationTree(userName, password);
            extent.SetStepStatusPass("Fetched location details.");
            string locationName = locationTree.FirstOrDefault().locationName.Trim();
            string groupName = locationTree.FirstOrDefault().groupName.Trim();
            Locations.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Locations"));
            wait.Until(driver => LocationsSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            LocationsSearchField.SendKeys(locationName);
            extent.SetStepStatusPass("Entered location name in search field.");
            Assert.AreEqual(locationName, FirstEntry.Text.Trim());
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => LocationIconRight.Displayed);
            extent.SetStepStatusPass("Verified that location image is displayed.");
            Assert.AreEqual(locationName, Location.Text.Trim());
            Assert.AreEqual(locationTree.FirstOrDefault().locationTypeName, LocationTypeRightPanel.Text.Trim());
            Assert.AreEqual(true, EditDetail.Displayed);
            Assert.AreEqual(true, EditLocation.Displayed);
            Assert.AreEqual(true, DeleteLocation.Displayed);
            Assert.AreEqual(true, ShowOnMapButton.Displayed);
            extent.SetStepStatusPass("Verified that location right panel top section is displayed.");
            Assert.AreEqual("Location details", LocationDetailsText.Text.Trim());
            Assert.AreEqual("Name", LocationNameRightPlaceholder.Text.Trim());
            Assert.AreEqual(locationName, LocationNameRightText.Text.Trim());
            Assert.AreEqual("Group", GroupRightPlaceholder.Text.Trim());
            Assert.AreEqual(locationTree.FirstOrDefault().groupName, GroupRightText.Text.Trim());
            Assert.AreEqual("Location Type", LocationTypeRightPlaceholder.Text.Trim());
            Assert.AreEqual(locationTree.FirstOrDefault().locationTypeName, LocationTypeRightText.Text.Trim());
            Assert.AreEqual("Description", DescriptionRightPlaceholder.Text.Trim());
            Assert.AreEqual(locationTree.FirstOrDefault().locationDescription, DescriptionRightText.Text.Trim());
            extent.SetStepStatusPass("Verified that location right panel bottom section is displayed.");
        }
        /// <summary>
        /// Verify Location Right panel redirection
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyLocationRightPanelRedirection(string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var locationTree = getAPIResponse.GetLocationTree(userName, password);
            extent.SetStepStatusPass("Fetched location details.");
            string locationName = locationTree.FirstOrDefault().locationName.Trim();
            Locations.Click();
            Thread.Sleep(1000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Locations"));
            wait.Until(driver => LocationsSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            LocationsSearchField.SendKeys(locationName);
            extent.SetStepStatusPass("Entered location name in search field.");
            Assert.AreEqual(locationName, FirstEntry.Text.Trim());
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => LocationIconRight.Displayed);
            extent.SetStepStatusPass("Verified that location image is displayed.");
            Assert.AreEqual(locationName, Location.Text.Trim());
            Assert.AreEqual(locationTree.FirstOrDefault().locationTypeName, LocationTypeRightPanel.Text.Trim());
            Assert.AreEqual(true, EditDetail.Displayed);
            Assert.AreEqual(true, EditLocation.Displayed);
            Assert.AreEqual(true, DeleteLocation.Displayed);
            Assert.AreEqual(true, ShowOnMapButton.Displayed);
            extent.SetStepStatusPass("Verified that location right panel top section is displayed.");
            EditDetail.Click();
            wait.Until(driver => EditLocationDetailsHeading.Displayed);
            EditLocationDetailsCancel.Click();
            extent.SetStepStatusPass("Verified redirection of edit details button.");
            Thread.Sleep(1000);
            DeleteLocation.Click();
            wait.Until(driver => DeleteLocationDetailsTitle.Displayed);
            DeleteLocationDetailsCancel.Click();
            extent.SetStepStatusPass("Verified redirection of delete location button.");
            Thread.Sleep(1000);
            EditLocation.Click();
            wait.Until(driver => EditLocationZone.Displayed);
            extent.SetStepStatusPass("Verified the redirection for location right panel.");
        }

        /// <summary>
        /// VerifyVehicleHistory Page
        /// </summary>
        /// <param name="vehicleName"></param>
        public void VerifyVehicleHistory(string vehicleName)
        {
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(2000);
            VehicleSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => VehicleImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            wait.Until(driver => HistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            HistoryButton.Click();
            Thread.Sleep(3000);
            wait.Until(driver => HistoryTitle.Displayed);
            Assert.IsTrue(HistoryTitle.Text.Contains(vehicleName));
            extent.SetStepStatusPass("Verified that history title is displayed.");
            wait.Until(driver => StatusLegends.Displayed);
            extent.SetStepStatusPass("Verified that status legends is displayed.");
            StatusLegends.Click();
            Thread.Sleep(2000);
            for (int i = 0; i < statusLegendtexts.Length; i++)
            {
                statusLegendValue = statusLegendtexts[i];
                wait.Until(driver => StatusLegendText.Displayed);
            }
            StatusLegends.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that status legend texts are displayed.");
            wait.Until(driver => HistoryContainer.Displayed);
            extent.SetStepStatusPass("Verified that history container is displayed.");
            wait.Until(driver => DriverStatusTextBox.Displayed);
            extent.SetStepStatusPass("Verified that driver status box is displayed.");
            wait.Until(driver => TimeSelectionDropdown.Displayed);
            TimeSelectionDropdown.Click();
            Thread.Sleep(2000);
            timeValue = "1 Hour";
            wait.Until(driver => TimeSelectionValue.Displayed);
            timeValue = "2 Hours";
            wait.Until(driver => TimeSelectionValue.Displayed);
            timeValue = "4 Hours";
            wait.Until(driver => TimeSelectionValue.Displayed);
            timeValue = "8 Hours";
            wait.Until(driver => TimeSelectionValue.Displayed);
            extent.SetStepStatusPass("Verified that time dropdown is displayed.");
            TimeSelectionValue.Click();
            wait.Until(driver => HistoryBackButton.Displayed);
            HistoryBackButton.Click();
            extent.SetStepStatusPass("Verified that the history back button is displayed.");

        }
        /// <summary>
        /// Verify Right Panel redirections
        /// </summary>
        /// <param name="vehicleName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyVehicleRightPanelRedirection(string vehicleName, string userName, string password)
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
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            VehicleSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => VehicleImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            ShowOnMapButton.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            DashCamUnavailableCheck();
            LocateVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            HistoryButton.Click();
            wait.Until(driver => HistoryDuration.Displayed);
            HistoryBack.Click();
            wait.Until(driver => VehicleImage.Displayed);
            ReportsButton.Click();
            wait.Until(driver => ReportsHeading.Displayed);
            extent.SetStepStatusPass("Verified the right panel redirections.");
        }

        /// <summary>
        /// Verify the contents of vehicle right Panel
        /// </summary>
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

            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            VehicleSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => VehicleImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            Assert.AreEqual(driverRightpanelStatus.unitName, VehicleName.Text);
            extent.SetStepStatusPass("Verified that vehicle name is displayed.");
            wait.Until(driver => IgnitionIcon.Displayed);
            extent.SetStepStatusPass("Verified that vehicle ignition icon is displayed.");
            if (driverRightpanelStatus.ign)
                Assert.AreEqual("Ignition ON", IgnitionText.Text);
            else
                Assert.AreEqual("Ignition OFF", IgnitionText.Text);
            extent.SetStepStatusPass("Verified that ignition text is displayed.");
            var speedValue = Math.Round(driverRightpanelStatus.speed) + " km/h";
            Assert.AreEqual(speedValue, Speed.Text);
            extent.SetStepStatusPass("Verified that speed is displayed.");
            string directionValue = getDirectionValue(driverRightpanelStatus.headStr);
            Assert.AreEqual(directionValue, Direction.Text);
            extent.SetStepStatusPass("Verified that direction is displayed.");
            wait.Until(driver => Locationicon.Displayed);
            extent.SetStepStatusPass("Verified that location icon is displayed.");
            Assert.AreEqual(driverRightpanelStatus.address, LocationDetails.Text);
            extent.SetStepStatusPass("Verified that location details is displayed.");
            wait.Until(driver => TimeLogIcon.Displayed);
            extent.SetStepStatusPass("Verified that time log icon is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), TimeDetails.Text);
            extent.SetStepStatusPass("Verified that time details is displayed.");
            wait.Until(driver => HistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => LocateVehicleButton.Displayed);
            extent.SetStepStatusPass("Verified that track vehicle button is displayed.");
            wait.Until(driver => ShowOnMapButton.Displayed);
            extent.SetStepStatusPass("Verified that show on map button is displayed.");
            wait.Until(driver => InfoTab.Displayed);
            extent.SetStepStatusPass("Verified that info tab button is displayed.");
            wait.Until(driver => StatusTab.Displayed);
            extent.SetStepStatusPass("Verified that status tab button is displayed.");
            wait.Until(driver => ServiceTab.Displayed);
            extent.SetStepStatusPass("Verified that service tab button is displayed.");
            Assert.AreEqual("Time at Location", TimeAtLocation.Text);
            extent.SetStepStatusPass("Verified that time at location label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), TimeAtLocationText.Text);
            extent.SetStepStatusPass("Verified that time at location text is displayed.");
            Assert.AreEqual("Driver", Driver.Text);
            extent.SetStepStatusPass("Verified that driver label is displayed.");
            if (driverRightpanelStatus.driverName == null)
                Assert.AreEqual("Driver not assigned", DriverName.Text.Trim());
            else
            {
                Assert.AreEqual(driverRightpanelStatus.driverName, DriverName.Text.Trim());
                extent.SetStepStatusPass($"Verified that driver name - {DriverName.Text.Trim()} is displayed.");
            }
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Actions actions = new Actions(driver);
            actions.MoveToElement(DriverStatus);
            actions.Perform();
            Assert.AreEqual("Driver status", DriverStatus.Text);
            extent.SetStepStatusPass("Verified that driver status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverStatus, DriverStatusText.Text);
            extent.SetStepStatusPass("Verified that driver status text is displayed.");
            Assert.AreEqual("Vehicle ID", VehicleId.Text);
            extent.SetStepStatusPass("Verified that vehicle id label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.vehId, VehicleIdText.Text);
            extent.SetStepStatusPass("Verified that vehicle id text is displayed.");
            Assert.AreEqual("Registration", Registration.Text);
            extent.SetStepStatusPass("Verified that registration label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.rego, RegistrationText.Text);
            extent.SetStepStatusPass("Verified that registration text is displayed.");
            Assert.AreEqual("Odometer", Odometer.Text);
            extent.SetStepStatusPass("Verified that odometer label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.odoKm).ToString(), OdometerText.Text);
            extent.SetStepStatusPass("Verified that odometer text is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.engineHours) + " hrs", EngineHoursValue.Text);
            extent.SetStepStatusPass("Verified that engine hours text is displayed.");
            StatusTab.Click();
            wait.Until(driver => LocationStatusValue.Displayed);
            extent.SetStepStatusPass("Verified that status tab is loaded.");
            Assert.AreEqual(driverRightpanelStatus.address, LocationStatusValue.Text);
            extent.SetStepStatusPass("Verified that location value is displayed.");
            Assert.AreEqual(driverRightpanelStatus.lastStopTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), DateAndTime.Text);
            extent.SetStepStatusPass("Verified that date and time value is displayed.");
            //Assert.AreEqual(driverRightpanelStatus.terminalState, TerminalStateValue.Text);
            //extent.SetStepStatusPass("Verified that terminal state value is displayed.");
            if (driverRightpanelStatus.ign)
                Assert.AreEqual("ON", IgnitionValue.Text);
            else
                Assert.AreEqual("OFF", IgnitionValue.Text);
            extent.SetStepStatusPass("Verified that Ignition state value is displayed.");

        }
        /// <summary>
        /// Returns direction of a vehicle
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
        /// Verify the contents of driver right Panel
        /// </summary>
        public void VerifyDriverRightPanel(string driverName, string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(userName, password);
            extent.SetStepStatusPass("Fetched driver details.");
            int driverId = 1;
            foreach (var n in driverTree)
            {
                if (n.driverShortName.Equals(driverName))
                {
                    driverId = n.driverId;
                }
            }
            getAPIResponse = new GetAPIResponse();
            var driverRightpanelStatus = getAPIResponse.GetDriverRightPanel(userName, password, driverId);
            Drivers.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Driver List"));
            wait.Until(driver => DriverSearchField.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            DriverSearchField.Clear();
            DriverSearchField.SendKeys(driverName);
            extent.SetStepStatusPass("Entered driver name in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => DriverName.Displayed);
            extent.SetStepStatusPass("Verified that driver name is available.");
            Assert.AreEqual(driverRightpanelStatus.driverName, DriverName.Text);
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Assert.AreEqual(driverRightpanelStatus.unitName, VehicleName.Text);
            extent.SetStepStatusPass("Verified that vehicle name is displayed.");
            wait.Until(driver => IgnitionIcon.Displayed);
            extent.SetStepStatusPass("Verified that vehicle ignition icon is displayed.");
            if (driverRightpanelStatus.ign)
                Assert.AreEqual("Ignition ON", IgnitionText.Text);
            else
                Assert.AreEqual("Ignition OFF", IgnitionText.Text);
            extent.SetStepStatusPass("Verified that ignition text is displayed.");
            var speedValue = Math.Round(driverRightpanelStatus.speed) + " km/h";
            Assert.AreEqual(speedValue, Speed.Text);
            extent.SetStepStatusPass("Verified that speed is displayed.");
            string directionValue = getDirectionValue(driverRightpanelStatus.headStr);
            Assert.AreEqual(directionValue, Direction.Text);
            extent.SetStepStatusPass("Verified that direction is displayed.");
            wait.Until(driver => Locationicon.Displayed);
            extent.SetStepStatusPass("Verified that location icon is displayed.");
            //Assert.AreEqual(driverRightpanelStatus.address, LocationDetails.Text);
            //extent.SetStepStatusPass("Verified that location details is displayed.");
            wait.Until(driver => TimeLogIcon.Displayed);
            extent.SetStepStatusPass("Verified that time log icon is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), TimeDetails.Text);
            extent.SetStepStatusPass("Verified that time details is displayed.");
            wait.Until(driver => HistoryButton.Displayed);
            extent.SetStepStatusPass("Verified that history button is displayed.");
            wait.Until(driver => LocateVehicleButton.Displayed);
            extent.SetStepStatusPass("Verified that locate vehicle button is displayed.");
            wait.Until(driver => ReportsButton.Displayed);
            extent.SetStepStatusPass("Verified that reports button is displayed.");
            wait.Until(driver => ShowOnMapButton.Displayed);
            extent.SetStepStatusPass("Verified that show on map button is displayed.");
            wait.Until(driver => InfoTab.Displayed);
            extent.SetStepStatusPass("Verified that info tab button is displayed.");
            wait.Until(driver => StatusTab.Displayed);
            extent.SetStepStatusPass("Verified that status tab button is displayed.");
            Assert.AreEqual("Time at Location", TimeAtLocation.Text);
            extent.SetStepStatusPass("Verified that time at location label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.utcTime.ToLocalTime().ToString("dd'/'MM'/'yyyy, h:mm tt"), TimeAtLocationText.Text);
            extent.SetStepStatusPass("Verified that time at location text is displayed.");
            Assert.AreEqual("Driver", Driver.Text);
            extent.SetStepStatusPass("Verified that driver label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverName, DriverName.Text);
            extent.SetStepStatusPass("Verified that driver name is displayed.");
            Actions actions = new Actions(driver);
            actions.MoveToElement(DriverStatus);
            actions.Perform();
            Assert.AreEqual("Driver status", DriverStatus.Text);
            extent.SetStepStatusPass("Verified that driver status label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.driverStatus, DriverStatusText.Text);
            extent.SetStepStatusPass("Verified that driver status text is displayed.");
            Assert.AreEqual("Vehicle ID", VehicleId.Text);
            extent.SetStepStatusPass("Verified that vehicle id label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.vehId, VehicleIdText.Text);
            extent.SetStepStatusPass("Verified that vehicle id text is displayed.");
            Assert.AreEqual("Registration", Registration.Text);
            extent.SetStepStatusPass("Verified that registration label is displayed.");
            Assert.AreEqual(driverRightpanelStatus.rego, RegistrationText.Text);
            extent.SetStepStatusPass("Verified that registration text is displayed.");
            Assert.AreEqual("Odometer", Odometer.Text);
            extent.SetStepStatusPass("Verified that odometer label is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.odoKm).ToString(), OdometerText.Text);
            extent.SetStepStatusPass("Verified that odometer text is displayed.");
            Assert.AreEqual(Math.Round(driverRightpanelStatus.engineHours) + " hrs", EngineHoursValue.Text);
            extent.SetStepStatusPass("Verified that engine hours text is displayed.");
            StatusTab.Click();
            wait.Until(driver => IgnitionValue.Displayed);
            extent.SetStepStatusPass("Verified that status tab is loaded.");
            //Assert.AreEqual(driverRightpanelStatus.terminalState, TerminalStateValue.Text);
            //extent.SetStepStatusPass("Verified that terminal state value is displayed.");
            if (driverRightpanelStatus.ign)
                Assert.AreEqual("ON", IgnitionValue.Text);
            else
                Assert.AreEqual("OFF", IgnitionValue.Text);
            extent.SetStepStatusPass("Verified that Ignition state value is displayed.");
            if (driverRightpanelStatus.backupPower == null)
                Assert.AreEqual("", BackupValue.Text.Trim());
            else
                Assert.AreEqual(driverRightpanelStatus.backupPower, BackupValue.Text);
            extent.SetStepStatusPass("Verified that backup value is displayed.");

        }
        /// <summary>
        /// Verify Driver Telemetry popup
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="driverName"></param>
        public void VerifyDriverTelemetry(string userName, string password, string driverName)
        {
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(userName, password);
            extent.SetStepStatusPass("Fetched driver details.");
            int driverId = 1;
            foreach (var n in driverTree)
            {
                if (n.driverShortName.Equals(driverName))
                {
                    driverId = n.driverId;
                }
            }
            getAPIResponse = new GetAPIResponse();
            var driverRightpanelStatus = getAPIResponse.GetDriverRightPanel(userName, password, driverId);
            extent.SetStepStatusPass("Fetched driver details.");
            string vehicleName = driverRightpanelStatus.unitName.Trim();
            string speed = Math.Round(driverRightpanelStatus.speed).ToString().Trim();
            int speedValue = Convert.ToInt32(Math.Round(driverRightpanelStatus.speed));
            string status = VehicleStatus(speedValue, driverRightpanelStatus.ign);
            string direction = driverRightpanelStatus.headStr.Trim();
            string location = driverRightpanelStatus.address.Trim();
            DateTime locationTime = driverRightpanelStatus.utcTime;
            Drivers.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Driver List"));
            wait.Until(driver => DriverSearchField.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            DriverSearchField.Clear();
            DriverSearchField.SendKeys(driverName);
            extent.SetStepStatusPass("Entered driver name in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => DriverName.Displayed);
            extent.SetStepStatusPass("Verified that driver name is available.");
            wait.Until(driver => ShowOnMapButton.Displayed);
            ShowOnMapButton.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            extent.SetStepStatusPass("Verified that telemetry pop up is displayed.");
            Assert.AreEqual(vehicleName + $" (Not Set)", TelemetryName.Text.Trim());
            Assert.AreEqual(driverName, TelemetrySecondLine.Text.Trim());
            Assert.AreEqual("Time", TimeText.Text.Trim());
            Assert.AreEqual(locationTime.ToLocalTime().ToString("dd'/'MM'/'yyyy"), DateTelemetry.Text.Trim());
            Assert.AreEqual(locationTime.ToLocalTime().ToString("hh:mm tt"), TimeTelemetry.Text.Trim());
            Assert.AreEqual("Location", LocationText.Text.Trim());
            Assert.AreEqual(location, LocationValue.Text.Trim());
            Assert.AreEqual("Speed", SpeedText.Text.Trim());
            Assert.AreEqual(speed + " km/h", SpeedTelemetry.Text.Trim());
            Assert.AreEqual(direction, DirectionTelemetry.Text.Trim());
            Assert.AreEqual(status, StatusTelemetry.Text.Trim());
            reportsTelemetry.Click();
            wait.Until(driver => ReportsHeading.Displayed);
            extent.SetStepStatusPass("Verified the Telemetry popup.");
        }
        /// <summary>
        /// Right panel redirection for drivers
        /// </summary>
        /// <param name="driverName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyDriverRightPanelRedirection(string driverName, string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var driverTree = getAPIResponse.GetDriverTree(userName, password);
            extent.SetStepStatusPass("Fetched driver details.");
            int driverId = 1;
            foreach (var n in driverTree)
            {
                if (n.driverShortName.Equals(driverName))
                {
                    driverId = n.driverId;
                }
            }
            getAPIResponse = new GetAPIResponse();
            var driverRightpanelStatus = getAPIResponse.GetDriverRightPanel(userName, password, driverId);
            extent.SetStepStatusPass("Fetched driver details.");
            Drivers.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Driver List"));
            wait.Until(driver => DriverSearchField.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            DriverSearchField.Clear();
            DriverSearchField.SendKeys(driverName);
            extent.SetStepStatusPass("Entered driver name in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => DriverName.Displayed);
            extent.SetStepStatusPass("Verified that driver name is available.");
            ShowOnMapButton.Click();
            wait.Until(driver => TelemetryPopUp.Displayed);
            DashCamUnavailableCheck();
            LocateVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            HistoryButton.Click();
            wait.Until(driver => HistoryDuration.Displayed);
            HistoryBack.Click();
            wait.Until(driver => VehicleImage.Displayed);
            ReportsButton.Click();
            wait.Until(driver => ReportsHeading.Displayed);
            extent.SetStepStatusPass("Verified the right panel redirections.");
        }
        /// <summary>
        /// Verify Dashcam popup
        /// </summary>
        public void DashCamUnavailableCheck()
        {
            DashcamButton.Click();
            wait.Until(driver => DashCamImage.Displayed);
            Assert.AreEqual("Dashcam unavailable", DashCamUnavailableText.Text.Trim());
            Assert.AreEqual("Dashcam module is not installed and enabled on this vehicle. Get in touch with Netstar to find out more.", DashCamNotInstalledText.Text.Trim());
            Assert.AreEqual("1300 728 882", DashCamPhone.Text.Trim());
            Assert.AreEqual("customersupport@netstaraus.com.au", DashCamEmail.Text.Trim());
            DashCamOk.Click();
            Thread.Sleep(1000);
        }
        /// <summary>
        /// Verify find now from vehicles tab
        /// </summary>
        /// <param name="vehicleName"></param>
        public void VerifyFindNowVehicles(string vehicleName)
        {
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(3000);
            VehicleSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered vehicle number in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => VehicleImage.Displayed);
            extent.SetStepStatusPass("Verified that vehicle image is displayed.");
            LocateVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            extent.SetStepStatusPass("Verified that ping is sent from vehicles.");
            driver.Navigate().Refresh();
            wait.Until(driver => VehicleSearchField.Displayed);
        }
        /// <summary>
        /// Verify find now from drivers tab
        /// </summary>
        /// <param name="driverName"></param>
        public void VerifyFindNowDrivers(string driverName)
        {
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(3000);
            Drivers.Click();
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Driver List"));
            wait.Until(driver => DriverSearchField.Displayed);
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            DriverSearchField.Clear();
            DriverSearchField.SendKeys(driverName);
            extent.SetStepStatusPass("Entered driver name in search field.");
            Thread.Sleep(2000);
            FirstEntry.Click();
            Thread.Sleep(2000);
            wait.Until(driver => DriverName.Displayed);
            extent.SetStepStatusPass("Verified that driver name is available.");
            LocateVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            extent.SetStepStatusPass("Verified that ping is sent from drivers.");
            driver.Navigate().Refresh();
            wait.Until(driver => VehicleSearchField.Displayed);
        }
        /// <summary>
        /// Verify find now from alerts tab
        /// </summary>
        /// <param name="vehicleName"></param>
        public void VerifyFindNowAlerts(string vehicleName)
        {
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(3000);
            Alerts.Click();
            Thread.Sleep(3000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alerts"));
            wait.Until(driver => AlertSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            AlertSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered alert name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Thread.Sleep(2000);
            AlarmTitle.Click();
            wait.Until(driver => AlertsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alerts image is displayed.");
            TrackVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            extent.SetStepStatusPass("Verified that ping is sent from alerts.");
            driver.Navigate().Refresh();
            wait.Until(driver => VehicleSearchField.Displayed);
        }
        /// <summary>
        /// Verify find now from alarms tab
        /// </summary>
        /// <param name="vehicleName"></param>
        public void VerifyFindNowAlarms(string vehicleName)
        {
            wait.Until(driver => VehicleSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            Thread.Sleep(3000);
            Alarms.Click();
            Thread.Sleep(3000);
            wait.Until(driver => FloatingPanelTitle.Text.Contains("Alarms"));
            wait.Until(driver => AlarmSearchField.Displayed);
            extent.SetStepStatusPass("Verified that search box is displayed.");
            AlarmSearchField.SendKeys(vehicleName);
            extent.SetStepStatusPass("Entered alarm name in search field.");
            wait.Until(driver => AlarmTitle.Displayed);
            Thread.Sleep(2000);
            AlarmTitle.Click();
            wait.Until(driver => AlarmsIcon.Displayed);
            extent.SetStepStatusPass("Verified that alarms image is displayed.");
            TrackVehicleButton.Click();
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Ping sent successfully!"));
            extent.SetStepStatusPass("Verified that ping is sent from alarms.");
            driver.Navigate().Refresh();
            wait.Until(driver => VehicleSearchField.Displayed);
        }

        #endregion
    }
}
