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
    public class ManageGlobalSettings : AVMNextGenBase
    {
        IWebDriver manageGlobalSettings;
        public ManageGlobalSettings() { }

        public ManageGlobalSettings(IWebDriver driver)
        {
            this.manageGlobalSettings = driver;
        }
        public GetAPIResponse getAPIResponse;
        #region Properties
        public string hour = string.Empty;
        public string minute = string.Empty;
        public string day = string.Empty;
        public string timezone = string.Empty;
        public string timeSlotName = string.Empty;
        public string dayVerification = string.Empty;
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement Title => driver.FindElement(By.XPath("//h2[contains(text(),'Users')]"));
        IWebElement ManageSettings => driver.FindElement(By.XPath("//li[contains(text(),'Global Settings')]"));
        IWebElement PageHeading => driver.FindElement(By.XPath("//h4[contains(text(),'Operational hours')]"));
        IWebElement TimePickerStartSelect => driver.FindElement(By.XPath($"//form//span[contains(text(),'{day}')]/parent::div/following-sibling::div//time-picker[contains(@formcontrolname,'start')]"));
        IWebElement TimePickerStopSelect => driver.FindElement(By.XPath($"//form//span[contains(text(),'{day}')]/parent::div/following-sibling::div//time-picker[contains(@formcontrolname,'stop')]"));
        IWebElement HourSelect => driver.FindElement(By.XPath($"//span[@id='hour-{hour}']"));
        IWebElement MinuteSelect => driver.FindElement(By.XPath($"//span[@id='minute-{minute}']"));
        IWebElement AMSelect => driver.FindElement(By.XPath($"//span[contains(text(),'AM')]"));
        IWebElement PMSelect => driver.FindElement(By.XPath($"//span[contains(text(),'PM')]"));
        IWebElement TimePickerOk => driver.FindElement(By.XPath("//button[contains(text(),'OK')]"));
        IWebElement AddNewButton => driver.FindElement(By.Id("new-entry-btn"));
        IWebElement EditNewButton => driver.FindElement(By.XPath($"//p[@id='optnl-hrs-name'][contains(text(),'{timeSlotName}')]/parent::div//img[@id='entry-edit-icon']"));
        IWebElement DeleteButton => driver.FindElement(By.XPath($"//p[@id='optnl-hrs-name'][contains(text(),'{timeSlotName}')]/parent::div//img[@id='entry-delete-icon']"));
        IWebElement DeleteTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement DeleteClose => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement DeleteBody => driver.FindElement(By.XPath("//div[@class='modal-body']/p"));
        IWebElement DeleteConfirm => driver.FindElement(By.XPath("//div[@class='modal-footer']//button[contains(text(),'Confirm')]"));
        IWebElement DeleteCancel => driver.FindElement(By.XPath("//div[@class='modal-footer']//button[contains(text(),'Cancel')]"));

        IWebElement ToggleCheckbox => driver.FindElement(By.XPath($"//input[contains(@id,'{day.ToLower()}')]/following-sibling::label"));
        IWebElement CheckboxStatus => driver.FindElement(By.XPath($"//form//span[contains(text(),'{day}')]/parent::div//span[contains(@class,'set-hours-status')]"));
        IWebElement TimeZoneText => driver.FindElement(By.XPath($"//label[contains(text(),'Time zone')]"));
        IWebElement AddEntryHeader => driver.FindElement(By.XPath("//p[contains(text(),'Add new operating hours')]"));
        IWebElement NamePlaceHolder => driver.FindElement(By.XPath("//label[contains(text(),'Name')]"));
        IWebElement DescriptionPlaceHolder => driver.FindElement(By.XPath("//label[contains(text(),'Description')]"));
        IWebElement NameValue => driver.FindElement(By.Id("name-field"));
        IWebElement DescriptionValue => driver.FindElement(By.XPath("//textarea[@formcontrolname='description']"));

        IWebElement TimezoneDropDown => driver.FindElement(By.XPath("//div[@role='combobox']"));
        IWebElement TimezoneSelection => driver.FindElement(By.XPath($"//span[contains(@class,'ng-option')][contains(text(),'{timezone}')]"));

        IWebElement CancelButton => driver.FindElement(By.Id("right-panel-cancel-btn"));
        IWebElement SaveButton => driver.FindElement(By.Id("right-panel-done-btn"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement TimeSlot => driver.FindElement(By.XPath($"//p[@id='optnl-hrs-name'][contains(text(),'{timeSlotName}')]"));
        IWebElement TimeZoneInfo => driver.FindElement(By.XPath($"//p[@id='optnl-hrs-name'][contains(text(),'{timeSlotName}')]/span"));

        IWebElement DayValue => driver.FindElement(By.XPath($"//p[@id='optnl-hrs-name'][contains(text(),'{timeSlotName}')]/parent::" +
            $"div/parent::div//span[@id='set-day'][contains(text(),'{dayVerification}')]"));
        IWebElement TimeInfo => driver.FindElement(By.XPath($"//p[@id='optnl-hrs-name'][contains(text(),'{timeSlotName}')]/parent::" +
            $"div/parent::div//span[@id='set-day'][contains(text(),'{dayVerification}')]/following-sibling::p"));

        IWebElement TimeZoneDescription => driver.FindElement(By.XPath($"//p[@id='optnl-hrs-name'][contains(text(),'{timeSlotName}')]/parent::div/following-sibling::p[@id='optnl-hrs-description']"));





        #endregion


        #region Methods
        /// <summary>
        /// Select Time from time picker
        /// </summary>
        /// <param name="dayValue"></param>
        /// <param name="hourValue"></param>
        /// <param name="minuteValue"></param>
        /// <param name="isStart"></param>
        public void SelectTime(string dayValue, string hourValue, string minuteValue, bool isStart,bool isAM=true)
        {
            day = dayValue;
            if (isStart)
                TimePickerStartSelect.Click();
            else
                TimePickerStopSelect.Click();
            wait.Until(driver => TimePickerOk.Displayed);
            hour = hourValue;
            HourSelect.Click();
            Thread.Sleep(2000);
            minute = minuteValue;
            MinuteSelect.Click();
            if(isAM)
                AMSelect.Click();
            else
                PMSelect.Click();
            TimePickerOk.Click();
            Thread.Sleep(2000);
        }
        public void SelectCheckbox(string dayValue, bool clickToggle, bool isEnabled)
        {
            day = dayValue;
            wait.Until(driver => ToggleCheckbox.Displayed);
            if (clickToggle)
            {
                Actions build = new Actions(driver);
                build.MoveToElement(ToggleCheckbox).Click().Build().Perform(); ;
            }
            if (isEnabled)
                Assert.AreEqual("Open", CheckboxStatus.Text.Trim());
            else
                Assert.AreEqual("Closed", CheckboxStatus.Text.Trim());

        }


        /// <summary>
        /// Navigate to manage Global Settings tab
        /// </summary>
        public void NavigateToManageGlobalSettings()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            Thread.Sleep(2000);
            wait.Until(driver => ManageSettings.Displayed);
            ManageSettings.Click();
            wait.Until(driver => PageHeading.Displayed);
            extent.SetStepStatusPass("Verified that the title is displayed.");
        }

        /// <summary>
        /// Add new time slot
        /// </summary>
        public void AddTimeSlot(string slotName)
        {
            NavigateToManageGlobalSettings();
            wait.Until(driver => AddNewButton.Displayed);
            AddNewButton.Click();
            wait.Until(driver => AddEntryHeader.Displayed);
            Actions actions = new Actions(driver);
            actions.MoveToElement(NamePlaceHolder);
            actions.Perform();
            Thread.Sleep(2000);
            NameValue.SendKeys(slotName);
            extent.SetStepStatusPass("Added time slot name");
            wait.Until(driver => DescriptionPlaceHolder.Displayed);
            DescriptionValue.SendKeys("Test Description");
            extent.SetStepStatusPass("Added description");
            wait.Until(driver => TimeZoneText.Displayed);
            TimezoneDropDown.Click();
            timezone = "Guam";
            wait.Until(driver => TimezoneSelection.Displayed);
            TimezoneSelection.Click();
            SelectTime("Mon", "09", "30", true, true);
            Thread.Sleep(1000);
            SelectTime("Mon", "10", "30", false, false);
            Thread.Sleep(1000);
            SelectCheckbox("Sun", true, true);
            Thread.Sleep(1000);
            SelectTime("Sun", "10", "30", true, true);
            Thread.Sleep(1000);
            SelectTime("Sun", "11", "30", false, false);
            Thread.Sleep(1000);
            SelectCheckbox("Tue", true, false);
            Thread.Sleep(1000);
            SelectCheckbox("Wed", true, false);
            Thread.Sleep(1000);
            SelectCheckbox("Thu", true, false);
            Thread.Sleep(1000);
            SelectCheckbox("Fri", true, false);
            Thread.Sleep(1000);
            SelectCheckbox("Sat", false, false);
            Thread.Sleep(1000);
            SaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Operational Hour added successfully", SuccessMessage.Text.Trim());
            extent.SetStepStatusPass("Added time slot info");
        }
        /// <summary>
        /// Verifies the time slot info displayed on the page.
        /// </summary>
        /// <param name="timeDetails"></param>
        /// <param name="days"></param>
        /// <param name="timeRange"></param>
        public void VerifyTimeSlot(string[] timeDetails, string[] days, string[] timeRange)
        {
            timeSlotName = timeDetails[0];
            wait.Until(driver => TimeSlot.Displayed);
            Assert.AreEqual(timeDetails[1], TimeZoneInfo.Text.Trim());
            for (int i = 0; i < days.Length; i++)
            {
                dayVerification = days[i];
                wait.Until(driver => DayValue.Displayed);
                Assert.AreEqual(timeRange[i], TimeInfo.Text.Trim());
            }
            Assert.AreEqual(timeDetails[2], TimeZoneDescription.Text.Trim());
        }
        /// <summary>
        /// Edit Time slot Info
        /// </summary>
        /// <param name="slotName"></param>
        public void EditTimeSlot(string slotName, string newSlotName)
        {
            NavigateToManageGlobalSettings();
            timeSlotName = slotName;
            wait.Until(driver => EditNewButton.Displayed);
            EditNewButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => AddEntryHeader.Displayed);
            Actions actions = new Actions(driver);
            actions.MoveToElement(NamePlaceHolder);
            actions.Perform();
            Thread.Sleep(2000);
            NameValue.Clear();
            NameValue.SendKeys(newSlotName);
            extent.SetStepStatusPass("Edited with the new name.");
            wait.Until(driver => DescriptionPlaceHolder.Displayed);
            DescriptionValue.Clear();
            DescriptionValue.SendKeys("Test Description Edited");
            extent.SetStepStatusPass("Description edited.");
            wait.Until(driver => TimeZoneText.Displayed);
            TimezoneDropDown.Click();
            timezone = "Universal";
            wait.Until(driver => TimezoneSelection.Displayed);
            TimezoneSelection.Click();
            SelectCheckbox("Mon", true, false);
            Thread.Sleep(1000);
            SelectCheckbox("Sun", true, false);
            Thread.Sleep(1000);
            SelectCheckbox("Tue", true, true);
            Thread.Sleep(1000);
            SelectTime("Tue", "09", "30", true, true);
            Thread.Sleep(1000);
            SelectTime("Tue", "10", "30", false, false);
            Thread.Sleep(1000);
            SelectCheckbox("Wed", false, false);
            Thread.Sleep(1000);
            SelectCheckbox("Thu", false, false);
            Thread.Sleep(1000);
            SelectCheckbox("Fri", false, false);
            Thread.Sleep(1000);
            SelectCheckbox("Sat", true, true);
            Thread.Sleep(1000);
            SelectTime("Sat", "10", "30", true, true);
            Thread.Sleep(1000);
            SelectTime("Sat", "11", "30", false, false);
            Thread.Sleep(1000);
            SaveButton.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Operational Hour updated successfully", SuccessMessage.Text.Trim());
            extent.SetStepStatusPass("Verified editing of time slots.");
        }

        public void DeleteTimeSlot(string slotName)
        {
            NavigateToManageGlobalSettings();
            timeSlotName = slotName;
            wait.Until(driver => DeleteButton.Displayed);
            DeleteButton.Click();
            Thread.Sleep(2000);
            wait.Until(driver => DeleteTitle.Displayed);
            Assert.AreEqual("Confirmation", DeleteTitle.Text.Trim());
            Assert.AreEqual("Do you want to delete the operational hour?", DeleteBody.Text.Trim());
            wait.Until(driver => DeleteClose.Displayed);
            wait.Until(driver => DeleteCancel.Displayed);
            DeleteConfirm.Click();
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.AreEqual("Operational Hour deleted successfully", SuccessMessage.Text.Trim());
            try
            {
                wait.Until(driver => DeleteButton.Displayed);
            }
            catch (Exception ex)
            {
                extent.SetStepStatusPass($"Verified that the time slot is no longer displayed- {ex}.");
            }
            extent.SetStepStatusPass("Verified the delete time slot functionality.");
        }
        #endregion
    }
}
