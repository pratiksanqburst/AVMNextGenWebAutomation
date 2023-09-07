using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class ClientRequestBody:APIHelper
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
        public CreateClientRequestBody createClientRequestBody = new CreateClientRequestBody()
        {
        
        driverGroupIds = new[] { 244, 244 },
        //driverIds = new int[] { },
        //unitIds = new int[] { },
        vehicleGroupIds = new[] { 388 }
    };
        public VehicleTreeBody vehicletreeBody = new VehicleTreeBody()
        {
           UserName ="userName"
        };
        public ClientIdRequestBody clientIdRequestBody = new ClientIdRequestBody()
        {
            clientId = 5
        };
        public CreateClientRequestBody createclientRequestBody = new CreateClientRequestBody()
        {
        
          driverGroupIds = new[] { 244, 244 },
          driverIds = new int[] { },
          unitIds = new int[] { },
          vehicleGroupIds = new[] { 388 }
        };
        public SuppressAlertsRequestBody suppressAlertsRequestBody = new SuppressAlertsRequestBody()
        {
            clientId = 5,// change value
            suppressAlerts = true
        };
        public SuppressAlarmsRequestBody SuppressAlarmsRequestBody = new SuppressAlarmsRequestBody()
        {
           clientId =5,
          suppressAlarms = true
        };
        public AccountLockedRequestBody accountLockedRequestBody = new AccountLockedRequestBody()
        {
           clientId = 5,
           isAccountLocked = 3 //value to be checked
        };
        public UpdatePasswordRequestBody updatePasswordRequestBody = new UpdatePasswordRequestBody()
        {
            password = "password"
         };
        public ClientInitialScriptRequestBody clientInitialScriptRequestBody = new ClientInitialScriptRequestBody()
        {
            locationTypeIcon = "PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHZpZXdCb3g9IjAgMCAyMCAyMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCiAgICA8ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPg0KICAgICAgICA8cGF0aCBkPSJNMCAwaDIwdjIwSDB6Ii8+ DQogICAgICAgIDxwYXRoIGQ9Im0xMCAxNy40MTcgNC4xMjUtNC4xMjVhNS44MzMgNS44MzMgMCAxIDAtOC4yNSAwTDEwIDE3LjQxN3ptMCAyLjM1Nkw0LjY5NyAxNC40N2E3LjUgNy41IDAgMSAxIDEwLjYwNiAwTDEwIDE5Ljc3M3ptMC04Ljk0QTEuNjY3IDEuNjY3IDAgMSAwIDEwIDcuNWExLjY2NyAxLjY2NyAwIDAgMCAwIDMuMzMzem0wIDEuNjY3YTMuMzMzIDMuMzMzIDAgMSAxIDAtNi42NjcgMy4zMzMgMy4zMzMgMCAwIDEgMCA2LjY2N3oiIGZpbGw9IiNGRkYiIGZpbGwtcnVsZT0ibm9uemVybyIvPg0KICAgIDwvZz4NCjwvc3ZnPg0K",
            locationTypeIocnUrl = "https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg"
        };
        
    }
}
