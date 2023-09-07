using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alarm
{
    
    
        public class AlarmBody
        {
            public string UserName { get; set; }
        }
    public class ClearAlarmBody
    {
        public string UserName { get; set; }
        public AlarmToClear alarmToClear { get; set; }
        public bool isTestingAlarm { get; set; }
        public bool isNonReportingMobile { get; set; }
        public string enteredName { get; set; }
        public string enteredReason { get; set; }
    }

}

