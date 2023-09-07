using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class ContactRequestBody:APIHelper
    {
        #region Properties
        static ResourceManager rm2 = new ResourceManager($"AVMNextGenWebAutomation.TestData{environment}", Assembly.GetExecutingAssembly());
        public static string userName = rm2.GetString("Username");
        public static string password = rm2.GetString("Password");
        public static string adminUser = rm2.GetString("AdminUser");
        public static string adminPassword = rm2.GetString("AdminPassword");
        public static string adminDev = rm2.GetString("AdminDev");
        public static string adminDevPassword = rm2.GetString("AdminDevPassword");
        static ResourceManager rm3 = new ResourceManager($"AVMNextGenWebAutomation.APITestData{environment}", Assembly.GetExecutingAssembly());
        public static string searchKey = rm3.GetString("Searchkey");
        #endregion
        public ContactGroupRequestBody contactGroupRequestBody = new ContactGroupRequestBody()
        {
         shortName = "groupName",
        fullName = "groupName",
        comments = "Test automation comments",
        deleted = false
        };
        public EditContactGroupRequestBody editContactGroupRequestBody = new EditContactGroupRequestBody()
        {
          contactGroupId = 5,
          fullName = "random",
          shortName = "random",
          comments = "Automation description edited",
          deleted = false
        };
        

    }
}
