using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class AlertRequestBody:APIHelper
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
        public LoginBody loginRequestbody = new LoginBody()
        {
            userName = ""
        };
        public DeleteAlerts deleteAlerts = new DeleteAlerts()
        {
            Property1 = ///enter the require field
        };
        
    }
       
   

}
