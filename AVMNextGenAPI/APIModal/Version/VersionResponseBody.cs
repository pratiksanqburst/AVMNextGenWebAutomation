using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Version
{
    public class VersionResponseBody
    {
        public string version { get; set; }
        public string date { get; set; }
        public bool cacheAccessible { get; set; }
        public bool avmAccessible { get; set; }
        public string error { get; set; }
    }
    public class VersionNumberResponseBody
    {
        public string versionnumber { get; set; }
    }
}
