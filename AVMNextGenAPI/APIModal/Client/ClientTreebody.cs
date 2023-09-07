using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client
{
    public class ClientTreebody
    {
        public class CreateClientRequestBody
        {
            public Client client { get; set; }
            public int[]? unitIds { get; set; }
            public int[]? vehicleGroupIds { get; set; }
            public int[]? driverIds { get; set; }
            public int[]? driverGroupIds { get; set; }
        }
        public class VehicleTreeBody
        {
            public string UserName { get; set; }
            public bool forManagement { get; set; }
        }
        public class ClientIdRequestBody
        {
            public int clientId { get; set; }
        }
        public class SuppressAlertsRequestBody
        {
            public int clientId { get; set; }
            public bool suppressAlerts { get; set; }
        }
        public class SuppressAlarmsRequestBody
        {
            public int clientId { get; set; }
            public bool suppressAlarms { get; set; }
        }
        public class AccountLockedRequestBody
        {
            public int clientId { get; set; }
            public int isAccountLocked { get; set; }
        }
        public class UpdatePasswordRequestBody
        {
            public string password { get; set; }
        }
        public class ClientInitialScriptRequestBody
        {
            public string locationTypeIcon { get; set; }
            public string locationTypeIocnUrl { get; set; }
        }
    }
}
