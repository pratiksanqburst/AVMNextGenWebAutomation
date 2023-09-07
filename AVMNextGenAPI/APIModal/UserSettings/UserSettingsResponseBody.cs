using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.UserSettings
{
    public class UserSettingsResponseBody
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public string name { get; set; }
        public string settings { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastModified { get; set; }
    }
}
