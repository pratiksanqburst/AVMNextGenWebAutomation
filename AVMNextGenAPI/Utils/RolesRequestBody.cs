using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class RolesRequestBody : APIHelper
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
        public RolesCreationRequestBody rolesCreationRequestBody = new RolesCreationRequestBody()
        {
           userName = userName,
           roleName = "",
           roleDescription = "Test automation description",
           defaultRole = true,
           reportList = new int[] { 830, 415 },
           accessRights = new int[] { 12, 82, 29, 27, 52, 30, 28, 60, 61, 35, 71, 46, 47, 3, 64, 58, 57, 56, 38, 44, 70, 45, 5, 53, 89, 90 }
        };
        public EditRoleNameRequestBody editRoleNameRequestBody = new EditRoleNameRequestBody()
        {
            roleName = "",
            userName = userName,
            roleDescription = "Automation description edited"
        };
        public EditRoleRightsRequestBody EditRoleRightsRequestBody = new EditRoleRightsRequestBody()
        {

         userName = userName,
         defaultRole = true,
         accessRights = new int[] { 12, 82, 29, 27, 52, 30 },
         reportList = new int[] { 830, 415, 303 },
        };
        public VehicleTreeBody vehicleTreeBody = new VehicleTreeBody()
        {
          UserName = userName,
          forManagement = true
            
        };


    }
}
