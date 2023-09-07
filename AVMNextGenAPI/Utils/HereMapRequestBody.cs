using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.HereMap.HereMapTreeBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class HereMapRequestBody:APIHelper
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


        public HereMaplocationbody hereMaplocationbody = new HereMaplocationbody()
        {
             SearchText="syd",
             Latitude =-33.869729620301804,
             Longitude= 151.2082497775555
        };

        public HereMapGetlocationbody HereMapGetlocationbody = new HereMapGetlocationbody()
        {
            Latitude = -33.869729620301804,
            Longitude = 151.2082497775555
        };
        public HereMapGetDrawRoutebody hereMapGetDrawRoutebody = new HereMapGetDrawRoutebody()
        {
           // Latitude = -33.869729620301804,
           // Longitude = 151.2082497775555
        };
    }
}
