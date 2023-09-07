using AVMNextGenWebAutomation.AVMNextGenAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Vehicles
{
    public class VehicleTreeBody
    {
        public string UserName { get; set; }
        public bool forManagement { get; set; }
    }

    public class VehicleGroupedResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupColor { get; set; }
        public Vehicle[] vehicles { get; set; }
    }
    public class VehicleTripBody
    {
        public int unitId { get; set; }
        public DateTime tripStartTime { get; set; }
        public DateTime tripEndTime { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public bool isAssignedTrip { get; set; }
    }
}
