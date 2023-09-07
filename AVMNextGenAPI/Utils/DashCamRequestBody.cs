using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;

using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.DashCam.DashCamTreeBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class DashCamRequestBody : APIHelper
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

        public DashCamStatusRequestBody dashCamStatusRequestBody = new DashCamStatusRequestBody()
        {
            vehID = 3

        };
        public DashCamStatusRequestBody dashcamStatusRequestBody = new DashCamStatusRequestBody()
        {
            vehID = 3

        };
        public DashCamCreatePlaybackrequestBody dashCamCreatePlaybackrequestBody = new DashCamCreatePlaybackrequestBody()//doubt
        {
           playbackvalue= 23184200

        };
        public GetDashCamrequestBody getDashCamrequestBody = new GetDashCamrequestBody()
        {
           unitId=52,
           startDateTime= "2023-07-26T18:30:00.756Z",
           endDateTime ="2023-07-27T06:06:51.756Z",
           recordings= [
            0,
           214,
           25,
           24,
           7,
          217,
          232,
          230,
          11
          ]

        };
        public DashCamvehdetailsRequestBody dashCamvehdetailsRequestBody = new DashCamvehdetailsRequestBody()
        {
            unitId = 52

        };

    }

}
