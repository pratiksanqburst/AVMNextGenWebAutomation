using AVMNextGenWebAutomation.AVMNextGenAPI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AVMNextGenWebAutomation.AVMNextGenPageObjects
{
    public class ManageVehicles : AVMNextGenBase
    {
        IWebDriver manageVehiclesDriver;
        public ManageVehicles() { }

        public ManageVehicles(IWebDriver driver)
        {
            this.manageVehiclesDriver = driver;
        }
        public GetAPIResponse getAPIResponse;

        #region Properties
        string operatingHours = string.Empty;
        string group = string.Empty;
        int count = 0;
        IWebElement ManageTab => driver.FindElement(By.Id("menu-manage"));
        IWebElement Table => driver.FindElement(By.Id("driver-table"));
        IWebElement ManageVehicleTab => driver.FindElement(By.XPath("//li[contains(text(),'Vehicle')]"));
        IWebElement Title => driver.FindElement(By.XPath("//p[@title='All Vehicles']"));
        IWebElement AddVehicleGroupBtn => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//button[@id='add-vehicle-grps-btn']"));
        IWebElement AddGroupTitle => driver.FindElement(By.XPath("//h4[@class='modal-title']"));
        IWebElement NamePlaceholder => driver.FindElement(By.XPath("//div[@class='group-name-field']/label"));
        IWebElement NameInput => driver.FindElement(By.Id("Name"));
        IWebElement DescriptionPlaceholder => driver.FindElement(By.XPath("//div[@class='group-description-field']/label"));
        IWebElement DescriptionInput => driver.FindElement(By.Id("Description"));
        IWebElement ColorPlaceholder => driver.FindElement(By.XPath("//div[@class='group-color-selection-wrapper']/label"));
        IWebElement OrangeColor => driver.FindElement(By.XPath("//div[contains(@class,'color-circles')]/div[2]"));
        IWebElement RedColor => driver.FindElement(By.XPath("//div[contains(@class,'color-circles')]/div[5]"));
        IWebElement CancelButton => driver.FindElement(By.Id("add-groups-cancel-btn"));
        IWebElement SaveButton => driver.FindElement(By.Id("add-groups-create-btn"));
        IWebElement CloseButton => driver.FindElement(By.Id("modal-close-btn"));
        IWebElement SuccessAlertDialogue => driver.FindElement(By.XPath("//div[@role='alert']"));
        IWebElement SearchGroup => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//input[@placeholder='Search Vehicle Group']"));
        IWebElement SelectFirstGroup => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//ul[@class='manage-vehicles-list']/li[1]"));
        IWebElement groupNameText => driver.FindElement(By.Id("group-name"));
        IWebElement VehicleNumberText => driver.FindElement(By.XPath("//p[@class='num-vehicles-text']"));
        IWebElement NumberOfVehicles => driver.FindElement(By.Id("group-count"));
        IWebElement EditGroupVehicle => driver.FindElement(By.Id("group-edit-icon"));
        IWebElement DeleteGroupVehicle => driver.FindElement(By.Id("group-delete-icon"));
        IWebElement DeleteModalTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement DeleteModalBody => driver.FindElement(By.XPath("//div[@class='modal-body']/p"));
        IWebElement DeleteCancelBtn => driver.FindElement(By.XPath("//div[@class='modal-dialog']//button[contains(text(),'Cancel')]"));
        IWebElement DeleteConfirmBtn => driver.FindElement(By.XPath("//div[@class='modal-dialog']//button[contains(text(),'Confirm')]"));
        IWebElement SearchCount => driver.FindElement(By.XPath("//div[contains(@class,'side-panel')]//span[@id='manage-vehicles-count']"));
        IWebElement Kebabmenu => driver.FindElement(By.XPath("//div[@class='kebab-menu']"));
        IWebElement EditVehicle => driver.FindElement(By.XPath("//li[contains(text(),'Edit')]"));
        IWebElement VehicleNameLabel => driver.FindElement(By.XPath("//label[contains(text(),'Vehicle Name*')]"));
        IWebElement VehicleIDLabel => driver.FindElement(By.XPath("//label[contains(text(),'Vehicle ID')]"));
        IWebElement MakeLabel => driver.FindElement(By.XPath("//label[contains(text(),'Make')]"));
        IWebElement ModelLabel => driver.FindElement(By.XPath("//label[contains(text(),'Model')]"));
        IWebElement RegNumberLabel => driver.FindElement(By.XPath("//label[contains(text(),'Registration No.')]"));
        IWebElement TypeLabel => driver.FindElement(By.XPath("//label[contains(text(),'Type')]"));
        IWebElement RequiredLicenseLabel => driver.FindElement(By.XPath("//label[contains(text(),'Required License')]"));
        IWebElement VINLabel => driver.FindElement(By.XPath("//label[contains(text(),'VIN')]"));
        IWebElement EngineNumberLabel => driver.FindElement(By.XPath("//label[contains(text(),'Engine No.')]"));
        IWebElement VehicleCategoryLabel => driver.FindElement(By.XPath("//label[contains(text(),'Vehicle Category')]"));
        IWebElement OperatingHoursLabel => driver.FindElement(By.XPath("//label[contains(text(),'Operating Hours')]"));
        IWebElement VehicleTrackerIDLabel => driver.FindElement(By.XPath("//label[contains(text(),'Vehicle Tracker ID')]"));
        IWebElement TrackSerialLabel => driver.FindElement(By.XPath("//label[contains(text(),'Tracker Serial Number')]"));
        IWebElement VehicleNameField => driver.FindElement(By.XPath("//input[@formcontrolname='vehicleName']"));
        IWebElement VehicleIDField => driver.FindElement(By.XPath("//input[@formcontrolname='vehicleId']"));
        IWebElement MakeField => driver.FindElement(By.XPath("//input[@formcontrolname='manufacturer']"));
        IWebElement ModelField => driver.FindElement(By.XPath("//input[@formcontrolname='model']"));
        IWebElement RegNumberField => driver.FindElement(By.XPath("//input[@formcontrolname='registration']"));
        IWebElement TypeField => driver.FindElement(By.XPath("//input[@formcontrolname='type']"));
        IWebElement RequiredLicenseField => driver.FindElement(By.XPath("//input[@formcontrolname='licensesRequired']"));
        IWebElement VINField => driver.FindElement(By.XPath("//input[@formcontrolname='chassisVin']"));
        IWebElement EngineNumberField => driver.FindElement(By.XPath("//input[@formcontrolname='engineNumber']"));
        IWebElement VehicleCategoryField => driver.FindElement(By.XPath("//input[@formcontrolname='vehicleCategory']"));
        IWebElement OperatingHoursdropdown => driver.FindElement(By.XPath("//ng-select[@formcontrolname='operatingHours']"));
        IWebElement OperatingHoursSelection => driver.FindElement(By.XPath($"//span[contains(text(),'{operatingHours}')]"));
        IWebElement EditCancelButton => driver.FindElement(By.XPath("//button[contains(text(),'Cancel')]"));
        IWebElement EditSaveButton => driver.FindElement(By.XPath($"//button[contains(text(),'Save')]"));

        IWebElement VehicleNameColumn => driver.FindElement(By.XPath($"//div[@class='col-vname']"));
        IWebElement VehicleIdColumn => driver.FindElement(By.XPath($"//div[@class='col-vid']"));
        IWebElement VehicleGroupColumn => driver.FindElement(By.XPath($"//div[@class='col-group']"));
        IWebElement VehicleDriverColumn => driver.FindElement(By.XPath($"//div[@class='col-driver']"));
        IWebElement VehicleMakeColumn => driver.FindElement(By.XPath($"//div[@class='col-make']"));
        IWebElement VehicleModelColumn => driver.FindElement(By.XPath($"//div[@class='col-model']"));
        IWebElement RegNumberColumn => driver.FindElement(By.XPath($"//div[@class='col-regno']"));

        IWebElement VehicleNameValue => driver.FindElement(By.Id("row-vname"));
        IWebElement VehicleIdValue => driver.FindElement(By.Id("row-vid"));
        IWebElement VehicleGroupValue => driver.FindElement(By.Id("row-group"));
        IWebElement VehicleDriverValue => driver.FindElement(By.Id("row-driver"));
        IWebElement VehicleMakeValue => driver.FindElement(By.Id("row-make"));
        IWebElement VehicleModelValue => driver.FindElement(By.Id("row-model"));
        IWebElement RegNumberValue => driver.FindElement(By.Id("row-regno"));

        IWebElement DeleteAction => driver.FindElement(By.Id("delete-action"));
        IWebElement ChangeGroup => driver.FindElement(By.XPath("//li[contains(text(),'Change Group')]"));
        IWebElement AssignGroupHeader => driver.FindElement(By.XPath("//p[@id='right-panel-tree-header'][contains(text(),'Assign group')]"));
        IWebElement SearchNewGroup => driver.FindElement(By.XPath("//div[@id='fleet-list-wrapper']//input[@placeholder='Search Vehicle Group']"));
        IWebElement SearchResult => driver.FindElement(By.XPath($"//div[@class='right-panel-tree right-slide-animation']//span[contains(text(),'{group}')]"));
        IWebElement CancelAssignButton => driver.FindElement(By.XPath("//div[@class='right-panel-tree right-slide-animation']//button[@id='right-panel-cancel-btn']"));
        IWebElement SaveAssignButton => driver.FindElement(By.XPath("//div[@class='right-panel-tree right-slide-animation']//button[@id='right-panel-done-btn']"));
        List<IWebElement> rows => driver.FindElements(By.XPath("//div[contains(@class,'vehicles-table')]/div[2]/div")).ToList();
        IWebElement vehicleRowName => driver.FindElement(By.XPath($"//div[contains(@class,'vehicles-table')]/div[2]/div[{count}]//div[@id='row-vname']"));
        IWebElement vehicleCheckbox => driver.FindElement(By.XPath($"//div[contains(@class,'vehicles-table')]/div[2]/div[{count}]//span[@class='checkmark']"));
        IWebElement SelectedVehicleCount => driver.FindElement(By.Id("selected-vehicles-count"));
        IWebElement SelectedVehicleText => driver.FindElement(By.Id("selected-vehicles-text"));
        IWebElement AssignGroupTopButton => driver.FindElement(By.Id("change-group-btn"));
        IWebElement RightPanelHeading => driver.FindElement(By.XPath("//div[@class='title']/h2"));
        IWebElement CalibrateReading => driver.FindElement(By.XPath("//button[contains(text(),'Calibrate Reading')]"));
        IWebElement DriverNameText => driver.FindElement(By.XPath("//p[text()='Driver']/following-sibling::p"));
        IWebElement VehicleGroupText => driver.FindElement(By.XPath("//p[text()='Vehicle Group']/following-sibling::p"));
        IWebElement MakeValue => driver.FindElement(By.XPath("//label[text()='Make']/following-sibling::p"));
        IWebElement ModelValue => driver.FindElement(By.XPath("//label[text()='Model']/following-sibling::p"));
        IWebElement RegNumberRightPanel => driver.FindElement(By.XPath("//label[text()='Registration Number']/following-sibling::p"));
        IWebElement TypeRightPanel => driver.FindElement(By.XPath("//label[text()='Type ']/following-sibling::p"));
        IWebElement ReqLicenseRightPanel => driver.FindElement(By.XPath("//label[text()='Required License']/following-sibling::p"));
        IWebElement VINRightPanel => driver.FindElement(By.XPath("//label[text()='VIN ']/following-sibling::p"));
        IWebElement EngNumberRightPanel => driver.FindElement(By.XPath("//label[text()='Engine Number']/following-sibling::p"));
        IWebElement VehicleCategoryRightPanel => driver.FindElement(By.XPath("//label[text()='Vehicle Category']/following-sibling::p"));
        IWebElement OperatingHoursValue => driver.FindElement(By.XPath("//label[text()='Operating Hours']/following-sibling::p"));
        IWebElement VehicleTrackerIdValue => driver.FindElement(By.XPath("//label[text()='Vehicle Tracker ID']/following-sibling::p"));
        IWebElement TrackerSerialNumber => driver.FindElement(By.XPath("//label[text()='Tracker Serial Number']/following-sibling::p"));



























        #endregion

        #region Methods
        /// <summary>
        /// Navigate to Manage Vehicles page
        /// </summary>
        public void NavigateToManageVehicles()
        {
            wait.Until(driver => ManageTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage link is displayed.");
            ManageTab.Click();
            wait.Until(driver => Table.Displayed);
            wait.Until(driver => ManageVehicleTab.Displayed);
            extent.SetStepStatusPass("Verified that Manage Vehicle Tab is displayed.");
            ManageVehicleTab.Click();
            wait.Until(driver => Title.Displayed);
            Assert.IsTrue(Title.Text.Trim().Contains("All Vehicles"));
            extent.SetStepStatusPass("Verified that the title is displayed.");
        }

        /// <summary>
        /// Create Vehicle group
        /// </summary>
        /// <param name="groupName">Group name</param>
        /// <param name="description">Description</param>
        public void CreateVehicleGroup(string groupName, string description)
        {
            NavigateToManageVehicles();
            wait.Until(driver => AddVehicleGroupBtn.Displayed);
            extent.SetStepStatusPass("Verified that the add group button is displayed.");
            AddVehicleGroupBtn.Click();
            wait.Until(driver => AddGroupTitle.Displayed);
            extent.SetStepStatusPass("Verified that the modal title is displayed.");
            Assert.IsTrue(AddGroupTitle.Text.Trim().Contains("Add Vehicle Group"));
            Assert.IsTrue(NamePlaceholder.Text.Trim().Contains("Name*"));
            Assert.IsTrue(DescriptionPlaceholder.Text.Trim().Contains("Description"));
            Assert.IsTrue(ColorPlaceholder.Text.Trim().Contains("Color"));
            extent.SetStepStatusPass("Verified that the placeholder texts are displayed.");
            NameInput.SendKeys(groupName);
            extent.SetStepStatusPass("Entered group name.");
            DescriptionInput.SendKeys(description);
            extent.SetStepStatusPass("Entered description.");
            OrangeColor.Click();
            extent.SetStepStatusPass("Clicked on orange color.");
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => CloseButton.Displayed);
            extent.SetStepStatusPass("Verified that the cancel and close buttons are displayed.");
            SaveButton.Click();
            extent.SetStepStatusPass("Clicked on save button.");
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Group Added Successfully."));
            extent.SetStepStatusPass("Verified that the success alert text is displayed.");
        }
        /// <summary>
        /// Search by vehicle group name
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="vehicleCount"></param>
        /// <param name="isDeleted"></param>
        public void SearchVehicleGroup(string groupName, int vehicleCount, bool isDeleted = false)
        {
            wait.Until(driver => SearchGroup.Displayed);
            extent.SetStepStatusPass("Verified that the search group field is displayed.");
            Thread.Sleep(3000);
            SearchGroup.Clear();
            SearchGroup.SendKeys(groupName);
            extent.SetStepStatusPass("Entered group name in search field.");
            if (isDeleted == false)
            {
                wait.Until(driver => SelectFirstGroup.Displayed);
                extent.SetStepStatusPass("Verified that the group is displayed.");
                Assert.IsTrue(Convert.ToInt32(SearchCount.Text.Trim()) > 0);
                extent.SetStepStatusPass("Verified that the search count is greater than 0.");
                SelectFirstGroup.Click();
                extent.SetStepStatusPass("Selects the first group displayed");
                wait.Until(driver => groupNameText.Displayed);
                Assert.IsTrue(groupNameText.Text.Trim().Contains(groupName));
                Assert.IsTrue(VehicleNumberText.Text.Trim().Contains("Number of vehicles:"));
                if (groupName != "Ungrouped")
                    Assert.IsTrue(NumberOfVehicles.Text.Trim().Contains(vehicleCount.ToString()));
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
        /// Edit the vehicle group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="description"></param>
        public void EditVehicleGroup(string groupName, string description)
        {
            wait.Until(driver => EditGroupVehicle.Displayed);
            extent.SetStepStatusPass("Verified that the edit group button is displayed.");
            EditGroupVehicle.Click();
            wait.Until(driver => AddGroupTitle.Displayed);
            extent.SetStepStatusPass("Verified that the modal title is displayed.");
            Assert.IsTrue(AddGroupTitle.Text.Trim().Contains("Edit Vehicle Group"));
            Assert.IsTrue(NamePlaceholder.Text.Trim().Contains("Name*"));
            Assert.IsTrue(DescriptionPlaceholder.Text.Trim().Contains("Description"));
            Assert.IsTrue(ColorPlaceholder.Text.Trim().Contains("Color"));
            extent.SetStepStatusPass("Verified that the placeholder texts are displayed.");
            NameInput.Clear();
            NameInput.SendKeys(groupName);
            extent.SetStepStatusPass("Entered group name.");
            DescriptionInput.Clear();
            DescriptionInput.SendKeys(description);
            extent.SetStepStatusPass("Entered description.");
            RedColor.Click();
            extent.SetStepStatusPass("Clicked on red color.");
            wait.Until(driver => CancelButton.Displayed);
            wait.Until(driver => CloseButton.Displayed);
            extent.SetStepStatusPass("Verified that the cancel and close buttons are displayed.");
            SaveButton.Click();
            extent.SetStepStatusPass("Clicked on save button.");
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Group Updated Successfully."));
            extent.SetStepStatusPass("Verified that the success alert text is displayed.");
        }
        /// <summary>
        /// Delete Vehicle Group
        /// </summary>
        /// <param name="groupName"></param>
        public void DeleteVehicleGroup(string groupName)
        {
            SearchVehicleGroup(groupName, 0);
            wait.Until(driver => DeleteGroupVehicle.Displayed);
            extent.SetStepStatusPass("Verified that the delete group button is displayed.");
            DeleteGroupVehicle.Click();
            wait.Until(driver => DeleteModalTitle.Displayed);
            extent.SetStepStatusPass("Verified that the modal title is displayed.");
            Assert.IsTrue(DeleteModalTitle.Text.Trim().Contains("Confirmation"));
            Assert.IsTrue(DeleteModalBody.Text.Trim().Contains("Deleting groups does not delete " +
                "the vehicles, but re-allocates the vehicles to 'Ungrouped'"));
            extent.SetStepStatusPass("Verified that the modal body is displayed properly.");
            Assert.IsTrue(DeleteCancelBtn.Displayed);
            extent.SetStepStatusPass("Verified that the cancel button is displayed.");
            DeleteConfirmBtn.Click();
            extent.SetStepStatusPass("Clicked on delete confirm button");
            driver.Navigate().Refresh();
            wait.Until(driver => ManageTab.Displayed);
            SearchVehicleGroup(groupName, 0, true);
        }
        /// <summary>
        /// Add Operational Hours
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="operationalHoursName"></param>
        public void EditOperationalHours(string groupName, string operationalHoursName)

        {
            SearchVehicleGroup(groupName, 1);
            wait.Until(driver => Kebabmenu.Displayed);
            Kebabmenu.Click();
            wait.Until(driver => EditVehicle.Displayed);
            EditVehicle.Click();
            Thread.Sleep(2000);
            wait.Until(driver => VehicleNameLabel.Displayed);
            OperatingHoursdropdown.Click();
            Thread.Sleep(1000);
            operatingHours = operationalHoursName;
            OperatingHoursSelection.Click();
            Thread.Sleep(500);
            EditSaveButton.Click();
            extent.SetStepStatusPass("Clicked on save button.");
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Updated successfully!"));
            extent.SetStepStatusPass("Verified that the success alert text is displayed.");
            Thread.Sleep(10000);
        }


        /// <summary>
        /// Verify Edit Vehicle details
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="editedVehicledetails"></param>
        public void EditVehicleDetails(string groupName, string[] editedVehicledetails)
        {
            SearchVehicleGroup(groupName, 1);
            wait.Until(driver => Kebabmenu.Displayed);
            Kebabmenu.Click();
            wait.Until(driver => EditVehicle.Displayed);
            EditVehicle.Click();
            wait.Until(driver => VehicleNameLabel.Displayed);
            wait.Until(driver => VehicleIDLabel.Displayed);
            wait.Until(driver => MakeLabel.Displayed);
            wait.Until(driver => ModelLabel.Displayed);
            wait.Until(driver => RegNumberLabel.Displayed);
            wait.Until(driver => TypeLabel.Displayed);
            wait.Until(driver => RequiredLicenseLabel.Displayed);
            wait.Until(driver => VINLabel.Displayed);
            wait.Until(driver => EngineNumberLabel.Displayed);
            wait.Until(driver => VehicleCategoryLabel.Displayed);
            wait.Until(driver => OperatingHoursLabel.Displayed);
            wait.Until(driver => VehicleTrackerIDLabel.Displayed);
            wait.Until(driver => TrackSerialLabel.Displayed);
            extent.SetStepStatusPass("Verified the labels displayed on the edit page.");
            Thread.Sleep(3000);
            VehicleNameField.Clear();
            VehicleNameField.SendKeys(editedVehicledetails[0]);
            Thread.Sleep(500);
            VehicleIDField.Clear();
            VehicleIDField.SendKeys(editedVehicledetails[1]);
            Thread.Sleep(500);
            MakeField.Clear();
            MakeField.SendKeys(editedVehicledetails[2]);
            Thread.Sleep(500);
            ModelField.Clear();
            ModelField.SendKeys(editedVehicledetails[3]);
            Thread.Sleep(500);
            RegNumberField.Clear();
            RegNumberField.SendKeys(editedVehicledetails[4]);
            Thread.Sleep(500);
            TypeField.Clear();
            TypeField.SendKeys(editedVehicledetails[5]);
            Thread.Sleep(500);
            RequiredLicenseField.Clear();
            RequiredLicenseField.SendKeys(editedVehicledetails[6]);
            Thread.Sleep(500);
            VINField.Clear();
            VINField.SendKeys(editedVehicledetails[7]);
            Thread.Sleep(500);
            EngineNumberField.Clear();
            EngineNumberField.SendKeys(editedVehicledetails[8]);
            Thread.Sleep(500);
            VehicleCategoryField.Clear();
            VehicleCategoryField.SendKeys(editedVehicledetails[9]);
            Thread.Sleep(500);
            OperatingHoursdropdown.Click();
            Thread.Sleep(1000);
            operatingHours = "Select Any";
            OperatingHoursSelection.Click();
            Thread.Sleep(500);
            wait.Until(driver => EditCancelButton.Displayed);
            EditSaveButton.Click();
            extent.SetStepStatusPass("Clicked on save button.");
            wait.Until(driver => SuccessAlertDialogue.Displayed);
            Assert.IsTrue(SuccessAlertDialogue.Text.Trim().Contains("Updated successfully!"));
            extent.SetStepStatusPass("Verified that the success alert text is displayed.");
        }
        /// <summary>
        /// Verify Vehicle Details
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="editedVehicledetails"></param>
        public void VerifyVehicleDetails(string groupName, string[] editedVehicledetails)
        {
            SearchVehicleGroup(groupName, 1);
            wait.Until(driver => Kebabmenu.Displayed);
            wait.Until(driver => VehicleNameColumn.Displayed);
            wait.Until(driver => VehicleIdColumn.Displayed);
            wait.Until(driver => VehicleGroupColumn.Displayed);
            wait.Until(driver => VehicleDriverColumn.Displayed);
            wait.Until(driver => VehicleMakeColumn.Displayed);
            wait.Until(driver => VehicleModelColumn.Displayed);
            wait.Until(driver => RegNumberColumn.Displayed);
            extent.SetStepStatusPass("Verified the labels displayed on the columns.");
            Assert.AreEqual(editedVehicledetails[0], VehicleNameValue.Text.Trim());
            Assert.AreEqual(editedVehicledetails[1], VehicleIdValue.Text.Trim());
            Assert.AreEqual(editedVehicledetails[2], VehicleGroupValue.Text.Trim());
            Assert.AreEqual(editedVehicledetails[3], VehicleDriverValue.Text.Trim());
            Assert.AreEqual(editedVehicledetails[4], VehicleMakeValue.Text.Trim());
            Assert.AreEqual(editedVehicledetails[5], VehicleModelValue.Text.Trim());
            Assert.AreEqual(editedVehicledetails[6], RegNumberValue.Text.Trim());
            extent.SetStepStatusPass("Verified that the correct details are displayed on the columns.");
        }
        /// <summary>
        /// Verify change group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="newGroupName"></param>
        public void VerifyChangeGroup(string groupName, string newGroupName)
        {
            SearchVehicleGroup(groupName, 1);
            wait.Until(driver => Kebabmenu.Displayed);
            Kebabmenu.Click();
            wait.Until(driver => ChangeGroup.Displayed);
            ChangeGroup.Click();
            wait.Until(driver => AssignGroupHeader.Displayed);
            SearchNewGroup.SendKeys(newGroupName);
            Thread.Sleep(1000);
            group = newGroupName;
            wait.Until(driver => SearchResult.Displayed);
            SearchResult.Click();
           // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.selected-vehicles-change-group.grouped-" +
            //    "list.flex-wrap.entity-deselect-color");
            wait.Until(driver => CancelAssignButton.Displayed);
            SaveAssignButton.Click();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();
            wait.Until(driver => ManageTab.Displayed);
            SearchVehicleGroup(newGroupName, 1);
            extent.SetStepStatusPass("Verified that the change group is completed.");
        }
        /// <summary>
        /// Remove Vehicle from group
        /// </summary>
        /// <param name="groupName"></param>
        public void VerifyRemoveGroup(string groupName)
        {
            SearchVehicleGroup(groupName, 1);
            wait.Until(driver => Kebabmenu.Displayed);
            Kebabmenu.Click();
            wait.Until(driver => DeleteAction.Displayed);
            DeleteAction.Click();
            wait.Until(driver => DeleteModalTitle.Displayed);
            extent.SetStepStatusPass("Verified that the modal title is displayed.");
            Assert.IsTrue(DeleteModalTitle.Text.Trim().Contains("Confirmation"));
            Assert.IsTrue(DeleteModalBody.Text.Trim().Contains("On clicking 'Remove' vehicle will be removed from current Group and added to Ungrouped." +
                " Are you sure you want to remove?"));
            extent.SetStepStatusPass("Verified that the modal body is displayed properly.");
            Assert.IsTrue(DeleteCancelBtn.Displayed);
            extent.SetStepStatusPass("Verified that the cancel button is displayed.");
            DeleteConfirmBtn.Click();
            extent.SetStepStatusPass("Clicked on delete confirm button");
            driver.Navigate().Refresh();
            wait.Until(driver => ManageTab.Displayed);
            SearchVehicleGroup(groupName, 0, false);
        }
        /// <summary>
        /// Assign vehcile to group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="vehicleName"></param>
        public void AssignVehicleToGroup(string groupName, string newGroupName, string vehicleName)
        {
            SearchVehicleGroup(groupName, 1);
            Thread.Sleep(3000);
            for (int i = 1; i <= rows.Count; i++)
            {
                count = i;
                if (vehicleRowName.Text.Equals(vehicleName))
                {
                    vehicleCheckbox.Click();
                    break;
                }
            }
            wait.Until(driver => SelectedVehicleCount.Displayed);
            Assert.AreEqual("1", SelectedVehicleCount.Text.Trim());
            Assert.AreEqual("Vehicle(s) selected", SelectedVehicleText.Text.Trim());
            wait.Until(driver => AssignGroupTopButton.Displayed);
            AssignGroupTopButton.Click();
            wait.Until(driver => AssignGroupHeader.Displayed);
            SearchNewGroup.SendKeys(newGroupName);
            Thread.Sleep(1000);
            group = newGroupName;
            wait.Until(driver => SearchResult.Displayed);
            Thread.Sleep(2000);
            SearchResult.Click();
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("document.querySelector(arguments[0],':before').click();", "li.selected-vehicles-change-group.grouped-" +
            //    "list.flex-wrap.entity-deselect-color");
            wait.Until(driver => CancelAssignButton.Displayed);
            SaveAssignButton.Click();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();
            wait.Until(driver => ManageTab.Displayed);
            SearchVehicleGroup(newGroupName, 1);
            extent.SetStepStatusPass("Verified that the assign group is completed.");
        }
        /// <summary>
        /// Verify the right panel for manage vehicles
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="vehicleId"></param>
        public void VerifyManageVehicleRightPanel(string groupName, int vehicleId)
        {
            getAPIResponse = new GetAPIResponse();
            var driverRightpanelStatus = getAPIResponse.GetRightPanelVehcileDetails(adminUser, adminPassword, vehicleId);
            SearchVehicleGroup(groupName, 1);
            Thread.Sleep(3000);
            count = 1;
            vehicleRowName.Click();
            wait.Until(driver => RightPanelHeading.Displayed);
            Assert.AreEqual(driverRightpanelStatus.vehicleName, RightPanelHeading.Text.Trim());
            wait.Until(driver => CalibrateReading.Displayed);
            if (driverRightpanelStatus.driverName == string.Empty)
                Assert.AreEqual("Unassigned", DriverNameText.Text.Trim());
            else
                Assert.AreEqual(driverRightpanelStatus.driverName, DriverNameText.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.group, VehicleGroupText.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.manufacturer, MakeValue.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.model, ModelValue.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.registration, RegNumberRightPanel.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.type, TypeRightPanel.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.licensesRequired, ReqLicenseRightPanel.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.chassisVin, VINRightPanel.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.engineNumber, EngNumberRightPanel.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.vehicleCategory, VehicleCategoryRightPanel.Text.Trim());
            if (driverRightpanelStatus.operatingHours == -1)
                Assert.AreEqual(string.Empty, OperatingHoursValue.Text.Trim());
            else
                Assert.AreEqual(driverRightpanelStatus.operatingHours.ToString(), OperatingHoursValue.Text.Trim());
            Assert.AreEqual(driverRightpanelStatus.trackerId.ToString(), VehicleTrackerIdValue.Text.Trim());
            extent.SetStepStatusPass("Verified that the manage vehicle right panel is displayed correctly.");
        }

        #endregion

    }
}
