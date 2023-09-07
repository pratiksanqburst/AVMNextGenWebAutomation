using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.HereMap
{
    public class HereMapTreeBody
    {
        public class HereMaplocationbody
        {
        public string SearchText { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
       }
        public class HereMapGetlocationbody
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
        public class HereMapGetDrawRoutebody
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
          //  public Source source { get; set; }
          //  public Destination destination { get; set; }
            public List<string> @return { get; set; }
            public string transportMode { get; set; }
        }
    }
}
