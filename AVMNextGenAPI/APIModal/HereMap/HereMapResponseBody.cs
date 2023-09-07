using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.HereMap
{
    public class HereMapResponseBody
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public object xRight { get; set; }
        public object yBottom { get; set; }
        public object speed { get; set; }
    }
}
