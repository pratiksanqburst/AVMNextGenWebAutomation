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
    public class ManageLocations : AVMNextGenBase
    {
        IWebDriver manageLocationsDriver;
        public ManageLocations() { }

        public ManageLocations(IWebDriver driver)
        {
            this.manageLocationsDriver = driver;
        }
        public GetAPIResponse getAPIResponse;


        #region Properties
        public string name=string.Empty;
        public string locationTypeValue = string.Empty;
        public string locationGroupValue = string.Empty;
        public string locationNameValue = string.Empty;
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement Table => driver.FindElement(By.Id("driver-table"));

        IWebElement LocationsLink => driver.FindElement(By.XPath("//li[contains(@class,'locations')]"));
        IWebElement LocationGroupsLink => driver.FindElement(By.LinkText("Groups"));
        IWebElement LocationTypesLink => driver.FindElement(By.LinkText("Types"));
        IWebElement SearchLocationGroup => driver.FindElement(By.Id("txt-search-location"));
        IWebElement AddLocationGroupButton => driver.FindElement(By.Id("add-vehicle-grps-btn"));
        IWebElement AddGroupTitle => driver.FindElement(By.XPath("//h4[@class='modal-title']"));
        IWebElement LocGroupNameLabel => driver.FindElement(By.XPath("//label[contains(text(),'Location Group Name*')]"));
        IWebElement DescriptionLabel => driver.FindElement(By.XPath("//label[contains(text(),'Description')]"));
        IWebElement NameValue => driver.FindElement(By.Id("Name"));
        IWebElement DescriptionValue => driver.FindElement(By.Id("Description"));
        IWebElement CloseButton => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement CancelButton => driver.FindElement(By.Id("add-groups-cancel-btn"));
        IWebElement SaveButton => driver.FindElement(By.Id("add-groups-create-btn"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement SearchResultText => driver.FindElement(By.XPath("//div[@data-test-id='search-location-result-count']/strong"));
        IWebElement SearchCount => driver.FindElement(By.Id("manage-vehicles-count"));
        IWebElement SelectGroup => driver.FindElement(By.XPath($"//li[@title='{name}']"));
        IWebElement GroupNameText => driver.FindElement(By.XPath($"//div[@data-test-id='title-group-name']/h2"));
        IWebElement LocationCount => driver.FindElement(By.XPath($"//div[@data-test-id='title-group-name']/p"));
        IWebElement EditGroupButton => driver.FindElement(By.Id("group-edit-icon"));
        IWebElement DeleteGroupButton => driver.FindElement(By.Id("group-delete-icon"));
        IWebElement DeleteTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement DeleteBody => driver.FindElement(By.XPath("//div[@class='modal-body']/p"));
        IWebElement DeleteCancel => driver.FindElement(By.Id("btn-delete-group-cancel"));
        IWebElement DeleteConfirm => driver.FindElement(By.Id("btn-delete-group-delete"));

        IWebElement CreateLocationIcon => driver.FindElement(By.XPath("//li[@ngbtooltip='Create a new location']"));
        IWebElement LocationNameField => driver.FindElement(By.XPath("//app-add-location//input[@formcontrolname='locationName']"));
        IWebElement CreateButton => driver.FindElement(By.XPath("//button[contains(text(),'Create')]"));
        IWebElement mapArea => driver.FindElement(By.Id("avm-map-container"));

        IWebElement CreateNewLocHeading => driver.FindElement(By.XPath("//h2[contains(text(),'Create New Location')]"));
        IWebElement NameField => driver.FindElement(By.XPath("//app-add-location//label[contains(text(),'Name')]/span[contains(text(),'*')]"));
        IWebElement GeometryField => driver.FindElement(By.XPath("//app-add-location//label[contains(text(),'Geometry')]"));
        IWebElement LocationTypeSearch => driver.FindElement(By.XPath("//app-add-location//input[@formcontrolname='search']"));
        IWebElement SelectLocType => driver.FindElement(By.XPath($"//app-add-location//label[contains(text(),'{locationTypeValue}')]"));
        IWebElement CrateLocDescriptionLabel => driver.FindElement(By.XPath("//app-add-location//label[contains(text(),'Description')]"));
        IWebElement CreateLocDescriptionValue => driver.FindElement(By.XPath("//app-add-location//input[@formcontrolname='description']"));
        IWebElement GroupLabel => driver.FindElement(By.XPath("//app-add-location//label[contains(text(),'Group')]/span[contains(text(),'*')]"));
        IWebElement LocGroupDropDwon => driver.FindElement(By.XPath("//app-add-location//ng-select[@formcontrolname='locationGroup']"));
        IWebElement SelectLocGroup => driver.FindElement(By.XPath($"//app-add-location//span[contains(text(),'{locationGroupValue}')]"));
        IWebElement LocationNanmeLabel => driver.FindElement(By.XPath($"//h2[contains(text(),'{locationNameValue}')]"));
        IWebElement LocationTypeLabel => driver.FindElement(By.XPath($"//p[contains(text(),'{locationTypeValue}')]"));
        IWebElement RadiusLabel => driver.FindElement(By.XPath("//label[contains(text(),'Radius')]"));
        IWebElement RadiusUnit => driver.FindElement(By.XPath("//label[contains(text(),'Radius')]/following-sibling::span[contains(text(),'km')]"));
        IWebElement RadiusValue => driver.FindElement(By.XPath("//label[contains(text(),'Radius')]/following-sibling::input"));
        IWebElement RightPanelCoordinates => driver.FindElement(By.XPath("//ul[@class='right-panel-coordinates-circle']"));
        IWebElement DeleteCoordinateButton => driver.FindElement(By.XPath("//img[contains(@src,'delete-icon')]"));
        IWebElement HelperMessage1 => driver.FindElement(By.XPath("//app-add-loc-coordinates//div[contains(@class,'finish-draw')]/div[1]/p[1]"));
        IWebElement HelperMessage2 => driver.FindElement(By.XPath("//app-add-loc-coordinates//div[contains(@class,'finish-draw')]/div[1]/p[2]"));
        IWebElement CreateLocCancelButton => driver.FindElement(By.XPath("//app-add-loc-coordinates//div[contains(@class,'finish-draw')]/div[2]//button[contains(text(),'Cancel')]"));
        IWebElement CreateLocSaveButton => driver.FindElement(By.XPath("//div[@id='app-right-info-view']/following-sibling::div[contains(@class,'finish-draw')]/div[2]//button[contains(text(),'Save')]"));

        // Location added
        #endregion



        #region Methods

        /// <summary>
        /// Create New Location
        /// </summary>
        /// <param name="locName"></param>
        /// <param name="locGroup"></param>
        /// <param name="locType"></param>
        public void CreateNewLocation(string locName,string locGroup,string locType)
        {
            wait.Until(driver => CreateLocationIcon.Displayed);
            CreateLocationIcon.Click();
            extent.SetStepStatusPass("Clicked on create location icon");
            Thread.Sleep(2000);
            wait.Until(driver => CreateNewLocHeading.Displayed);
            wait.Until(driver => NameField.Displayed);
            wait.Until(driver => GeometryField.Displayed);
            wait.Until(driver => CrateLocDescriptionLabel.Displayed);
            wait.Until(driver => GroupLabel.Displayed);
            extent.SetStepStatusPass("Verified the labels in create location pop up");
            LocationNameField.SendKeys(locName);
            LocationTypeSearch.SendKeys(locType);
            Thread.Sleep(2000);
            locationTypeValue = locType;
            SelectLocType.Click();
            extent.SetStepStatusPass("Selected the location type");
            CreateLocDescriptionValue.SendKeys("Test Description");
            LocGroupDropDwon.Click();
            Thread.Sleep(2000);
            locationGroupValue = locGroup;
            SelectLocGroup.Click();
            Thread.Sleep(2000);
            CreateButton.Click();
            extent.SetStepStatusPass("Clicked on create button");
            Thread.Sleep(2000);
            locationNameValue = locName;
            wait.Until(driver => LocationNanmeLabel.Displayed);
            wait.Until(driver => LocationTypeLabel.Displayed);
            wait.Until(driver => RadiusLabel.Displayed);
            wait.Until(driver => RadiusUnit.Displayed);
            mapArea.Click();
            extent.SetStepStatusPass("Clicked on map.");
            RadiusValue.Clear();
            RadiusValue.SendKeys("10");
            Thread.Sleep(2000);
            wait.Until(driver => RightPanelCoordinates.Displayed);
            DeleteCoordinateButton.Click();
            extent.SetStepStatusPass("Deleted the coordinate.");
            Thread.Sleep(2000);
            mapArea.Click();
            RadiusValue.Clear();
            RadiusValue.SendKeys("20");
            Thread.Sleep(2000);
            wait.Until(driver => RightPanelCoordinates.Displayed);
            Assert.AreEqual("Press Enter for finish drawing", HelperMessage1.Text.Trim().Replace("/r/n", ""));
            Assert.AreEqual("Press Esc to reset", HelperMessage2.Text.Trim().Replace("/r/n", ""));
            wait.Until(driver => CreateLocCancelButton.Displayed);
            CreateLocSaveButton.Click();
            extent.SetStepStatusPass("Clicked on save button.");
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Trim().Contains("Location added"));
            extent.SetStepStatusPass("Verified the success message.");
        }
        /// <summary>
        /// Navigate to Manage Location groups
        /// </summary>
        public void NavigateToManageLocationGroups()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            wait.Until(driver => Table.Displayed);
            Actions action = new Actions(driver);
            action.MoveToElement(LocationsLink).Perform();
            wait.Until(driver => LocationGroupsLink.Displayed);
            LocationGroupsLink.Click();
            Thread.Sleep(3000);
            wait.Until(driver => SearchLocationGroup.Displayed);
            extent.SetStepStatusPass("Verified that the location groups page is displayed.");
        }
        /// <summary>
        /// Create new location group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="description"></param>
        public void CreateLocationGroup(string groupName, string description)
        {
            NavigateToManageLocationGroups();
            wait.Until(driver => AddLocationGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that the add group button is displayed.");
            AddLocationGroupButton.Click();
            wait.Until(driver => AddGroupTitle.Displayed);
            extent.SetStepStatusPass("Verified that the modal title is displayed.");
            Assert.IsTrue(AddGroupTitle.Text.Trim().Contains("Create New Location Group"));
            wait.Until(driver => LocGroupNameLabel.Displayed);
            wait.Until(driver => DescriptionLabel.Displayed);
            extent.SetStepStatusPass("Verified that the placeholder texts are displayed.");
            NameValue.SendKeys(groupName);
            extent.SetStepStatusPass("Entered group name.");
            DescriptionValue.SendKeys(description);
            extent.SetStepStatusPass("Entered description.");
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => CloseButton.Displayed);
            extent.SetStepStatusPass("Verified that the cancel and close buttons are displayed.");
            SaveButton.Click();
            extent.SetStepStatusPass("Clicked on save button.");
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Trim().Contains("Location Group Added Successfully."));
            extent.SetStepStatusPass("Verified that the success alert text is displayed.");
        }
        /// <summary>
        /// Search by location group name
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="locationCount"></param>
        /// <param name="isDeleted"></param>
        public void SearchLocationGroupByName(string groupName, int locationCount, bool isDeleted = false)
        {
            wait.Until(driver => SearchLocationGroup.Displayed);
            extent.SetStepStatusPass("Verified that the search group field is displayed.");
            Thread.Sleep(3000);
            SearchLocationGroup.Clear();
            SearchLocationGroup.SendKeys(groupName);
            name = groupName;
            extent.SetStepStatusPass("Entered group name in search field.");
            if (isDeleted == false)
            {

                wait.Until(driver => SelectGroup.Displayed);
                extent.SetStepStatusPass("Verified that the group is displayed.");
                Assert.IsTrue(Convert.ToInt32(SearchCount.Text.Trim()) > 0);
                extent.SetStepStatusPass("Verified that the search count is greater than 0.");
                SelectGroup.Click();
                extent.SetStepStatusPass("Selects the first group displayed");
                Thread.Sleep(5000);
                wait.Until(driver => GroupNameText.Displayed);
                Assert.IsTrue(GroupNameText.Text.Trim().Contains(groupName));
                Assert.IsTrue(LocationCount.Text.Trim().Contains($"Number of locations: {locationCount}"));
                extent.SetStepStatusPass("Verified that the group contents are displayed correctly.");
            }
            else
            {
                wait.Until(driver => SearchCount.Displayed);
                Assert.IsTrue(Convert.ToInt32(SearchCount.Text.Trim()) == 0);
                extent.SetStepStatusPass("Verified that the search count is 0.");
            }
        }
        /// <summary>
        /// Edit the location group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="description"></param>
        public void EditLocationGroup(string groupName, string description)
        {
            wait.Until(driver => EditGroupButton.Displayed);
            Thread.Sleep(1000);
            extent.SetStepStatusPass("Verified that the edit group button is displayed.");
            EditGroupButton.Click();
            Thread.Sleep(1000);
            wait.Until(driver => AddGroupTitle.Displayed);
            extent.SetStepStatusPass("Verified that the modal title is displayed.");
            Assert.IsTrue(AddGroupTitle.Text.Trim().Contains("Edit Location Group"));
            Assert.IsTrue(LocGroupNameLabel.Text.Trim().Contains("Location Group Name*"));
            Assert.IsTrue(DescriptionLabel.Text.Trim().Contains("Description"));
            extent.SetStepStatusPass("Verified that the placeholder texts are displayed.");
            NameValue.Clear();
            Thread.Sleep(1000);
            NameValue.SendKeys(groupName);
            extent.SetStepStatusPass("Entered group name.");
            DescriptionValue.Clear();
            DescriptionValue.SendKeys(description);
            extent.SetStepStatusPass("Entered description.");
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => CloseButton.Displayed);
            extent.SetStepStatusPass("Verified that the cancel and close buttons are displayed.");
            SaveButton.Click();
            extent.SetStepStatusPass("Clicked on save button.");
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Trim().Contains("Location Group Edited Successfully."));
            extent.SetStepStatusPass("Verified that the success alert text is displayed.");
        }
        /// <summary>
        /// Delete Location Group
        /// </summary>
        /// <param name="groupName"></param>
        public void DeleteLocationGroup(string groupName)
        {
            SearchLocationGroupByName(groupName, 1);
            wait.Until(driver => DeleteGroupButton.Displayed);
            extent.SetStepStatusPass("Verified that the delete group button is displayed.");
            DeleteGroupButton.Click();
            wait.Until(driver => DeleteTitle.Displayed);
            extent.SetStepStatusPass("Verified that the modal title is displayed.");
            Assert.IsTrue(DeleteTitle.Text.Trim().Contains("Confirmation"));
            Assert.IsTrue(DeleteBody.Text.Trim().Contains("Deleting a location group does not delete the location in it." +
                " The location will be relocated to the 'Ungrouped' category. Do you want to delete this group?"));
            extent.SetStepStatusPass("Verified that the modal body is displayed properly.");
            Assert.IsTrue(DeleteCancel.Displayed);
            extent.SetStepStatusPass("Verified that the cancel button is displayed.");
            DeleteConfirm.Click();
            extent.SetStepStatusPass("Clicked on delete confirm button");
            wait.Until(driver => SuccessMessage.Displayed);
            Assert.IsTrue(SuccessMessage.Text.Trim().Contains("Location Group Deleted Successfully."));
            SearchLocationGroupByName(groupName, 0, true);
        }
        #endregion
    }
}
