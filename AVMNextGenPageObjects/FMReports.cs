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
    public class FMReports : AVMNextGenBase
    {
        IWebDriver fMReportsDriver;
        public FMReports() { }

        public FMReports(IWebDriver driver)
        {
            this.fMReportsDriver = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        public string reportName = string.Empty;
        public string status = "Active";
        public string date = string.Empty;
        string searchKey = string.Empty;
        public string hour = string.Empty;
        public string minute = string.Empty;
        public string day = string.Empty;
        public string timezone = string.Empty;
        public int colNumber = 1;
        public int rowNumber = 1;
        public string option = "Current day";
        IWebElement ReportsHeading => driver.FindElement(By.XPath("//h3[text()='Reports']"));
        IWebElement ReportsPlusButton => driver.FindElement(By.XPath("//h3[text()='Reports']/following-sibling::button[@class='button plus']"));
        IWebElement NoReportsHeading => driver.FindElement(By.XPath("//h3[contains(text(),'No Reports')]"));
        IWebElement SelectOptionsText => driver.FindElement(By.XPath("//h3[contains(text(),'No Reports')]/following-sibling::p"));
        IWebElement RunReportButton => driver.FindElement(By.XPath("//h3[contains(text(),'No Reports')]/following-sibling::button"));
        IWebElement ReportSteps => driver.FindElement(By.XPath("//div[contains(@class,'report-steps')]/h3"));
        IWebElement ReportStepsSubText => driver.FindElement(By.XPath("//div[contains(@class,'report-steps')]/p"));
        IWebElement ReportStepsButton => driver.FindElement(By.XPath("//div[contains(@class,'report-steps')]/button"));
        IWebElement RecentReportHeading => driver.FindElement(By.XPath("//h3[contains(text(),'Recently Run Report')]"));
        IWebElement FirstRecentReportHeading => driver.FindElement(By.XPath("//h3[contains(text(),'Recently')]/parent::div/following-sibling::ul/li[1]"));
        IWebElement SelectReportType => driver.FindElement(By.XPath("//h3[contains(text(),'Select Report Type')]"));
        IWebElement SearchField => driver.FindElement(By.Id("search-field"));
        IWebElement FirstReportSelect => driver.FindElement(By.XPath($"//ul[@class='report-types-list']//li[contains(text(),'{reportName}')]"));
        IWebElement CancelButton => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tree parameters-panel right-slide-animation')]//button[@id='right-panel-cancel-btn']"));
        IWebElement DoneButton => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tree parameters-panel right-slide-animation')]//button[@id='right-panel-done-btn']"));

        IWebElement TimePeriodHeader => driver.FindElement(By.Id("customize-report-header"));
        IWebElement PeriodHeader => driver.FindElement(By.Id("period-text"));
        IWebElement StartDatePicker => driver.FindElement(By.XPath("//label[contains(text(),'Start Date')]/following-sibling::input"));
        IWebElement EndDatePicker => driver.FindElement(By.XPath("//label[contains(text(),'End Date')]/following-sibling::input"));
        IWebElement StartTimePicker => driver.FindElement(By.XPath("//label[contains(text(),'Start Time')]/following-sibling::time-picker//input"));
        IWebElement EndTimePicker => driver.FindElement(By.XPath("//label[contains(text(),'End Time')]/following-sibling::time-picker//input"));
        IWebElement ReportHeader => driver.FindElement(By.XPath($"//h2[contains(text(),'{reportName}')]"));






        IWebElement VehicleTreeHeader => driver.FindElement(By.XPath("//p[@id='reports-vehicle-tree-header']"));
        IWebElement SelectAllButton => driver.FindElement(By.XPath("//button[@id='reports-select-all-btn']"));
        IWebElement UnselectAllButton => driver.FindElement(By.XPath(" //button[@id='reports-unselect-all-btn']"));
        IWebElement Checkbox => driver.FindElement(By.XPath($"//button[contains(text(),'{searchKey}')]"));
        IWebElement VehicleRadio => driver.FindElement(By.XPath($"//label[contains(text(),'Vehicle')]"));
        IWebElement DriverRadio => driver.FindElement(By.XPath($"//label[contains(text(),'Driver')]"));
        IWebElement SearchVehicle => driver.FindElement(By.XPath("//input[@placeholder='Search vehicle']"));
        IWebElement SearchDrivers => driver.FindElement(By.XPath("//input[@placeholder='Search Drivers']"));
        IWebElement SearchResult => driver.FindElement(By.XPath($"//button[@data-test-id='entityname'][contains(text(),'{searchKey}')]"));
        IWebElement ChooseYear => driver.FindElement(By.XPath($"//button[@aria-label='Choose month and year']"));
        IWebElement ChoosePreviuosYear => driver.FindElement(By.XPath($"//button[@aria-label='Previous 24 years']"));
        IWebElement DateSelect => driver.FindElement(By.XPath($"//div[contains(@class,'mat-calendar-body-cell')][text()=' {date} ']"));
        IWebElement HourSelect => driver.FindElement(By.XPath($"//span[@id='hour-{hour}']"));
        IWebElement MinuteSelect => driver.FindElement(By.XPath($"//span[@id='minute-{minute}']"));
        IWebElement AMSelect => driver.FindElement(By.XPath($"//span[text()='AM']"));
        IWebElement PMSelect => driver.FindElement(By.XPath($"//span[text()='PM']"));
        IWebElement TimePickerOk => driver.FindElement(By.XPath("//button[contains(text(),'OK')]"));
        IWebElement TimezoneDropDown => driver.FindElement(By.XPath("//div[@role='combobox']"));
        IWebElement TimezoneSelection => driver.FindElement(By.XPath($"//span[contains(@class,'ng-option')][contains(text(),'{timezone}')]"));

        IWebElement ReportTypeValue => driver.FindElement(By.XPath("//label[contains(text(),'Report type')]/following-sibling::p"));
        IWebElement AssetsValue => driver.FindElement(By.XPath("//label[contains(text(),'Assets')]/following-sibling::p"));
        IWebElement TimePeriodValue => driver.FindElement(By.XPath("//label[contains(text(),'Time period')]/following-sibling::p"));
        IWebElement ReportNavigation => driver.FindElement(By.Id("menu-reports"));

        IWebElement ColumnName => driver.FindElement(By.XPath($"//table/thead/tr/th[{colNumber}]"));
        int ColumnCount => driver.FindElements(By.XPath($"//table/thead/tr/th")).Count();

        IWebElement RowValues => driver.FindElement(By.XPath($"//table/tbody/tr[{rowNumber}]/td[{colNumber}]"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement SuccessMessageClose => driver.FindElement(By.XPath("//div[@id='toast-container']//button[@type='button']"));

        IWebElement DBSort => driver.FindElement(By.XPath("//th[contains(text(),'Date')]/span[2]/img"));
        IWebElement DBSearch => driver.FindElement(By.XPath("//input[@placeholder='Search']"));
        IWebElement ExportButton => driver.FindElement(By.Id("export-btn"));
        IWebElement DownloadPDF => driver.FindElement(By.XPath("//span[contains(text(),'PDF')]"));
        IWebElement DownloadExcel => driver.FindElement(By.XPath("//span[contains(text(),'Excel File')]"));
        IWebElement DownloadCSV => driver.FindElement(By.XPath("//span[contains(text(),'CSV')]"));

        IWebElement ScheduleButton => driver.FindElement(By.Id("schedule-this-report-btn"));
        IWebElement ScheduleHeading => driver.FindElement(By.XPath("//h2[contains(text(),'Schedule report')]"));
        IWebElement ReportNameField => driver.FindElement(By.XPath("//label[contains(text(),'Report Name*')]/following-sibling::input"));
        IWebElement ScheduleText => driver.FindElement(By.XPath("//label[contains(text(),'Schedule')]"));
        IWebElement DailyDropDown => driver.FindElement(By.XPath("//span[contains(text(),'Daily')]"));
        IWebElement SelectDaysText => driver.FindElement(By.XPath("//label[contains(text(),'Select days to run')]"));
        IWebElement TimeToRunPicker => driver.FindElement(By.XPath("//label[contains(text(),'Time to run')]/following-sibling::time-picker//div[@id='time']"));
        IWebElement TimeToRunPickerEdit => driver.FindElement(By.XPath("//label[contains(text(),'End Time')]/following-sibling::time-picker//div[@id='time']//input"));
        IWebElement ExportRangeDropdown => driver.FindElement(By.XPath("//label[contains(text(),'Export Time Range')]/following-sibling::ng-select"));
        IWebElement DropdownOption => driver.FindElement(By.XPath($"//span[contains(@class,'ng-option')][contains(text(),'{option}')]"));
        IWebElement ScheduleSummaryText => driver.FindElement(By.XPath("//h3[contains(text(),'Schedule Summary')]"));
        IWebElement ContactGroupDropdown => driver.FindElement(By.XPath("//label[contains(text(),'Send Reports To*')]/following-sibling::div/ng-select"));
        IWebElement ClearSelection => driver.FindElement(By.XPath("//span[text()='x']"));
        IWebElement ContactGroupDropdownEdit => driver.FindElement(By.XPath("//label[contains(text(),'Send Reports To*')]/following-sibling::ng-select[1]"));
        IWebElement OutputFormDropdown => driver.FindElement(By.XPath("//label[contains(text(),'Output format')]/following-sibling::ng-select"));
        IWebElement NotesTextArea => driver.FindElement(By.XPath("//label[contains(text(),'Notes')]/following-sibling::textarea"));
        IWebElement ScheduleCancelButton => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tree-footer action-buttons')]//button[contains(text(),'Cancel')]"));
        IWebElement ScheduleSaveButton => driver.FindElement(By.XPath("//div[contains(@class,'right-panel-tree-footer action-buttons')]//button[contains(text(),'Save')]"));
        IWebElement ViewSchedulesButton => driver.FindElement(By.XPath("//button[contains(text(),'View Schedules')]"));
        IWebElement SchedulesTitle => driver.FindElement(By.XPath("//span[contains(text(),'Schedules')]"));
        int RowCount => driver.FindElements(By.XPath("//div[contains(@class,'report-schedul-table')]/div[2]/div")).Count;
        IWebElement ColumnHeading => driver.FindElement(By.XPath($"//div[contains(@class,'report-schedul-table')]/div[1]/div[{colNumber}]"));
        IWebElement ColumnValue => driver.FindElement(By.XPath($"//div[contains(@class,'report-schedul-table')]/div[2]/div[{rowNumber}]/div[{colNumber}]"));
        IWebElement Kebabmenu => driver.FindElement(By.XPath($"//div[contains(@class,'report-schedul-table')]/div[2]/div[{rowNumber}]//div[contains(@class,'col-action')]//img"));
        IWebElement EditSchedule => driver.FindElement(By.XPath("//li[contains(text(),'Edit')]"));
        IWebElement DeleteSchedule => driver.FindElement(By.XPath("//li[@id='delete-action']"));
        IWebElement PauseSchedule => driver.FindElement(By.XPath("//li[contains(text(),'Pause')]"));
        IWebElement RestartSchedule => driver.FindElement(By.XPath("//li[contains(text(),'Restart')]"));
        IWebElement RunSchedule => driver.FindElement(By.XPath("//li[contains(text(),'Run now')]"));
        IWebElement DeleteModalTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement DeleteBody => driver.FindElement(By.XPath("//div[@class='modal-body']/p"));
        IWebElement DeleteModalClose => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement DeleteModalCancel => driver.FindElement(By.Id("schedules-list-cancel-btn"));
        IWebElement DeleteModalSave => driver.FindElement(By.Id("schedules-list-delete-btn"));

        IWebElement RightPanelScheduleName => driver.FindElement(By.Id("schedule-name"));
        IWebElement RightPanelScheduleEdit => driver.FindElement(By.Id("schedule-edit-btn"));
        IWebElement RightPanelSchedulePause => driver.FindElement(By.Id("schedule-pause-btn"));
        IWebElement RightPanelScheduleRunNow => driver.FindElement(By.Id("schedule-play-btn"));
        IWebElement RightPanelScheduleDelete => driver.FindElement(By.Id("schedule-delete-btn"));
        IWebElement RightPanelScheduleStatus => driver.FindElement(By.XPath($"//div[@class='status'][contains(text(),'{status}')]"));

        IWebElement RightPanelScheduleText => driver.FindElement(By.XPath("//p[contains(text(),'Schedule')]"));
        IWebElement RightPanelScheduleTextValue => driver.FindElement(By.XPath("//p[contains(text(),'Schedule')]/following-sibling::span"));
        IWebElement RightPanelScheduleStatusText => driver.FindElement(By.XPath("//p[contains(text(),'Status')]"));
        IWebElement RightPanelScheduleDaysRun => driver.FindElement(By.XPath("//p[contains(text(),'Selected days to run')]"));
        IWebElement RightPanelScheduleDaysRunValue => driver.FindElement(By.XPath("//p[contains(text(),'Selected days to run')]/following-sibling::span"));
        IWebElement RightPanelScheduleTimeToRun => driver.FindElement(By.XPath("//p[contains(text(),'Time to run')]"));
        IWebElement RightPanelScheduleTimeToRunValue => driver.FindElement(By.XPath("//p[contains(text(),'Time to run')]/following-sibling::span"));
        IWebElement RightPanelScheduleRangeHeading => driver.FindElement(By.XPath("//p[contains(text(),'Export Time Range')]"));
        IWebElement RightPanelScheduleRangeValue => driver.FindElement(By.XPath("//p[contains(text(),'Export Time Range')]/following-sibling::span"));
        IWebElement RightPanelScheduleSummary => driver.FindElement(By.XPath("//span[contains(text(),'Schedule Summary')]"));
        IWebElement RightPanelScheduleSummaryValue => driver.FindElement(By.XPath("//span[contains(text(),'Schedule Summary')]/parent::div/following-sibling::div"));
        IWebElement RightPanelScheduleSendReportsHeading => driver.FindElement(By.XPath("//p[contains(text(),'Send Reports To')]"));
        IWebElement RightPanelScheduleSendReportsValue => driver.FindElement(By.XPath("//p[contains(text(),'Send Reports To')]/following-sibling::span"));
        IWebElement RightPanelScheduleOutputFormatHeading => driver.FindElement(By.XPath("//p[contains(text(),'Output format')]"));
        IWebElement RightPanelScheduleOFValue => driver.FindElement(By.XPath("//p[contains(text(),'Output format')]/following-sibling::span"));
        IWebElement RightPanelScheduleNotesHeading => driver.FindElement(By.XPath("//p[contains(text(),'Notes')]"));
        IWebElement RightPanelScheduleNotesValue => driver.FindElement(By.XPath("//p[contains(text(),'Notes')]/following-sibling::p"));

        IWebElement RightPanelReportWindow => driver.FindElement(By.XPath($"//span[contains(text(),'{reportName}')]"));
        IWebElement ReportWindowHeading => driver.FindElement(By.XPath($"//h4[contains(text(),'{reportName}"));
        IWebElement ReportWindowSubHeading => driver.FindElement(By.XPath($"/h6[contains(text(),'Vehicles')]"));
        IWebElement ReportWindowDept => driver.FindElement(By.XPath($"//th[contains(text(),'Department')]"));
        IWebElement ReportWindowGrp => driver.FindElement(By.XPath($"//th[contains(text(),'Group')]"));
        IWebElement ReportWindowVeh => driver.FindElement(By.XPath($"//th[contains(text(),'Vehicles')]"));
        IWebElement ReportWindowDepDetails => driver.FindElement(By.XPath($"//tbody/tr[1]/td[1]"));
        IWebElement ReportWindowGrpDetails => driver.FindElement(By.XPath($"//tbody/tr[1]/td[2]"));
        IWebElement ReportWindowVehDetails => driver.FindElement(By.XPath($"//tbody/tr[1]/td[3]/span"));
        IWebElement ReportWindowClose => driver.FindElement(By.XPath($" //button[contains(@class,'btn-close')]"));


















        #endregion

        #region Methods
        /// <summary>
        /// Navigate to Reports
        /// </summary>
        public void NavigateToReportsPage()
        {

            wait.Until(driver => ReportNavigation.Displayed);
            extent.SetStepStatusPass("Verified that report link is displayed.");
            ReportNavigation.Click();
            wait.Until(driver => ReportsHeading.Displayed);
            extent.SetStepStatusPass("Verified that the reports page is displayed.");
        }
        /// <summary>
        /// Verify the report landing page
        /// </summary>
        public void VerifyReportsLandingPage()
        {
            wait.Until(driver => ReportsHeading.Displayed);
            wait.Until(driver => ReportsPlusButton.Displayed);
            wait.Until(driver => NoReportsHeading.Displayed);
            Assert.AreEqual("Select the options to run a new report", SelectOptionsText.Text.Trim());
            wait.Until(driver => RunReportButton.Displayed);
            Assert.AreEqual("Steps to run a report", ReportSteps.Text.Trim());
            Assert.IsTrue(ReportStepsSubText.Text.Trim().Contains("Select a report to run"));
            Assert.IsTrue(ReportStepsSubText.Text.Trim().Contains("Select parameters to run"));
            wait.Until(driver => ReportStepsButton.Displayed);
            wait.Until(driver => RecentReportHeading.Displayed);
            ReportsPlusButton.Click();
            wait.Until(driver => SelectReportType.Displayed);
            wait.Until(driver => CancelButton.Displayed);
            Thread.Sleep(1000);
            CancelButton.Click();
            extent.SetStepStatusPass("Verified report plus button.");
            Thread.Sleep(1000);
            RunReportButton.Click();
            wait.Until(driver => SelectReportType.Displayed);
            wait.Until(driver => CancelButton.Displayed);
            CancelButton.Click();
            extent.SetStepStatusPass("Verified run report button.");
            Thread.Sleep(1000);
            ReportStepsButton.Click();
            wait.Until(driver => SelectReportType.Displayed);
            wait.Until(driver => CancelButton.Displayed);
            CancelButton.Click();
            extent.SetStepStatusPass("Verified run report button in middle.");
        }
        /// <summary>
        /// Report generation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="dateTime"></param>
        /// <param name="timeZone"></param>
        /// <param name="isVehicle"></param>
        public void GenerateReport(string report, string name, DateTime startDate, DateTime endTime, string timeZone, bool isVehicle = true)
        {
            reportName = report;
            wait.Until(driver => ReportStepsButton.Displayed);
            ReportStepsButton.Click();
            wait.Until(driver => SelectReportType.Displayed);
            Thread.Sleep(3000);
            SearchField.SendKeys(report);
            Thread.Sleep(3000);
            FirstReportSelect.Click();
            Thread.Sleep(1000);
            DoneButton.Click();
            Thread.Sleep(3000);
            wait.Until(driver => SearchVehicle.Displayed);
            SelectAllButton.Click();
            UnselectAllButton.Click();
            if (isVehicle)
                SearchVehicle.SendKeys(name);
            else
            {
                DriverRadio.Click();
                SearchDrivers.SendKeys(name);
            }
            Thread.Sleep(3000);
            searchKey = name;
            wait.Until(driver => SearchResult.Displayed);
            Actions build = new Actions(driver);
            build.MoveToElement(Checkbox).Click().Build().Perform();
            DoneButton.Click();
            Thread.Sleep(3000);
            wait.Until(driver => TimePeriodHeader.Displayed);
            Assert.AreEqual("Add report time period", TimePeriodHeader.Text.Trim());
            Assert.AreEqual("Period", PeriodHeader.Text.Trim());
            StartDatePicker.Click();
            SelectDateFromCalender(startDate);
            StartTimePicker.Click();
            SelectTime("06", "30", true);
            EndTimePicker.Click();
            SelectTime("10", "30", false);
            EndDatePicker.Click();
            SelectDateFromCalender(endTime);
            timezone = timeZone;
            TimezoneDropDown.Click();
            TimezoneSelection.Click();
            DoneButton.Click();
            Thread.Sleep(3000);
            wait.Until(driver => ReportHeader.Displayed);
            wait.Until(driver => ReportTypeValue.Displayed);
            Assert.AreEqual(reportName, ReportTypeValue.Text.Trim());
            Assert.AreEqual("1 Group & 1 Vehicle", AssetsValue.Text.Trim());
            string timeValue = startDate.ToString("dd'/'MM'/'yyyy") + " | 06:30 AM - " + endTime.ToString("dd'/'MM'/'yyyy") + " | 10:30 PM";
            Assert.AreEqual(timeValue, TimePeriodValue.Text.Trim());
            extent.SetStepStatusPass($"Verified generate- {report}.");
        }
        /// <summary>
        /// Driver behaviour sort
        /// </summary>
        public void DriverBehaviourSort()
        {
            DBSort.Click();
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Download reports
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="Exception"></exception>
        public void DownloadReport(string fileName)
        {
            ExportButton.Click();
            DownloadPDF.Click();
            Thread.Sleep(4000);
            if (CheckFileDownloaded(fileName))
                extent.SetStepStatusPass("Verified that the PDF file is downloaded.");
            else
                throw new Exception("Download Failed");
            ExportButton.Click();
            DownloadExcel.Click();
            Thread.Sleep(4000);
            if (CheckFileDownloaded(fileName))
                extent.SetStepStatusPass("Verified that the Excel file is downloaded.");
            else
                throw new Exception("Download Failed");
            ExportButton.Click();
            DownloadCSV.Click();
            Thread.Sleep(4000);
            if (CheckFileDownloaded(fileName))
                extent.SetStepStatusPass("Verified that the CSV file is downloaded.");
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
        /// Search report result
        /// </summary>
        /// <param name="keyword"></param>
        public void ReportSearch(string keyword)
        {
            DBSearch.Clear();
            DBSearch.SendKeys(keyword);
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Returns the report count
        /// </summary>
        /// <param name="requestBody"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ReportResultCountDB(DriverBehaviourRequestBody requestBody, string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var drivBehaviourReport = getAPIResponse.GenerateDriverBehaviourReport(requestBody, userName, password);
            return drivBehaviourReport.report.Count();
        }
        /// <summary>
        /// SAL Count
        /// </summary>
        /// <param name="requestBody"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ReportResultCountDB(SALRequestBody requestBody, string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var salReport = getAPIResponse.GenerateSALReport(requestBody, userName, password);
            return salReport.report.Count();
        }
        /// <summary>
        /// Verify DB report results
        /// </summary>
        /// <param name="requestBody"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void VerifyDriverBehaviourReportDetails(DriverBehaviourRequestBody requestBody, string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var drivBehaviourReport = getAPIResponse.GenerateDriverBehaviourReport(requestBody, userName, password);
            string[] columnNameValues = { "Date", "Vehicle", "Driver", "Distance Travelled", "Score", "Speeding", "Excessive Idling", "Harsh Acceleration", "Harsh Cornering", "Harsh Braking", "Crash Detected", "Fatigue Alerts", "Fatigue Alarms" };
            for (int i = 1; i < (ColumnCount); i++)
            {
                colNumber = i;
                Assert.AreEqual(columnNameValues[colNumber - 1], ColumnName.Text.Trim());
            }
            int rowCountValue = 5;

            if (drivBehaviourReport.report.Count() <= 5)
                rowCountValue = drivBehaviourReport.report.Count();

            for (int j = 0; j < rowCountValue; j++)
            {
                rowNumber = j + 1;
                colNumber = 1;
                Assert.AreEqual(drivBehaviourReport.report[j].Date, RowValues.Text.Trim());
                colNumber = 2;
                Assert.AreEqual(drivBehaviourReport.report[j].Vehicle, RowValues.Text.Trim());
                colNumber = 3;
                Assert.AreEqual(drivBehaviourReport.report[j].Driver, RowValues.Text.Trim());
                colNumber = 4;
                Assert.AreEqual(drivBehaviourReport.report[j].DistanceTravelled.ToString(), RowValues.Text.Trim());
                colNumber = 5;
                Assert.AreEqual(drivBehaviourReport.report[j].Score.ToString(), RowValues.Text.Trim());
                colNumber = 6;
                Assert.AreEqual(drivBehaviourReport.report[j].Speeding.ToString(), RowValues.Text.Trim());
                colNumber = 7;
                Assert.AreEqual(drivBehaviourReport.report[j].ExcessiveIdling.ToString(), RowValues.Text.Trim());
                colNumber = 8;
                Assert.AreEqual(drivBehaviourReport.report[j].HarshAcceleration.ToString(), RowValues.Text.Trim());
                colNumber = 9;
                Assert.AreEqual(drivBehaviourReport.report[j].HarshCornering.ToString(), RowValues.Text.Trim());
                colNumber = 10;
                Assert.AreEqual(drivBehaviourReport.report[j].HarshBraking.ToString(), RowValues.Text.Trim());
                colNumber = 11;
                Assert.AreEqual(drivBehaviourReport.report[j].CrashDetected.ToString(), RowValues.Text.Trim());
                colNumber = 12;
                Assert.AreEqual(drivBehaviourReport.report[j].FatigueAlerts.ToString(), RowValues.Text.Trim());
                colNumber = 13;
                Assert.AreEqual(drivBehaviourReport.report[j].FatigueAlarms.ToString(), RowValues.Text.Trim());
            }
            extent.SetStepStatusPass($"Verified the first {rowCountValue} rows of driver behaviour Reports.");
        }

        public void VerifySALReportDetails(SALRequestBody requestBody, string userName, string password)
        {
            getAPIResponse = new GetAPIResponse();
            var salReport = getAPIResponse.GenerateSALReport(requestBody, userName, password);
            string[] columnNameValues = { "Date", "Vehicle", "Driver","Address", "Stop Duration", "KMs to Stop", "Driving Duration"  };
            for (int i = 1; i < (ColumnCount); i++)
            {
                colNumber = i;
                Assert.AreEqual(columnNameValues[colNumber - 1], ColumnName.Text.Trim());
            }
            int rowCountValue = 5;

            if (salReport.report.Count() <= 5)
                rowCountValue = salReport.report.Count();

            for (int j = 0; j < rowCountValue; j++)
            {
                rowNumber = j + 1;
                colNumber = 1;
                Assert.AreEqual(salReport.report[j].Date, RowValues.Text.Trim());
                colNumber = 2;
                Assert.AreEqual(salReport.report[j].Vehicle, RowValues.Text.Trim());
                colNumber = 3;
                Assert.AreEqual(salReport.report[j].Driver, RowValues.Text.Trim());
                colNumber = 4;
                Assert.AreEqual(salReport.report[j].Address.Trim(), RowValues.Text.Trim());
                colNumber = 5;
                Assert.AreEqual(salReport.report[j].StopDuration, RowValues.Text.Trim());
                colNumber = 6;
                Assert.AreEqual(salReport.report[j].KMstoStop.ToString(), RowValues.Text.Trim());
                colNumber = 7;
                Assert.AreEqual(salReport.report[j].DrivingDuration, RowValues.Text.Trim());
            }
            extent.SetStepStatusPass($"Verified the first {rowCountValue} rows of SAL Reports.");
        }

        /// <summary>
        /// Selects the date from calender
        /// </summary>
        /// <param name="dateValue"></param>
        /// 
        public void SelectDateFromCalender(DateTime dateTime)
        {
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
        /// <summary>
        /// Select Time from time picker
        /// </summary>
        /// <param name="hourValue"></param>
        /// <param name="minuteValue"></param>
        public void SelectTime(string hourValue, string minuteValue, bool isAM = true)
        {
            wait.Until(driver => TimePickerOk.Displayed);
            hour = hourValue;
            HourSelect.Click();
            Thread.Sleep(2000);
            minute = minuteValue;
            MinuteSelect.Click();
            if (isAM)
                AMSelect.Click();
            else
                PMSelect.Click();
            TimePickerOk.Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Create Schedule
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="rangeOption"></param>
        /// <param name="outputFormat"></param>
        public void CreateSchedule(string scheduleName, string rangeOption, string outputFormat)
        {
            wait.Until(driver => ScheduleButton.Displayed);
            ScheduleButton.Click();
            wait.Until(driver => ScheduleHeading.Displayed);
            ReportNameField.SendKeys(scheduleName);
            wait.Until(driver => ScheduleText.Displayed);
            wait.Until(driver => DailyDropDown.Displayed);
            wait.Until(driver => SelectDaysText.Displayed);
            TimeToRunPicker.Click();
            SelectTime("06", "30", true);
            ExportRangeDropdown.Click();
            option = rangeOption;
            DropdownOption.Click();
            wait.Until(driver => ScheduleSummaryText.Displayed);
            ContactGroupDropdown.Click();
            option = "Sandeep Contact Group";
            DropdownOption.Click();
            OutputFormDropdown.Click();
            option = outputFormat;
            DropdownOption.Click();
            NotesTextArea.SendKeys("Test automation notes");
            wait.Until(driver => ScheduleCancelButton.Displayed);
            ScheduleSaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Report scheduled", SuccessMessage.Text.Trim());
            Thread.Sleep(1000);
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that schedule report is working as expected.");
        }
        /// <summary>
        /// Verify that the schedule details are correctly displayed
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="reportName"></param>
        /// <param name="rangeOption"></param>
        /// <param name="outputFormat"></param>
        /// <exception cref="Exception"></exception>
        public void VerifyScheduleDetails(string[] scheduleValues,bool redirect= true)
        {
            if (redirect)
            {
                wait.Until(driver => ViewSchedulesButton.Displayed);
                ViewSchedulesButton.Click();
            }
            bool isEqual = true;
            bool columnValuesMatching = true;
            bool isPresent = false;
            wait.Until(driver => SchedulesTitle.Displayed);
            Thread.Sleep(3000);
            string[] columnHeadingValues = new[] { "Name", "Report Type", "Schedule", "Format", "Last Run", "Next Run", "By", "Recipient" };
            for (int i = 1; i < 9; i++)
            {
                colNumber = i + 1;
                if (columnHeadingValues[i - 1].Equals(ColumnHeading.Text))
                    isEqual = true;
                else
                { isEqual = false; break; }
            }
            if (isEqual)
                extent.SetStepStatusPass("Verified that the column names are same.");
            else
                throw new Exception("Column headings are not correct.");
            for (int j = 1; j <= RowCount; j++)
            {
                rowNumber = j;
                colNumber = 2;
                if (ColumnValue.Text == scheduleValues[0])
                {
                    for (int k = 0; k < scheduleValues.Length; k++)
                    {
                        colNumber = k + 2;
                        if (scheduleValues[k].Equals(ColumnValue.Text))
                            columnValuesMatching = true;
                        else
                        { columnValuesMatching = false; break; }
                    }
                    isPresent = true;
                    break;
                }
                else
                    isPresent = false;

            }
            if (isPresent)
                extent.SetStepStatusPass("Verified that the schedule is listed.");
            else
                throw new Exception("Schedule is not listed.");
            if (columnValuesMatching)
                extent.SetStepStatusPass("Verified that the schedule details are correct.");
            else
                throw new Exception("Schedule details are not correct.");
        }
        /// <summary>
        /// Open the right panel or kebab menu
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="isKebab"></param>
        /// <exception cref="Exception"></exception>
        public void OpenRightPanelOrKebabMenu(string scheduleName, bool isKebab = true)
        {
            bool isPresent = false;
            for (int i = 0; i < RowCount; i++)
            {

                rowNumber = i+1;
                colNumber = 2;
                if (ColumnValue.Text == scheduleName)
                {

                    isPresent = true;
                    if (isKebab)
                    {
                        Kebabmenu.Click();
                        wait.Until(driver => EditSchedule.Displayed);
                        extent.SetStepStatusPass("Opened Kebab menu.");
                    }
                    else
                    {
                        ColumnValue.Click();
                        wait.Until(driver => RightPanelScheduleName.Displayed);
                        extent.SetStepStatusPass("Opened Right panel.");
                    }
                    break;
                }
                else
                    isPresent = false;
            }
            if (isPresent)
                extent.SetStepStatusPass("Verified that the schedule is listed.");
            else
                throw new Exception("Schedule is not listed.");

            Thread.Sleep(3000);
        }

        /// <summary>
        /// Edit Schedules
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="rangeOption"></param>
        /// <param name="reportName"></param>
        /// <param name="outputFormat"></param>
        /// <param name="userName"></param>
        public void EditScheduleReport(string scheduleName, string rangeOption, string outputFormat, bool isFormatAlone = false)
        {
            OpenRightPanelOrKebabMenu(scheduleName);
            EditSchedule.Click();
            wait.Until(driver => ScheduleHeading.Displayed);
            ScheduleCancelButton.Click();
            Thread.Sleep(2000);
            OpenRightPanelOrKebabMenu(scheduleName, false);
            RightPanelScheduleEdit.Click();
            wait.Until(driver => ScheduleHeading.Displayed);
            Thread.Sleep(4000);
            if (isFormatAlone == false)
            {
                ReportNameField.Clear();
                ReportNameField.SendKeys(scheduleName + "Edit");
                wait.Until(driver => ScheduleText.Displayed);
                wait.Until(driver => SelectDaysText.Displayed);
                TimeToRunPickerEdit.Click();
                SelectTime("10", "30", true);
                ExportRangeDropdown.Click();
                option = rangeOption;
                DropdownOption.Click();
                wait.Until(driver => ScheduleSummaryText.Displayed);
                ClearSelection.Click();
                //ContactGroupDropdownEdit.Click();
                option = "AutoContactGrp";
                DropdownOption.Click();
                NotesTextArea.Clear();
                NotesTextArea.SendKeys("Test automation notes Edited");
            }
            OutputFormDropdown.Click();
            option = outputFormat;
            DropdownOption.Click();
            wait.Until(driver => ScheduleCancelButton.Displayed);
            ScheduleSaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Schedule updated successfully.", SuccessMessage.Text.Trim());
            Thread.Sleep(1000);
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that edit schedule report is working as expected.");
        }

        /// <summary>
        /// Pause schedule
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="isKebab"></param>
        public void VerifyPauseSchedule(string scheduleName, bool isKebab = true)
        {
            if (isKebab)
            {
                OpenRightPanelOrKebabMenu(scheduleName);
                PauseSchedule.Click();
            }
            else
            {
                OpenRightPanelOrKebabMenu(scheduleName, false);
                RightPanelSchedulePause.Click();
            }
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Scheduled report has been paused", SuccessMessage.Text.Trim());
            Thread.Sleep(1000);
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            if (isKebab)
                OpenRightPanelOrKebabMenu(scheduleName, false);
            status = "Inactive";
            wait.Until(driver => RightPanelScheduleStatus.Displayed);
            extent.SetStepStatusPass("Verified that pause schedule is working as expected.");
            RightPanelScheduleRunNow.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("It is a paused schedule", SuccessMessage.Text.Trim());
            Thread.Sleep(1000);
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that pause schedule run now is working as expected.");
        }
        /// <summary>
        /// Restart Schedule
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="isKebab"></param>
        public void VerifyRestartSchedule(string scheduleName, bool isKebab = true)
        {
            if (isKebab)
            {
                OpenRightPanelOrKebabMenu(scheduleName);
                RestartSchedule.Click();
            }
            else
            {
                OpenRightPanelOrKebabMenu(scheduleName, false);
                RightPanelSchedulePause.Click();
            }
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Scheduled report has been restarted", SuccessMessage.Text.Trim());
            Thread.Sleep(1000);
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            if (isKebab)
                OpenRightPanelOrKebabMenu(scheduleName, false);
            status = "Active";
            wait.Until(driver => RightPanelScheduleStatus.Displayed);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that pause schedule is working as expected.");
        }
        /// <summary>
        /// Run Report
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="count"></param>
        /// <param name="isKebab"></param>
        public void VerifyRunSchedule(string scheduleName, int count, bool isKebab = true)
        {
            if (isKebab)
            {
                OpenRightPanelOrKebabMenu(scheduleName);
                RunSchedule.Click();
            }
            else
            {
                OpenRightPanelOrKebabMenu(scheduleName, false);
                RightPanelScheduleRunNow.Click();
            }
            wait.Until(driver => SuccessMessage.Displayed);
            if (count > 0)
                Assert.AreEqual("Report ran successfully.", SuccessMessage.Text.Trim());
            else
                Assert.AreEqual("No data found", SuccessMessage.Text.Trim());
            Thread.Sleep(1000);
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that run schedule is working as expected.");
        }

        /// <summary>
        /// DeleteScheduleReport
        /// </summary>
        /// <param name="scheduleName"></param>
        public void DeleteScheduleReport(string scheduleName)
        {
            OpenRightPanelOrKebabMenu(scheduleName);
            DeleteSchedule.Click();
            wait.Until(driver => DeleteModalClose.Displayed);
            DeleteModalClose.Click();
            OpenRightPanelOrKebabMenu(scheduleName, false);
            RightPanelScheduleDelete.Click();
            wait.Until(driver => DeleteModalClose.Displayed);
            Assert.AreEqual("Delete", DeleteModalTitle.Text.Trim());
            Assert.AreEqual($"Are you sure you want to delete the scheduled report : {scheduleName}?", DeleteBody.Text.Trim());
            DeleteModalCancel.Click();
            Thread.Sleep(1000);
            RightPanelScheduleDelete.Click();
            wait.Until(driver => DeleteModalClose.Displayed);
            DeleteModalSave.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Schedule deleted successfully", SuccessMessage.Text.Trim());
            Thread.Sleep(1000);
            SuccessMessageClose.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that delete schedule is working as expected.");
        }
        /// <summary>
        /// Navigate to the schedule page
        /// </summary>
        public void NavigateToViewSchedules()
        {
            wait.Until(driver => ViewSchedulesButton.Displayed);
            ViewSchedulesButton.Click();
            wait.Until(driver => SchedulesTitle.Displayed);
            Thread.Sleep(4000); 
        }
        /// <summary>
        /// Validated the schedule right panel
        /// </summary>
        /// <param name="scheduleValues"></param>
        public void ScheduleRightPanel(string[] scheduleValues, bool isRedirect = true)
        {
            if (isRedirect)
            {
                NavigateToViewSchedules();
            }
            OpenRightPanelOrKebabMenu(scheduleValues[0], false);
            Assert.AreEqual(scheduleValues[0], RightPanelScheduleName.Text);
            wait.Until(driver => RightPanelScheduleName.Displayed);
            wait.Until(driver => RightPanelScheduleRunNow.Displayed);
            wait.Until(driver => RightPanelSchedulePause.Displayed);
            wait.Until(driver => RightPanelScheduleEdit.Displayed);
            wait.Until(driver => RightPanelScheduleDelete.Displayed);
            extent.SetStepStatusPass("Verified that the buttons are displayed on the right panel.");
            wait.Until(driver => RightPanelScheduleText.Displayed);
            Assert.AreEqual(scheduleValues[1], RightPanelScheduleTextValue.Text);
            wait.Until(driver => RightPanelScheduleStatusText.Displayed);
            status = scheduleValues[2];
            wait.Until(driver => RightPanelScheduleStatus.Displayed);
            wait.Until(driver => RightPanelScheduleDaysRun.Displayed);
            Assert.AreEqual("Sun, Mon, Tue, Wed, Thu, Fri and Sat", RightPanelScheduleDaysRunValue.Text);
            wait.Until(driver => RightPanelScheduleTimeToRun.Displayed);
            Assert.AreEqual(scheduleValues[4], RightPanelScheduleTimeToRunValue.Text);
            wait.Until(driver => RightPanelScheduleRangeHeading.Displayed);
            Assert.AreEqual(scheduleValues[5], RightPanelScheduleRangeValue.Text);
            wait.Until(driver => RightPanelScheduleSummary.Displayed);
            Assert.AreEqual($"Report will be sent on Sun, Mon, Tue, Wed, Thu, Fri and Sat at{scheduleValues[4]}for the data for{scheduleValues[5]}", RightPanelScheduleSummaryValue.Text);
            wait.Until(driver => RightPanelScheduleSendReportsHeading.Displayed);
            Assert.AreEqual(scheduleValues[6], RightPanelScheduleSendReportsValue.Text);
            wait.Until(driver => RightPanelScheduleOutputFormatHeading.Displayed);
            Assert.AreEqual(scheduleValues[3], RightPanelScheduleOFValue.Text);
            wait.Until(driver => RightPanelScheduleNotesHeading.Displayed);
            Assert.AreEqual(scheduleValues[7], RightPanelScheduleNotesValue.Text);
            extent.SetStepStatusPass("Verified that the schedule right panel is working as expected.");
        }

        /// <summary>
        /// DB report panel details
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="vehicleName"></param>
        public void DBReportPanel(string report, string vehicleName)
        {
            reportName = report;
            wait.Until(driver => RightPanelReportWindow.Displayed);
            RightPanelReportWindow.Click();
            wait.Until(driver => ReportWindowHeading.Displayed);
            wait.Until(driver => ReportWindowSubHeading.Displayed);
            wait.Until(driver => ReportWindowDept.Displayed);
            wait.Until(driver => ReportWindowGrp.Displayed);
            wait.Until(driver => ReportWindowVeh.Displayed);
            Assert.AreEqual("No Department", ReportWindowDepDetails.Text);
            Assert.AreEqual("Ungrouped", ReportWindowGrpDetails.Text);
            Assert.AreEqual(vehicleName, ReportWindowVehDetails.Text);
            ReportWindowClose.Click();
            Thread.Sleep(2000);
            extent.SetStepStatusPass("Verified that the DB window.");
        }



        #endregion














    }
}
