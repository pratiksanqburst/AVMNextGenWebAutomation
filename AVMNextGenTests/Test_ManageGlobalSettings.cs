using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("ManageGlobalSettings")]
    public class Test_ManageGlobalSettings : ManageGlobalSettings
    {

        #region Properties
        public Login login;
        static string slotTimeName = "AutoTimeSlot" + DateTime.Now.ToString("dd");
        static string editedSlotTimeName = "TimeSlotEdit" + DateTime.Now.ToString("dd");
        string[] slotDetails = { slotTimeName, "(UTC+10:00) Papua New Guinea Time (Port Moresby)", "Test Description" };
        string[] dayDetails = { "Monday", "Sunday" };
        string[] timeDetails = { "09:30 - 22:30", "10:30 - 23:30" };
        string[] editedSlotDetails = { editedSlotTimeName, "(UTC) Coordinated Universal Time", "Test Description Edited" };
        string[] editedDayDetails = { "Tuesday", "Saturday" };
        #endregion


        [Test, Order(1)]
        public void Test_Add_TimeSlot()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            AddTimeSlot(slotTimeName);
            VerifyTimeSlot(slotDetails, dayDetails, timeDetails);
        }
        [Test, Order(2)]
        public void Test_Edit_TimeSlot()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            EditTimeSlot(slotTimeName,editedSlotTimeName);
            VerifyTimeSlot(editedSlotDetails, editedDayDetails, timeDetails);
        }

        [Test, Order(3)]
        public void Test_Delete_TimeSlot()
        {
            login = new Login(driver);
            login.LoginToAVMLite(adminUser, adminPassword);
            DeleteTimeSlot(editedSlotTimeName);
        }

    }
}
