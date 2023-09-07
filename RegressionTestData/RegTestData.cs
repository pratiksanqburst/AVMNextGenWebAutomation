using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.RegressionTestData
{
    public class RegTestData
    {
        public string[] userDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "Automation", "User", "Non-Admin", "1234567890", "NetStarFleetLiteAutomation@gmail.com" };
        public string[] userDetailsRightPanel = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy"), "Automation User", "Non-Admin", "NetStarFleetLiteAutomation@gmail.com",
            "(+61)1234567890", "AutomationGroup", "Test Automation Notes" };
        public string[] editUserDetails = { "AutomationUser" + DateTime.Now.ToString("ddMMyyyy") + "Edited", "EditAutomation", "EditUser", "New role", "987654321", "NetStarFleetLiteAutomationedit@gmail.com" };
        public string roleName = "AutoRole " + DateTime.Now.ToString("ddMMyyyy");
        public string roleNameEdited = "AutoRole " + DateTime.Now.ToString("ddMMyyyy") + " Edited";
        public string forgotUserName = "otomationuser";
        public string UserNameChangePassword = "Test@v2";
        public string UserNameChangePassword2 = "Test@v12";
        public string VehicleName = "AutoVehicle";
        public string DriverName = "Automation Driver";
        public static string date = DateTime.Now.AddDays(-1).Day.ToString();
        public static string dateEdited = DateTime.Now.AddDays(-2).Day.ToString();
        public static string dateValue = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Replace("-", "/") + " 12:30 AM";
        public static string dateValueEdited = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy").Replace("-", "/") + " 11:30 AM";
        public string[] serviceDetails = { "AutoVehicle", date, "12", "30", "Minor", "1000", "12345", "10000", "Automation notes" };
        public string[] serviceDetailsVerification = { "AutoVehicle", dateValue, "Minor", "1000", "12345", "10000", "Automation notes" };
        public string[] editServiceDetails = { "AutoVehicle", dateEdited, "11", "30", "Major", "2000", "54321", "99999", "Automation notes edited" };
        public string[] editServiceDetailsVerification = { "AutoVehicle", dateValueEdited, "Major", "2000", "54321", "99999", "Automation notes edited" };





        public string contactGroup = "AutomationGroup" + DateTime.Now.ToString("dd");
        public static string contactName = "AutomationContact" + DateTime.Now.ToString("dd");
        public static string editContactName = "AutomationContact" + DateTime.Now.ToString("dd") + " edited";
        public static string editedContactGroup = "AutomationGroup" + DateTime.Now.ToString("dd") + " edited";
        public string[] contactDetails = { contactName, "1234567890", "FleetLiteAutomationContact@gmail.com" };
        public string[] contactDetailsVerification = { contactName, "+611234567890", "ENABLED", "FleetLiteAutomationContact@gmail.com", "ENABLED" };
        public string[] editContactDetails = { editContactName, "987654321", "FleetLiteAutomationContactEdited@gmail.com" };
        public string[] editContactDetailsVerification = { editContactName, "+61987654321", "DISABLED", "FleetLiteAutomationContactEdited@gmail.com", "DISABLED" };
        public static string slotTimeName = "AutoTimeSlot" + DateTime.Now.ToString("dd");
        public static string editedSlotTimeName = "TimeSlotEdit" + DateTime.Now.ToString("dd");
        public string[] slotDetails = { slotTimeName, "(UTC+10:00) Papua New Guinea Time (Port Moresby)", "Test Description" };
        public string[] dayDetails = { "Monday", "Sunday" };
        public string[] timeDetails = { "09:30 - 22:30", "10:30 - 23:30" };
        public string[] editedSlotDetails = { editedSlotTimeName, "(UTC) Coordinated Universal Time", "Test Description Edited" };
        public string[] editedDayDetails = { "Tuesday", "Saturday" };
    }
}
