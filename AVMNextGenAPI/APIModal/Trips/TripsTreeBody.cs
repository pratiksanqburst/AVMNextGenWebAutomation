using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Trips
{
    public class TripsTreeBody
    {
        public class VehicleTripBody
        {
            public int unitId { get; set; }
            public DateTime tripStartTime { get; set; }
            public DateTime tripEndTime { get; set; }
            public int page { get; set; }
            public int pageSize { get; set; }
            public bool isAssignedTrip { get; set; }
        }
        public class SingleTriprequestBody
        {
            public int tripId { get; set; }
            public int driverId { get; set; }
            public string startDate { get; set; }
        }
    }
}
