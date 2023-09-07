using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.DashCam
{
    public class DashCamTreeBody
    {
        public class DashCamStatusRequestBody
        {
            public int vehID { get; set; }
        }
        public class DashCamstatusrequestBody
        {
            public int vehID { get; set; }
        }
        public class DashCamCreatePlaybackrequestBody
        {
            public int playbackvalue { get; set; }
        }
        public class GetDashCamrequestBody
        {
            public int unitId { get; set; }
            public DateTime startDateTime { get; set; }
            public DateTime endDateTime { get; set; }
            public List<int> recordings { get; set; }
        }
        public class DashCamvehdetailsRequestBody
        {
            public int unitId { get; set; }
        }
    }
}
