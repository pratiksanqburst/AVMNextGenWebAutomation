using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.UserSettings
{
    public class UserSettingsTreeBody
    {
        public class UserSettingsSaveRequest
        {
            public string settingName { get; set; }
            public string settingValue { get; set; }
        }

    }
}
